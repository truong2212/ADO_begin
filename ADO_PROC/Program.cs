using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_PROC
{
    class Program
    {
        static void Main(string[] args)
        {
           // Viet lenh dung PROC trong sql
            try
            {


                string constr = "Server = GREYT\\SQLEXPRESS; Database =TestADO;Integrated Security = true";
                var connect = new SqlConnection(constr);
                connect.Open();

                int masv; string hoten; DateTime ngaysinh; string gt;
                Console.WriteLine("Nhap Ma SV: ");
                masv = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nhap ho ten SV: ");
                hoten = Console.ReadLine();
                Console.WriteLine("Nhap ngay sinh: ");
                ngaysinh = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Nhap Gioi tinh: ");
                gt = Console.ReadLine();
                // TAO COMMAND
                var cmd = connect.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertSV";
                cmd.Parameters.AddWithValue("@masv", masv);
                cmd.Parameters.AddWithValue("@tensv", hoten);
                cmd.Parameters.AddWithValue("@ns", ngaysinh);
                cmd.Parameters.AddWithValue("@gt", gt);
                int i = cmd.ExecuteNonQuery();
                if (i > 0) Console.WriteLine("ADDED SUCCESS");
                else Console.WriteLine("ADDED FAILURE");

                connect.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}
