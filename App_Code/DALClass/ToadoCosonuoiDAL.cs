/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/19/2011 10:55:36 PM
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
    public class ToadoCosonuoiDAL : SqlProvider<ToadoCosonuoiEntity>
    {
        static ToadoCosonuoiDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                ToadoCosonuoiEntity entity = new ToadoCosonuoiEntity();
				entity.PK_iToadocosonuoiID = Int64.Parse("0"+dr["PK_iToadocosonuoiID"].ToString());
				entity.FK_iCosonuoiID = Int32.Parse("0"+dr["FK_iCosonuoiID"].ToString());
				entity.sLat = dr["sLat"].ToString();
				entity.sLon = dr["sLon"].ToString();
                return entity;
            };
        }
        public static ToadoCosonuoiEntity GetOne(Int64 PK_iToadocosonuoiID)
        {
            string cmdName = "spToadoCosonuoi_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iToadocosonuoiID", PK_iToadocosonuoiID);
            ToadoCosonuoiEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<ToadoCosonuoiEntity> GetAll()
        {
            string cmdName = "spToadoCosonuoi_Get";
            return GetList(cmdName);
        }
        public static List<ToadoCosonuoiEntity> GetByFK_iCosonuoiID(Int32 FK_iCosonuoiID)
		{
			string cmdName = "spToadoCosonuoi_GetByFK_FK_iCosonuoiID";
			SqlParameter p = new SqlParameter("@FK_iCosonuoiID",FK_iCosonuoiID);
			List<ToadoCosonuoiEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(ToadoCosonuoiEntity entity)
        {
            string cmdName = "spToadoCosonuoi_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(ToadoCosonuoiEntity entity)
        {
            string cmdName = "spToadoCosonuoi_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int64 PK_iToadocosonuoiID)
        {
            string cmdName = "spToadoCosonuoi_Delete";
            SqlParameter p = new SqlParameter("@PK_iToadocosonuoiID", PK_iToadocosonuoiID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(ToadoCosonuoiEntity entity)
        {
            SqlParameter[] p = new SqlParameter[4];
			p[0] = new SqlParameter("@PK_iToadocosonuoiID", entity.PK_iToadocosonuoiID);
			p[1] = new SqlParameter("@FK_iCosonuoiID", entity.FK_iCosonuoiID);
			p[2] = new SqlParameter("@sLat", entity.sLat);
			p[3] = new SqlParameter("@sLon", entity.sLon);
            return p;
        }
        #endregion
       
    }
}