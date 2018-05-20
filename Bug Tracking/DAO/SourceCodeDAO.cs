using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class SourceCodeDAO : GenericDAO<SourceCode>
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
                query.CommandText = "DELETE FROM table_code WHERE bug_id=@bugId";
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

        public List<SourceCode> GetAll()
        {
            throw new NotImplementedException();
        }

        public SourceCode GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(SourceCode t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "INSERT INTO table_code VALUES(@filepath, @filename, @plan, @bug_id)";
                query.Prepare();
                query.Parameters.AddWithValue("@filepath", t.CodePath);
                query.Parameters.AddWithValue("@filename", t.CodeFileName);
                query.Parameters.AddWithValue("@plan", t.Language);
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

        public void Update(SourceCode t)
        {
            throw new NotImplementedException();
        }
    }
}
