/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:45:30 PM
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
    public class AdvDAL : SqlProvider<AdvEntity>
    {
        static AdvDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                AdvEntity entity = new AdvEntity();
				entity.iAdvID = Int32.Parse("0"+dr["iAdvID"].ToString());
				entity.sTitle = dr["sTitle"].ToString();
				entity.sLink = dr["sLink"].ToString();
				entity.sDesc = dr["sDesc"].ToString();
				entity.sMedia = dr["sMedia"].ToString();
				entity.iType = Byte.Parse("0"+dr["iType"].ToString());
				entity.iOrder = Byte.Parse("0"+dr["iOrder"].ToString());
				entity.iPositionID = Int32.Parse("0"+dr["iPositionID"].ToString());
				entity.iWidth = Int16.Parse("0"+dr["iWidth"].ToString());
				entity.iHeight = Int16.Parse("0"+dr["iHeight"].ToString());
                return entity;
            };
        }
        public static AdvEntity GetOne(int iAdvID)
        {
            string cmdName = "spAdv_GetByPK";
            SqlParameter p = new SqlParameter("@iAdvID", iAdvID);
            AdvEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<AdvEntity> GetAll()
        {
            string cmdName = "spAdv_Get";
            return GetList(cmdName);
        }
        public static List<AdvEntity> GetByiPositionID(Int32 iPositionID)
		{
			string cmdName = "spAdv_GetByFK_iPositionID";
			SqlParameter p = new SqlParameter("@iPositionID",iPositionID);
			List<AdvEntity> list = GetList(cmdName, p);
			return list;
		}
        public static int Add(AdvEntity entity)
        {
            string cmdName = "spAdv_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(AdvEntity entity)
        {
            string cmdName = "spAdv_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iAdvID)
        {
            string cmdName = "spAdv_Delete";
            SqlParameter p = new SqlParameter("@iAdvID", iAdvID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(AdvEntity entity)
        {
            SqlParameter[] p = new SqlParameter[10];
			p[0] = new SqlParameter("@iAdvID", entity.iAdvID);
			p[1] = new SqlParameter("@sTitle", entity.sTitle);
			p[2] = new SqlParameter("@sLink", entity.sLink);
			p[3] = new SqlParameter("@sDesc", entity.sDesc);
			p[4] = new SqlParameter("@sMedia", entity.sMedia);
			p[5] = new SqlParameter("@iType", entity.iType);
			p[6] = new SqlParameter("@iOrder", entity.iOrder);
			p[7] = new SqlParameter("@iPositionID", entity.iPositionID);
			p[8] = new SqlParameter("@iWidth", entity.iWidth);
			p[9] = new SqlParameter("@iHeight", entity.iHeight);
            return p;
        }
        #endregion
       
    }
}