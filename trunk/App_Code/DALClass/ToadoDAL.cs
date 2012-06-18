/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:04/11/2011 4:04:03 CH
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
    public class ToadoDAL : SqlProvider<ToadoEntity>
    {
        static ToadoDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                ToadoEntity entity = new ToadoEntity();
				entity.PK_iToadoID = Int32.Parse("0"+dr["PK_iToadoID"].ToString());
				entity.Latitude = dr["Latitude"].ToString();
				entity.Longitude = dr["Longitude"].ToString();
                return entity;
            };
        }
        public static ToadoEntity GetOne(Int32 PK_iToadoID)
        {
            string cmdName = "spToado_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iToadoID", PK_iToadoID);
            ToadoEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<ToadoEntity> GetAll()
        {
            string cmdName = "spToado_Get";
            return GetList(cmdName);
        }
        
        public static int Add(ToadoEntity entity)
        {
            string cmdName = "spToado_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(ToadoEntity entity)
        {
            string cmdName = "spToado_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iToadoID)
        {
            string cmdName = "spToado_Delete";
            SqlParameter p = new SqlParameter("@PK_iToadoID", PK_iToadoID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(ToadoEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iToadoID", entity.PK_iToadoID);
			p[1] = new SqlParameter("@Latitude", entity.Latitude);
			p[2] = new SqlParameter("@Longitude", entity.Longitude);
            return p;
        }
        #endregion
       
    }
}