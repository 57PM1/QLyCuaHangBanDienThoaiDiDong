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
    public class DA_CTHDB
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public string Error;

        public static bool insertCTHDB(EC_CTHDB cthd)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "CTHDB_Insert";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MAHDB", SqlDbType.NVarChar).Value = cthd.MaHDB;
            cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = cthd.MaSP;
            cmd.Parameters.Add("@SOLUONG", SqlDbType.Int).Value = cthd.SoLuong;
            cmd.Parameters.Add("@DONGIA", SqlDbType.Float).Value = cthd.DonGia;
            cmd.Parameters.Add("@THANHTIEN", SqlDbType.Float).Value = cthd.thanhTien;

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
        public static bool updateCTHDB(EC_CTHDB cthd)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "CTHDB_Update";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAHDB", SqlDbType.NVarChar).Value = cthd.MaHDB;
            cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = cthd.MaSP;
            cmd.Parameters.Add("@SOLUONG", SqlDbType.NVarChar).Value = cthd.SoLuong;
            cmd.Parameters.Add("@DONGIA", SqlDbType.NVarChar).Value = cthd.DonGia;
            cmd.Parameters.Add("@THANHTIEN", SqlDbType.NVarChar).Value = cthd.thanhTien;

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
        public static bool deleteCTHDB(EC_CTHDB cthd)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "CTHDB_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAHDB", SqlDbType.NVarChar).Value = cthd.MaHDB;
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
        public static DataTable getAllByIDMaHDB(String key)
        {
            conn = GetData.KetNoi();
            cmd = new SqlCommand("CTHDB_GetByIDMaHDB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAHDB", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }
    }
}
