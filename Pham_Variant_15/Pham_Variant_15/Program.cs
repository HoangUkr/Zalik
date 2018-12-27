using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pham_Variant_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Зачетная работа");
            Console.WriteLine("Студент: Фам Суан Хоанг");
            Console.WriteLine("Группа ИС-63");
            Console.WriteLine("Задания 1");
            string path = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\famsu\Desktop\Learning materials\Семестр 5\Веб орієнтоване програмування\Test\Pham_Variant_15\Pham_Variant_15\Database1.mdf;Integrated Security=True";
            SqlConnection cn = new SqlConnection(path);
            cn.Open();
            Console.WriteLine("=========================#1=========================");
            Console.WriteLine("File name: ");
            string file_nm = Console.ReadLine();
            string query2 = "select file_.name, catalog_.name, file_.parent_catalog from file_ inner join catalog_ on file_.id_catalog = catalog.ID where file_.name = ";
            SqlCommand cmd2 = new SqlCommand(query2, cn);
            SqlDataReader r2 = cmd2.ExecuteReader();
            while (r2.Read())
            {
                string nm_file = "'\'" + r2.GetString(2) + "'\'" + r2.GetString(1) + "'\'" + r2.GetString(0);
                Console.WriteLine("{0} \t", nm_file);
            }
            Console.WriteLine("Successfully connected");
            r2.Close();
            cmd2.Dispose();
            Console.WriteLine("=========================#2=========================");
            Console.Write("Name catalog: ");
            string nm_catalog = Console.ReadLine();
            string query = "select file_.name from file_ inner join catalog_ on file_.id_catalog = catalog.ID where catalog_.name = "+ nm_catalog;
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataReader r = cmd.ExecuteReader();
            while(r.Read())
            {
                string nm_file = r.GetString(0);
                Console.WriteLine("{0} \t", nm_file);
            }
            Console.WriteLine("Successfully connected");
            r.Close();
            cmd.Dispose();
            Console.WriteLine("=========================#3=========================");
            Console.Write("Name catalog: ");
            string nm_catalog1 = Console.ReadLine();
            string query1 = "select sum(file_.capable) from file_ inner join catalog_ on file_.id_catalog = catalog.ID where catalog_.name = " + nm_catalog1;
            SqlCommand cmd1 = new SqlCommand(query1, cn);
            SqlDataReader r1 = cmd1.ExecuteReader();
            while (r1.Read())
            {
                string total = r1.GetString(0);
                Console.WriteLine("{0} \t", total);
            }
            r1.Close();
            cmd1.Dispose();
            cn.Close();
            Console.ReadKey();
        }
    }
}
