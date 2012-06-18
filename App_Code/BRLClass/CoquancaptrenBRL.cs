/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:1/1/2012 9:47:33 PM
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
    public class CoquancaptrenBRL
    {
        #region Init
        private static string EX_NOT_EXIST="Không Tồn Tại Coquancaptren Này";
		private static string EX_STENCOQUAN_EMPTY="sTencoquan không được để trống";
		private static string EX_ID_INVALID="PK_iCoquancaptrenID không hợp lệ";
        #endregion
        #region Public Methods
        /// <summary>
        /// Get Coquancaptren Theo ID
        /// </summary>
        /// <param name="PK_iCoquancaptrenID">Int32:Coquancaptren ID</param>
        /// <returns>CoquancaptrenEntity</returns>        
        public static CoquancaptrenEntity GetOne(Int32 PK_iCoquancaptrenID)
        {
            
			if(PK_iCoquancaptrenID<=0)
				throw new Exception(EX_ID_INVALID);
            return CoquancaptrenDAL.GetOne(PK_iCoquancaptrenID);
        }
        /// <summary>
        /// Lấy về List các Coquancaptren
        /// </summary>
        /// <returns>List CoquancaptrenEntity:List Coquancaptren Cần lấy</returns>
        public static List<CoquancaptrenEntity> GetAll()
        {
            return CoquancaptrenDAL.GetAll();
        }
        
        /// <summary>
        /// Kiểm tra và thêm mới Coquancaptren
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Int32: ID của Coquancaptren Mới Thêm Vào</returns>
        public static Int32 Add(CoquancaptrenEntity entity)
        {
            checkLogic(entity);
            checkDuplicate(entity, false);
            checkFK(entity);
            return CoquancaptrenDAL.Add(entity);
        }
        /// <summary>
        /// Kiểm tra và chỉnh sửa Coquancaptren
        /// </summary>
        /// <param name="entity">CoquancaptrenEntity</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Edit(CoquancaptrenEntity entity)
        {
            checkExist(entity.PK_iCoquancaptrenID);
            checkLogic(entity);
            checkDuplicate(entity, true);
            checkFK(entity);
            return CoquancaptrenDAL.Edit(entity);
        }
        /// <summary>
        /// Kiểm tra và xoá Coquancaptren
        /// </summary>
        /// <param name="PK_iCoquancaptrenID">Int32 : PK_iCoquancaptrenID</param>
        /// <returns>bool:kết quả thực hiện</returns>
        public static bool Remove(Int32 PK_iCoquancaptrenID)
        {
            checkExist(PK_iCoquancaptrenID);
            return CoquancaptrenDAL.Remove(PK_iCoquancaptrenID);
        }
        #endregion
        #region Private Methods
        private static void checkExist(Int32 PK_iCoquancaptrenID)
        {
            CoquancaptrenEntity oCoquancaptren=CoquancaptrenDAL.GetOne(PK_iCoquancaptrenID);
            if(oCoquancaptren==null)
                throw new Exception(EX_NOT_EXIST);
        }
        /// <summary>
        /// Kiểm tra logic Entity
        /// </summary>
        /// <param name="entity">CoquancaptrenEntity: entity</param>
        private static void checkLogic(CoquancaptrenEntity entity)
        {   
			if (String.IsNullOrEmpty(entity.sTencoquan))
				throw new Exception(EX_STENCOQUAN_EMPTY);
        }
        /// <summary>
        /// Kiểm tra trùng lặp bản ghi
        /// </summary>
        /// <param name="entity">CoquancaptrenEntity: CoquancaptrenEntity</param>
        private static void checkDuplicate(CoquancaptrenEntity entity,bool checkPK)
        {
            /* 
            Example
            List<CoquancaptrenEntity> list = CoquancaptrenDAL.GetAll();
            if (list.Exists(
                delegate(CoquancaptrenEntity oldEntity)
                {
                    bool result =oldEntity.FIELD.Equals(entity.FIELD, StringComparison.OrdinalIgnoreCase);
                    if(checkPK)
                        result=result && oldEntity.PK_iCoquancaptrenID != entity.PK_iCoquancaptrenID;
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
        /// <param name="entity">CoquancaptrenEntity:entity</param>
        private static void checkFK(CoquancaptrenEntity entity)
        {            
        }
        #endregion
    }
}
