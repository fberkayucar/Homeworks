using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using EntityLayer;
using BusinessLogicLayer;

namespace ShoppingListWebApp.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<SLEntity> list = BLLSLEntity.BllListSL();
            RptVSL.DataSource = list;
            RptVSL.DataBind();
        }
    }
}