using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormKOS.Model
{
    class IDataBase
    {
        public static string connectionString = "Data Source = DESKTOP-VM4R1FF\\SQLEXPRESS; Initial Catalog = KOSDb; Integrated Security = SSPI;";
        public static DataTable DataToDataTable(string query, List<SqlParameter> parameters) //Metotumuzu static olarak tanımladım.Çünkü sınıfın ismi üzerinden erişilmesini istiyorum
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, con);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd); //Veri okuma işlemleri
                DataTable dt = new DataTable(); //Okunan verileri kaydetme
                da.Fill(dt);

                return dt;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public static DataTable DataToDataTable(string query, SqlParameter parameter)
        {
            return DataToDataTable(query, new List<SqlParameter>() { parameter });
        }
        public static DataTable DataToDataTable(string query)
        {
            return DataToDataTable(query, new List<SqlParameter>() { });
        }
        public static void executeNonQuery(string query, List<SqlParameter> parameters) //Katmanlı MİMARİ
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            try
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            finally
            {
                con.Close();
            }
        }
        public static void executeNonQuery(string query, SqlParameter parameter)
        {
            executeNonQuery(query, new List<SqlParameter>() { parameter });
        }
        public static object executeScaler(string query, List<SqlParameter> parameters) //Katmanlı MİMARİ
        {
            object value = null;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            try
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                value = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            finally
            {
                con.Close();

            }
            return value;
        }

    }
}

 
