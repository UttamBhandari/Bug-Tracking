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
            SqlTransaction trans = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = trans;
                sql.CommandText = "DELETE FROM table_image WHERE bug_id=@bugId";
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
            SqlTransaction trans = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO table_image VALUES(@filepath, @filename, @bugid)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@filepath", t.ImagePath);
                sql.Parameters.AddWithValue("@filename", t.ImageName);
                sql.Parameters.AddWithValue("@bugid", t.BugId);

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

        public void Update(BugImage t)
        {
            connection.Open();
            SqlTransaction trans = connection.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, connection);
                sql.Transaction = trans;
                sql.CommandText = "UPDATE table_image SET image_name = @filename WHERE image_id = @imageId;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@filename", t.ImageName);
                sql.Parameters.AddWithValue("@imageId", t.ImageId);

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
