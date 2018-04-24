using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webshop.Business;

namespace Webshop
{
    public partial class Add : System.Web.UI.Page
    {
        Controller controller = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            picture.ImageUrl = @"~\Images\" + controller.GetSelectedProduct(Convert.ToInt32(Session["id"])).Picture;
            lbldescription.Text = controller.GetSelectedProduct(Convert.ToInt32(Session["id"])).Description;
            lblid.Text = controller.GetSelectedProduct(Convert.ToInt32(Session["id"])).ID.ToString();
            lblname.Text = controller.GetSelectedProduct(Convert.ToInt32(Session["id"])).Name.ToString();
            lblprice.Text = controller.GetSelectedProduct(Convert.ToInt32(Session["id"])).Price.ToString();
            lblstock.Text = controller.GetSelectedProduct(Convert.ToInt32(Session["id"])).Stock.ToString();


        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}