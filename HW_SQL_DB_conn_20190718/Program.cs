using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data.OleDb;
using System.Linq;
using System.Data;

namespace HW_SQL_DB_conn_20190718
{
    class Program
    {

        private static readonly string conn_str = "Server = ASUS_P52F\\SQLEXPRESS; Database = InternetShop; user Id = OVA; Password=123";
                
        private static DataSet SelectByGender(string gender)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(conn_str))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("p_select_by_gender", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@gender", gender);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }

        private static void InsertCustomer
            (
            string first_name,
            string last_name,
            string email,
            string password,
            string address,
            long phone,
            string gender,
            DateTime birthdate,
            DateTime reg_date,
            int bonus_percent
            )
        {

            using (SqlConnection conn = new SqlConnection(conn_str))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("p_insert_to_customer", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@birthdate", birthdate);
                cmd.Parameters.AddWithValue("@reg_date", reg_date);
                cmd.Parameters.AddWithValue("@bonus_percent", bonus_percent);
                cmd.ExecuteNonQuery();
            }
        }

        private static void DeleteCustomerById(int customer_id)
        {
            using (SqlConnection conn = new SqlConnection(conn_str))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("p_delete_from_Customer_by_id", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_id", customer_id);
                cmd.ExecuteNonQuery();
            }
        }

        static void Main(string[] args)
        {
            // Task 1

            foreach (DataRow item in SelectByGender("f").Tables[0].Rows)
            {
                Console.WriteLine(item[0].ToString() + "-" + item[1].ToString() + "-" + item[2].ToString());
            }

            // Task 2

            InsertCustomer("Николай", "Смирнов", "smirnov@mail.ru", "qwerty1", "Сейфулина, 510 - 35", 87019548651, "m", new DateTime(1985, 03, 08), new DateTime(2019, 07, 25), 10);

            // Task 3

            DeleteCustomerById(21);

            Console.ReadKey();
        }
    }
}
