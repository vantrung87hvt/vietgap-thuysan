/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:5/17/2012 4:27:53 PM
------------------------------------------------------*/
using INVI.DataAccess.Base;
using INVI.Entity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;

namespace INVI.DataAccess
{    
    public class TaiKhoanDangKyToChucChungNhanDAL : SqlProvider<TaiKhoanDangKyToChucChungNhanEntity>
    {
        static TaiKhoanDangKyToChucChungNhanDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                TaiKhoanDangKyToChucChungNhanEntity entity = new TaiKhoanDangKyToChucChungNhanEntity();
				entity.PK_iTaikhoanTochucID = Int32.Parse("0"+dr["PK_iTaikhoanTochucID"].ToString());
				entity.FK_iTaikhoanID = Int64.Parse("0"+dr["FK_iTaikhoanID"].ToString());
				entity.FK_iTochucchungnhanID = Int32.Parse("0"+dr["FK_iTochucchungnhanID"].ToString());
				entity.dNgaydangky =String.IsNullOrEmpty(dr["dNgaydangky"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaydangky"].ToString());
				entity.bDuyet =String.IsNullOrEmpty(dr["bDuyet"].ToString())?false:Boolean.Parse(dr["bDuyet"].ToString());
                return entity;
            };
        }
        public static TaiKhoanDangKyToChucChungNhanEntity GetOne(int PK_iTaikhoanTochucID)
        {
            string cmdName = "spTaiKhoanDangKyToChucChungNhan_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iTaikhoanTochucID", PK_iTaikhoanTochucID);
            TaiKhoanDangKyToChucChungNhanEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<TaiKhoanDangKyToChucChungNhanEntity> GetAll()
        {
            string cmdName = "spTaiKhoanDangKyToChucChungNhan_Get";
            return GetList(cmdName);
        }
        public static List<TaiKhoanDangKyToChucChungNhanEntity> GetByFK_iTaikhoanID(Int64 FK_iTaikhoanID)
		{
			string cmdName = "spTaiKhoanDangKyToChucChungNhan_GetByFK_FK_iTaikhoanID";
			SqlParameter p = new SqlParameter("@FK_iTaikhoanID",FK_iTaikhoanID);
			List<TaiKhoanDangKyToChucChungNhanEntity> list = GetList(cmdName, p);
			return list;
		}public static List<TaiKhoanDangKyToChucChungNhanEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			string cmdName = "spTaiKhoanDangKyToChucChungNhan_GetByFK_FK_iTochucchungnhanID";
			SqlParameter p = new SqlParameter("@FK_iTochucchungnhanID",FK_iTochucchungnhanID);
			List<TaiKhoanDangKyToChucChungNhanEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(TaiKhoanDangKyToChucChungNhanEntity entity)
        {
            string cmdName = "spTaiKhoanDangKyToChucChungNhan_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(TaiKhoanDangKyToChucChungNhanEntity entity)
        {
            string cmdName = "spTaiKhoanDangKyToChucChungNhan_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iTaikhoanTochucID)
        {
            string cmdName = "spTaiKhoanDangKyToChucChungNhan_Delete";
            SqlParameter p = new SqlParameter("@PK_iTaikhoanTochucID", PK_iTaikhoanTochucID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(TaiKhoanDangKyToChucChungNhanEntity entity)
        {
            SqlParameter[] p = new SqlParameter[5];
			p[0] = new SqlParameter("@PK_iTaikhoanTochucID", entity.PK_iTaikhoanTochucID);
			p[1] = new SqlParameter("@FK_iTaikhoanID", entity.FK_iTaikhoanID);
			p[2] = new SqlParameter("@FK_iTochucchungnhanID", entity.FK_iTochucchungnhanID);
			p[3] = new SqlParameter("@dNgaydangky", entity.dNgaydangky);
			p[4] = new SqlParameter("@bDuyet", entity.bDuyet);
            return p;
        }
        #endregion
       
    }
}