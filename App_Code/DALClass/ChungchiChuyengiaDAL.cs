/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/28/2012 3:45:54 PM
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
    public class ChungchiChuyengiaDAL : SqlProvider<ChungchiChuyengiaEntity>
    {
        static ChungchiChuyengiaDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                ChungchiChuyengiaEntity entity = new ChungchiChuyengiaEntity();
				entity.PK_iChungchiChuyengiaID = Int32.Parse("0"+dr["PK_iChungchiChuyengiaID"].ToString());
				entity.FK_iChuyengiaID = Int32.Parse("0"+dr["FK_iChuyengiaID"].ToString());
				entity.FK_iChungchiID = Int32.Parse("0"+dr["FK_iChungchiID"].ToString());
                return entity;
            };
        }
        public static ChungchiChuyengiaEntity GetOne(int PK_iChungchiChuyengiaID)
        {
            string cmdName = "spChungchiChuyengia_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iChungchiChuyengiaID", PK_iChungchiChuyengiaID);
            ChungchiChuyengiaEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<ChungchiChuyengiaEntity> GetAll()
        {
            string cmdName = "spChungchiChuyengia_Get";
            return GetList(cmdName);
        }
        public static List<ChungchiChuyengiaEntity> GetByFK_iChuyengiaID(Int32 FK_iChuyengiaID)
		{
			string cmdName = "spChungchiChuyengia_GetByFK_FK_iChuyengiaID";
			SqlParameter p = new SqlParameter("@FK_iChuyengiaID",FK_iChuyengiaID);
			List<ChungchiChuyengiaEntity> list = GetList(cmdName, p);
			return list;
		}public static List<ChungchiChuyengiaEntity> GetByFK_iChungchiID(Int32 FK_iChungchiID)
		{
			string cmdName = "spChungchiChuyengia_GetByFK_FK_iChungchiID";
			SqlParameter p = new SqlParameter("@FK_iChungchiID",FK_iChungchiID);
			List<ChungchiChuyengiaEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(ChungchiChuyengiaEntity entity)
        {
            string cmdName = "spChungchiChuyengia_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(ChungchiChuyengiaEntity entity)
        {
            string cmdName = "spChungchiChuyengia_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iChungchiChuyengiaID)
        {
            string cmdName = "spChungchiChuyengia_Delete";
            SqlParameter p = new SqlParameter("@PK_iChungchiChuyengiaID", PK_iChungchiChuyengiaID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(ChungchiChuyengiaEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iChungchiChuyengiaID", entity.PK_iChungchiChuyengiaID);
			p[1] = new SqlParameter("@FK_iChuyengiaID", entity.FK_iChuyengiaID);
			p[2] = new SqlParameter("@FK_iChungchiID", entity.FK_iChungchiID);
            return p;
        }
        #endregion
       
    }
}