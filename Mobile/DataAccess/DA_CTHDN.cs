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
    public class DA_CTHDN
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public string Error;

        public static bool insertCTHDN(EC_CTHDN cthd)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "CTHDN_Insert";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MAHDN", SqlDbType.NVarChar).Value = cthd.MaHDN;
            cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = cthd.MaSP;
            cmd.Parameters.Add("@SOLUONG", SqlDbType.Int).Value = cthd.SoLuong;
            cmd.Parameters.Add("@DONGIA", SqlDbType.Float).Value = cthd.DonGia;
            cmd.Parameters.Add("@THANHTIEN", SqlDbType.Float).Value = cthd.ThanhTien;

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
        public static bool updateCTHDN(EC_CTHDN cthd)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "CTHDN_Update";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MAHDN", SqlDbType.NVarChar).Value = cthd.MaHDN;
            cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = cthd.MaSP;
            cmd.Parameters.Add("@SOLUONG", SqlDbType.Int).Value = cthd.SoLuong;
            cmd.Parameters.Add("@DONGIA", SqlDbType.Float).Value = cthd.DonGia;
            cmd.Parameters.Add("@THANHTIEN", SqlDbType.Float).Value = cthd.ThanhTien;

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
        public static bool deleteCTHDN(EC_CTHDN cthd)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "CTHDN_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAHDN", SqlDbType.NVarChar).Value = cthd.MaHDN;
            cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = cthd.MaSP;
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
        public static DataTable getAllByIDMaHDN(String key)
        {
            conn = GetData.KetNoi();
            cmd = new SqlCommand("CTHDN_GetByIDMaHDN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAHDN", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }
    }
}
