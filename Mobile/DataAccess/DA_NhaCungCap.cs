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
    public class DA_NhaCungCap
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public string Error;

        public static bool insertNCC(EC_NhaCungCap ncc)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "NhaCungCap_Insert";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MANCC", SqlDbType.NVarChar).Value = ncc.MaNCC;
            cmd.Parameters.Add("@TENNCC", SqlDbType.NVarChar).Value = ncc.TenNCC;
            cmd.Parameters.Add("@DIENTHOAI", SqlDbType.NVarChar).Value = ncc.DienThoai;
            cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = ncc.DiaChi;
            cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = ncc.Email;
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
        public static bool updateNCC(EC_NhaCungCap ncc)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "NhaCungCap_Update";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MANCC", SqlDbType.NVarChar).Value = ncc.MaNCC;
            cmd.Parameters.Add("@TENNCC", SqlDbType.NVarChar).Value = ncc.TenNCC;
            cmd.Parameters.Add("@DIENTHOAI", SqlDbType.NVarChar).Value = ncc.DienThoai;
            cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = ncc.DiaChi;
            cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = ncc.Email;
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
        public static bool deleteNCC(EC_NhaCungCap ncc)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "NhaCungCap_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MANCC", SqlDbType.NVarChar).Value = ncc.MaNCC;
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
            SqlDataAdapter adapter = new SqlDataAdapter("NhaCungCap_SelectAll", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
        public static DataTable searchMaNCC(string key)
        {
            cmd = new SqlCommand("NhaCungCap_GetByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MANCC", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }

        public static DataTable searchTenNCC(string key)
        {
            cmd = new SqlCommand("NhaCungCap_GetByTen", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TENNCC", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }



    }
}
