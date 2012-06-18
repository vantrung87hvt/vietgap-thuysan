/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/17/2011 9:34:36 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class BaocaokhacphucloiEntity
    {
        public BaocaokhacphucloiEntity()
        {
			m_pk_ibaocaokhacphucloiid=0;
			m_fk_icosonuoiid=0;
			m_stailieukiemtheo="";
			m_dngaykiemtra=DateTime.Now;
			m_sdoankiemtra="";
        }
		private Int64 m_pk_ibaocaokhacphucloiid;
		public Int64 PK_iBaocaokhacphucloiID
		{
			get { return m_pk_ibaocaokhacphucloiid ; }
			set { m_pk_ibaocaokhacphucloiid = value; }
		}
		private Int64 m_fk_icosonuoiid;
		public Int64 FK_iCosonuoiID
		{
			get { return m_fk_icosonuoiid ; }
			set { m_fk_icosonuoiid = value; }
		}
		private String m_stailieukiemtheo;
		public String sTailieukiemtheo
		{
			get { return m_stailieukiemtheo ; }
			set { m_stailieukiemtheo = value; }
		}
		private DateTime m_dngaykiemtra;
		public DateTime dNgaykiemtra
		{
			get { return m_dngaykiemtra ; }
			set { m_dngaykiemtra = value; }
		}
		private String m_sdoankiemtra;
		public String sDoankiemtra
		{
			get { return m_sdoankiemtra ; }
			set { m_sdoankiemtra = value; }
		}

        #region Comparison
        public static List<BaocaokhacphucloiEntity> Sort(List<BaocaokhacphucloiEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(BaocaokhacphucloiEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<BaocaokhacphucloiEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<BaocaokhacphucloiEntity> COMPARISON_PK_iBaocaokhacphucloiID
		{
			get
			{
				return delegate(BaocaokhacphucloiEntity entity,BaocaokhacphucloiEntity other)
				{
					return entity.PK_iBaocaokhacphucloiID.CompareTo(other.PK_iBaocaokhacphucloiID);
				};
			}
		}
		public static Comparison<BaocaokhacphucloiEntity> COMPARISON_FK_iCosonuoiID
		{
			get
			{
				return delegate(BaocaokhacphucloiEntity entity,BaocaokhacphucloiEntity other)
				{
					return entity.FK_iCosonuoiID.CompareTo(other.FK_iCosonuoiID);
				};
			}
		}
		public static Comparison<BaocaokhacphucloiEntity> COMPARISON_sTailieukiemtheo
		{
			get
			{
				return delegate(BaocaokhacphucloiEntity entity,BaocaokhacphucloiEntity other)
				{
					return entity.sTailieukiemtheo.CompareTo(other.sTailieukiemtheo);
				};
			}
		}
		public static Comparison<BaocaokhacphucloiEntity> COMPARISON_dNgaykiemtra
		{
			get
			{
				return delegate(BaocaokhacphucloiEntity entity,BaocaokhacphucloiEntity other)
				{
					return entity.dNgaykiemtra.CompareTo(other.dNgaykiemtra);
				};
			}
		}
		public static Comparison<BaocaokhacphucloiEntity> COMPARISON_sDoankiemtra
		{
			get
			{
				return delegate(BaocaokhacphucloiEntity entity,BaocaokhacphucloiEntity other)
				{
					return entity.sDoankiemtra.CompareTo(other.sDoankiemtra);
				};
			}
		}
        #endregion
    }
}
