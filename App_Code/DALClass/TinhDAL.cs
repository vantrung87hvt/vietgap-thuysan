/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/13/2011 2:12:34 PM
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
    public class TinhDAL : SqlProvider<TinhEntity>
    {
        static TinhDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                TinhEntity entity = new TinhEntity();
				entity.PK_iTinhID = Int16.Parse("0"+dr["PK_iTinhID"].ToString());
				entity.sTentinh = dr["sTentinh"].ToString();
				entity.sKyhieu = dr["sKyhieu"].ToString();
				entity.ISO31662 = dr["ISO31662"].ToString();
                return entity;
            };
        }
        public static TinhEntity GetOne(Int16 PK_iTinhID)
        {
            string cmdName = "spTinh_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iTinhID", PK_iTinhID);
            TinhEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<TinhEntity> GetAll()
        {
            string cmdName = "spTinh_Get";
            return GetList(cmdName);
        }
        
        public static int Add(TinhEntity entity)
        {
            string cmdName = "spTinh_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(TinhEntity entity)
        {
            string cmdName = "spTinh_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int16 PK_iTinhID)
        {
            string cmdName = "spTinh_Delete";
            SqlParameter p = new SqlParameter("@PK_iTinhID", PK_iTinhID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(TinhEntity entity)
        {
            SqlParameter[] p = new SqlParameter[4];
			p[0] = new SqlParameter("@PK_iTinhID", entity.PK_iTinhID);
			p[1] = new SqlParameter("@sTentinh", entity.sTentinh);
			p[2] = new SqlParameter("@sKyhieu", entity.sKyhieu);
			p[3] = new SqlParameter("@ISO31662", entity.ISO31662);
            return p;
        }
        #endregion
       
    }
}