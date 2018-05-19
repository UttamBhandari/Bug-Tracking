using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class BugInformationDAO : GenericDAO<BugInformation>
    {
        private SqlConnection connection = new DBConnection().GetConnection();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BugInformation> GetAll()
        {
            throw new NotImplementedException();
        }

        public BugInformation GetById(int id)
        {
            connection.Open();
            BugInformation p = null;

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.CommandText = "SELECT * FROM table_bug_information WHERE bug_id=@bug_id;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@bug_id", id);
                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        p = new BugInformation
                        {
                            InformationId = Convert.ToInt32(reader["bug_information_id"]),
                            Cause = reader["cause"].ToString(),
                            Symtons = reader["symptons"].ToString(),
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

        public void Insert(BugInformation t)
        {
            connection.Open();
            SqlTransaction trans = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO table_bug_information VALUES(@symptons, @cause, @bug_id)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@symptons", t.Symtons);
                sql.Parameters.AddWithValue("@cause", t.Cause);
                sql.Parameters.AddWithValue("@bug_id", t.BugId);

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

        public void Update(BugInformation t)
        {
            connection.Open();
            SqlTransaction trans = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = trans;
                sql.CommandText = "UPDATE table_bug_information SET symptons = @symptons, cause = @cause WHERE bug_id = @bug_id";
                sql.Prepare();
                sql.Parameters.AddWithValue("@symptons", t.Symtons);
                sql.Parameters.AddWithValue("@cause", t.Cause);
                sql.Parameters.AddWithValue("@bug_id", t.BugId);

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
    }
}
