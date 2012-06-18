/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/15/2011 9:17:24 PM
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
    public class ChitieuDAL : SqlProvider<ChitieuEntity>
    {
        static ChitieuDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                ChitieuEntity entity = new ChitieuEntity();
				entity.PK_iChitieuID = Int32.Parse("0"+dr["PK_iChitieuID"].ToString());
				entity.sNoidung = dr["sNoidung"].ToString();
				entity.sYeucauvietgap = dr["sYeucauvietgap"].ToString();
				entity.iThuthu = Int16.Parse("0"+dr["iThuthu"].ToString());
				entity.FK_iMucdoID = Int32.Parse("0"+dr["FK_iMucdoID"].ToString());
				entity.sGhichu = dr["sGhichu"].ToString();
				entity.FK_iDanhmucchitieuID = Int32.Parse("0"+dr["FK_iDanhmucchitieuID"].ToString());
                return entity;
            };
        }
        public static ChitieuEntity GetOne(Int32 PK_iChitieuID)
        {
            string cmdName = "spChitieu_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iChitieuID", PK_iChitieuID);
            ChitieuEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<ChitieuEntity> GetAll()
        {
            string cmdName = "spChitieu_Get";
            return GetList(cmdName);
        }
        public static Int32 Count()
        {
            string cmdName = "spChitieu_Get";
            
            return GetList(cmdName).Count;
        }
        public static List<ChitieuEntity> GetByFK_iMucdoID(Int32 FK_iMucdoID)
		{
			string cmdName = "spChitieu_GetByFK_FK_iMucdoID";
			SqlParameter p = new SqlParameter("@FK_iMucdoID",FK_iMucdoID);
			List<ChitieuEntity> list = GetList(cmdName, p);
			return list;
		}public static List<ChitieuEntity> GetByFK_iDanhmucchitieuID(Int32 FK_iDanhmucchitieuID)
		{
			string cmdName = "spChitieu_GetByFK_FK_iDanhmucchitieuID";
			SqlParameter p = new SqlParameter("@FK_iDanhmucchitieuID",FK_iDanhmucchitieuID);
			List<ChitieuEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(ChitieuEntity entity)
        {
            string cmdName = "spChitieu_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(ChitieuEntity entity)
        {
            string cmdName = "spChitieu_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iChitieuID)
        {
            string cmdName = "spChitieu_Delete";
            SqlParameter p = new SqlParameter("@PK_iChitieuID", PK_iChitieuID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(ChitieuEntity entity)
        {
            SqlParameter[] p = new SqlParameter[7];
			p[0] = new SqlParameter("@PK_iChitieuID", entity.PK_iChitieuID);
			p[1] = new SqlParameter("@sNoidung", entity.sNoidung);
			p[2] = new SqlParameter("@sYeucauvietgap", entity.sYeucauvietgap);
			p[3] = new SqlParameter("@iThuthu", entity.iThuthu);
			p[4] = new SqlParameter("@FK_iMucdoID", entity.FK_iMucdoID);
			p[5] = new SqlParameter("@sGhichu", entity.sGhichu);
			p[6] = new SqlParameter("@FK_iDanhmucchitieuID", entity.FK_iDanhmucchitieuID);
            return p;
        }
        #endregion
       
    }
}