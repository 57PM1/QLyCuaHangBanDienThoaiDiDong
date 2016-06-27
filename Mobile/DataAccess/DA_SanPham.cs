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
    public class DA_SanPham
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public string Error;

        public static bool insertSanPham(EC_SanPham sp)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "SanPham_Insert";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = sp.MaSP;
            cmd.Parameters.Add("@TENSP", SqlDbType.NVarChar).Value = sp.TenSP;
            cmd.Parameters.Add("@SOLUONG", SqlDbType.Int).Value = sp.SoLuong;
            cmd.Parameters.Add("@DONGIABAN", SqlDbType.Float).Value = sp.DonGiaBan;
            cmd.Parameters.Add("@DONVITINH", SqlDbType.NVarChar).Value = sp.DonViTinh;
            //cmd.Parameters.Add("@HINHANH", SqlDbType.NVarChar).Value = sp.HinhAnh;
            cmd.Parameters.Add("@MANSX", SqlDbType.NVarChar).Value = sp.MaNSX;
            cmd.Parameters.Add("@HEDIEUHANH", SqlDbType.NVarChar).Value = sp.HeDieuHanh;
            cmd.Parameters.Add("@CPU", SqlDbType.NVarChar).Value = sp.Cpu;
            cmd.Parameters.Add("@RAM", SqlDbType.NVarChar).Value = sp.Ram;
            cmd.Parameters.Add("@PIN", SqlDbType.NVarChar).Value = sp.Pin;
            cmd.Parameters.Add("@KETNOI", SqlDbType.NVarChar).Value = sp.KetNoi;
            cmd.Parameters.Add("@BONHO", SqlDbType.NVarChar).Value = sp.BoNho;
            cmd.Parameters.Add("@CAMERA", SqlDbType.NVarChar).Value = sp.Camera;
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
        public static bool updateSanPham(EC_SanPham sp)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "SanPham_Update";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = sp.MaSP;
            cmd.Parameters.Add("@TENSP", SqlDbType.NVarChar).Value = sp.TenSP;
            cmd.Parameters.Add("@SOLUONG", SqlDbType.Int).Value = sp.SoLuong;
            cmd.Parameters.Add("@DONGIABAN", SqlDbType.Float).Value = sp.DonGiaBan;
            cmd.Parameters.Add("@DONVITINH", SqlDbType.NVarChar).Value = sp.DonViTinh;
            //cmd.Parameters.Add("@HINHANH", SqlDbType.NVarChar).Value = sp.HinhAnh;
            cmd.Parameters.Add("@MANSX", SqlDbType.NVarChar).Value = sp.MaNSX;
            cmd.Parameters.Add("@HEDIEUHANH", SqlDbType.NVarChar).Value = sp.HeDieuHanh;
            cmd.Parameters.Add("@CPU", SqlDbType.NVarChar).Value = sp.Cpu;
            cmd.Parameters.Add("@RAM", SqlDbType.NVarChar).Value = sp.Ram;
            cmd.Parameters.Add("@PIN", SqlDbType.NVarChar).Value = sp.Pin;
            cmd.Parameters.Add("@KETNOI", SqlDbType.NVarChar).Value = sp.KetNoi;
            cmd.Parameters.Add("@BONHO", SqlDbType.NVarChar).Value = sp.BoNho;
            cmd.Parameters.Add("@CAMERA", SqlDbType.NVarChar).Value = sp.Camera;
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
        public static bool deleteSP(EC_SanPham sp)
        {
            conn = GetData.KetNoi();
            string sTruyVan = "SanPham_Delete";
            cmd = new SqlCommand(sTruyVan, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = sp.MaSP;
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
            SqlDataAdapter adapter = new SqlDataAdapter("SanPham_SelectAll", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
        public static DataTable tkMa(string key)
        {
            cmd = new SqlCommand("SanPham_GetByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MASP", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }

        public static DataTable tkTen(string key)
        {
            cmd = new SqlCommand("SanPham_GetByName", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TENSP", SqlDbType.NVarChar).Value = key;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmd.Dispose();
            adapter.Dispose();
            return table;
        }
    }
}
