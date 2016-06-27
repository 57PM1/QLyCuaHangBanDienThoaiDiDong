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
    public class DA_HDN
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public string Error;

        public static bool insertHDN(EC_HDN cthd)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "HoaDonNhap_Insert";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAHDN", SqlDbType.NVarChar).Value = cthd.MaHDN;
            cmd.Parameters.Add("@NGAYNHAP", SqlDbType.Date).Value = cthd.NgayNhap;
            cmd.Parameters.Add("@MANV", SqlDbType.NVarChar).Value = cthd.MaNV;
            cmd.Parameters.Add("@MANCC", SqlDbType.NVarChar).Value = cthd.MaNCC;
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
        public static bool updateHDN(EC_HDN cthd)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "HoaDonNhap_Update";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAHDN", SqlDbType.NVarChar).Value = cthd.MaHDN;
            cmd.Parameters.Add("@NGAYNHAP", SqlDbType.Date).Value = cthd.NgayNhap;
            cmd.Parameters.Add("@MANV", SqlDbType.NVarChar).Value = cthd.MaNV;
            cmd.Parameters.Add("@MANCC", SqlDbType.NVarChar).Value = cthd.MaNCC;
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
        public static bool deleteHDN(EC_HDN cthd)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "HoaDonNhap_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAHDN", SqlDbType.NVarChar).Value = cthd.MaHDN;
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
            SqlDataAdapter adapter = new SqlDataAdapter("HoaDonNhap_SelectAll", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }



        public static DataTable GetTTHoaDon(string mahd)
        {
            GetData data = new GetData();
            string select = "SELECT dbo.HoaDonNhap.MAHDN, dbo.HoaDonNhap.NGAYNHAP, dbo.CTHDN.MASP, dbo.CTHDN.SOLUONG, dbo.CTHDN.DONGIA, dbo.CTHDN.THANHTIEN, dbo.SanPham.TENSP, dbo.NhanVien.TENNV, dbo.NhaCungCap.TENNCC FROM dbo.CTHDN INNER JOIN dbo.SanPham ON dbo.CTHDN.MASP = dbo.SanPham.MASP INNER JOIN  dbo.HoaDonNhap ON dbo.CTHDN.MAHDN = dbo.HoaDonNhap.MAHDN INNER JOIN dbo.NhaCungCap ON dbo.HoaDonNhap.MANCC = dbo.NhaCungCap.MANCC INNER JOIN dbo.NhanVien ON dbo.HoaDonNhap.MANV = dbo.NhanVien.MANV";
            select += " where dbo.HoaDonNhap.MaHDN='" + mahd + "'";
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
