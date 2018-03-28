using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//tambahkan using berikut
using MySql.Data.MySqlClient;
using PhoneNumber.Models;
using PhoneNumber.DAO;
using System.Data;

namespace PhoneNumber.DAO
{
    class PhonebookDAO
    {
        public MySqlDataAdapter showPhone()
        {
            DBConnect db = new DBConnect();
            MySqlConnection conn = new MySqlConnection(db.connectionString());
            MySqlCommand cmd;
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, name, mobileno FROM phonebook";
                //cmd.Parameters.AddWithValue("@row_number", 0);
                //cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                return adapter;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool insertPhone(Phonebook P)
        {
            DBConnect db = new DBConnect();
            MySqlConnection conn = new MySqlConnection(db.connectionString());
            MySqlCommand cmd;
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO phonebook(name, mobileno) VALUES(@name, @mobileno)";
                cmd.Parameters.AddWithValue("@name", P.Name);
                cmd.Parameters.AddWithValue("@mobileno", P.Mobileno);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool updatePhone(Phonebook P, int id)
        {
            DBConnect db = new DBConnect();
            MySqlConnection conn = new MySqlConnection(db.connectionString());
            MySqlCommand cmd;
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE phonebook SET name = @name, mobileno = @mobileno WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", P.Name);
                cmd.Parameters.AddWithValue("@mobileno", P.Mobileno);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool deletePhone(int id)
        {
            DBConnect db = new DBConnect();
            MySqlConnection conn = new MySqlConnection(db.connectionString());
            MySqlCommand cmd;
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM phonebook WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
