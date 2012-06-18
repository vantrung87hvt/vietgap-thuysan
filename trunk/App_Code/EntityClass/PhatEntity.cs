/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/27/2011 8:55:00 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class PhatEntity
    {
        public PhatEntity()
        {
			m_pk_iphatdinhchiid=0;
			m_slydo="";
			m_imucdo=0;
			m_fk_icosonuoiid=0;
			m_dngaythuchien=DateTime.Now;
        }
		private Int32 m_pk_iphatdinhchiid;
		public Int32 PK_iPhatDinhchiID
		{
			get { return m_pk_iphatdinhchiid ; }
			set { m_pk_iphatdinhchiid = value; }
		}
		private String m_slydo;
		public String sLydo
		{
			get { return m_slydo ; }
			set { m_slydo = value; }
		}
		private Int16 m_imucdo;
		public Int16 iMucdo
		{
			get { return m_imucdo ; }
			set { m_imucdo = value; }
		}
		private Int64 m_fk_icosonuoiid;
		public Int64 FK_iCosonuoiID
		{
			get { return m_fk_icosonuoiid ; }
			set { m_fk_icosonuoiid = value; }
		}
		private DateTime m_dngaythuchien;
		public DateTime dNgaythuchien
		{
			get { return m_dngaythuchien ; }
			set { m_dngaythuchien = value; }
		}

        #region Comparison
        public static List<PhatEntity> Sort(List<PhatEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(PhatEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<PhatEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<PhatEntity> COMPARISON_PK_iPhatDinhchiID
		{
			get
			{
				return delegate(PhatEntity entity,PhatEntity other)
				{
					return entity.PK_iPhatDinhchiID.CompareTo(other.PK_iPhatDinhchiID);
				};
			}
		}
		public static Comparison<PhatEntity> COMPARISON_sLydo
		{
			get
			{
				return delegate(PhatEntity entity,PhatEntity other)
				{
					return entity.sLydo.CompareTo(other.sLydo);
				};
			}
		}
		public static Comparison<PhatEntity> COMPARISON_iMucdo
		{
			get
			{
				return delegate(PhatEntity entity,PhatEntity other)
				{
					return entity.iMucdo.CompareTo(other.iMucdo);
				};
			}
		}
		public static Comparison<PhatEntity> COMPARISON_FK_iCosonuoiID
		{
			get
			{
				return delegate(PhatEntity entity,PhatEntity other)
				{
					return entity.FK_iCosonuoiID.CompareTo(other.FK_iCosonuoiID);
				};
			}
		}
		public static Comparison<PhatEntity> COMPARISON_dNgaythuchien
		{
			get
			{
				return delegate(PhatEntity entity,PhatEntity other)
				{
					return entity.dNgaythuchien.CompareTo(other.dNgaythuchien);
				};
			}
		}
        #endregion
    }
}
