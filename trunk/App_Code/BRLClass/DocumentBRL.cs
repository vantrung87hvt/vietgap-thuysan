/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:11/21/2011 9:47:41 PM
------------------------------------------------------*/
using INVI.Entity;
using INVI.DataAccess;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
namespace INVI.Business
{
    public class DocumentBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Document Này";
		private static string EX_STITLE_EMPTY="sTitle không được để trống";
		private static string EX_IDOWNLOADTIME_INVALID="iDownloadTime không hợp lệ";
		private static string EX_IUSERID_INVALID="iUserID không hợp lệ";
		private static string EX_SLINKFILE_EMPTY="sLinkFile không được để trống";
		private static string EX_TDATE_INVALID="tDate không hợp lệ";
		private static string EX_SAUTHOR_EMPTY="sAuthor không được để trống";
		private static string EX_SCOQUANBANHANH_EMPTY="sCoquanbanhanh không được để trống";
		private static string EX_FK_ILOAIVANBANID_INVALID="FK_iLoaivanbanID không hợp lệ";
		private static string EX_DNGAYBANHANH_INVALID="dNgaybanhanh không hợp lệ";
		private static string EX_DNGAYDANGCONGBAO_INVALID="dNgaydangcongbao không hợp lệ";
		private static string EX_DNGAYCOHIEULUC_INVALID="dNgaycohieuluc không hợp lệ";
		private static string EX_DNGAYHETHIEULUC_INVALID="dNgayhethieuluc không hợp lệ";
		private static string EX_SPHAMVI_EMPTY="sPhamvi không được để trống";
		private static string EX_SSOKYHIEU_EMPTY="sSokyhieu không được để trống";
		private static string EX_ID_INVALID="PK_iDocumentID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Document Theo ID
        /// </summary>
        /// <param name="PK_iDocumentID">Int32:Document ID</param>
        /// <returns>DocumentEntity</returns>        
        public static DocumentEntity GetOne(Int32 PK_iDocumentID)
        {
            
			if(PK_iDocumentID<=0)
				throw new Exception(EX_ID_INVALID);
            return DocumentDAL.GetOne(PK_iDocumentID);
        }
        /// <summary>
        /// Lấy về List các Document
        /// </summary>
        /// <returns>List DocumentEntity:List Document Cần lấy</returns>
        public static List<DocumentEntity> GetAll()
        {
            return DocumentDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Document
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Document Mới Thêm Vào</returns>
        public static Int32 Add(DocumentEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return DocumentDAL.Add(entity);
        }
/// <summary>
        /// Thêm mới document
        /// </summary>
        /// <param name="title"></param>
        /// <param name="linkfile"></param>
        /// <param name="minhhoa"></param>
        /// <param name="tacgia"></param>
        /// <param name="mota"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static Int32 Add(string title, string linkfile, string minhhoa, string tacgia, string mota, int userID, String sSokyhieu, String sCoquanbanhanh, DateTime dNgaybanhanh, DateTime dNgayhethieuluc, DateTime dNgaydangcongbao, String sPhamvi, int iLoaivanbanID, DateTime dNgaycohieuluc)
        {
            DocumentEntity oDoc = new DocumentEntity();
            
            oDoc.iDownloadTime = 0;
            oDoc.iUserID = userID;
            oDoc.sAuthor = tacgia;
            oDoc.sDesc = mota;
            oDoc.sImage = minhhoa;
            oDoc.sLinkFile = linkfile;
            oDoc.sTitle = title;
            oDoc.tDate = DateTime.Now;
            oDoc.dNgaybanhanh = dNgaybanhanh;
            oDoc.dNgaydangcongbao = dNgaydangcongbao;
            oDoc.dNgayhethieuluc = dNgayhethieuluc;
            oDoc.sCoquanbanhanh = sCoquanbanhanh;
            oDoc.sPhamvi = sPhamvi;
            oDoc.sCoquanbanhanh = sCoquanbanhanh;
            oDoc.sSokyhieu = sSokyhieu;
            oDoc.FK_iLoaivanbanID = iLoaivanbanID;
            oDoc.dNgaycohieuluc = dNgaycohieuluc;
            //
            checkLogic(oDoc);
            checkDuplicate(oDoc, false);
            checkFK(oDoc);
            return DocumentDAL.Add(oDoc);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa document
        /// </summary>
        /// <param name="docID"></param>
        /// <param name="title"></param>
        /// <param name="linkfile"></param>
        /// <param name="minhhoa"></param>
        /// <param name="tacgia"></param>
        /// <param name="mota"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool Edit(int docID, string title, string linkfile, string minhhoa, string tacgia, string mota, int userID, String sSokyhieu, String sCoquanbanhanh, DateTime dNgaybanhanh, DateTime dNgayhethieuluc, DateTime dNgaydangcongbao, String sPhamvi, int iLoaivanbanID, DateTime dNgaycohieuluc)
        {
            DocumentEntity oDoc = DocumentDAL.GetOne(docID);
            oDoc.iUserID = userID;
            oDoc.sAuthor = tacgia;
            oDoc.sDesc = mota;
            oDoc.sImage = minhhoa;
            oDoc.sLinkFile = linkfile;
            oDoc.sTitle = title;
            oDoc.dNgaybanhanh = dNgaybanhanh;
            oDoc.dNgaydangcongbao = dNgaydangcongbao;
            oDoc.dNgayhethieuluc = dNgayhethieuluc;
            oDoc.sCoquanbanhanh = sCoquanbanhanh;
            oDoc.sPhamvi = sPhamvi;
            oDoc.sCoquanbanhanh = sCoquanbanhanh;
            oDoc.sSokyhieu = sSokyhieu;
            oDoc.FK_iLoaivanbanID = iLoaivanbanID;
            oDoc.dNgaycohieuluc = dNgaycohieuluc;
            //
            checkExist(oDoc.PK_iDocumentID);
            checkLogic(oDoc);
            checkDuplicate(oDoc, true);
            checkFK(oDoc);
            return DocumentDAL.Edit(oDoc);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Document
        /// </summary>
        /// <param name="entity">DocumentEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(DocumentEntity entity)
        {
            checkExist(entity.PK_iDocumentID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return DocumentDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Document
        /// </summary>
        /// <param name="PK_iDocumentID">Int32 : PK_iDocumentID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iDocumentID)
        {
            checkExist(PK_iDocumentID);
            return DocumentDAL.Remove(PK_iDocumentID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iDocumentID)
        {
            DocumentEntity oDocument=DocumentDAL.GetOne(PK_iDocumentID);
            if(oDocument==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">DocumentEntity: entity</param>
        private static void checkLogic(DocumentEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTitle))
				throw new Exception(EX_STITLE_EMPTY);
			if (entity.iDownloadTime < 0)
				throw new Exception(EX_IDOWNLOADTIME_INVALID);
			if (entity.iUserID < 0)
				throw new Exception(EX_IUSERID_INVALID);
			if (String.IsNullOrEmpty(entity.sLinkFile))
				throw new Exception(EX_SLINKFILE_EMPTY);
			if (DateTime.Parse("1753-01-01")>entity.tDate)
				throw new Exception(EX_TDATE_INVALID);
			if (String.IsNullOrEmpty(entity.sAuthor))
				throw new Exception(EX_SAUTHOR_EMPTY);
			if (String.IsNullOrEmpty(entity.sCoquanbanhanh))
				throw new Exception(EX_SCOQUANBANHANH_EMPTY);
			if (entity.FK_iLoaivanbanID < 0)
				throw new Exception(EX_FK_ILOAIVANBANID_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaybanhanh)
				throw new Exception(EX_DNGAYBANHANH_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaydangcongbao)
				throw new Exception(EX_DNGAYDANGCONGBAO_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgaycohieuluc)
				throw new Exception(EX_DNGAYCOHIEULUC_INVALID);
			if (DateTime.Parse("1753-01-01")>entity.dNgayhethieuluc)
				throw new Exception(EX_DNGAYHETHIEULUC_INVALID);
			if (String.IsNullOrEmpty(entity.sPhamvi))
				throw new Exception(EX_SPHAMVI_EMPTY);
			if (String.IsNullOrEmpty(entity.sSokyhieu))
				throw new Exception(EX_SSOKYHIEU_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">DocumentEntity: DocumentEntity</param>
        private static void checkDuplicate(DocumentEntity entity,bool checkPK)
        {
            /* 
            Example
            List<DocumentEntity> list = DocumentDAL.GetAll();
            if (list.Exists(
                delegate(DocumentEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iDocumentID != entity.PK_iDocumentID;
                    return result;
                }
            ))
            {
                list.Clear();
                throw new Exception(EX_FIELD_EXISTED);
            }
            */
        }
        /// <summary>
        /// Kiểm tra tồn tại khóa ngoại
        /// </summary>
        /// <param name="entity">DocumentEntity:entity</param>
        private static void checkFK(DocumentEntity entity)
        {            
        }
        #endregion
    }
}
