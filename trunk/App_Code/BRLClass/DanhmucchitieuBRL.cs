/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/15/2011 9:16:55 PM
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
    public class DanhmucchitieuBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Danhmucchitieu Này";
		private static string EX_STENCHUYENMUC_EMPTY="sTenchuyenmuc không được để trống";
		private static string EX_ITHUTU_INVALID="iThutu không hợp lệ";
		private static string EX_ID_INVALID="PK_iDanhmucchitieuID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Danhmucchitieu Theo ID
        /// </summary>
        /// <param name="PK_iDanhmucchitieuID">Int32:Danhmucchitieu ID</param>
        /// <returns>DanhmucchitieuEntity</returns>        
        public static DanhmucchitieuEntity GetOne(Int32 PK_iDanhmucchitieuID)
        {
            
			if(PK_iDanhmucchitieuID<=0)
				throw new Exception(EX_ID_INVALID);
            return DanhmucchitieuDAL.GetOne(PK_iDanhmucchitieuID);
        }
        /// <summary>
        /// Lấy về List các Danhmucchitieu
        /// </summary>
        /// <returns>List DanhmucchitieuEntity:List Danhmucchitieu Cần lấy</returns>
        public static List<DanhmucchitieuEntity> GetAll()
        {
            return DanhmucchitieuDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Danhmucchitieu
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Danhmucchitieu Mới Thêm Vào</returns>
        public static Int32 Add(DanhmucchitieuEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return DanhmucchitieuDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Danhmucchitieu
        /// </summary>
        /// <param name="entity">DanhmucchitieuEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(DanhmucchitieuEntity entity)
        {
            checkExist(entity.PK_iDanhmucchitieuID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return DanhmucchitieuDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Danhmucchitieu
        /// </summary>
        /// <param name="PK_iDanhmucchitieuID">Int32 : PK_iDanhmucchitieuID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iDanhmucchitieuID)
        {
            checkExist(PK_iDanhmucchitieuID);
            return DanhmucchitieuDAL.Remove(PK_iDanhmucchitieuID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iDanhmucchitieuID)
        {
            DanhmucchitieuEntity oDanhmucchitieu=DanhmucchitieuDAL.GetOne(PK_iDanhmucchitieuID);
            if(oDanhmucchitieu==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">DanhmucchitieuEntity: entity</param>
        private static void checkLogic(DanhmucchitieuEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTenchuyenmuc))
				throw new Exception(EX_STENCHUYENMUC_EMPTY);
			if (entity.iThutu < 0)
				throw new Exception(EX_ITHUTU_INVALID);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">DanhmucchitieuEntity: DanhmucchitieuEntity</param>
        private static void checkDuplicate(DanhmucchitieuEntity entity,bool checkPK)
        {
            /* 
            Example
            List<DanhmucchitieuEntity> list = DanhmucchitieuDAL.GetAll();
            if (list.Exists(
                delegate(DanhmucchitieuEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iDanhmucchitieuID != entity.PK_iDanhmucchitieuID;
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
        /// <param name="entity">DanhmucchitieuEntity:entity</param>
        private static void checkFK(DanhmucchitieuEntity entity)
        {            
        }
        #endregion
    }
}
