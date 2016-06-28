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
   public class DA_BaoHanh
    {
        static SqlConnection conn;
        static SqlCommand cmd;


        GetData data = new GetData();
        public string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }


        public static bool insertBaoHanh(EC_BaoHanh bh)
        {
            conn = GetData.KetNoi();
            string truyvan = "BaoHanh_Insert";
            cmd = new SqlCommand(truyvan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MABH", SqlDbType.NVarChar).Value = bh.MaBH;
            cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = bh.MaKH;
            cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = bh.MaSP;
            cmd.Parameters.Add("@IMEI", SqlDbType.NVarChar).Value = bh.IMEI;
            cmd.Parameters.Add("@NGAYBD", SqlDbType.NVarChar).Value = bh.NgayBD;
            cmd.Parameters.Add("@NGAYKT", SqlDbType.NVarChar).Value = bh.NgayKT;
            cmd.Parameters.Add("@LOI", SqlDbType.NVarChar).Value = bh.Loi;
            cmd.Parameters.Add("@GHICHU", SqlDbType.NVarChar).Value = bh.GhiChu;

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            try
            {
                GetData.ThucThiTruyVanNonQuery(truyvan, conn);
                GetData.DongKetNoi(conn);
                return true;
            }
            catch (Exception ex)
            {
                GetData.DongKetNoi(conn);
                return false;
            }
        }

        public static bool updateBaoHanh(EC_BaoHanh bh)
        {
            conn = GetData.KetNoi();
            string truyvan = "BaoHanh_Update";
            cmd = new SqlCommand(truyvan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MABH", SqlDbType.NVarChar).Value = bh.MaBH;
            cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = bh.MaKH;
            cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = bh.MaSP;
            cmd.Parameters.Add("@IMEI", SqlDbType.NVarChar).Value = bh.IMEI;
            cmd.Parameters.Add("@NGAYBD", SqlDbType.NVarChar).Value = bh.NgayBD;
            cmd.Parameters.Add("@NGAYKT", SqlDbType.NVarChar).Value = bh.NgayKT;
            cmd.Parameters.Add("@LOI", SqlDbType.NVarChar).Value = bh.Loi;
            cmd.Parameters.Add("@GHICHU", SqlDbType.NVarChar).Value = bh.GhiChu;

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            try
            {
                GetData.ThucThiTruyVanNonQuery(truyvan, conn);
                GetData.DongKetNoi(conn);
                return true;
            }
            catch (Exception ex)
            {
                GetData.DongKetNoi(conn);
                return false;
            }
        }

        public static bool deleteBaoHanh(EC_BaoHanh bh)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "BaoHanh_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MABH", SqlDbType.NVarChar).Value = bh.MaBH;
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
            SqlDataAdapter adapter = new SqlDataAdapter("BaoHanh_SelectAll", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }

        public static DataTable getKhachHang()
        {
            conn = GetData.KetNoi();
            SqlDataAdapter adapter = new SqlDataAdapter("KhachHang_SelectAll", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }

        public static DataTable getSanPham()
        {
            conn = GetData.KetNoi();
            SqlDataAdapter adapter = new SqlDataAdapter("SanPham_SelectAll", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
        public static DataTable searchIMEI(string key)
        {
            cmd = new SqlCommand("BaoHanh_GetByIMEI", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IMEI", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }

        public static DataTable searchMaBH(string key)
        {
            cmd = new SqlCommand("BaoHanh_GetByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MABH", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }

        public static DataTable searchMaKH(string key)
        {
            cmd = new SqlCommand("BaoHanh_GetByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }


        public static DataTable GetMaBH(string mabh)
        {           
            GetData data = new GetData();
            string select = "SELECT dbo.BaoHanh.MABH, dbo.KhachHang.TENKH, dbo.SanPham.TENSP, dbo.BaoHanh.IMEI, dbo.BaoHanh.NGAYBD, dbo.BaoHanh.NGAYKT, dbo.BaoHanh.LOI, dbo.BaoHanh.GHICHU, dbo.BaoHanh.MASP,dbo.BaoHanh.MAKH FROM dbo.BaoHanh INNER JOIN dbo.SanPham ON dbo.BaoHanh.MASP = dbo.SanPham.MASP INNER JOIN dbo.KhachHang ON dbo.BaoHanh.MAKH = dbo.KhachHang.MAKH";
            select += " where dbo.BaoHanh.MABH = N'" + mabh + "'";
            try
            {
                return GetData.LayDataTable(select, conn);
            }
            catch
            {

                return null;
            }
        }
    }
}
