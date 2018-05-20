using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class ProjectAdminDAO : GenericDAO<ProjectAdmin>
    {
        private SqlConnection connection = new DBConnection().GetConnection();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProjectAdmin> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProjectAdmin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProjectAdmin t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = transaction;
                sql.CommandText = "INSERT INTO table_admin VALUES(@company_name, @username, @password)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@company_name", t.Organization);
                sql.Parameters.AddWithValue("@username", t.Username);
                sql.Parameters.AddWithValue("@password", t.Password);

                sql.ExecuteNonQuery();

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

        public void Update(ProjectAdmin t)
        {
            throw new NotImplementedException();
        }

        public int IsLogin(string username, string password)
        {
            connection.Open();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.CommandText = "SELECT * FROM table_admin WHERE username=@username AND password=@password;SELECT SCOPE_IDENTITY()";
                sql.Prepare();
                sql.Parameters.AddWithValue("@username", username);
                sql.Parameters.AddWithValue("@password", password);

                int id = Convert.ToInt32(sql.ExecuteScalar());

                return id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
