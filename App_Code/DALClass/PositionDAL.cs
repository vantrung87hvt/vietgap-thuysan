/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:45:37 PM
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
    public class PositionDAL : SqlProvider<PositionEntity>
    {
        static PositionDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                PositionEntity entity = new PositionEntity();
				entity.iPositionID = Int32.Parse("0"+dr["iPositionID"].ToString());
				entity.sName = dr["sName"].ToString();
                return entity;
            };
        }
        public static PositionEntity GetOne(int iPositionID)
        {
            string cmdName = "spPosition_GetByPK";
            SqlParameter p = new SqlParameter("@iPositionID", iPositionID);
            PositionEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<PositionEntity> GetAll()
        {
            string cmdName = "spPosition_Get";
            return GetList(cmdName);
        }
        
        public static int Add(PositionEntity entity)
        {
            string cmdName = "spPosition_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(PositionEntity entity)
        {
            string cmdName = "spPosition_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 iPositionID)
        {
            string cmdName = "spPosition_Delete";
            SqlParameter p = new SqlParameter("@iPositionID", iPositionID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(PositionEntity entity)
        {
            SqlParameter[] p = new SqlParameter[2];
			p[0] = new SqlParameter("@iPositionID", entity.iPositionID);
			p[1] = new SqlParameter("@sName", entity.sName);
            return p;
        }
        #endregion
       
    }
}