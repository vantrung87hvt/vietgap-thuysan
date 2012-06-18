/*------------------------------------------------------
                INVIGEN beta v1.0
Author: xtrung.net@gmail.com
Write On: 04/27/2008
Create On:5/18/2012 3:43:31 PM
------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace INVI.Entity
{
    public class TochucchungnhanEntity
    {
        public TochucchungnhanEntity()
        {
            m_pk_itochucchungnhanid = 0;
            m_stochucchungnhan = "";
            m_skytuviettat = "";
            m_sdiachi = "";
            m_fk_iquanhuyenid = 0;
            m_ssodienthoai = "";
            m_imglogo = null;
            m_sfax = "";
            m_semail = "";
            m_ssodangkykinhdoanh = "";
            m_scoquancap = "";
            m_dngaycapdangkykinhdoanh = DateTime.Now;
            m_snoicapdangkykinhdoanh = "";
            m_itrangthai = 0;
            m_bduyet = false;
            m_fk_icoquancaptrenid = 0;
            m_smaso = "";
        }
        private Int32 m_pk_itochucchungnhanid;
        public Int32 PK_iTochucchungnhanID
        {
            get { return m_pk_itochucchungnhanid; }
            set { m_pk_itochucchungnhanid = value; }
        }
        private String m_stochucchungnhan;
        public String sTochucchungnhan
        {
            get { return m_stochucchungnhan; }
            set { m_stochucchungnhan = value; }
        }
        private String m_skytuviettat;
        public String sKytuviettat
        {
            get { return m_skytuviettat; }
            set { m_skytuviettat = value; }
        }
        private String m_sdiachi;
        public String sDiachi
        {
            get { return m_sdiachi; }
            set { m_sdiachi = value; }
        }
        private Int64 m_fk_iquanhuyenid;
        public Int64 FK_iQuanHuyenID
        {
            get { return m_fk_iquanhuyenid; }
            set { m_fk_iquanhuyenid = value; }
        }
        private String m_ssodienthoai;
        public String sSodienthoai
        {
            get { return m_ssodienthoai; }
            set { m_ssodienthoai = value; }
        }

        private Byte[] m_imglogo;
        public Byte[] imgLogo
        {
            get { return m_imglogo; }
            set { m_imglogo = value; }
        }
        private String m_sfax;
        public String sFax
        {
            get { return m_sfax; }
            set { m_sfax = value; }
        }
        private String m_semail;
        public String sEmail
        {
            get { return m_semail; }
            set { m_semail = value; }
        }
        private String m_ssodangkykinhdoanh;
        public String sSodangkykinhdoanh
        {
            get { return m_ssodangkykinhdoanh; }
            set { m_ssodangkykinhdoanh = value; }
        }
        private String m_scoquancap;
        public String sCoquancap
        {
            get { return m_scoquancap; }
            set { m_scoquancap = value; }
        }
        private DateTime m_dngaycapdangkykinhdoanh;
        public DateTime dNgaycapdangkykinhdoanh
        {
            get { return m_dngaycapdangkykinhdoanh; }
            set { m_dngaycapdangkykinhdoanh = value; }
        }
        private String m_snoicapdangkykinhdoanh;
        public String sNoicapdangkykinhdoanh
        {
            get { return m_snoicapdangkykinhdoanh; }
            set { m_snoicapdangkykinhdoanh = value; }
        }
        private Int16 m_itrangthai;
        public Int16 iTrangthai
        {
            get { return m_itrangthai; }
            set { m_itrangthai = value; }
        }
        private Boolean m_bduyet;
        public Boolean bDuyet
        {
            get { return m_bduyet; }
            set { m_bduyet = value; }
        }
        private Int32 m_fk_icoquancaptrenid;
        public Int32 FK_iCoquancaptrenID
        {
            get { return m_fk_icoquancaptrenid; }
            set { m_fk_icoquancaptrenid = value; }
        }
        private String m_smaso;
        public String sMaso
        {
            get { return m_smaso; }
            set { m_smaso = value; }
        }

        #region Comparison
        public static List<TochucchungnhanEntity> Sort(List<TochucchungnhanEntity> list, String SortExpression, String SortDirection)
        {
            string strComparisonAttrb = "COMPARISON_" + SortExpression;
            PropertyInfo propInfo = typeof(TochucchungnhanEntity).GetProperty(strComparisonAttrb);
            if (propInfo != null)
            {
                list.Sort(propInfo.GetGetMethod().Invoke(null, null) as Comparison<TochucchungnhanEntity>);
                if (SortDirection == "DESC")
                    list.Reverse();
            }
            return list;
        }

        public static Comparison<TochucchungnhanEntity> COMPARISON_PK_iTochucchungnhanID
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.PK_iTochucchungnhanID.CompareTo(other.PK_iTochucchungnhanID);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_sTochucchungnhan
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.sTochucchungnhan.CompareTo(other.sTochucchungnhan);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_sKytuviettat
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.sKytuviettat.CompareTo(other.sKytuviettat);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_sDiachi
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.sDiachi.CompareTo(other.sDiachi);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_FK_iQuanHuyenID
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.FK_iQuanHuyenID.CompareTo(other.FK_iQuanHuyenID);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_sSodienthoai
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.sSodienthoai.CompareTo(other.sSodienthoai);
                };
            }
        }

        public static Comparison<TochucchungnhanEntity> COMPARISON_imgLogo
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    if (entity.imgLogo.Equals(other.imgLogo) == true)
                        return 1;
                    else
                        return 0;

                };
            }

        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_sFax
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.sFax.CompareTo(other.sFax);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_sEmail
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.sEmail.CompareTo(other.sEmail);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_sSodangkykinhdoanh
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.sSodangkykinhdoanh.CompareTo(other.sSodangkykinhdoanh);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_sCoquancap
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.sCoquancap.CompareTo(other.sCoquancap);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_dNgaycapdangkykinhdoanh
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.dNgaycapdangkykinhdoanh.CompareTo(other.dNgaycapdangkykinhdoanh);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_sNoicapdangkykinhdoanh
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.sNoicapdangkykinhdoanh.CompareTo(other.sNoicapdangkykinhdoanh);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_iTrangthai
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.iTrangthai.CompareTo(other.iTrangthai);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_bDuyet
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.bDuyet.CompareTo(other.bDuyet);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_FK_iCoquancaptrenID
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.FK_iCoquancaptrenID.CompareTo(other.FK_iCoquancaptrenID);
                };
            }
        }
        public static Comparison<TochucchungnhanEntity> COMPARISON_sMaso
        {
            get
            {
                return delegate(TochucchungnhanEntity entity, TochucchungnhanEntity other)
                {
                    return entity.sMaso.CompareTo(other.sMaso);
                };
            }
        }
        #endregion
    }
}
