/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:10/26/2011 9:44:32 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class AdvEntity
    {
        public AdvEntity()
        {
			m_iadvid=0;
			m_stitle="";
			m_slink="";
			m_sdesc="";
			m_smedia="";
			m_itype=0;
			m_iorder=0;
			m_ipositionid=0;
			m_iwidth=0;
			m_iheight=0;
        }
		private Int32 m_iadvid;
		public Int32 iAdvID
		{
			get { return m_iadvid ; }
			set { m_iadvid = value; }
		}
		private String m_stitle;
		public String sTitle
		{
			get { return m_stitle ; }
			set { m_stitle = value; }
		}
		private String m_slink;
		public String sLink
		{
			get { return m_slink ; }
			set { m_slink = value; }
		}
		private String m_sdesc;
		public String sDesc
		{
			get { return m_sdesc ; }
			set { m_sdesc = value; }
		}
		private String m_smedia;
		public String sMedia
		{
			get { return m_smedia ; }
			set { m_smedia = value; }
		}
		private Byte m_itype;
		public Byte iType
		{
			get { return m_itype ; }
			set { m_itype = value; }
		}
		private Byte m_iorder;
		public Byte iOrder
		{
			get { return m_iorder ; }
			set { m_iorder = value; }
		}
		private Int32 m_ipositionid;
		public Int32 iPositionID
		{
			get { return m_ipositionid ; }
			set { m_ipositionid = value; }
		}
		private Int16 m_iwidth;
		public Int16 iWidth
		{
			get { return m_iwidth ; }
			set { m_iwidth = value; }
		}
		private Int16 m_iheight;
		public Int16 iHeight
		{
			get { return m_iheight ; }
			set { m_iheight = value; }
		}

        #region Comparison
        public static List<AdvEntity> Sort(List<AdvEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(AdvEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<AdvEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<AdvEntity> COMPARISON_iAdvID
		{
			get
			{
				return delegate(AdvEntity entity,AdvEntity other)
				{
					return entity.iAdvID.CompareTo(other.iAdvID);
				};
			}
		}
		public static Comparison<AdvEntity> COMPARISON_sTitle
		{
			get
			{
				return delegate(AdvEntity entity,AdvEntity other)
				{
					return entity.sTitle.CompareTo(other.sTitle);
				};
			}
		}
		public static Comparison<AdvEntity> COMPARISON_sLink
		{
			get
			{
				return delegate(AdvEntity entity,AdvEntity other)
				{
					return entity.sLink.CompareTo(other.sLink);
				};
			}
		}
		public static Comparison<AdvEntity> COMPARISON_sDesc
		{
			get
			{
				return delegate(AdvEntity entity,AdvEntity other)
				{
					return entity.sDesc.CompareTo(other.sDesc);
				};
			}
		}
		public static Comparison<AdvEntity> COMPARISON_sMedia
		{
			get
			{
				return delegate(AdvEntity entity,AdvEntity other)
				{
					return entity.sMedia.CompareTo(other.sMedia);
				};
			}
		}
		public static Comparison<AdvEntity> COMPARISON_iType
		{
			get
			{
				return delegate(AdvEntity entity,AdvEntity other)
				{
					return entity.iType.CompareTo(other.iType);
				};
			}
		}
		public static Comparison<AdvEntity> COMPARISON_iOrder
		{
			get
			{
				return delegate(AdvEntity entity,AdvEntity other)
				{
					return entity.iOrder.CompareTo(other.iOrder);
				};
			}
		}
		public static Comparison<AdvEntity> COMPARISON_iPositionID
		{
			get
			{
				return delegate(AdvEntity entity,AdvEntity other)
				{
					return entity.iPositionID.CompareTo(other.iPositionID);
				};
			}
		}
		public static Comparison<AdvEntity> COMPARISON_iWidth
		{
			get
			{
				return delegate(AdvEntity entity,AdvEntity other)
				{
					return entity.iWidth.CompareTo(other.iWidth);
				};
			}
		}
		public static Comparison<AdvEntity> COMPARISON_iHeight
		{
			get
			{
				return delegate(AdvEntity entity,AdvEntity other)
				{
					return entity.iHeight.CompareTo(other.iHeight);
				};
			}
		}
        #endregion
    }
}
