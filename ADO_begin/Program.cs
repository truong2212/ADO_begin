using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ADO_begin
{
    class Program
    {
        static void Main(string[] args)
        {

          //  Console.WriteLine(connect.State);
        //    Viet lenh truc tiep
            try
            {
                string constr = "Server = GREYT\\SQLEXPRESS; Database =TestADO;Integrated Security = true";
                var connect = new SqlConnection(constr);
                //connect.Open();
                int masv; string hoten; DateTime ngaysinh; string gt;
                Console.WriteLine("Nhap Ma SV: ");
                masv = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nhap ho ten SV: ");
                hoten = Console.ReadLine();
                Console.WriteLine("Nhap ngay sinh: ");
                ngaysinh = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Nhap Gioi tinh: ");
                gt = Console.ReadLine();
                bool i = Program.themSV(constr, masv, hoten, ngaysinh, gt);
                if (i) Console.WriteLine("Add Success");
                else Console.WriteLine("Add Failure");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
 
        }
        public static bool themSV(string constr, int masv, string hoten, DateTime ngaysinh, string Gioitinh)
        {
            string sqlInsert = "insert into SINHVIEN " +
               "values (" + masv + ",N'" + hoten + "','" + ngaysinh + "','" + Gioitinh + "')";
            Console.WriteLine(sqlInsert);
            var connect = new SqlConnection(constr);
            var cmd = new SqlCommand(sqlInsert, connect);
            cmd.CommandType = CommandType.Text;
            connect.Open();
            int i = cmd.ExecuteNonQuery();
            connect.Close();
            return i > 0;

        }
    }
  
}
