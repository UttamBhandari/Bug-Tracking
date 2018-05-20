using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class BugInfoDAO : GenericDAO<BugInfo>
    {
        private SqlConnection connection = new DBConnection().GetConnection();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BugInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public BugInfo GetById(int id)
        {
            connection.Open();
            BugInfo p = null;

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.CommandText = "SELECT * FROM table_bug_information WHERE bug_id=@bug_id;";
                query.Prepare();
                query.Parameters.AddWithValue("@bug_id", id);
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        p = new BugInfo
                        {
                            BugInfoID = Convert.ToInt32(reader["bug_information_id"]),
                            Cause = reader["cause"].ToString(),
                            Symptoms = reader["symptons"].ToString(),
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

        public void Insert(BugInfo t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "INSERT INTO table_bug_information VALUES(@symptons, @cause, @bug_id)";
                query.Prepare();
                query.Parameters.AddWithValue("@symptons", t.Symptoms);
                query.Parameters.AddWithValue("@cause", t.Cause);
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

        public void Update(BugInfo t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "UPDATE table_bug_information SET symptons = @symptons, cause = @cause WHERE bug_id = @bug_id";
                query.Prepare();
                query.Parameters.AddWithValue("@symptons", t.Symptoms);
                query.Parameters.AddWithValue("@cause", t.Cause);
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
    }
}
