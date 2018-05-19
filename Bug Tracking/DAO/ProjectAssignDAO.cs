using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class ProjectAssignDAO : GenericDAO<ProjectAssign>
    {
        private SqlConnection connection = new DBConnection().GetConnection();
        public bool Delete(int id)
        {
            connection.Open();
            ProjectAssign p = null;

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.CommandText = "DELETE FROM table_assign WHERE bug_id=@bug_id;";
                query.Prepare();
                query.Parameters.AddWithValue("@bug_id", id);

                query.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<ProjectAssign> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProjectAssign GetById(int id)
        {
            connection.Open();
            ProjectAssign p = null;

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.CommandText = "SELECT * FROM table_assign WHERE bug_id=@bug_id;";
                query.Prepare();
                query.Parameters.AddWithValue("@bug_id", id);
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        p = new ProjectAssign
                        {
                            AssignDate = DateTime.Parse(reader["assign_date"].ToString()),
                            Description = reader["descriptions"].ToString(),
                            AssignBy = Convert.ToInt32(reader["assign_by"]),
                            AssignTo = Convert.ToInt32(reader["assign_to"]),
                            BugId = Convert.ToInt32(reader["bug_id"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return p;
        }

        public void Insert(ProjectAssign t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "INSERT INTO table_assign VALUES(@assign_date, @descriptions, @assign_by, @assign_to, @bug_id)";
                query.Prepare();
                query.Parameters.AddWithValue("@assign_date", DateTime.Now);
                query.Parameters.AddWithValue("@descriptions", t.Description);
                query.Parameters.AddWithValue("@assign_by", t.AssignBy);
                query.Parameters.AddWithValue("@assign_to", t.AssignTo);
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

        public void Update(ProjectAssign t)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllAssignedUsersByBugId(int bugId)
        {
            connection.Open();
            List<string> list = new List<string>();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.CommandText = "SELECT p.full_name FROM table_programmer p JOIN table_assign a ON a.assign_to = p.programmer_id AND bug_id = @bugId";
                query.Prepare();
                query.Parameters.AddWithValue("@bugId", bugId);
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return list;
        }

        public bool RemoveAssignedUser(int bugId, int userId)
        {
            connection.Open();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.CommandText = "DELETE FROM table_assign WHERE bug_id=@bug_id AND assign_to = @assignTo;";
                query.Prepare();
                query.Parameters.AddWithValue("@bug_id", bugId);
                query.Parameters.AddWithValue("@bug_id", userId);

                query.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
