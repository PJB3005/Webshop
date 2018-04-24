using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webshop.Business;

namespace Webshop
{
    public partial class Catalog : System.Web.UI.Page
    {
        Controller controller = new Controller();
 
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = controller.GetProduct();
            GridView1.DataBind();
            for(int i=0; i<GridView1.Rows.Count; i++)
            {
                if(controller.CheckStock(Convert.ToInt32(GridView1.Rows[i].Cells[0].Text)))
                {
                    GridView1.Rows[i].Cells[6].Text = "Not in stock";
                    GridView1.Rows[i].Cells[6].Enabled = false;
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["id"] = Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text);
            Response.Redirect("Add.aspx");
        }
    }
}