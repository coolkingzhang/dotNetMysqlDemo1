using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Configuration;
namespace dotNetMysql
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            //  string conf = "server=127.0.0.1;user id=root;password=root;database=world;sslmode=None";
            string conf = ConfigurationManager.ConnectionStrings["MYSQL"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(conf))
            {
                
                conn.Open();
                MySqlDataAdapter comm = new MySqlDataAdapter("select * from `city` where `Name` like '%Shanghai%'", conn);
                DataSet ds = new DataSet();
                comm.Fill(ds);
                DataTable dt = ds.Tables[0];
                Console.WriteLine(dt.Rows.Count);
                Console.WriteLine(dt.Rows[0]["Name"].ToString());
            }
            //////////////////////////////////
            DataTable dt2 = MYSQLHELPER.ExecuteDataset("select * from `country` where `Name` like '%Chin%'").Tables[0];
            Console.WriteLine("国家名称："+dt2.Rows[0]["Name"]);
            ////
            MySqlParameter[] param ={
                    new MySqlParameter("@China",MySqlDbType.VarChar,52)
            };
            param[0].Value = "China";
            DataTable dt3= MYSQLHELPER.ExecuteDataset("select * from `country` where `Name` = @China", param).Tables[0];//注意（这里的@China不用用''括起来）
            Console.WriteLine("地区："+dt3.Rows[0]["Region"]);
            Console.ReadLine();
        }
    }
}
