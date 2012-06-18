/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:01/01/2012 4:22:12 CH
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
    public class DanhgiavienDAL : SqlProvider<DanhgiavienEntity>
    {
        static DanhgiavienDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                DanhgiavienEntity entity = new DanhgiavienEntity();
				entity.PK_iDanhgiavienID = Int32.Parse("0"+dr["PK_iDanhgiavienID"].ToString());
				entity.sHoten = dr["sHoten"].ToString();
				entity.FK_iTochucchungnhanID = Int32.Parse("0"+dr["FK_iTochucchungnhanID"].ToString());
				entity.sTrinhdo = dr["sTrinhdo"].ToString();
				entity.iNamkinhnghiem = Int16.Parse("0"+dr["iNamkinhnghiem"].ToString());
				entity.bTCVN190112003 =String.IsNullOrEmpty(dr["bTCVN190112003"].ToString())?false:Boolean.Parse(dr["bTCVN190112003"].ToString());
				entity.bISO190112002 =String.IsNullOrEmpty(dr["bISO190112002"].ToString())?false:Boolean.Parse(dr["bISO190112002"].ToString());
				entity.bVietGapCer =String.IsNullOrEmpty(dr["bVietGapCer"].ToString())?false:Boolean.Parse(dr["bVietGapCer"].ToString());
				entity.sMaso = dr["sMaso"].ToString();
				entity.bDuyet =String.IsNullOrEmpty(dr["bDuyet"].ToString())?false:Boolean.Parse(dr["bDuyet"].ToString());
				entity.iTrangthai = Int16.Parse("0"+dr["iTrangthai"].ToString());
                return entity;
            };
        }
        public static DanhgiavienEntity GetOne(Int32 PK_iDanhgiavienID)
        {
            string cmdName = "spDanhgiavien_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iDanhgiavienID", PK_iDanhgiavienID);
            DanhgiavienEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<DanhgiavienEntity> GetAll()
        {
            string cmdName = "spDanhgiavien_Get";
            return GetList(cmdName);
        }
        public static List<DanhgiavienEntity> GetByFK_iTochucchungnhanID(Int32 FK_iTochucchungnhanID)
		{
			string cmdName = "spDanhgiavien_GetByFK_FK_iTochucchungnhanID";
			SqlParameter p = new SqlParameter("@FK_iTochucchungnhanID",FK_iTochucchungnhanID);
			List<DanhgiavienEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(DanhgiavienEntity entity)
        {
            string cmdName = "spDanhgiavien_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(DanhgiavienEntity entity)
        {
            string cmdName = "spDanhgiavien_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iDanhgiavienID)
        {
            string cmdName = "spDanhgiavien_Delete";
            SqlParameter p = new SqlParameter("@PK_iDanhgiavienID", PK_iDanhgiavienID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(DanhgiavienEntity entity)
        {
            SqlParameter[] p = new SqlParameter[11];
			p[0] = new SqlParameter("@PK_iDanhgiavienID", entity.PK_iDanhgiavienID);
			p[1] = new SqlParameter("@sHoten", entity.sHoten);
			p[2] = new SqlParameter("@FK_iTochucchungnhanID", entity.FK_iTochucchungnhanID);
			p[3] = new SqlParameter("@sTrinhdo", entity.sTrinhdo);
			p[4] = new SqlParameter("@iNamkinhnghiem", entity.iNamkinhnghiem);
			p[5] = new SqlParameter("@bTCVN190112003", entity.bTCVN190112003);
			p[6] = new SqlParameter("@bISO190112002", entity.bISO190112002);
			p[7] = new SqlParameter("@bVietGapCer", entity.bVietGapCer);
			p[8] = new SqlParameter("@sMaso", entity.sMaso);
			p[9] = new SqlParameter("@bDuyet", entity.bDuyet);
			p[10] = new SqlParameter("@iTrangthai", entity.iTrangthai);
            return p;
        }
        #endregion
       
    }
}