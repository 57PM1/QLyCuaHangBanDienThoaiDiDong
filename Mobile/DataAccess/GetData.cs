using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
    public class GetData
    {


        //Kết nối 
        public static SqlConnection KetNoi()
        {
            string sChuoiKetNoi = @"Data Source=TENT\SQLEXPRESS;Initial Catalog=Mobile;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sChuoiKetNoi);
            conn.Open();
            return conn;
        }
        //Đóng kết nối
        public static void DongKetNoi(SqlConnection conn)
        {
            conn.Close();
        }
        //Lấy DataTable
        public static DataTable LayDataTable(string sTruyVan, SqlConnection conn)
        {
            SqlDataAdapter da = new SqlDataAdapter(sTruyVan, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //Thực thi truy vấn ExcuteNonQuery
        public static bool ThucThiTruyVanNonQuery(string sTruyVan, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sTruyVan, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool CheckLogin(string name, string pass)
        {
            string sChuoiKetNoi = @"Data Source=TENT\SQLEXPRESS;Initial Catalog=Mobile;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sChuoiKetNoi);
            // SqlConnection con = KetNoi();
            SqlCommand cmd = new SqlCommand("select * from TaiKhoan where TAIKHOAN='" + name + "' and MATKHAU='" + pass + "'", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
        public String getQuyen(string name, string pass)
        {
            String quyen = "";
            string sChuoiKetNoi = @"Data Source=TENT\SQLEXPRESS;Initial Catalog=Mobile;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sChuoiKetNoi);
            // SqlConnection con = KetNoi();
            //SqlCommand cmd = new SqlCommand("SELECT [Quyen] From TaiKhoan Where TaiKhoan='" + name + "' and MatKhau='" + pass + "'", con);

            conn.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT [QUYEN] From TaiKhoan Where TAIKHOAN='" + name + "' and MATKHAU='" + pass + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow drow = dt.Rows[0];
                quyen = drow["QUYEN"].ToString();
                conn.Close();
                return quyen;
            }
            catch (Exception e)
            {
                conn.Close();
                return null;
            }
        }
        public String getMaNV(string name, string pass)
        {
            String quyen = "";
            string sChuoiKetNoi = @"Data Source=TENT\SQLEXPRESS;Initial Catalog=Mobile;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sChuoiKetNoi);
            // SqlConnection con = KetNoi();
            //SqlCommand cmd = new SqlCommand("SELECT [Quyen] From TaiKhoan Where TaiKhoan='" + name + "' and MatKhau='" + pass + "'", con);

            conn.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT [MANV] From TaiKhoan Where TAIKHOAN='" + name + "' and MATKHAU='" + pass + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow drow = dt.Rows[0];
                quyen = drow["MANV"].ToString();
                conn.Close();
                return quyen;
            }
            catch (Exception e)
            {
                conn.Close();
                return null;
            }
        }
    }
}
