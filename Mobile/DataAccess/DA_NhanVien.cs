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
    public class DA_NhanVien
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public string Error;

        public static bool insertNV(EC_NhanVien nv)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "NhanVien_Insert";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MANV", SqlDbType.NVarChar).Value = nv.MaNV;
            cmd.Parameters.Add("@TENNV", SqlDbType.NVarChar).Value = nv.TenNV;
            cmd.Parameters.Add("@NGAYSINH", SqlDbType.NVarChar).Value = nv.NgaySinh;
            cmd.Parameters.Add("@GIOITINH", SqlDbType.NVarChar).Value = nv.GioiTinh;
            cmd.Parameters.Add("@DIENTHOAI", SqlDbType.NVarChar).Value = nv.DienThoai;
            cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = nv.DiaChi;
            cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = nv.Email;
            cmd.Parameters.Add("@CHUCVU", SqlDbType.NVarChar).Value = nv.ChucVu;
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
        public static bool updateNV(EC_NhanVien nv)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "NhanVien_Update";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MANV", SqlDbType.NVarChar).Value = nv.MaNV;
            cmd.Parameters.Add("@TENNV", SqlDbType.NVarChar).Value = nv.TenNV;
            cmd.Parameters.Add("@NGAYSINH", SqlDbType.NVarChar).Value = nv.NgaySinh;
            cmd.Parameters.Add("@GIOITINH", SqlDbType.NVarChar).Value = nv.GioiTinh;
            cmd.Parameters.Add("@DIENTHOAI", SqlDbType.NVarChar).Value = nv.DienThoai;
            cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = nv.DiaChi;
            cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = nv.Email;
            cmd.Parameters.Add("@CHUCVU", SqlDbType.NVarChar).Value = nv.ChucVu;
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
        public static bool deleteNV(EC_NhanVien nv)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "NhanVien_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MANV", SqlDbType.NVarChar).Value = nv.MaNV;
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
            SqlDataAdapter adapter = new SqlDataAdapter("NhanVien_SelectAll", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
        public static DataTable tkMa(string key)
        {
            cmd = new SqlCommand("NhanVien_GetByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MANV", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }

        public static DataTable tkTen(string key)
        {
            cmd = new SqlCommand("NhanVien_GetByTen", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TENNV", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }
        public static DataTable GetDoanhThu(string manv)
        {
            GetData data = new GetData();
            string select = "SELECT        NhanVien.MANV, NhanVien.TENNV, HoaDonBan.MAHDB, HoaDonBan.TONGTIEN, HoaDonBan.NGAYBAN FROM NhanVien INNER JOIN HoaDonBan ON NhanVien.MANV = HoaDonBan.MANV";
            select += " where dbo.NhanVien.MaNV='" + manv + "'";
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
