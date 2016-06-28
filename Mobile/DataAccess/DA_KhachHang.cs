using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClass;
using System.Data;
using System.Data.SqlClient;



namespace DataAccess
{
    public class DA_KhachHang
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public string Error;

        public static bool insertKH(EC_KhachHang khach)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "KhachHang_Insert";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = khach.MaKH;
            cmd.Parameters.Add("@TENKH", SqlDbType.NVarChar).Value = khach.TenKH;
            cmd.Parameters.Add("@DIENTHOAI", SqlDbType.NVarChar).Value = khach.DienThoai;
            cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = khach.DiaChi;
            cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = khach.Email;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            try
            {
                GetData.ThucThiTruyVanNonQuery(sTruyVan, conn);
                //Đóng kết nối
                GetData.DongKetNoi(conn);
                return true;
            }
            catch (Exception ex)
            {
                //Đóng kết nối
                GetData.DongKetNoi(conn);
                return false;
            }
        }
        public static bool updateKH(EC_KhachHang khach)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "KhachHang_Update";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = khach.MaKH;
            cmd.Parameters.Add("@TENKH", SqlDbType.NVarChar).Value = khach.TenKH;
            cmd.Parameters.Add("@DIENTHOAI", SqlDbType.NVarChar).Value = khach.DienThoai;
            cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = khach.DiaChi;
            cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = khach.Email;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            try
            {
                GetData.ThucThiTruyVanNonQuery(sTruyVan, conn);
                //Đóng kết nối
                GetData.DongKetNoi(conn);
                return true;
            }
            catch (Exception ex)
            {
                //Đóng kết nối
                GetData.DongKetNoi(conn);
                return false;
            }
        }
        public static bool deleteKH(EC_KhachHang khach)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "KhachHang_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = khach.MaKH;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            try
            {
                GetData.ThucThiTruyVanNonQuery(sTruyVan, conn);
                //Đóng kết nối
                GetData.DongKetNoi(conn);
                return true;
            }
            catch (Exception ex)
            {
                //Đóng kết nối
                GetData.DongKetNoi(conn);
                return false;
            }
        }
        public static DataTable getAll()
        {
            conn = GetData.KetNoi();
            SqlDataAdapter adapter = new SqlDataAdapter("KhachHang_SelectAll", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
        public static DataTable searchMaKH(string key)
        {
            cmd = new SqlCommand("KhachHang_GetByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }

        public static DataTable searchTenKH(string key)
        {
            cmd = new SqlCommand("KhachHang_GetByTen", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TENKH", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }


    }
}
