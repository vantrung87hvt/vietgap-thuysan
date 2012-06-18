using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using INVI.Business;
using INVI.Entity;

public partial class maps : MyUI
{   

    protected void Page_Load(object sender, EventArgs e)
    {
            
        GoogleMapForASPNet1.PushpinDrag += new GoogleMapForASPNet.PushpinDragHandler(OnPushpinDrag);
        if (!IsPostBack)
        {
            if (Request.QueryString["add"] != null)
            {
                LoadMap(Request.QueryString["add"].ToString());
            }
            else
            {
                LoadMap("Hà Nội");
            }
        }
    }
    private void LoadMap(string add)
    {
        GooglePoint GP = new GooglePoint();
        GP.Address = add;

        if (GP.GeocodeAddress(ConfigurationManager.AppSettings["GoogleAPIKey"].ToString()))
        {
            GP.InfoHTML = GP.Address;
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = GP;
            txtKinhDo.Text = GP.Longitude;
            txtViDo.Text = GP.Latitude;
            GoogleMapForASPNet1.GoogleMapObject.Points.Clear();
            GP.Draggable = true;
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP);
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 15;
            GoogleMapForASPNet1.GoogleMapObject.RecenterMap = true;
        }

    }   
    
    void OnPushpinDrag(string pID)
    {
        txtKinhDo.Text = GoogleMapForASPNet1.GoogleMapObject.Points[pID].Longitude.ToString();
        txtViDo.Text = GoogleMapForASPNet1.GoogleMapObject.Points[pID].Latitude.ToString();       
        
    }
    protected void btnSavePos_Click(object sender, EventArgs e)
    {
        ToadoEntity toado = new ToadoEntity();
        toado.Latitude = txtViDo.Text;
        toado.Longitude = txtKinhDo.Text;
        Session["ToaDo"] = toado;
    }    
}