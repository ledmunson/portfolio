using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using PapaBobs.DTO;


namespace PapaBobs.Presentation
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter a name.";
                validationLabel.Visible = true;
                return;
            }

            if (addressTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter an address.";
                validationLabel.Visible = true;
                return;
            }

            if (zipTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter a zip code.";
                validationLabel.Visible = true;
                return;
            }

            if (phoneTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter a phone number";
                validationLabel.Visible = true;
                return;
            }

            try
            {
                var order = buildOrder();
                Domain.OrderManager.CreateOrder(order);
                Response.Redirect("success.aspx");
            }
            catch (Exception ex)
            {
                validationLabel.Text = ex.Message;
                validationLabel.Visible = true;
                return;
            }
            
        }

        private DTO.PaymentType determinePaymentType()
        {
            DTO.PaymentType paymentType;
            if (cashRadioButton.Checked)
            {
                paymentType = DTO.PaymentType.Cash;
            }
            else 
            {
                paymentType = DTO.PaymentType.Credit;
            }
            
            return paymentType;
        }

        private DTO.Crust determineCrust()
        {
            DTO.Crust crust;
            if (!Enum.TryParse(crustDropDownList.SelectedValue, out crust))
            {
                throw new Exception("Could not determine Pizza crust.");
            }
            return crust;
        }

        private DTO.Size determineSize()
        {
            DTO.Size size;
            if (!Enum.TryParse(sizeDropDownList.SelectedValue, out size))
            {
                throw new Exception("Could not determine Pizza size.");
            }
            return size;
        }

        protected void recalculateTotalCost(object sender, EventArgs e)
        {
            if (sizeDropDownList.SelectedValue == String.Empty) return;
            if (crustDropDownList.SelectedValue == String.Empty) return;

            var order = buildOrder();

            try
            {
                totalLabel.Text = Domain.PizzaPriceManager.CalculateCost(order).ToString("C");
            }
            catch (Exception)
            {
                // Swallow the error
            }                        
        }

        private DTO.DTOOrder buildOrder()
        {
            var order = new DTOOrder();
            order.Size = determineSize();
            order.Crust = determineCrust();
            order.Sausage = sausageCheckBox.Checked;
            order.Pepperoni = pepperoniCheckBox.Checked;
            order.Onions = onionsCheckBox.Checked;
            order.GreenPeppers = greenPeppersCheckBox.Checked;
            order.Name = nameTextBox.Text;
            order.Address = addressTextBox.Text;
            order.Zip = zipTextBox.Text;
            order.Phone = phoneTextBox.Text;
            order.PaymentType = determinePaymentType();

            return order;
        }
    }

    public enum Size
    {
        Small,
        Medium,
        Large    
    }

    public enum Crust
    {
        Regular,
        Thin,
        Thick
    }

    public enum PaymentType
    {
        Cash,
        Credit
    }
}