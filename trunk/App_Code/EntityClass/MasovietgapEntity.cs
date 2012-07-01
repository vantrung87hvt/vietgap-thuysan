/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:12/23/2011 8:18:07 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class MasovietgapEntity
    {
        public MasovietgapEntity()
        {
			m_pk_imasovietgapid=0;
			m_smaso="";
			m_fk_itochucchungnhanid=0;
			m_fk_icosonuoitrongid=0;
			m_dngaycap=DateTime.Now;
			m_dngayhethan=DateTime.Now;
			m_ithoihan=0;
			m_itrangthai=0;
			m_isanluongdukienmoi=0;
			m_fdientichmorong=0;
        }
		private Int64 m_pk_imasovietgapid;
		public Int64 PK_iMasoVietGapID
		{
			get { return m_pk_imasovietgapid ; }
			set { m_pk_imasovietgapid = value; }
		}
		private String m_smaso;
		public String sMaso
		{
			get { return m_smaso ; }
			set { m_smaso = value; }
		}
		private Int32 m_fk_itochucchungnhanid;
		public Int32 FK_iTochucchungnhanID
		{
			get { return m_fk_itochucchungnhanid ; }
			set { m_fk_itochucchungnhanid = value; }
		}
		private Int64 m_fk_icosonuoitrongid;
		public Int64 FK_iCosonuoitrongID
		{
			get { return m_fk_icosonuoitrongid ; }
			set { m_fk_icosonuoitrongid = value; }
		}
		private DateTime m_dngaycap;
		public DateTime dNgaycap
		{
			get { return m_dngaycap ; }
			set { m_dngaycap = value; }
		}
		private DateTime m_dngayhethan;
		public DateTime dNgayhethan
		{
			get { return m_dngayhethan ; }
			set { m_dngayhethan = value; }
		}
		private Int16 m_ithoihan;
		public Int16 iThoihan
		{
			get { return m_ithoihan ; }
			set { m_ithoihan = value; }
		}
		private Int16 m_itrangthai;
		public Int16 iTrangthai
		{
			get { return m_itrangthai ; }
			set { m_itrangthai = value; }
		}
		private Int64 m_isanluongdukienmoi;
		public Int64 iSanluongdukienmoi
		{
			get { return m_isanluongdukienmoi ; }
			set { m_isanluongdukienmoi = value; }
		}
		private float m_fdientichmorong;
		public float fDientichmorong
		{
			get { return m_fdientichmorong ; }
			set { m_fdientichmorong = value; }
		}

        #region Comparison
        public static List<MasovietgapEntity> Sort(List<MasovietgapEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(MasovietgapEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<MasovietgapEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<MasovietgapEntity> COMPARISON_PK_iMasoVietGapID
		{
			get
			{
				return delegate(MasovietgapEntity entity,MasovietgapEntity other)
				{
					return entity.PK_iMasoVietGapID.CompareTo(other.PK_iMasoVietGapID);
				};
			}
		}
		public static Comparison<MasovietgapEntity> COMPARISON_sMaso
		{
			get
			{
				return delegate(MasovietgapEntity entity,MasovietgapEntity other)
				{
					return entity.sMaso.CompareTo(other.sMaso);
				};
			}
		}
		public static Comparison<MasovietgapEntity> COMPARISON_FK_iTochucchungnhanID
		{
			get
			{
				return delegate(MasovietgapEntity entity,MasovietgapEntity other)
				{
					return entity.FK_iTochucchungnhanID.CompareTo(other.FK_iTochucchungnhanID);
				};
			}
		}
		public static Comparison<MasovietgapEntity> COMPARISON_FK_iCosonuoitrongID
		{
			get
			{
				return delegate(MasovietgapEntity entity,MasovietgapEntity other)
				{
					return entity.FK_iCosonuoitrongID.CompareTo(other.FK_iCosonuoitrongID);
				};
			}
		}
		public static Comparison<MasovietgapEntity> COMPARISON_dNgaycap
		{
			get
			{
				return delegate(MasovietgapEntity entity,MasovietgapEntity other)
				{
					return entity.dNgaycap.CompareTo(other.dNgaycap);
				};
			}
		}
		public static Comparison<MasovietgapEntity> COMPARISON_dNgayhethan
		{
			get
			{
				return delegate(MasovietgapEntity entity,MasovietgapEntity other)
				{
					return entity.dNgayhethan.CompareTo(other.dNgayhethan);
				};
			}
		}
		public static Comparison<MasovietgapEntity> COMPARISON_iThoihan
		{
			get
			{
				return delegate(MasovietgapEntity entity,MasovietgapEntity other)
				{
					return entity.iThoihan.CompareTo(other.iThoihan);
				};
			}
		}
		public static Comparison<MasovietgapEntity> COMPARISON_iTrangthai
		{
			get
			{
				return delegate(MasovietgapEntity entity,MasovietgapEntity other)
				{
					return entity.iTrangthai.CompareTo(other.iTrangthai);
				};
			}
		}
		public static Comparison<MasovietgapEntity> COMPARISON_iSanluongdukienmoi
		{
			get
			{
				return delegate(MasovietgapEntity entity,MasovietgapEntity other)
				{
					return entity.iSanluongdukienmoi.CompareTo(other.iSanluongdukienmoi);
				};
			}
		}
		public static Comparison<MasovietgapEntity> COMPARISON_fDientichmorong
		{
			get
			{
				return delegate(MasovietgapEntity entity,MasovietgapEntity other)
				{
					return entity.fDientichmorong.CompareTo(other.fDientichmorong);
				};
			}
		}
        #endregion
    }
}
