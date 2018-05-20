using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class SourceControlDAO : GenericDAO<SourceLink>
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
                query.CommandText = "DELETE FROM table_source_control WHERE bug_id=@bugId";
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

        public List<SourceLink> GetAll()
        {
            throw new NotImplementedException();
        }

        public SourceLink GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(SourceLink t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "INSERT INTO table_source_control VALUES(@link, @start_line, @end_line, @bug_id)";
                query.Prepare();
                query.Parameters.AddWithValue("@link", t.Link);
                query.Parameters.AddWithValue("@start_line", t.StartLine);
                query.Parameters.AddWithValue("@end_line", t.EndLine);
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

        public void Update(SourceLink t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "UPDATE table_source_control SET link = @link, start_line = @start_line, end_line = @end_line WHERE bug_id = @bug_id;";
                query.Prepare();
                query.Parameters.AddWithValue("@link", t.Link);
                query.Parameters.AddWithValue("@start_line", t.StartLine);
                query.Parameters.AddWithValue("@end_line", t.EndLine);
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
