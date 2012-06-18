/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:31/10/2011 7:39:58 CH
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
    public class DoituongnuoiDAL : SqlProvider<DoituongnuoiEntity>
    {
        static DoituongnuoiDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                DoituongnuoiEntity entity = new DoituongnuoiEntity();
				entity.PK_iDoituongnuoiID = Int32.Parse("0"+dr["PK_iDoituongnuoiID"].ToString());
				entity.sTendoituong = dr["sTendoituong"].ToString();
				entity.sKytu = dr["sKytu"].ToString();
                return entity;
            };
        }
        public static DoituongnuoiEntity GetOne(Int32 PK_iDoituongnuoiID)
        {
            string cmdName = "spDoituongnuoi_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iDoituongnuoiID", PK_iDoituongnuoiID);
            DoituongnuoiEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<DoituongnuoiEntity> GetAll()
        {
            string cmdName = "spDoituongnuoi_Get";
            return GetList(cmdName);
        }
        
        public static int Add(DoituongnuoiEntity entity)
        {
            string cmdName = "spDoituongnuoi_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(DoituongnuoiEntity entity)
        {
            string cmdName = "spDoituongnuoi_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iDoituongnuoiID)
        {
            string cmdName = "spDoituongnuoi_Delete";
            SqlParameter p = new SqlParameter("@PK_iDoituongnuoiID", PK_iDoituongnuoiID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(DoituongnuoiEntity entity)
        {
            SqlParameter[] p = new SqlParameter[3];
			p[0] = new SqlParameter("@PK_iDoituongnuoiID", entity.PK_iDoituongnuoiID);
			p[1] = new SqlParameter("@sTendoituong", entity.sTendoituong);
			p[2] = new SqlParameter("@sKytu", entity.sKytu);
            return p;
        }
        #endregion
       
    }
}