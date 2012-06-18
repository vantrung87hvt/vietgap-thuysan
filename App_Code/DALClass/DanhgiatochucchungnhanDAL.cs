/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/26/2011 9:58:23 PM
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
    public class DanhgiatochucchungnhanDAL : SqlProvider<DanhgiatochucchungnhanEntity>
    {
        static DanhgiatochucchungnhanDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                DanhgiatochucchungnhanEntity entity = new DanhgiatochucchungnhanEntity();
				entity.PK_iDanhgiatochucchungnhanID = Int32.Parse("0"+dr["PK_iDanhgiatochucchungnhanID"].ToString());
				entity.sPhamvinghidinh = dr["sPhamvinghidinh"].ToString();
				entity.tGiodanhgia =String.IsNullOrEmpty(dr["tGiodanhgia"].ToString())?DateTime.Now:DateTime.Parse(dr["tGiodanhgia"].ToString());
				entity.dNgaydanhgia =String.IsNullOrEmpty(dr["dNgaydanhgia"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaydanhgia"].ToString());
				entity.sCancudanhgia = dr["sCancudanhgia"].ToString();
				entity.sNoidungdanhgia = dr["sNoidungdanhgia"].ToString();
				entity.sKetquadanhgia = dr["sKetquadanhgia"].ToString();
				entity.iKetquadanhgia = Int16.Parse("0"+dr["iKetquadanhgia"].ToString());
				entity.sKiennghi = dr["sKiennghi"].ToString();
				entity.FK_iTochucchungnhanID = Int32.Parse("0"+dr["FK_iTochucchungnhanID"].ToString());
				entity.FK_iTruongdoandanhgiaID = Int32.Parse("0"+dr["FK_iTruongdoandanhgiaID"].ToString());
                return entity;
            };
        }
        public static DanhgiatochucchungnhanEntity GetOne(Int32 PK_iDanhgiatochucchungnhanID)
        {
            string cmdName = "spDanhgiatochucchungnhan_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iDanhgiatochucchungnhanID", PK_iDanhgiatochucchungnhanID);
            DanhgiatochucchungnhanEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<DanhgiatochucchungnhanEntity> GetAll()
        {
            string cmdName = "spDanhgiatochucchungnhan_Get";
            return GetList(cmdName);
        }
        public static List<DanhgiatochucchungnhanEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			string cmdName = "spDanhgiatochucchungnhan_GetByFK_FK_iTochucchungnhanID";
			SqlParameter p = new SqlParameter("@FK_iTochucchungnhanID",FK_iTochucchungnhanID);
			List<DanhgiatochucchungnhanEntity> list = GetList(cmdName, p);
			return list;
		}public static List<DanhgiatochucchungnhanEntity> GetByFK_iTruongdoandanhgiaID(Int32 FK_iTruongdoandanhgiaID)
		{
			string cmdName = "spDanhgiatochucchungnhan_GetByFK_FK_iTruongdoandanhgiaID";
			SqlParameter p = new SqlParameter("@FK_iTruongdoandanhgiaID",FK_iTruongdoandanhgiaID);
			List<DanhgiatochucchungnhanEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(DanhgiatochucchungnhanEntity entity)
        {
            string cmdName = "spDanhgiatochucchungnhan_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(DanhgiatochucchungnhanEntity entity)
        {
            string cmdName = "spDanhgiatochucchungnhan_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iDanhgiatochucchungnhanID)
        {
            string cmdName = "spDanhgiatochucchungnhan_Delete";
            SqlParameter p = new SqlParameter("@PK_iDanhgiatochucchungnhanID", PK_iDanhgiatochucchungnhanID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(DanhgiatochucchungnhanEntity entity)
        {
            SqlParameter[] p = new SqlParameter[11];
			p[0] = new SqlParameter("@PK_iDanhgiatochucchungnhanID", entity.PK_iDanhgiatochucchungnhanID);
			p[1] = new SqlParameter("@sPhamvinghidinh", entity.sPhamvinghidinh);
			p[2] = new SqlParameter("@tGiodanhgia", entity.tGiodanhgia);
			p[3] = new SqlParameter("@dNgaydanhgia", entity.dNgaydanhgia);
			p[4] = new SqlParameter("@sCancudanhgia", entity.sCancudanhgia);
			p[5] = new SqlParameter("@sNoidungdanhgia", entity.sNoidungdanhgia);
			p[6] = new SqlParameter("@sKetquadanhgia", entity.sKetquadanhgia);
			p[7] = new SqlParameter("@iKetquadanhgia", entity.iKetquadanhgia);
			p[8] = new SqlParameter("@sKiennghi", entity.sKiennghi);
			p[9] = new SqlParameter("@FK_iTochucchungnhanID", entity.FK_iTochucchungnhanID);
			p[10] = new SqlParameter("@FK_iTruongdoandanhgiaID", entity.FK_iTruongdoandanhgiaID);
            return p;
        }
        #endregion
       
    }
}