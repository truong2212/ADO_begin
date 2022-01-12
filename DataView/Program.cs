using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace DataViewExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string constr = "Server = GREYT\\SQLEXPRESS; Database =TestADO;Integrated Security = true";
            string sql = "SELECT * FROM SINHVIEN";
            var connect = new SqlConnection(constr);
            connect.Open();
            var adapter = new SqlDataAdapter(sql, connect);
            var ds = new DataSet();
            adapter.Fill(ds, "SV");
            var table = ds.Tables["SV"];
            var dv = new DataView(table, "sGioitinh = 'nu'", "dNgaysinh", DataViewRowState.CurrentRows);
            foreach (DataRowView i in dv)
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", i["MaSV"], i["sHoten"],
                        i["dNgaysinh"], i["sGioitinh"]);



            connect.Close();
            Console.Read();

        }
    }
}
