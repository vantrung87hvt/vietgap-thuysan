/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/27/2011 8:55:03 PM
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
    public class PhatDAL : SqlProvider<PhatEntity>
    {
        static PhatDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                PhatEntity entity = new PhatEntity();
				entity.PK_iPhatDinhchiID = Int32.Parse("0"+dr["PK_iPhatDinhchiID"].ToString());
				entity.sLydo = dr["sLydo"].ToString();
				entity.iMucdo = Int16.Parse("0"+dr["iMucdo"].ToString());
				entity.FK_iCosonuoiID = Int64.Parse("0"+dr["FK_iCosonuoiID"].ToString());
				entity.dNgaythuchien =String.IsNullOrEmpty(dr["dNgaythuchien"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaythuchien"].ToString());
                return entity;
            };
        }
        public static PhatEntity GetOne(Int32 PK_iPhatDinhchiID)
        {
            string cmdName = "spPhat_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iPhatDinhchiID", PK_iPhatDinhchiID);
            PhatEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<PhatEntity> GetAll()
        {
            string cmdName = "spPhat_Get";
            return GetList(cmdName);
        }
        public static List<PhatEntity> GetByFK_iCosonuoiID(Int64 FK_iCosonuoiID)
		{
			string cmdName = "spPhat_GetByFK_FK_iCosonuoiID";
			SqlParameter p = new SqlParameter("@FK_iCosonuoiID",FK_iCosonuoiID);
			List<PhatEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(PhatEntity entity)
        {
            string cmdName = "spPhat_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(PhatEntity entity)
        {
            string cmdName = "spPhat_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iPhatDinhchiID)
        {
            string cmdName = "spPhat_Delete";
            SqlParameter p = new SqlParameter("@PK_iPhatDinhchiID", PK_iPhatDinhchiID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(PhatEntity entity)
        {
            SqlParameter[] p = new SqlParameter[5];
			p[0] = new SqlParameter("@PK_iPhatDinhchiID", entity.PK_iPhatDinhchiID);
			p[1] = new SqlParameter("@sLydo", entity.sLydo);
			p[2] = new SqlParameter("@iMucdo", entity.iMucdo);
			p[3] = new SqlParameter("@FK_iCosonuoiID", entity.FK_iCosonuoiID);
			p[4] = new SqlParameter("@dNgaythuchien", entity.dNgaythuchien);
            return p;
        }
        #endregion
       
    }
}