﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Tracker.Model;

namespace Bug_Tracker.DAO
{
    class ProgrammerDAO : GenericDAO<Programmer>
    {
        private SqlConnection connection = new DBConnection().GetConnection();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Programmer> GetAll()
        {
            connection.Open();
            List<Programmer> list = new List<Programmer>();

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.CommandText = "SELECT * FROM table_programmer;";
                query.Prepare();
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Programmer p = new Programmer
                        {
                            ProgrammerId = Convert.ToInt32(reader["programmer_id"]),
                            FullName = reader["full_name"].ToString(),
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString()
                        };

                        list.Add(p);
                    }
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }

        public Programmer GetById(int id)
        {
            connection.Open();
            Programmer p = null;

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.CommandText = "SELECT * FROM table_programmer WHERE programmer_id=@programmerId;";
                query.Prepare();
                query.Parameters.AddWithValue("@programmerId", id);
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        p = new Programmer
                        {
                            ProgrammerId = Convert.ToInt32(reader["programmer_id"]),
                            FullName = reader["full_name"].ToString(),
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } finally
            {
                connection.Close();
            }

            return p;
        }

        public void Insert(Programmer t)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            
            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "INSERT INTO table_programmer VALUES(@fullName, @username, @password)";
                query.Prepare();
                query.Parameters.AddWithValue("@fullName", t.FullName);
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

        public void Update(Programmer t)
        {
            throw new NotImplementedException();
        }

        public int IsLogin(string username, string password)
        {
            connection.Open();
            SqlTransaction transaction = null;

            try
            {
                SqlCommand query = new SqlCommand(null, connection);
                query.Transaction = transaction;
                query.CommandText = "SELECT * FROM table_programmer WHERE username=@username AND password=@password;SELECT SCOPE_IDENTITY()";
                query.Prepare();
                query.Parameters.AddWithValue("@username", username);
                query.Parameters.AddWithValue("@password", password);

                int id = Convert.ToInt32(query.ExecuteScalar());

                return id;
                //trans.Commit();
            } catch(SqlException ex)
            {
                transaction.Rollback();
                throw ex;
            } finally
            {
                connection.Close();
            }
        }
    }
}
