/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/26/2011 11:54:13 AM
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
    public class HinhthucnuoiDAL : SqlProvider<HinhthucnuoiEntity>
    {
        static HinhthucnuoiDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                HinhthucnuoiEntity entity = new HinhthucnuoiEntity();
				entity.PK_iHinhthucnuoiID = Int32.Parse("0"+dr["PK_iHinhthucnuoiID"].ToString());
				entity.sTenhinhthuc = dr["sTenhinhthuc"].ToString();
                return entity;
            };
        }
        public static HinhthucnuoiEntity GetOne(Int32 PK_iHinhthucnuoiID)
        {
            string cmdName = "spHinhthucnuoi_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iHinhthucnuoiID", PK_iHinhthucnuoiID);
            HinhthucnuoiEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<HinhthucnuoiEntity> GetAll()
        {
            string cmdName = "spHinhthucnuoi_Get";
            return GetList(cmdName);
        }
        
        public static int Add(HinhthucnuoiEntity entity)
        {
            string cmdName = "spHinhthucnuoi_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(HinhthucnuoiEntity entity)
        {
            string cmdName = "spHinhthucnuoi_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iHinhthucnuoiID)
        {
            string cmdName = "spHinhthucnuoi_Delete";
            SqlParameter p = new SqlParameter("@PK_iHinhthucnuoiID", PK_iHinhthucnuoiID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(HinhthucnuoiEntity entity)
        {
            SqlParameter[] p = new SqlParameter[2];
			p[0] = new SqlParameter("@PK_iHinhthucnuoiID", entity.PK_iHinhthucnuoiID);
			p[1] = new SqlParameter("@sTenhinhthuc", entity.sTenhinhthuc);
            return p;
        }
        #endregion
       
    }
}