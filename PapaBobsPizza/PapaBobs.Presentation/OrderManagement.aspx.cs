using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobs.Presentation
{
    public partial class OrderManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGridView();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView2.Rows[index];
            var value = row.Cells[1].Text.ToString();
            var orderID = Guid.Parse(value);

            Domain.OrderManager.CompleteOrder(orderID);

            refreshGridView();
        }

        private void refreshGridView()
        {
            var orders = Domain.OrderManager.GetOrders();
            GridView2.DataSource = orders;
            GridView2.DataBind();
        }
    }
}