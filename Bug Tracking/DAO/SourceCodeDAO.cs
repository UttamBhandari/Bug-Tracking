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
            SqlTransaction trans = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = trans;
                sql.CommandText = "DELETE FROM table_code WHERE bug_id=@bugId";
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
            SqlTransaction trans = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO table_code VALUES(@filepath, @filename, @plan, @bug_id)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@filepath", t.CodeFilePath);
                sql.Parameters.AddWithValue("@filename", t.CodeFileName);
                sql.Parameters.AddWithValue("@plan", t.ProgrammingLanguage);
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

        public void Update(SourceCode t)
        {
            throw new NotImplementedException();
        }
    }
}
