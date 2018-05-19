using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class SourceControlDAO : GenericDAO<SourceControl>
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
                sql.CommandText = "DELETE FROM table_source_control WHERE bug_id=@bugId";
                sql.Prepare();
                sql.Parameters.AddWithValue("@bugId", id);

                sql.ExecuteNonQuery();
                trans.Commit();

                return true;
            }
            catch (SqlException ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<SourceControl> GetAll()
        {
            throw new NotImplementedException();
        }

        public SourceControl GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(SourceControl t)
        {
            connection.Open();
            SqlTransaction trans = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO table_source_control VALUES(@link, @start_line, @end_line, @bug_id)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@link", t.Link);
                sql.Parameters.AddWithValue("@start_line", t.StartLine);
                sql.Parameters.AddWithValue("@end_line", t.EndLine);
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

        public void Update(SourceControl t)
        {
            connection.Open();
            SqlTransaction trans = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = trans;
                sql.CommandText = "UPDATE table_source_control SET link = @link, start_line = @start_line, end_line = @end_line WHERE bug_id = @bug_id;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@link", t.Link);
                sql.Parameters.AddWithValue("@start_line", t.StartLine);
                sql.Parameters.AddWithValue("@end_line", t.EndLine);
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
