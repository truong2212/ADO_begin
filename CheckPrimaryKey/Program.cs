using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPrimaryKey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap ma SV can kiem tra: ");
            int masv = Convert.ToInt32(Console.ReadLine());
            string constr = "Server = GREYT\\SQLEXPRESS; Database =TestADO;Integrated Security = true";
            var connect = new SqlConnection(constr);
            string checkMsv = " select MaSV from SINHVIEN WHERE MaSV = " + masv;
            var myData = new SqlDataAdapter(checkMsv, connect);
            var tblCheck = new DataTable();
            myData.Fill(tblCheck);
            if(tblCheck.Rows.Count>0)  Console.WriteLine("Ma sv da ton tai");
            else  Console.WriteLine("ma sv {0} chua co", masv);
            Console.ReadLine();
        }
    }
}
