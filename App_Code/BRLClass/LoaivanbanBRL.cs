/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:11/21/2011 4:39:34 PM
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
    public class LoaivanbanBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Loaivanban Này";
		private static string EX_STENLOAI_EMPTY="sTenloai không được để trống";
		private static string EX_ID_INVALID="PK_iLoaivanbanID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Loaivanban Theo ID
        /// </summary>
        /// <param name="PK_iLoaivanbanID">Int32:Loaivanban ID</param>
        /// <returns>LoaivanbanEntity</returns>        
        public static LoaivanbanEntity GetOne(Int32 PK_iLoaivanbanID)
        {
            
			if(PK_iLoaivanbanID<=0)
				throw new Exception(EX_ID_INVALID);
            return LoaivanbanDAL.GetOne(PK_iLoaivanbanID);
        }
        /// <summary>
        /// Lấy về List các Loaivanban
        /// </summary>
        /// <returns>List LoaivanbanEntity:List Loaivanban Cần lấy</returns>
        public static List<LoaivanbanEntity> GetAll()
        {
            return LoaivanbanDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Loaivanban
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Loaivanban Mới Thêm Vào</returns>
        public static Int32 Add(LoaivanbanEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return LoaivanbanDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Loaivanban
        /// </summary>
        /// <param name="entity">LoaivanbanEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(LoaivanbanEntity entity)
        {
            checkExist(entity.PK_iLoaivanbanID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return LoaivanbanDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Loaivanban
        /// </summary>
        /// <param name="PK_iLoaivanbanID">Int32 : PK_iLoaivanbanID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iLoaivanbanID)
        {
            checkExist(PK_iLoaivanbanID);
            return LoaivanbanDAL.Remove(PK_iLoaivanbanID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iLoaivanbanID)
        {
            LoaivanbanEntity oLoaivanban=LoaivanbanDAL.GetOne(PK_iLoaivanbanID);
            if(oLoaivanban==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">LoaivanbanEntity: entity</param>
        private static void checkLogic(LoaivanbanEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTenloai))
				throw new Exception(EX_STENLOAI_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">LoaivanbanEntity: LoaivanbanEntity</param>
        private static void checkDuplicate(LoaivanbanEntity entity,bool checkPK)
        {
            /* 
            Example
            List<LoaivanbanEntity> list = LoaivanbanDAL.GetAll();
            if (list.Exists(
                delegate(LoaivanbanEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iLoaivanbanID != entity.PK_iLoaivanbanID;
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
        /// <param name="entity">LoaivanbanEntity:entity</param>
        private static void checkFK(LoaivanbanEntity entity)
        {            
        }
        #endregion
    }
}
