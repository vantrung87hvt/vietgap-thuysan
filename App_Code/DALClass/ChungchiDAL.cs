/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:6/28/2012 3:55:50 PM
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
    public class ChungchiDAL : SqlProvider<ChungchiEntity>
    {
        static ChungchiDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                ChungchiEntity entity = new ChungchiEntity();
				entity.PK_iChungchiID = Int32.Parse("0"+dr["PK_iChungchiID"].ToString());
				entity.sTenChungchi = dr["sTenChungchi"].ToString();
				entity.sMota = dr["sMota"].ToString();
                return entity;
            };
        }
        public static ChungchiEntity GetOne(int PK_iChungchiID)
        {
            string cmdName = "spChungchi_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iChungchiID", PK_iChungchiID);
            ChungchiEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<ChungchiEntity> GetAll()
        {
            string cmdName = "spChungchi_Get";
            return GetList(cmdName);
        }
        
        public static int Add(ChungchiEntity entity)
        {
            string cmdName = "spChungchi_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(ChungchiEntity entity)
        {
            string cmdName = "spChungchi_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iChungchiID)
        {
            string cmdName = "spChungchi_Delete";
            SqlParameter p = new SqlParameter("@PK_iChungchiID", PK_iChungchiID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(ChungchiEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iChungchiID", entity.PK_iChungchiID);
			p[1] = new SqlParameter("@sTenChungchi", entity.sTenChungchi);
			p[2] = new SqlParameter("@sMota", entity.sMota);
            return p;
        }
        #endregion
       
    }
}