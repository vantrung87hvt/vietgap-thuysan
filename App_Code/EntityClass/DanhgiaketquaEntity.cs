/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/15/2011 10:28:01 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class DanhgiaketquaEntity
    {
        public DanhgiaketquaEntity()
        {
			m_pk_idanhgiaketquaid=0;
			m_fk_ichitieuid=0;
			m_fk_iphuongphapkiemtraid=0;
			m_fk_icosonuoiid=0;
			m_iketqua=0;
        }
		private Int32 m_pk_idanhgiaketquaid;
		public Int32 PK_iDanhgiaketquaID
		{
			get { return m_pk_idanhgiaketquaid ; }
			set { m_pk_idanhgiaketquaid = value; }
		}
		private Int32 m_fk_ichitieuid;
		public Int32 FK_iChitieuID
		{
			get { return m_fk_ichitieuid ; }
			set { m_fk_ichitieuid = value; }
		}
		private Int32 m_fk_iphuongphapkiemtraid;
		public Int32 FK_iPhuongphapkiemtraID
		{
			get { return m_fk_iphuongphapkiemtraid ; }
			set { m_fk_iphuongphapkiemtraid = value; }
		}
		private Int64 m_fk_icosonuoiid;
		public Int64 FK_iCosonuoiID
		{
			get { return m_fk_icosonuoiid ; }
			set { m_fk_icosonuoiid = value; }
		}
		private Int16 m_iketqua;
		public Int16 iKetqua
		{
			get { return m_iketqua ; }
			set { m_iketqua = value; }
		}

        #region Comparison
        public static List<DanhgiaketquaEntity> Sort(List<DanhgiaketquaEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(DanhgiaketquaEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<DanhgiaketquaEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<DanhgiaketquaEntity> COMPARISON_PK_iDanhgiaketquaID
		{
			get
			{
				return delegate(DanhgiaketquaEntity entity,DanhgiaketquaEntity other)
				{
					return entity.PK_iDanhgiaketquaID.CompareTo(other.PK_iDanhgiaketquaID);
				};
			}
		}
		public static Comparison<DanhgiaketquaEntity> COMPARISON_FK_iChitieuID
		{
			get
			{
				return delegate(DanhgiaketquaEntity entity,DanhgiaketquaEntity other)
				{
					return entity.FK_iChitieuID.CompareTo(other.FK_iChitieuID);
				};
			}
		}
		public static Comparison<DanhgiaketquaEntity> COMPARISON_FK_iPhuongphapkiemtraID
		{
			get
			{
				return delegate(DanhgiaketquaEntity entity,DanhgiaketquaEntity other)
				{
					return entity.FK_iPhuongphapkiemtraID.CompareTo(other.FK_iPhuongphapkiemtraID);
				};
			}
		}
		public static Comparison<DanhgiaketquaEntity> COMPARISON_FK_iCosonuoiID
		{
			get
			{
				return delegate(DanhgiaketquaEntity entity,DanhgiaketquaEntity other)
				{
					return entity.FK_iCosonuoiID.CompareTo(other.FK_iCosonuoiID);
				};
			}
		}
		public static Comparison<DanhgiaketquaEntity> COMPARISON_iKetqua
		{
			get
			{
				return delegate(DanhgiaketquaEntity entity,DanhgiaketquaEntity other)
				{
					return entity.iKetqua.CompareTo(other.iKetqua);
				};
			}
		}
        #endregion
    }
}
