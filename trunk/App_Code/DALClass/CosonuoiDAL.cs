/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/19/2011 10:55:32 PM
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
    public class CosonuoiDAL : SqlProvider<CosonuoiEntity>
    {
        static CosonuoiDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                CosonuoiEntity entity = new CosonuoiEntity();
				entity.PK_iCosonuoiID = Int32.Parse("0"+dr["PK_iCosonuoiID"].ToString());
				entity.sTencoso = dr["sTencoso"].ToString();
				entity.sDiachi = dr["sDiachi"].ToString();
                return entity;
            };
        }
        public static CosonuoiEntity GetOne(Int32 PK_iCosonuoiID)
        {
            string cmdName = "spCosonuoi_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iCosonuoiID", PK_iCosonuoiID);
            CosonuoiEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<CosonuoiEntity> GetAll()
        {
            string cmdName = "spCosonuoi_Get";
            return GetList(cmdName);
        }
        
        public static int Add(CosonuoiEntity entity)
        {
            string cmdName = "spCosonuoi_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(CosonuoiEntity entity)
        {
            string cmdName = "spCosonuoi_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iCosonuoiID)
        {
            string cmdName = "spCosonuoi_Delete";
            SqlParameter p = new SqlParameter("@PK_iCosonuoiID", PK_iCosonuoiID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(CosonuoiEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iCosonuoiID", entity.PK_iCosonuoiID);
			p[1] = new SqlParameter("@sTencoso", entity.sTencoso);
			p[2] = new SqlParameter("@sDiachi", entity.sDiachi);
            return p;
        }
        #endregion
       
    }
}