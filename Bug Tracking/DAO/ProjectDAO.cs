using Bug_Tracker.Model;
using Bug_Tracker.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class ProjectDAO : GenericDAO<Project>
    {
        private SqlConnection connection = new DBConnection().GetConnection();

        public bool Delete(int id)
        {
            connection.Open();
            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.CommandText = "DELETE FROM table_project WHERE project_id=@projectId;";
                query.Prepare();
                query.Parameters.AddWithValue("@projectId", id);

                int res = query.ExecuteNonQuery();

                if (res > 0)
                {
                    return true;
                } else
                {
                    return false;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Project> GetAll()
        {
            connection.Open();
            List<Project> list = new List<Project>();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.CommandText = "SELECT * FROM table_project WHERE admin_id=@adminId;";
                query.Prepare();
                query.Parameters.AddWithValue("@adminId", Program.adminId);

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Project p = new Project
                        {
                            ProjectId = Convert.ToInt32(reader["project_id"]),
                            ProjectName = reader["project_name"].ToString(),
                            AdminId = Convert.ToInt32(reader["admin_id"])
                        };

                        list.Add(p);
                    }
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }

        public Project GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Project t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "INSERT INTO table_project VALUES(@projectName, @adminId)";
                query.Prepare();
                query.Parameters.AddWithValue("@projectName", t.ProjectName);
                query.Parameters.AddWithValue("@adminId", Program.adminId);

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

        public void Update(Project t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "UPDATE table_project SET project_name = @projectName WHERE project_id = @projectId";
                query.Prepare();
                query.Parameters.AddWithValue("@projectName", t.ProjectName);
                query.Parameters.AddWithValue("@projectId", t.ProjectId);

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

        public List<string> GetAllProjectByUserId()
        {
            connection.Open();
            List<string> list = new List<string>();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.CommandText = "SELECT pr.project_name FROM table_project pr JOIN table_project_programmer pp ON pr.project_id = pp.project_id JOIN table_programmer pro ON pp.programmer_id = pro.programmer_id WHERE pro.programmer_id = @userId ";
                query.Prepare();
                query.Parameters.AddWithValue("@userId", UserLogin.userId);

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["project_name"].ToString());
                    }
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }
    }
}
