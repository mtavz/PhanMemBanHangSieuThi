using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PhanMemBanHangSieuThi_DAL
{
    public class KetNoiDB
    {
        public static SqlConnection connect;
        public static string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
        static string _message = "";

        //Mo ket noi
        public static void MoKetNoi()
        {
            if (KetNoiDB.connect == null)
            {
                KetNoiDB.connect = new SqlConnection(connectionString);
            }
            if (KetNoiDB.connect.State != ConnectionState.Open)
            {
                KetNoiDB.connect.Open();
            }
        }
        //Dong ket noi
        public void DongKetNoi()
        {
            if (KetNoiDB.connect.State != null)
            {
                if (KetNoiDB.connect.State == ConnectionState.Open)
                {
                    KetNoiDB.connect.Close();
                }
            }
        }
        //Thuc thi cau lenh SQL: insert, update, delete
        public int ThucThiCauLenhSQL(string strSql)
        {
            try
            {              
                MoKetNoi();
                connect.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
                SqlCommand sqlCmd = new SqlCommand(strSql, connect);
                sqlCmd.ExecuteNonQuery();
                DongKetNoi();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public string ThucThiCauLenhSQL_CoThongBao(string strSql)
        {
            try
            {
                _message = "";
                MoKetNoi();
                connect.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
                SqlCommand sqlCmd = new SqlCommand(strSql, connect);
                sqlCmd.ExecuteNonQuery();
                DongKetNoi();
                return _message;
            }
            catch 
            {
                return _message;
            }
        }
        static void InfoMessageHandler(object sender, SqlInfoMessageEventArgs e)
        {
            _message = e.Message;
        }

        //Lay du lieu ra bang: select
        public DataTable getDatatable(string strSql)
        {
            try
            {
                MoKetNoi();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDa = new SqlDataAdapter(strSql, connect);
                sqlDa.Fill(dt);
                DongKetNoi();
                return dt;
            }
            catch { return null; }
        }

        //Lay gia tri dau cua bang khi select
        public string getValue(string strSql)
        {
            string temp = null;
            MoKetNoi();
            SqlCommand sqlCmd = new SqlCommand(strSql, connect);
            SqlDataReader sqlDr = sqlCmd.ExecuteReader();
            while (sqlDr.Read())
            {
                temp = sqlDr[0].ToString();
            }
            DongKetNoi();
            return temp;

        }
    }
}
