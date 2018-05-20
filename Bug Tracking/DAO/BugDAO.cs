using Bug_Tracker.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class BugDAO : GenericDAO<Bug>
    {

        private SqlConnection connection = new DBConnection().GetConnection();

        /// <summary>
        /// used to delete bugs
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "DELETE FROM table_bug WHERE bug_id=@bugId";
                query.Prepare();
                query.Parameters.AddWithValue("@bugId", id);

                query.ExecuteNonQuery();
                transaction.Commit();

                return true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Bug> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns bugs by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Bug GetById(int id)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            Bug bug = null;
            SourceCode code = null;
            BugImage image = null;
            ControlLink sourceControl = null;

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "SELECT * FROM table_bug b JOIN table_code c ON b.bug_id = c.bug_id JOIN table_image i ON b.bug_id = i.bug_id JOIN table_source_control sc ON sc.bug_id = i.bug_id WHERE bug_status = 0 AND b.bug_id = @id;";
                query.Prepare();
                query.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bug = new Bug();
                        code = new SourceCode();
                        image = new BugImage();
                        sourceControl = new ControlLink();

                        bug.BugId = Convert.ToInt32(reader["bug_id"]);
                        bug.ProjectName = Convert.ToString(reader["project_name"]);
                        bug.ClassName = Convert.ToString(reader["class_name"]);
                        bug.MethodName = Convert.ToString(reader["method_name"]);
                        bug.StartLine = Convert.ToInt32(reader["start_line"]);
                        bug.EndLine = Convert.ToInt32(reader["end_line"]);
                        bug.ProgrammerId = Convert.ToInt32(reader["code_author"]);
                        bug.Status = Convert.ToString(reader["bug_status"]);

                        code.CodeId = Convert.ToInt32(reader["code_id"]);
                        code.CodePath = Convert.ToString(reader["code_file_path"]);
                        code.CodeFileName = Convert.ToString(reader["code_file_name"]);
                        code.Language = Convert.ToString(reader["programming_language"]);
                        code.BugId = Convert.ToInt32(reader["bug_id"]);

                        image.ImageId = Convert.ToInt32(reader["image_id"]);
                        image.ImagePath = Convert.ToString(reader["image_path"]);
                        image.ImageName = Convert.ToString(reader["image_name"]);
                        image.BugId = Convert.ToInt32(reader["bug_id"]);

                        sourceControl.LinkID = Convert.ToInt32(reader["source_control_id"]);
                        sourceControl.CodeLink = reader["link"].ToString();
                        sourceControl.StartLine = Convert.ToInt32(reader["start_line"]);
                        sourceControl.EndLine = Convert.ToInt32(reader["end_line"]);
                        sourceControl.BugId = Convert.ToInt32(reader["bug_id"]);

                        bug.SourceControl = sourceControl;
                        bug.Images = image;
                        bug.Codes = code;
                    }
                }

            }
            catch (SqlException ex)
            {
                connection.Close();
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                connection.Close();
                throw new NullReferenceException(ex.Message);
            }

            return bug;
        }

        /// <summary>
        /// insert new bugs
        /// </summary>
        /// <param name="t"></param>
        public void Insert(Bug t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "INSERT INTO table_bug VALUES(@projectname, @classname, @methodname, @startline, @endline, @codeauthor, @status); SELECT SCOPE_IDENTITY()";
                query.Prepare();
                query.Parameters.AddWithValue("@projectname", t.ProjectName);
                query.Parameters.AddWithValue("@classname", t.ClassName);
                query.Parameters.AddWithValue("@methodname", t.MethodName);
                query.Parameters.AddWithValue("@startline", t.StartLine);
                query.Parameters.AddWithValue("@endline", t.EndLine);
                query.Parameters.AddWithValue("@codeauthor", t.ProgrammerId);
                query.Parameters.AddWithValue("@status", t.Status);

                query.ExecuteNonQuery();

                t.BugId = Convert.ToInt32(query.ExecuteScalar());

                transaction.Commit();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }
        /// <summary>
        /// update bugs
        /// </summary>
        /// <param name="t"></param>
        public void Update(Bug t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "UPDATE table_bug SET project_name = @projectname, class_name = @classname, method_name = @methodname, start_line = @startline, end_line = @endline WHERE bug_id=@bug_id;";
                query.Prepare();
                query.Parameters.AddWithValue("@projectname", t.ProjectName);
                query.Parameters.AddWithValue("@classname", t.ClassName);
                query.Parameters.AddWithValue("@methodname", t.MethodName);
                query.Parameters.AddWithValue("@startline", t.StartLine);
                query.Parameters.AddWithValue("@endline", t.EndLine);
                query.Parameters.AddWithValue("@bug_id", t.BugId);

                query.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// get all bugs with related code and image
        /// </summary>
        /// <returns>List<string></returns>
        public List<Bug> getAllBugs()
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            List<Bug> bugList = new List<Bug>();
            Bug bug = null;
            SourceCode code = null;
            BugImage image = null;
            ControlLink sourceControl = null;

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "SELECT * FROM table_bug b JOIN table_code c ON b.bug_id = c.bug_id JOIN table_image i ON b.bug_id = i.bug_id JOIN table_source_control sc ON sc.bug_id = i.bug_id WHERE bug_status = 0 ;";
                query.Prepare();

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        bug = new Bug();
                        code = new SourceCode();
                        image = new BugImage();
                        sourceControl = new ControlLink();

                        bug.BugId = Convert.ToInt32(reader["bug_id"]);
                        bug.ProjectName = Convert.ToString(reader["project_name"]);
                        bug.ClassName = Convert.ToString(reader["class_name"]);
                        bug.MethodName = Convert.ToString(reader["method_name"]);
                        bug.StartLine = Convert.ToInt32(reader["start_line"]);
                        bug.EndLine = Convert.ToInt32(reader["end_line"]);
                        bug.ProgrammerId = Convert.ToInt32(reader["code_author"]);
                        bug.Status = Convert.ToString(reader["bug_status"]);

                        code.CodeId = Convert.ToInt32(reader["code_id"]);
                        code.CodePath = Convert.ToString(reader["code_file_path"]);
                        code.CodeFileName = Convert.ToString(reader["code_file_name"]);
                        code.Language = Convert.ToString(reader["programming_language"]);
                        code.BugId = Convert.ToInt32(reader["bug_id"]);

                        image.ImageId = Convert.ToInt32(reader["image_id"]);
                        image.ImagePath = Convert.ToString(reader["image_path"]);
                        image.ImageName = Convert.ToString(reader["image_name"]);
                        image.BugId = Convert.ToInt32(reader["bug_id"]);

                        sourceControl.LinkID = Convert.ToInt32(reader["source_control_id"]);
                        sourceControl.CodeLink = reader["link"].ToString();
                        sourceControl.StartLine = Convert.ToInt32(reader["start_line"]);
                        sourceControl.EndLine = Convert.ToInt32(reader["end_line"]);
                        sourceControl.BugId = Convert.ToInt32(reader["bug_id"]);

                        bug.SourceControl = sourceControl;
                        bug.Images = image;
                        bug.Codes = code;
                        bugList.Add(bug);
                    }
                }
                
            }
            catch (SqlException ex)
            {
                connection.Close();
                throw ex;
            } catch(NullReferenceException ex)
            {
                connection.Close();
                throw new NullReferenceException(ex.Message);
            }

            return bugList;
        }

        /// <summary>
        /// returns programmer's related bug
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Bug> GetAllBugsByProgrammerId(int id)
        {
            connection.Close();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            List<Bug> bugList = new List<Bug>();
            Bug bug = null;
            SourceCode code = null;
            BugImage image = null;
            ControlLink sourceControl = null;

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "SELECT * FROM table_bug b JOIN table_code c ON b.bug_id = c.bug_id JOIN table_image i ON b.bug_id = i.bug_id JOIN table_source_control sc ON sc.bug_id = i.bug_id WHERE bug_status = 0 AND b.code_author = @id;";
                query.Prepare();
                query.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bug = new Bug();
                        code = new SourceCode();
                        image = new BugImage();
                        sourceControl = new ControlLink();

                        bug.BugId = Convert.ToInt32(reader["bug_id"]);
                        bug.ProjectName = Convert.ToString(reader["project_name"]);
                        bug.ClassName = Convert.ToString(reader["class_name"]);
                        bug.MethodName = Convert.ToString(reader["method_name"]);
                        bug.StartLine = Convert.ToInt32(reader["start_line"]);
                        bug.EndLine = Convert.ToInt32(reader["end_line"]);
                        bug.ProgrammerId = Convert.ToInt32(reader["code_author"]);
                        bug.Status = Convert.ToString(reader["bug_status"]);

                        code.CodeId = Convert.ToInt32(reader["code_id"]);
                        code.CodePath = Convert.ToString(reader["code_file_path"]);
                        code.CodeFileName = Convert.ToString(reader["code_file_name"]);
                        code.Language = Convert.ToString(reader["programming_language"]);
                        code.BugId = Convert.ToInt32(reader["bug_id"]);

                        image.ImageId = Convert.ToInt32(reader["image_id"]);
                        image.ImagePath = Convert.ToString(reader["image_path"]);
                        image.ImageName = Convert.ToString(reader["image_name"]);
                        image.BugId = Convert.ToInt32(reader["bug_id"]);

                        sourceControl.LinkID = Convert.ToInt32(reader["source_control_id"]);
                        sourceControl.CodeLink = reader["link"].ToString();
                        sourceControl.StartLine = Convert.ToInt32(reader["start_line"]);
                        sourceControl.EndLine = Convert.ToInt32(reader["end_line"]);
                        sourceControl.BugId = Convert.ToInt32(reader["bug_id"]);

                        bug.SourceControl = sourceControl;
                        bug.Images = image;
                        bug.Codes = code;
                        bugList.Add(bug);
                    }
                }

            }
            catch (SqlException ex)
            {
                connection.Close();
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                connection.Close();
                throw new NullReferenceException(ex.Message);
            }

            return bugList;
        }

        /// <summary>
        /// update bug status
        /// </summary>
        /// <param name="bugId"></param>
        public void BugFixed(int bugId)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "UPDATE table_bug SET bug_status = @bug_status WHERE bug_id=@bug_id;";
                query.Prepare();
                query.Parameters.AddWithValue("@bug_status", "1");
                query.Parameters.AddWithValue("@bug_id", bugId);

                query.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
