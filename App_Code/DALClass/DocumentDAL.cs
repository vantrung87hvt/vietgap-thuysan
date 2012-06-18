/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:11/21/2011 9:48:14 PM
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
    public class DocumentDAL : SqlProvider<DocumentEntity>
    {
        static DocumentDAL()
        {
            InitReader();
        }
        protected static void InitReader()
        {
            getFromReader=delegate(SqlDataReader dr)
            {
                DocumentEntity entity = new DocumentEntity();
				entity.PK_iDocumentID = Int32.Parse("0"+dr["PK_iDocumentID"].ToString());
				entity.sTitle = dr["sTitle"].ToString();
				entity.sDesc = dr["sDesc"].ToString();
				entity.sImage = dr["sImage"].ToString();
				entity.iDownloadTime = Int32.Parse("0"+dr["iDownloadTime"].ToString());
				entity.iUserID = Int32.Parse("0"+dr["iUserID"].ToString());
				entity.sLinkFile = dr["sLinkFile"].ToString();
				entity.tDate =String.IsNullOrEmpty(dr["tDate"].ToString())?DateTime.Now:DateTime.Parse(dr["tDate"].ToString());
				entity.sAuthor = dr["sAuthor"].ToString();
				entity.sCoquanbanhanh = dr["sCoquanbanhanh"].ToString();
				entity.FK_iLoaivanbanID = Int32.Parse("0"+dr["FK_iLoaivanbanID"].ToString());
				entity.dNgaybanhanh =String.IsNullOrEmpty(dr["dNgaybanhanh"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaybanhanh"].ToString());
				entity.dNgaydangcongbao =String.IsNullOrEmpty(dr["dNgaydangcongbao"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaydangcongbao"].ToString());
				entity.dNgaycohieuluc =String.IsNullOrEmpty(dr["dNgaycohieuluc"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgaycohieuluc"].ToString());
				entity.dNgayhethieuluc =String.IsNullOrEmpty(dr["dNgayhethieuluc"].ToString())?DateTime.Now:DateTime.Parse(dr["dNgayhethieuluc"].ToString());
				entity.sPhamvi = dr["sPhamvi"].ToString();
				entity.sSokyhieu = dr["sSokyhieu"].ToString();
                return entity;
            };
        }
        public static DocumentEntity GetOne(Int32 PK_iDocumentID)
        {
            string cmdName = "spDocument_GetByPK";
            SqlParameter p = new SqlParameter("@PK_iDocumentID", PK_iDocumentID);
            DocumentEntity entity = GetOne(cmdName, p);
            return entity;
        }
        public static List<DocumentEntity> GetAll()
        {
            string cmdName = "spDocument_Get";
            return GetList(cmdName);
        }
        
        public static int Add(DocumentEntity entity)
        {
            string cmdName = "spDocument_Insert";
            return Run(cmdName,true,initParams(entity));

        }
        public static bool Edit(DocumentEntity entity)
        {
            string cmdName = "spDocument_Update";
            return Run(cmdName,false,initParams(entity))>0;
        }
        public static bool Remove(Int32 PK_iDocumentID)
        {
            string cmdName = "spDocument_Delete";
            SqlParameter p = new SqlParameter("@PK_iDocumentID", PK_iDocumentID);
            return Run(cmdName,false,p)>0;
        }
        #region private
        private static SqlParameter[] initParams(DocumentEntity entity)
        {
            SqlParameter[] p = new SqlParameter[17];
			p[0] = new SqlParameter("@PK_iDocumentID", entity.PK_iDocumentID);
			p[1] = new SqlParameter("@sTitle", entity.sTitle);
			p[2] = new SqlParameter("@sDesc", entity.sDesc);
			p[3] = new SqlParameter("@sImage", entity.sImage);
			p[4] = new SqlParameter("@iDownloadTime", entity.iDownloadTime);
			p[5] = new SqlParameter("@iUserID", entity.iUserID);
			p[6] = new SqlParameter("@sLinkFile", entity.sLinkFile);
			p[7] = new SqlParameter("@tDate", entity.tDate);
			p[8] = new SqlParameter("@sAuthor", entity.sAuthor);
			p[9] = new SqlParameter("@sCoquanbanhanh", entity.sCoquanbanhanh);
			p[10] = new SqlParameter("@FK_iLoaivanbanID", entity.FK_iLoaivanbanID);
			p[11] = new SqlParameter("@dNgaybanhanh", entity.dNgaybanhanh);
			p[12] = new SqlParameter("@dNgaydangcongbao", entity.dNgaydangcongbao);
			p[13] = new SqlParameter("@dNgaycohieuluc", entity.dNgaycohieuluc);
			p[14] = new SqlParameter("@dNgayhethieuluc", entity.dNgayhethieuluc);
			p[15] = new SqlParameter("@sPhamvi", entity.sPhamvi);
			p[16] = new SqlParameter("@sSokyhieu", entity.sSokyhieu);
            return p;
        }
        #endregion
       
    }
}