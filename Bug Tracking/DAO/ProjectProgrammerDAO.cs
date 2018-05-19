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
            SqlTransaction trans = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = trans;
                sql.CommandText = "DELETE FROM table_project_programmer WHERE programmer_id = @projectPragrammerID";
                sql.Prepare();
                sql.Parameters.AddWithValue("@projectPragrammerID", id);

                int res = sql.ExecuteNonQuery();

                if (res > 0)
                {
                    trans.Commit();
                    return true;
                } else
                {
                    return false;
                }
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

        public List<ProjectProgrammer> GetAll()
        {
            connection.Open();
            List<ProjectProgrammer> list = new List<ProjectProgrammer>();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.CommandText = "SELECT * FROM table_project_programmer;";
                sql.Prepare();
                using (SqlDataReader reader = sql.ExecuteReader())
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
            SqlTransaction trans = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO table_project_programmer VALUES(@projectId, @programmerId, @adminId)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@projectId", t.ProjectId);
                sql.Parameters.AddWithValue("@programmerId", t.ProgrammerId);
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
                SqlCommand sql = new SqlCommand(null, connection);
                sql.CommandText = "SELECT * FROM table_project_programmer WHERE project_id=@projectId;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@projectId", projectId);
                using (SqlDataReader reader = sql.ExecuteReader())
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
