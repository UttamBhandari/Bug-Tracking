using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class FixerDAO : GenericDAO<Fixer>
    {
        private SqlConnection connection = new DBConnection().GetConnection();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Fixer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Fixer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Fixer t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "INSERT INTO table_fixer VALUES(@fixed_by, @bug_id, @fixed_date)";
                query.Prepare();
                query.Parameters.AddWithValue("@fixed_by", t.FixedBy);
                query.Parameters.AddWithValue("@bug_id", t.BugId);
                query.Parameters.AddWithValue("@fixed_date", DateTime.Now);

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

        public void Update(Fixer t)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// returns a name of bug fixer
        /// </summary>
        /// <returns></returns>
        public List<Fixer> GetBugFixers()
        {
            connection.Open();
            List<Fixer> list = new List<Fixer>();
            Fixer fixer = null;
            Programmer programmer = null;

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.CommandText = "SELECT f.bug_id, f.fixed_date, p.full_name FROM table_programmer p JOIN table_fixer f ON p.programmer_id = f.fixed_by;";
                query.Prepare();

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fixer = new Fixer();
                        programmer = new Programmer();

                        fixer.BugId = Convert.ToInt32(reader["bug_id"]);
                        fixer.FixedDate = DateTime.Parse(reader["bug_id"].ToString());
                        programmer.FullName = reader["full_name"].ToString();

                        fixer.programmer = programmer;

                        list.Add(fixer);
                    }
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }
     }
}
