using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class TesterDAO : GenericDAO<Tester>
    {
        private SqlConnection connection = new DBConnection().GetConnection();
        /// <summary>
        /// used for deleting tester
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// used for getting all the tester information
        /// </summary>
        /// <returns></returns>

        public List<Tester> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// used to get a specific user information based on their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tester GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// used to insert new tester
        /// </summary>
        /// <param name="t"></param>
        public void Insert(Tester t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "INSERT INTO table_tester VALUES(@fullName, @username, @password)";
                query.Prepare();
                query.Parameters.AddWithValue("@fullName", t.Full_name);
                query.Parameters.AddWithValue("@username", t.Username);
                query.Parameters.AddWithValue("@password", t.Password);

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
        /// used to update tester information
        /// </summary>
        /// <param name="t"></param>
        public void Update(Tester t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// used to allow tester to logged in a system
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int IsLogin(string username, string password)
        {
            connection.Open();
            SqlTransaction transaction = null;

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "SELECT * FROM table_tester WHERE username=@username AND password=@password;SELECT SCOPE_IDENTITY()";
                query.Prepare();
                query.Parameters.AddWithValue("@username", username);
                query.Parameters.AddWithValue("@password", password);

                int id = Convert.ToInt32(query.ExecuteScalar());

                return id;
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
    }
}