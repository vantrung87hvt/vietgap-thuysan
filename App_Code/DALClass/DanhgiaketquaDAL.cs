/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/15/2011 10:28:04 PM
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
    public class DanhgiaketquaDAL : SqlProvider<DanhgiaketquaEntity>
    {
        static DanhgiaketquaDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                DanhgiaketquaEntity entity = new DanhgiaketquaEntity();
				entity.PK_iDanhgiaketquaID = Int32.Parse("0"+dr["PK_iDanhgiaketquaID"].ToString());
				entity.FK_iChitieuID = Int32.Parse("0"+dr["FK_iChitieuID"].ToString());
				entity.FK_iPhuongphapkiemtraID = Int32.Parse("0"+dr["FK_iPhuongphapkiemtraID"].ToString());
				entity.FK_iCosonuoiID = Int64.Parse("0"+dr["FK_iCosonuoiID"].ToString());
				entity.iKetqua = Int16.Parse("0"+dr["iKetqua"].ToString());
                return entity;
            };
        }
        public static DanhgiaketquaEntity GetOne(Int32 PK_iDanhgiaketquaID)
        {
            string cmdName = "spDanhgiaketqua_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iDanhgiaketquaID", PK_iDanhgiaketquaID);
            DanhgiaketquaEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static DanhgiaketquaEntity GetOneByCosonuoitrongAndChitieu(Int32 FK_iCosonuoitrongID, Int32 iChitieuID)
        {
            string cmdName = "sp_tblDanhgiaketqua_GetOneByCosoAndChitieu";
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@FK_iCosonuoitrongID", FK_iCosonuoitrongID);
            p[1] = new SqlParameter("@FK_iChitieuID", iChitieuID);
            DanhgiaketquaEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<DanhgiaketquaEntity> GetAll()
        {
            string cmdName = "spDanhgiaketqua_Get";
            return GetList(cmdName);
        }
        public static Int32 CountTrue(Int32 FK_iCosonuoitrongID)
        {
            string cmdName = "sp_tblDanhgiaketqua_CountTrue";
            SqlParameter p = new SqlParameter("@FK_iCosonuoitrongID", FK_iCosonuoitrongID);
            return GetList(cmdName, p).Count;
        }
        public static List<DanhgiaketquaEntity> GetByFK_iChitieuID(Int32 FK_iChitieuID)
		{
			string cmdName = "spDanhgiaketqua_GetByFK_FK_iChitieuID";
			SqlParameter p = new SqlParameter("@FK_iChitieuID",FK_iChitieuID);
			List<DanhgiaketquaEntity> list = GetList(cmdName, p);
			return list;
		}public static List<DanhgiaketquaEntity> GetByFK_iPhuongphapkiemtraID(Int32 FK_iPhuongphapkiemtraID)
		{
			string cmdName = "spDanhgiaketqua_GetByFK_FK_iPhuongphapkiemtraID";
			SqlParameter p = new SqlParameter("@FK_iPhuongphapkiemtraID",FK_iPhuongphapkiemtraID);
			List<DanhgiaketquaEntity> list = GetList(cmdName, p);
			return list;
		}public static List<DanhgiaketquaEntity> GetByFK_iCosonuoiID(Int64 FK_iCosonuoiID)
		{
			string cmdName = "spDanhgiaketqua_GetByFK_FK_iCosonuoiID";
			SqlParameter p = new SqlParameter("@FK_iCosonuoiID",FK_iCosonuoiID);
			List<DanhgiaketquaEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(DanhgiaketquaEntity entity)
        {
            string cmdName = "spDanhgiaketqua_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(DanhgiaketquaEntity entity)
        {
            string cmdName = "spDanhgiaketqua_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iDanhgiaketquaID)
        {
            string cmdName = "spDanhgiaketqua_Delete";
            SqlParameter p = new SqlParameter("@PK_iDanhgiaketquaID", PK_iDanhgiaketquaID);
            return Run(cmdName,false,p)>0;
        }
        public static bool RemoveByCosonuoitrong(Int32 FK_iCosonuoitrongID)
        {
            string cmdName = "sp_tblDanhgiaketqua_DellByCosonuoitrong";
            SqlParameter p = new SqlParameter("@FK_iCosonuoitrongID", FK_iCosonuoitrongID);
            return Run(cmdName, false, p) > 0;
        }
        public static bool avaiable(Int32 FK_iCosonuoitrongID)
        {
            string cmdName = "sp_tblDanhgiaketqua_CheckAvaiableByFK_Csnt";
            SqlParameter p = new SqlParameter("@FK_iCosonuoitrongID", FK_iCosonuoitrongID);
            List<DanhgiaketquaEntity> list = GetList(cmdName, p);
            if (list.Count > 0)
                return true;
            else
                return false;
        }
        #region private
        private static SqlParameter[] initParams(DanhgiaketquaEntity entity)
        {
            SqlParameter[] p = new SqlParameter[5];
			p[0] = new SqlParameter("@PK_iDanhgiaketquaID", entity.PK_iDanhgiaketquaID);
			p[1] = new SqlParameter("@FK_iChitieuID", entity.FK_iChitieuID);
			p[2] = new SqlParameter("@FK_iPhuongphapkiemtraID", entity.FK_iPhuongphapkiemtraID);
			p[3] = new SqlParameter("@FK_iCosonuoiID", entity.FK_iCosonuoiID);
			p[4] = new SqlParameter("@iKetqua", entity.iKetqua);
            return p;
        }
        #endregion
       
    }
}