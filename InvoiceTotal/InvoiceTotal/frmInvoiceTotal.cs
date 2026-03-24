namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        // TODO: declare class variables for array and list here

        string[] invoiceTotals = new string[5];
        decimal[] invoiceTotalsList = new decimal[5];
        string invoiceTotalsString = "";
        int i = 0;

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSubtotal.Text == "")
                {
                    MessageBox.Show(
                        "Subtotal is a required field.", "Entry Error");
                }
                else
                {
                    decimal subtotal = Decimal.Parse(txtSubtotal.Text);
                    if (subtotal > 0 && subtotal < 10000 && i < invoiceTotals.Length)
                    {
                        decimal discountPct = .25m;
                        decimal discountAmt = Math.Round(subtotal * discountPct, 2);
                        decimal invoiceTotal = Math.Round(subtotal - discountAmt, 2);

                        txtDiscountPct.Text = discountPct.ToString("p1");
                        txtDiscountAmt.Text = discountAmt.ToString("c");
                        txtTotal.Text = invoiceTotal.ToString("c");

                        invoiceTotals[i] = txtTotal.Text;
                        if (invoiceTotalsList is [..])
                        {
                            invoiceTotalsList[i] = invoiceTotal;
                        }
                        i++;
                    }
                    else if (i >= invoiceTotals.Length)
                    {
                        MessageBox.Show("'Order Totals - Array' count exceeded. Please exit the program.", "Entry Error");
                    }
                    else
                    {
                        MessageBox.Show(
                            "Subtotal must be greater than 0 and less than 10,000.",
                            "Entry Error");
                    }
                }
            }
            catch
            {
                MessageBox.Show(
                    "Please enter a valid number for the Subtotal field.",
                    "Entry Error");
            }
            txtSubtotal.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // TODO: add code that displays dialog boxes here
            Array.Sort(invoiceTotals);
            foreach (string invoice in invoiceTotals)
            {
                if (invoice != "")
                {
                    invoiceTotalsString += invoice + "\n";
                }
            }
            MessageBox.Show(invoiceTotalsString, "Order Totals - Array");

            invoiceTotalsString = "";
            foreach (decimal invoice in invoiceTotalsList)
            {
                invoiceTotalsString += invoice + "\n";
            }
            MessageBox.Show(invoiceTotalsString, "Order Totals - List");

            this.Close();
        }
    }
}