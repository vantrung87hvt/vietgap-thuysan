/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/15/2011 9:17:09 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class ChitieuEntity
    {
        public ChitieuEntity()
        {
			m_pk_ichitieuid=0;
			m_snoidung="";
			m_syeucauvietgap="";
			m_ithuthu=0;
			m_fk_imucdoid=0;
			m_sghichu="";
			m_fk_idanhmucchitieuid=0;
        }
		private Int32 m_pk_ichitieuid;
		public Int32 PK_iChitieuID
		{
			get { return m_pk_ichitieuid ; }
			set { m_pk_ichitieuid = value; }
		}
		private String m_snoidung;
		public String sNoidung
		{
			get { return m_snoidung ; }
			set { m_snoidung = value; }
		}
		private String m_syeucauvietgap;
		public String sYeucauvietgap
		{
			get { return m_syeucauvietgap ; }
			set { m_syeucauvietgap = value; }
		}
		private Int16 m_ithuthu;
		public Int16 iThuthu
		{
			get { return m_ithuthu ; }
			set { m_ithuthu = value; }
		}
		private Int32 m_fk_imucdoid;
		public Int32 FK_iMucdoID
		{
			get { return m_fk_imucdoid ; }
			set { m_fk_imucdoid = value; }
		}
		private String m_sghichu;
		public String sGhichu
		{
			get { return m_sghichu ; }
			set { m_sghichu = value; }
		}
		private Int32 m_fk_idanhmucchitieuid;
		public Int32 FK_iDanhmucchitieuID
		{
			get { return m_fk_idanhmucchitieuid ; }
			set { m_fk_idanhmucchitieuid = value; }
		}

        #region Comparison
        public static List<ChitieuEntity> Sort(List<ChitieuEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(ChitieuEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<ChitieuEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<ChitieuEntity> COMPARISON_PK_iChitieuID
		{
			get
			{
				return delegate(ChitieuEntity entity,ChitieuEntity other)
				{
					return entity.PK_iChitieuID.CompareTo(other.PK_iChitieuID);
				};
			}
		}
		public static Comparison<ChitieuEntity> COMPARISON_sNoidung
		{
			get
			{
				return delegate(ChitieuEntity entity,ChitieuEntity other)
				{
					return entity.sNoidung.CompareTo(other.sNoidung);
				};
			}
		}
		public static Comparison<ChitieuEntity> COMPARISON_sYeucauvietgap
		{
			get
			{
				return delegate(ChitieuEntity entity,ChitieuEntity other)
				{
					return entity.sYeucauvietgap.CompareTo(other.sYeucauvietgap);
				};
			}
		}
		public static Comparison<ChitieuEntity> COMPARISON_iThuthu
		{
			get
			{
				return delegate(ChitieuEntity entity,ChitieuEntity other)
				{
					return entity.iThuthu.CompareTo(other.iThuthu);
				};
			}
		}
		public static Comparison<ChitieuEntity> COMPARISON_FK_iMucdoID
		{
			get
			{
				return delegate(ChitieuEntity entity,ChitieuEntity other)
				{
					return entity.FK_iMucdoID.CompareTo(other.FK_iMucdoID);
				};
			}
		}
		public static Comparison<ChitieuEntity> COMPARISON_sGhichu
		{
			get
			{
				return delegate(ChitieuEntity entity,ChitieuEntity other)
				{
					return entity.sGhichu.CompareTo(other.sGhichu);
				};
			}
		}
		public static Comparison<ChitieuEntity> COMPARISON_FK_iDanhmucchitieuID
		{
			get
			{
				return delegate(ChitieuEntity entity,ChitieuEntity other)
				{
					return entity.FK_iDanhmucchitieuID.CompareTo(other.FK_iDanhmucchitieuID);
				};
			}
		}
        #endregion
    }
}
