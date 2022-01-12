using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            // DataReader doc du lieu trong bang SINHVIEN
            string constr = "Server = GREYT\\SQLEXPRESS; Database =TestADO;Integrated Security = true";
            var connect = new SqlConnection(constr);
            connect.Open();
            var cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "select * from SINHVIEN";
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //var id = reader[0];
                    //var hoten = reader[1];
                    //var ns = reader[2];
                    //var gt = reader[3];
                    //Console.WriteLine($"{id} \t {hoten} \t {ns} \t {gt}");
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader["MaSV"], reader["sHoten"],
                        reader["dNgaysinh"], reader["sGioitinh"]);

                }

            }
            else Console.WriteLine("Khong co du lieu");
            reader.Close();
            connect.Close();
            Console.ReadLine();
        }
    }
}
