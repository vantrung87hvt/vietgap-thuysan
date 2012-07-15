/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:7/15/2012 8:51:39 AM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class VideoClipEntity
    {
        public VideoClipEntity()
        {
			m_pk_ivideoid=0;
			m_stentep="";
			m_stieude="";
			m_isolanxem=0;
			m_idungluong=0;
			m_iwidth=0;
			m_iheight=0;
			m_fk_icategoryid=0;
			m_bvideoclip=null;
            m_smota = "";
        }
		private Int32 m_pk_ivideoid;
		public Int32 PK_iVideoID
		{
			get { return m_pk_ivideoid ; }
			set { m_pk_ivideoid = value; }
		}
		private String m_stentep;
		public String sTentep
		{
			get { return m_stentep ; }
			set { m_stentep = value; }
		}
		private String m_stieude;
		public String sTieude
		{
			get { return m_stieude ; }
			set { m_stieude = value; }
		}
		private Int32 m_isolanxem;
		public Int32 iSolanxem
		{
			get { return m_isolanxem ; }
			set { m_isolanxem = value; }
		}
		private Int64 m_idungluong;
		public Int64 iDungluong
		{
			get { return m_idungluong ; }
			set { m_idungluong = value; }
		}
		private Int32 m_iwidth;
		public Int32 iWidth
		{
			get { return m_iwidth ; }
			set { m_iwidth = value; }
		}
		private Int32 m_iheight;
		public Int32 iHeight
		{
			get { return m_iheight ; }
			set { m_iheight = value; }
		}
		private Int32 m_fk_icategoryid;
		public Int32 FK_iCategoryID
		{
			get { return m_fk_icategoryid ; }
			set { m_fk_icategoryid = value; }
		}
		private Byte[] m_bvideoclip;
		public Byte[] bVideoClip
		{
			get { return m_bvideoclip ; }
			set { m_bvideoclip = value; }
		}
        private String m_smota;
        public String sMota
        {
            get { return m_smota; }
            set { m_smota = value; }
        }
        #region Comparison
        public static List<VideoClipEntity> Sort(List<VideoClipEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb="COMPARISON_"+SortExpression;
            PropertyInfo propInfo= typeof(VideoClipEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null,null) as Comparison<VideoClipEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }
        
		public static Comparison<VideoClipEntity> COMPARISON_PK_iVideoID
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.PK_iVideoID.CompareTo(other.PK_iVideoID);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_sTentep
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.sTentep.CompareTo(other.sTentep);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_sTieude
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.sTieude.CompareTo(other.sTieude);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_iSolanxem
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.iSolanxem.CompareTo(other.iSolanxem);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_iDungluong
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.iDungluong.CompareTo(other.iDungluong);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_iWidth
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.iWidth.CompareTo(other.iWidth);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_iHeight
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.iHeight.CompareTo(other.iHeight);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_FK_iCategoryID
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.FK_iCategoryID.CompareTo(other.FK_iCategoryID);
				};
			}
		}
		public static Comparison<VideoClipEntity> COMPARISON_bVideoClip
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
                    if (entity.bVideoClip.Equals(other.bVideoClip) == true)
                        return 1;
                    else
                        return 0;
				};
			}
		}
        public static Comparison<VideoClipEntity> COMPARISON_sMota
		{
			get
			{
				return delegate(VideoClipEntity entity,VideoClipEntity other)
				{
					return entity.sMota.CompareTo(other.sMota);
				};
			}
		}
        #endregion
    }
}