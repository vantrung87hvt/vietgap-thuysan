/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/22/2011 5:52:41 PM
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
    public class HosokemtheoTochucchungnhanDAL : SqlProvider<HosokemtheoTochucchungnhanEntity>
    {
        static HosokemtheoTochucchungnhanDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                HosokemtheoTochucchungnhanEntity entity = new HosokemtheoTochucchungnhanEntity();
				entity.PK_iHosokemtheoID = Int64.Parse("0"+dr["PK_iHosokemtheoID"].ToString());
				entity.FK_iGiaytoID = Int32.Parse("0"+dr["FK_iGiaytoID"].ToString());
				entity.FK_iDangkyChungnhanVietGapID = Int32.Parse("0"+dr["FK_iDangkyChungnhanVietGapID"].ToString());
                return entity;
            };
        }
        public static HosokemtheoTochucchungnhanEntity GetOne(Int64 PK_iHosokemtheoID)
        {
            string cmdName = "spHosokemtheoTochucchungnhan_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iHosokemtheoID", PK_iHosokemtheoID);
            HosokemtheoTochucchungnhanEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<HosokemtheoTochucchungnhanEntity> GetAll()
        {
            string cmdName = "spHosokemtheoTochucchungnhan_Get";
            return GetList(cmdName);
        }
        public static List<HosokemtheoTochucchungnhanEntity> GetByFK_iGiaytoID(Int32 FK_iGiaytoID)
		{
			string cmdName = "spHosokemtheoTochucchungnhan_GetByFK_FK_iGiaytoID";
			SqlParameter p = new SqlParameter("@FK_iGiaytoID",FK_iGiaytoID);
			List<HosokemtheoTochucchungnhanEntity> list = GetList(cmdName, p);
			return list;
		}public static List<HosokemtheoTochucchungnhanEntity> GetByFK_iDangkyChungnhanVietGapID(Int32 FK_iDangkyChungnhanVietGapID)
		{
			string cmdName = "spHosokemtheoTochucchungnhan_GetByFK_FK_iDangkyChungnhanVietGapID";
			SqlParameter p = new SqlParameter("@FK_iDangkyChungnhanVietGapID",FK_iDangkyChungnhanVietGapID);
			List<HosokemtheoTochucchungnhanEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(HosokemtheoTochucchungnhanEntity entity)
        {
            string cmdName = "spHosokemtheoTochucchungnhan_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(HosokemtheoTochucchungnhanEntity entity)
        {
            string cmdName = "spHosokemtheoTochucchungnhan_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int64 PK_iHosokemtheoID)
        {
            string cmdName = "spHosokemtheoTochucchungnhan_Delete";
            SqlParameter p = new SqlParameter("@PK_iHosokemtheoID", PK_iHosokemtheoID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(HosokemtheoTochucchungnhanEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iHosokemtheoID", entity.PK_iHosokemtheoID);
			p[1] = new SqlParameter("@FK_iGiaytoID", entity.FK_iGiaytoID);
			p[2] = new SqlParameter("@FK_iDangkyChungnhanVietGapID", entity.FK_iDangkyChungnhanVietGapID);
            return p;
        }
        #endregion
       
    }
}