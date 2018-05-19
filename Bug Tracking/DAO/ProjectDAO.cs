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
                SqlCommand sql = new SqlCommand(null, connection);
                sql.CommandText = "DELETE FROM table_project WHERE project_id=@projectId;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@projectId", id);

                int res = sql.ExecuteNonQuery();

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
                SqlCommand sql = new SqlCommand(null, connection);
                sql.CommandText = "SELECT * FROM table_project WHERE admin_id=@adminId;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@adminId", Program.adminId);

                using (SqlDataReader reader = sql.ExecuteReader())
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
            SqlTransaction trans = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO table_project VALUES(@projectName, @adminId)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@projectName", t.ProjectName);
                sql.Parameters.AddWithValue("@adminId", Program.adminId);

                sql.ExecuteNonQuery();

                trans.Commit();
            }
            catch (SqlException ex)
            {
                trans.Rollback();
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
            SqlTransaction trans = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = trans;
                sql.CommandText = "UPDATE table_project SET project_name = @projectName WHERE project_id = @projectId";
                sql.Prepare();
                sql.Parameters.AddWithValue("@projectName", t.ProjectName);
                sql.Parameters.AddWithValue("@projectId", t.ProjectId);

                sql.ExecuteNonQuery();

                trans.Commit();
            }
            catch (SqlException ex)
            {
                trans.Rollback();
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
                SqlCommand sql = new SqlCommand(null, connection);
                sql.CommandText = "SELECT pr.project_name FROM table_project pr JOIN table_project_programmer pp ON pr.project_id = pp.project_id JOIN table_programmer pro ON pp.programmer_id = pro.programmer_id WHERE pro.programmer_id = @userId ";
                sql.Prepare();
                sql.Parameters.AddWithValue("@userId", UserLogin.userId);

                using (SqlDataReader reader = sql.ExecuteReader())
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
