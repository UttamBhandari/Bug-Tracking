using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class ProjectProgrammerDAO : GenericDAO<ProjectProgrammer>
    {

        private SqlConnection connection = new DBConnection().GetConnection();

        public bool Delete(int id)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "DELETE FROM table_project_programmer WHERE programmer_id = @projectPragrammerID";
                query.Prepare();
                query.Parameters.AddWithValue("@projectPragrammerID", id);

                int res = query.ExecuteNonQuery();

                if (res > 0)
                {
                    transaction.Commit();
                    return true;
                } else
                {
                    return false;
                }
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

        public List<ProjectProgrammer> GetAll()
        {
            connection.Open();
            List<ProjectProgrammer> list = new List<ProjectProgrammer>();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.CommandText = "SELECT * FROM table_project_programmer;";
                query.Prepare();
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        ProjectProgrammer p = new ProjectProgrammer
                        {
                            ProjectProgrammerId = Convert.ToInt32(reader["project_programmer_id"]),
                            ProjectId = Convert.ToInt32(reader["project_id"]),
                            ProgrammerId = Convert.ToInt32(reader["programmer_id"])
                        };

                        list.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }

        public ProjectProgrammer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProjectProgrammer t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "INSERT INTO table_project_programmer VALUES(@projectId, @programmerId, @adminId)";
                query.Prepare();
                query.Parameters.AddWithValue("@projectId", t.ProjectId);
                query.Parameters.AddWithValue("@programmerId", t.ProgrammerId);
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

        public void Update(ProjectProgrammer t)
        {
            throw new NotImplementedException();
        }

        public List<ProjectProgrammer> GetAllProjectsByProjectId(int projectId)
        {
            connection.Open();
            List<ProjectProgrammer> list = new List<ProjectProgrammer>();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.CommandText = "SELECT * FROM table_project_programmer WHERE project_id=@projectId;";
                query.Prepare();
                query.Parameters.AddWithValue("@projectId", projectId);
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        ProjectProgrammer p = new ProjectProgrammer
                        {
                            ProjectProgrammerId = Convert.ToInt32(reader["project_programmer_id"]),
                            ProjectId = Convert.ToInt32(reader["project_id"]),
                            ProgrammerId = Convert.ToInt32(reader["programmer_id"])
                        };

                        list.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }

       
    }
}
