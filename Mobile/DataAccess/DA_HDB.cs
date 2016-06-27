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
    public class DA_HDB
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public string Error;

        public static bool insertHDB(EC_HDB cthd)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "HoaDonBan_Insert";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAHDB", SqlDbType.NVarChar).Value = cthd.MaHDB;
            cmd.Parameters.Add("@NGAYBAN", SqlDbType.Date).Value = cthd.NgayBan;
            cmd.Parameters.Add("@MANV", SqlDbType.NVarChar).Value = cthd.MaNV;
            cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = cthd.MaKH;
            cmd.Parameters.Add("@TONGTIEN", SqlDbType.Float).Value = cthd.TongTien;

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
        public static bool updateHDB(EC_HDB cthd)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "HoaDonBan_Update";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAHDB", SqlDbType.NVarChar).Value = cthd.MaHDB;
            cmd.Parameters.Add("@NGAYBAN", SqlDbType.Date).Value = cthd.NgayBan;
            cmd.Parameters.Add("@MANV", SqlDbType.NVarChar).Value = cthd.MaNV;
            cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = cthd.MaKH;
            cmd.Parameters.Add("@TONGTIEN", SqlDbType.Float).Value = cthd.TongTien;


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
        public static bool deleteHDB(EC_HDB cthd)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "HoaDonBan_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAHDB", SqlDbType.NVarChar).Value = cthd.MaHDB;
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
            SqlDataAdapter adapter = new SqlDataAdapter("HoaDonBan_SelectAll", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
        public static DataTable GetTTHoaDon(string mahd)
        {
            GetData data = new GetData();
            string select = "SELECT        dbo.HoaDonBan.MAHDB, dbo.HoaDonBan.NGAYBAN, dbo.CTHDB.SOLUONG, dbo.CTHDB.DONGIA, dbo.CTHDB.THANHTIEN, dbo.HoaDonBan.TONGTIEN, dbo.SanPham.TENSP, dbo.KhachHang.TENKH, dbo.NhanVien.TENNV, dbo.SanPham.DONVITINH, dbo.KhachHang.DIENTHOAI, dbo.KhachHang.EMAIL, dbo.KhachHang.DIACHI FROM dbo.CTHDB INNER JOIN dbo.HoaDonBan ON dbo.CTHDB.MAHDB = dbo.HoaDonBan.MAHDB INNER JOIN dbo.SanPham ON dbo.CTHDB.MASP = dbo.SanPham.MASP INNER JOIN dbo.KhachHang ON dbo.HoaDonBan.MAKH = dbo.KhachHang.MAKH INNER JOIN dbo.NhanVien ON dbo.HoaDonBan.MANV = dbo.NhanVien.MANV";
            select += " where dbo.HoaDonBan.MaHDB='" + mahd + "'";
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
