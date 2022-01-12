using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAdapter_DataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string constr = "Server = GREYT\\SQLEXPRESS; Database =TestADO;Integrated Security = true";
            var connection = new SqlConnection(constr);
            connection.Open();
            var cmd = new SqlCommand("select * from SINHVIEN", connection);
            var myData = new SqlDataAdapter(cmd);
            var table = new DataTable();
            myData.Fill(table);
            if (table.Rows.Count == 0) Console.WriteLine("Khong co du lieu");
            else foreach (DataRow r in table.Rows)
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", r[0],r[1], r[2], r[3]);
            connection.Close();
            Console.Read();
        }
    }
}
