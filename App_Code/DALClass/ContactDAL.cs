/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/2/2011 8:50:16 PM
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
    public class ContactDAL : SqlProvider<ContactEntity>
    {
        static ContactDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                ContactEntity entity = new ContactEntity();
				entity.PK_iContactID = int.Parse("0"+dr["PK_iContactID"].ToString());
				entity.FK_iPhongBanID = int.Parse("0"+dr["FK_iPhongBanID"].ToString());
				entity.FK_iChucVuID = int.Parse("0"+dr["FK_iChucVuID"].ToString());
				entity.sHoTen = dr["sHoTen"].ToString();
				entity.sDienThoai = dr["sDienThoai"].ToString();
				entity.sEmail = dr["sEmail"].ToString();
                return entity;
            };
        }
        public static ContactEntity GetOne(int PK_iContactID)
        {
            string cmdName = "spContact_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iContactID", PK_iContactID);
            ContactEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<ContactEntity> GetAll()
        {
            string cmdName = "spContact_Get";
            return GetList(cmdName);
        }
        
        public static int Add(ContactEntity entity)
        {
            string cmdName = "spContact_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(ContactEntity entity)
        {
            string cmdName = "spContact_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(int PK_iContactID)
        {
            string cmdName = "spContact_Delete";
            SqlParameter p = new SqlParameter("@PK_iContactID", PK_iContactID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(ContactEntity entity)
        {
            SqlParameter[] p = new SqlParameter[6];
			p[0] = new SqlParameter("@PK_iContactID", entity.PK_iContactID);
			p[1] = new SqlParameter("@FK_iPhongBanID", entity.FK_iPhongBanID);
			p[2] = new SqlParameter("@FK_iChucVuID", entity.FK_iChucVuID);
			p[3] = new SqlParameter("@sHoTen", entity.sHoTen);
			p[4] = new SqlParameter("@sDienThoai", entity.sDienThoai);
			p[5] = new SqlParameter("@sEmail", entity.sEmail);
            return p;
        }
        #endregion
       
    }
}