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
    public class DA_TaiKhoan
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public string Error;
        GetData data = new GetData();

        public static bool insertTK(EC_TaiKhoan tk)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "TaiKhoan_Insert";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = tk.TaiKhoan;
            cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = tk.MatKhau;
            cmd.Parameters.Add("@Quyen", SqlDbType.NVarChar).Value = tk.Quyen;
            cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = tk.MaNV;
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
        public static bool updateTK(EC_TaiKhoan tk)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "TaiKhoan_Update";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = tk.TaiKhoan;
            cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = tk.MatKhau;
            cmd.Parameters.Add("@Quyen", SqlDbType.NVarChar).Value = tk.Quyen;
            cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = tk.MaNV;
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
        public static bool deleteTK(EC_TaiKhoan tk)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "TaiKhoan_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = tk.TaiKhoan;
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
            SqlDataAdapter adapter = new SqlDataAdapter("TaiKhoan_SelectAll", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
        public static DataTable tkTenTK(string key)
        {
            conn = GetData.KetNoi();
            cmd = new SqlCommand("TaiKhoan_GetByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TAIKHOAN", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }

        public static DataTable tkQuyen(string key)
        {
            cmd = new SqlCommand("TaiKhoan_GetByQuyen", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Quyen", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }


        public static bool getUser(EC_TaiKhoan tk)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "TaiKhoan_GetUser";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = tk.TaiKhoan;
            cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = tk.MatKhau;
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


        public static bool updateMK(EC_TaiKhoan tk)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "TaiKhoan_Update_MK";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = tk.TaiKhoan;
            cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = tk.MatKhau;
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

    }
}
