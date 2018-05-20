using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Tracker.Model;

namespace Bug_Tracker.DAO
{
    class BugImageDAO : GenericDAO<BugImage>
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
                query.CommandText = "DELETE FROM table_image WHERE bug_id=@bugId";
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

        public List<BugImage> GetAll()
        {
            throw new NotImplementedException();
        }

        public BugImage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(BugImage t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "INSERT INTO table_image VALUES(@filepath, @filename, @bugid)";
                query.Prepare();
                query.Parameters.AddWithValue("@filepath", t.ImagePath);
                query.Parameters.AddWithValue("@filename", t.ImageName);
                query.Parameters.AddWithValue("@bugid", t.BugId);

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

        public void Update(BugImage t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "UPDATE table_image SET image_name = @filename WHERE image_id = @imageId;";
                query.Prepare();
                query.Parameters.AddWithValue("@filename", t.ImageName);
                query.Parameters.AddWithValue("@imageId", t.ImageId);

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
