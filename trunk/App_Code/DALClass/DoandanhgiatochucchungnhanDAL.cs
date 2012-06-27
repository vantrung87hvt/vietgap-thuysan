/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/27/2012 8:38:46 AM
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
    public class DoandanhgiatochucchungnhanDAL : SqlProvider<DoandanhgiatochucchungnhanEntity>
    {
        static DoandanhgiatochucchungnhanDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                DoandanhgiatochucchungnhanEntity entity = new DoandanhgiatochucchungnhanEntity();
				entity.PK_iDoandanhgiatochucchungnhanID = Int32.Parse("0"+dr["PK_iDoandanhgiatochucchungnhanID"].ToString());
				entity.FK_iDanhgiatochucchungnhanID = Int32.Parse("0"+dr["FK_iDanhgiatochucchungnhanID"].ToString());
				entity.FK_iChuyengiaID = Int32.Parse("0"+dr["FK_iChuyengiaID"].ToString());
                return entity;
            };
        }
        public static DoandanhgiatochucchungnhanEntity GetOne(int PK_iDoandanhgiatochucchungnhanID)
        {
            string cmdName = "spDoandanhgiatochucchungnhan_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iDoandanhgiatochucchungnhanID", PK_iDoandanhgiatochucchungnhanID);
            DoandanhgiatochucchungnhanEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<DoandanhgiatochucchungnhanEntity> GetAll()
        {
            string cmdName = "spDoandanhgiatochucchungnhan_Get";
            return GetList(cmdName);
        }
        public static List<DoandanhgiatochucchungnhanEntity> GetByFK_iDanhgiatochucchungnhanID(Int32 FK_iDanhgiatochucchungnhanID)
		{
			string cmdName = "spDoandanhgiatochucchungnhan_GetByFK_FK_iDanhgiatochucchungnhanID";
			SqlParameter p = new SqlParameter("@FK_iDanhgiatochucchungnhanID",FK_iDanhgiatochucchungnhanID);
			List<DoandanhgiatochucchungnhanEntity> list = GetList(cmdName, p);
			return list;
		}public static List<DoandanhgiatochucchungnhanEntity> GetByFK_iChuyengiaID(Int32 FK_iChuyengiaID)
		{
			string cmdName = "spDoandanhgiatochucchungnhan_GetByFK_FK_iChuyengiaID";
			SqlParameter p = new SqlParameter("@FK_iChuyengiaID",FK_iChuyengiaID);
			List<DoandanhgiatochucchungnhanEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(DoandanhgiatochucchungnhanEntity entity)
        {
            string cmdName = "spDoandanhgiatochucchungnhan_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(DoandanhgiatochucchungnhanEntity entity)
        {
            string cmdName = "spDoandanhgiatochucchungnhan_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iDoandanhgiatochucchungnhanID)
        {
            string cmdName = "spDoandanhgiatochucchungnhan_Delete";
            SqlParameter p = new SqlParameter("@PK_iDoandanhgiatochucchungnhanID", PK_iDoandanhgiatochucchungnhanID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(DoandanhgiatochucchungnhanEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iDoandanhgiatochucchungnhanID", entity.PK_iDoandanhgiatochucchungnhanID);
			p[1] = new SqlParameter("@FK_iDanhgiatochucchungnhanID", entity.FK_iDanhgiatochucchungnhanID);
			p[2] = new SqlParameter("@FK_iChuyengiaID", entity.FK_iChuyengiaID);
            return p;
        }
        #endregion
       
    }
}