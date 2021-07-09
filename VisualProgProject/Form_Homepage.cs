using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Components;
using System.Windows.Forms;
using iTextSharp.text;

using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
namespace VisualProgProject
{
    public partial class Form_Homepage : MetroFramework.Forms.MetroForm
    {
        public string localDbConnectionString;
        public ControllerClass controllerclassobject;
        public int productidToBeUpdated=0;
        public int customeridToBeUpdated=0;
        public Class_SelectedCustomer selectedcustomerobj;
        public Class_EmployeeDataDisplay empcurrent;
        public Class_CurrentBranch currentbranchobj;
        public int billid = 0;
        public Form_Homepage(Class_EmployeeDataDisplay employeedisplayobj)
        {
            localDbConnectionString = "User Id=ESHOP_OLTP;Password=eshop;Data Source=PC";
            InitializeComponent();
            controllerclassobject = new ControllerClass();
            selectedcustomerobj = new Class_SelectedCustomer();
            empcurrent = new Class_EmployeeDataDisplay(employeedisplayobj);
            currentbranchobj = new Class_CurrentBranch();
            currentbranchobj = controllerclassobject.getCurrentbranchData(employeedisplayobj.getBranchName());
            productidToBeUpdated = 0;
            customeridToBeUpdated = 0;
            /**************** Fill HomeScreen Start******************/
            this.datetimelbl.Text = DateTime.Now.ToString();
            this.currentusernamelbl.Text = employeedisplayobj.getUsername();
            this.branchnamelbl.Text = employeedisplayobj.getBranchName();
            this.currentcitylbl.Text = employeedisplayobj.getCity();
            customersTabControl.SelectedIndex = 0;
            empcurrent.setCity(employeedisplayobj.getCity());
            empcurrent.setJob(employeedisplayobj.getJob());
            
            empcurrent.setBranchName(employeedisplayobj.getBranchName());
            empcurrent.setBranchID(employeedisplayobj.getbranchid());
           
            empcurrent.setUsername(employeedisplayobj.getUsername());
            /**************** Fill HomeScreen End******************/
            /**************** Fill HomeScreen End******************/
            
            if ((empcurrent.getJob().ToString().Equals("SALESMAN")) || (empcurrent.getJob().ToString().Equals("salesman")))
            {
                MAINTAB.Controls.Remove(dashboardTab);
                MAINTAB.Controls.Remove(storeBranchesTab);
                MAINTAB.Controls.Remove(employeesTab);
                MAINTAB.Controls.Remove(etlTab);
                    MAINTAB.Controls.Remove(ReportsTab);
            }
            /**************** Fill ComboBoxes Start******************/
            
            

            controllerclassobject.getCitiesInComboBox(serviceCenterCitiesComboBox);
            serviceCenterCitiesComboBox.SelectedIndex = 0;
            
            controllerclassobject.getCategoriesInComboBox(categoryOfProductDisplayComboBox);
            categoryOfProductDisplayComboBox.SelectedIndex = 0;
            
            controllerclassobject.getCategoriesInComboBox(addCategoryOfProductComboBox);
            addCategoryOfProductComboBox.SelectedIndex = 0;
           
            controllerclassobject.getCitiesInComboBox(addCityToProductComboBox);
            addCityToProductComboBox.SelectedIndex = 0;
            
            controllerclassobject.getCitiesInComboBox(addcustomercityComboBox);
            addcustomercityComboBox.SelectedIndex = 0;
            
            controllerclassobject.getCitiesInComboBox(updateCustomerCityComboBox);
            updateCustomerCityComboBox.SelectedIndex = 0;
            /**************** Fill ComboBoxes End******************/
            /**************** Fll Gridviews Start *******************/
            controllerclassobject.getbranchesInDataGrid(branchesGrid);
            controllerclassobject.getEmployees(employeesGrid);
            controllerclassobject.getProducts(productsGrid);
            controllerclassobject.getCustomers(customerGrid);
            /**************** Fill Tables End *******************/
            /************** Tab Control Selection Start ********/
            MAINTAB.SelectedIndex = 0;
            ProductsTabControl.SelectedIndex = 0;
            customersTabControl.SelectedIndex = 0;
            /*************** Tab Control Selection End *********/
            /****************** ScrollBars To DataGridViews *******/
            branchesGrid.ScrollBars = ScrollBars.Both;
        }
        private void clockTimer_Tick(object sender, EventArgs e)
        {
            this.datetimelbl.Text = DateTime.Now.ToString();
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Restart();
        }
        private void serviceCenterCitiesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
            
        }
        private void searchServiceCenterbtn_Click(object sender, EventArgs e)
        {
            serviceCenterCitiesComboBox.SelectedIndex = 0; 
            string chosencity = "";
            chosencity = serviceCenterCitiesComboBox.SelectedItem.ToString();
            if ((string.IsNullOrEmpty(chosencity) || string.IsNullOrWhiteSpace(chosencity)))
            {
                MetroFramework.MetroMessageBox.Show(this, "ERROR", "You Did Not Choose City/Area", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                chosencity = serviceCenterCitiesComboBox.SelectedItem.ToString();
            controllerclassobject.searchbranches(chosencity,branchesGrid);
        }
        }
        private void showAllServiceCentersbtn_Click(object sender, EventArgs e)
        {
            branchesGrid.DataSource = null;
            branchesGrid.Rows.Clear();
            controllerclassobject.getbranchesInDataGrid(branchesGrid);
        }
        private void serviceCenterTile_Click(object sender, EventArgs e)
        {
            MAINTAB.SelectedIndex=1;
        }
        
        
        private void employeesTile_Click(object sender, EventArgs e)
        {
            MAINTAB.SelectedIndex = 2;
        }
        private void partsTile_Click(object sender, EventArgs e)
        {
            MAINTAB.SelectedIndex = 3;
        }
        private void customersTile_Click(object sender, EventArgs e)
        {
            MAINTAB.SelectedIndex = 4;
        }
        private void metroLabel2_Click(object sender, EventArgs e)
        {
        }
        private void Form_Homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void metroTile1_Click(object sender, EventArgs e)
        {
            MAINTAB.SelectedIndex = 3;
        }
        private void metroTile2_Click(object sender, EventArgs e)
        {
            MAINTAB.SelectedIndex = 4;
        }
        private void checkOutTile_Click(object sender, EventArgs e)
        {
            MAINTAB.SelectedIndex = 5;
        }
        private void salesHistoryTile_Click(object sender, EventArgs e)
        {
            MAINTAB.SelectedIndex = 7;
        }
        private void categoryOfProductDisplayComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }
        private void searchByCategoryBtn_Click(object sender, EventArgs e)
        {
            String chosencategory = categoryOfProductDisplayComboBox.SelectedItem.ToString();
           
            
            
                controllerclassobject.searchByCategoryAndSubCategory(chosencategory, productsGrid);
            
        }
        private void searchByPartNameOrNumberBtn_Click(object sender, EventArgs e)
        {
            int searchstring = Convert.ToInt32(searchProductsTxtBox.Text.ToString());
                    if(searchstring==0)
                    {
                        MessageBox.Show("ENTER PRODUCT ID TO SEARCH .. ERROR .. YOU ENTERED NOTHING");

                    }
                    else
                    {

                        controllerclassobject.searchPartByNameOrNumber(searchstring, productsGrid);
                    }
                
            
        }
        private void updateProductTile_Click(object sender, EventArgs e)
        {
            controllerclassobject.getCategoriesInComboBox(updateCategoryComboBox);
            controllerclassobject.getCitiesInComboBox(updatecityComboBox);
            int selectedrowindex = productsGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = productsGrid.Rows[selectedrowindex];
            productidToBeUpdated = Convert.ToInt32(selectedRow.Cells["PRODUCTID"].Value);
            string productname = Convert.ToString(selectedRow.Cells["PRODUCTNAME"].Value);
           
            double costprice = Convert.ToDouble(selectedRow.Cells["COSTPRICE"].Value);
            double retailprice = Convert.ToDouble(selectedRow.Cells["RETAILPRICE"].Value);
            int quantityinstock = Convert.ToInt32(selectedRow.Cells["STOCK"].Value);
            
            
            updateproductnameTxtBox.Text = productname;
            updatecostpricetxtbox.Text = Convert.ToString(costprice);
            updateretailpricetxtbox.Text = Convert.ToString(retailprice);
            updatequantityTxtBox.Text = Convert.ToString(quantityinstock);
            ProductsTabControl.SelectedIndex = 2;
        }
        private void removeProductTile_Click(object sender, EventArgs e)
        {
            int selectedrowindex = productsGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = productsGrid.Rows[selectedrowindex];
            int productid = Convert.ToInt32(selectedRow.Cells["PRODUCTID"].Value);
            controllerclassobject.removeProduct(productid,productsGrid);
        }
        private void addCategoryOfProductComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }
        private void addCityToProductComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MessageBox.Show(addCityToProductComboBox.SelectedItem.ToString());
            controllerclassobject.getStoreBranchesInComboBox(addCityToProductComboBox.SelectedItem.ToString(),addStoreBranchComboBox);
        }
        
        private void addProductBtn_Click(object sender, EventArgs e)
        {
            int pid = 0;
            string category = addCategoryOfProductComboBox.SelectedItem.ToString();
           int branchid = 0;
            string city = addCityToProductComboBox.SelectedItem.ToString();
            string branchname = addStoreBranchComboBox.SelectedItem.ToString();
            string productname = addProductNameToProductTxtBox.Text;
            double retailprice = Convert.ToDouble(RetailPriceTxtBox.Text);
            double costprice = Convert.ToDouble(CostPriceTextBox.Text);
            int quantityinstock = Convert.ToInt32(quantityinstockTxtBox.Text);
            
            
            int catid = 0;
            string companyname = addCompanytoproducttxtbox.Text;
            catid = controllerclassobject.getCatId(category);
            branchid = controllerclassobject.getbranchid(branchname);
           

            using (OracleConnection GETPRODUCTID = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    GETPRODUCTID.Open();
                    OracleCommand loCmd = GETPRODUCTID.CreateCommand();
                    loCmd.CommandType = CommandType.Text;
                    loCmd.CommandText = "select PRODUCTSID.nextval from dual";
                    pid = Convert.ToInt32(loCmd.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Could Not Obtain Cities Data");
                }
                finally
                {
                    GETPRODUCTID.Close();
                }
                controllerclassobject.addProduct(pid, productname, costprice, retailprice, quantityinstock, companyname, catid, branchid, productsGrid);
                controllerclassobject.getProducts(productsGrid);
            }
             }
        private void metroTile3_Click(object sender, EventArgs e)
        {
            controllerclassobject.getProducts(productsGrid);
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            ProductsTabControl.SelectedIndex = 0;
        }
        private void updateCategoryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }
        private void updatecityComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateStoreBranchComboBox.Items.Clear();
            controllerclassobject.getStoreBranchesInComboBox(updatecityComboBox.SelectedItem.ToString(), updateStoreBranchComboBox);
        }
        
        
        private void updateProductBtn_Click(object sender, EventArgs e)
        {
            string category = updateCategoryComboBox.SelectedItem.ToString();
           
            string city = updatecityComboBox.SelectedItem.ToString();
           
            string storebranch = updateStoreBranchComboBox.SelectedItem.ToString();
          
            string productname = updateproductnameTxtBox.Text;
            
            double retailprice = Convert.ToDouble(updateretailpricetxtbox.Text);
            double costprice = Convert.ToDouble(updatecostpricetxtbox.Text);
            int quantityinstock = Convert.ToInt32(updatequantityTxtBox.Text);
            int branchid = controllerclassobject.getbranchid(updateStoreBranchComboBox.SelectedItem.ToString());
            int catid = 0;
            string companyname = "";
            int pid = 0;
            pid = 
            catid = controllerclassobject.getCatId(category);
            companyname = updatecompanytxt.Text;
            controllerclassobject.updateProduct(pid,productname, costprice,retailprice, quantityinstock, companyname, catid,branchid , productsGrid);
        }
        private void metroTile4_Click(object sender, EventArgs e)
        {
            controllerclassobject.getCustomers(customerGrid);
        }
        private void metroTile6_Click(object sender, EventArgs e)
        {
            int selectedrowindex = customerGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = customerGrid.Rows[selectedrowindex];
            int customerid = Convert.ToInt32(selectedRow.Cells["customerID"].ToString());
            controllerclassobject.removeCustomer(customerid, customerGrid);
        }
        private void metroTile5_Click(object sender, EventArgs e)
        {
            int selectedrowindex = customerGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = customerGrid.Rows[selectedrowindex];
            int customerIdtoBeUpdated = Convert.ToInt32(selectedRow.Cells["customerID"].Value);
            string customername = Convert.ToString(selectedRow.Cells["customername"].Value);
            string customeremailaddress = Convert.ToString(selectedRow.Cells["email"].Value);
            long customermobilenumber = Convert.ToInt64(selectedRow.Cells["contactnumber"].Value);
            updateCustomerNameTxtBox.Text = customername;
            updateCustomerEmailAddressTextBox.Text = customeremailaddress;
            updateCustomerMobileNumberTextBox.Text = Convert.ToString(customermobilenumber);
            customersTabControl.SelectedIndex = 2;
        }
        private void metroButton3_Click(object sender, EventArgs e)
        {
            customersTabControl.SelectedIndex = 0;
        }
        private void addCustomerTabPage_Click(object sender, EventArgs e)
        {
        }
        private void addcustomercityComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            addcustomerStoreBranchComboBox.Items.Clear();
            controllerclassobject.getStoreBranchesInComboBox(addcustomercityComboBox.SelectedItem.ToString(), addcustomerStoreBranchComboBox);
        }
        private void addcustomerAreaComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }
        private void updateCustomerCityComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            controllerclassobject.getStoreBranchesInComboBox(updateCustomerCityComboBox.SelectedItem.ToString(), updateCustomerStoreBranchComboBox);
        }
        private void updateCustomerAreaComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }
        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            string customername = addcustomerNameTextBox.Text.ToString();
            string customeremailaddress = addcustomerEmailAddressTextBox.Text.ToString();
            long customermobilenumber = Convert.ToInt64(addcustomerMobileNumberTextBox.Text.ToString());
            int custid = 0;
            using (OracleConnection GETCUSTOMERID = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    GETCUSTOMERID.Open();
                    OracleCommand loCmd = GETCUSTOMERID.CreateCommand();
                    loCmd.CommandType = CommandType.Text;
                    loCmd.CommandText = "select CUSTOMERSID.nextval from dual";
                    custid = Convert.ToInt32(loCmd.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Could Not Obtain Cities Data");
                }
                finally
                {
                    GETCUSTOMERID.Close();
                }
            }
            controllerclassobject.addCustomer(custid,customername, customermobilenumber, customeremailaddress,customerGrid);
            controllerclassobject.getCustomers(customerGrid);
        }
        private void updateCustomerBtn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = customerGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = customerGrid.Rows[selectedrowindex];
            customeridToBeUpdated = Convert.ToInt32(selectedRow.Cells["CUSTOMERID"].Value);
            string customername = updateCustomerNameTxtBox.Text.ToString();
            string customeremailaddress =updateCustomerEmailAddressTextBox.Text.ToString();
            long customercontact =Convert.ToInt64(updateCustomerMobileNumberTextBox.Text.ToString());
            
            
            controllerclassobject.updateCustomer(customeridToBeUpdated, customername, customercontact, customeremailaddress, customerGrid);
            controllerclassobject.getCustomers(customerGrid);
        }
        private void selectMoreProducts_Click(object sender, EventArgs e)
        {
        }
        private void metroButton5_Click(object sender, EventArgs e)
        {
            MAINTAB.SelectedIndex = 4;
            customersTabControl.SelectedIndex = 0;
            MAINTAB.Show();
            customersTabControl.Show();
        }
        private void searchcustomerbutton_Click(object sender, EventArgs e)
        {
            if(searchcustomerbymobilenumberradiobutton.Checked)
            {
                long custmobilenumber = Convert.ToInt64(searchcustomertxtbox.Text.ToString());
                if (custmobilenumber != 0)
                { selectedcustomerobj = controllerclassobject.searchcustomerbycontactnumber(custmobilenumber); }

                if(selectedcustomerobj.getCustomerID()==0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "ERROR", "CUSTOMER NOT FOUND, Please Create Customer Record First", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    selectedcustomernamelbl.Text = selectedcustomerobj.getcustomername();
                    selectedcustomermobilenumberlbl.Text = selectedcustomerobj.getcontactnumber().ToString();
                    selectedcustomeremailidlbl.Text = selectedcustomerobj.getcustomeremail();
                    selectedcustomercustomeridlbl.Text = selectedcustomerobj.getCustomerID().ToString();
                }
            }
            if(searchcustomerbyemailaddressradiobutton.Checked)
            {
                string custemailaddress = searchcustomertxtbox.Text.ToString();
                selectedcustomerobj = controllerclassobject.searchcustomerbyemailaddress(custemailaddress);
                if (selectedcustomerobj.getCustomerID()==0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "ERROR", "CUSTOMER NOT FOUND, Please Create Customer Record First", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    selectedcustomernamelbl.Text = selectedcustomerobj.getcustomername();
                    selectedcustomermobilenumberlbl.Text = selectedcustomerobj.getcontactnumber().ToString();
                    selectedcustomeremailidlbl.Text = selectedcustomerobj.getcustomeremail();
                    selectedcustomercustomeridlbl.Text = selectedcustomerobj.getCustomerID().ToString();
                }
            }
        }
        private void metroTile9_Click(object sender, EventArgs e)
        {
            int selectedrowindex = productsGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = productsGrid.Rows[selectedrowindex];
            double retailprice = Convert.ToDouble(selectedRow.Cells["RETAILPRICE"].Value);
            
            int selectedquantity = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("ENTER QUANTITY"));
             int discount = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("ENTER DISCOUNT"));
             double charges = (double)selectedquantity * retailprice;
             double total = (double)charges - discount;
            string productname = Convert.ToString(selectedRow.Cells["productName"].Value);
            int productid = Convert.ToInt32(selectedRow.Cells["PRODUCTID"].Value);
            string companyname = Convert.ToString(selectedRow.Cells["COMPANYNAME"].Value);
           // double costprice = Convert.ToDouble(selectedRow.Cells["costprice"].Value);
           int quantityinstock = Convert.ToInt32(selectedRow.Cells["STOCK"].Value);
           int categoryid = Convert.ToInt32(selectedRow.Cells["CATEGORYID"].Value);
           currentSaleGrid.Rows.Add(productid, productname, companyname, retailprice, selectedquantity, discount, total, categoryid);
            MAINTAB.SelectedIndex = 5;
            checkoutTabControl.SelectedIndex = 1;
            MAINTAB.Show();
            checkoutTabControl.Show();
        }
        private void metroTile10_Click(object sender, EventArgs e)
        {
            MAINTAB.SelectedIndex = 3;
            ProductsTabControl.SelectedIndex = 0;
            MAINTAB.Show();
            customersTabControl.Show();
        }
        private void metroTile8_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in currentSaleGrid.SelectedRows)
            {
                if (!row.IsNewRow)
                    currentSaleGrid.Rows.Remove(row);
            }
        }
        private void metroTile7_Click(object sender, EventArgs e)
        {
            double total = 0.0;
            foreach (DataGridViewRow row in currentSaleGrid.Rows)
            {
                double currentcharge = Convert.ToDouble(row.Cells["TOTALCOLUMN"].Value);
                total += currentcharge;
            }
            int branchid = empcurrent.getbranchid();
            int customerid = selectedcustomerobj.getCustomerID();
            string username_current = empcurrent.getUsername();
            
            //GET SEQUENCE.NEXTVAL IN A C# INTEGER VARIABLE
            int billnumber = 0;
            using (OracleConnection GETBILLNUMBER = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    GETBILLNUMBER.Open();
                    OracleCommand loCmd = GETBILLNUMBER.CreateCommand();
                    loCmd.CommandType = CommandType.Text;
                    loCmd.CommandText = "select BILLSID.nextval from dual";
                    billnumber = Convert.ToInt32(loCmd.ExecuteScalar());
                   
                }
                catch (Exception ex)
                {
                    
                }
                finally
                {
                    GETBILLNUMBER.Close();
                }
                //INSERT RECORD IN BILLSOLTP
                controllerclassobject.insertBillRecord(billnumber, customerid, branchid,  username_current);
                
                int linenumber = 1;
                int productid = 0;
                string productname = "";
                int quantitypurchased = 0;
                int discount = 0;
                int categoryid = 0;
                string companyname = "";
                for (int i = 0; i < currentSaleGrid.Rows.Count - 1; i++)
                {
                    productid = Convert.ToInt32(currentSaleGrid.Rows[i].Cells[0].Value.ToString());
                    productname = Convert.ToString(currentSaleGrid.Rows[i].Cells[1].Value.ToString());
                    companyname = Convert.ToString(currentSaleGrid.Rows[i].Cells[2].Value.ToString());
                    quantitypurchased = Convert.ToInt32(currentSaleGrid.Rows[i].Cells[4].Value.ToString());
                    discount = Convert.ToInt32(currentSaleGrid.Rows[i].Cells[5].Value.ToString());
                    categoryid = Convert.ToInt32(currentSaleGrid.Rows[i].Cells[7].Value.ToString());
                    controllerclassobject.insertBillDetailsRecord(billnumber, linenumber, productid, categoryid, companyname, quantitypurchased, discount);
                    linenumber = linenumber + 1;
                }
                linenumber = 1;
                //INSERT RECORD IN BILLDETAILSOLTP
                foreach (DataGridViewRow row in currentSaleGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int producttid = Convert.ToInt32(row.Cells["PRODUCTIDCOLUMN"].Value);
                        int quantitybought = Convert.ToInt32(row.Cells["QUANTITYPURCHASEDCOLUMN"].Value);
                        double charges = Convert.ToDouble(row.Cells["TOTALCOLUMN"].Value);
                        controllerclassobject.updateProductQuantity(producttid, quantitybought, productsGrid);
                       
                    }
                }
                
                Document finalReport = new Document(PageSize.A4);
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string date = DateTime.Now.ToString("dd/MM/yyyy"); 
                DateTime dt = DateTime.Now;
               var output = new FileStream(path + "/Bills/" + selectedcustomerobj.getcontactnumber().ToString() + dt.Day.ToString() + "-" + dt.Month.ToString() + "-" + dt.Year.ToString() + Convert.ToString(billnumber) + ".pdf", FileMode.Create);
                var writer = PdfWriter.GetInstance(finalReport, output);
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20,BaseColor.RED);
               
               
                finalReport.Open();
                List BRANCHINFO = new List(List.UNORDERED);
                BRANCHINFO.SetListSymbol("");
               ListItem shop_name = new ListItem("SHOP NAME :    " + empcurrent.getBranchName());
                 
               
                
                shop_name.Alignment = Element.ALIGN_CENTER;
                
                BRANCHINFO.Add(shop_name);
               
                
                ListItem shop_telephone = new ListItem("SHOP TELEPHONE NUMBER :    " + "021-34825386");
                shop_telephone.Alignment = Element.ALIGN_CENTER;
                BRANCHINFO.Add(shop_telephone);
                ListItem shop_mobile = new ListItem("SHOP MOBILE NUMBER :    " + "0331-8302835");
                shop_mobile.Alignment = Element.ALIGN_CENTER;
                BRANCHINFO.Add(shop_mobile);
                ListItem shop_emailaddress = new ListItem("SHOP EMAIL ADDRESS :    " + "umartariq@gmail.com");
                shop_emailaddress.Alignment = Element.ALIGN_CENTER;
                BRANCHINFO.Add(shop_emailaddress);
                ListItem shop_address = new ListItem("SHOP ADDRESS :    " + "ABC STORE , XYZ BUILDING , MNOP ROAD , PQRST STREET , BLOCK # 16 , GULSHAN-E-IQBAL , KARACHI");
                shop_address.Alignment = Element.ALIGN_CENTER;
                BRANCHINFO.Add(shop_address);
                ListItem add_newline = new ListItem("                                                         ");
                add_newline.Alignment = Element.ALIGN_CENTER;
                BRANCHINFO.Add(add_newline);
                BRANCHINFO.Add(add_newline);
                BRANCHINFO.Add(add_newline);
                BRANCHINFO.Add(add_newline);
                ListItem customerinfotitle = new ListItem("CUSTOMER INFO :    ");
                customerinfotitle.Alignment = Element.ALIGN_CENTER;
                BRANCHINFO.Add(customerinfotitle);
                BRANCHINFO.Add(add_newline);
                ListItem customername = new ListItem("CUSTOMER NAME :    " + selectedcustomerobj.getcustomername());
                customername.Alignment = Element.ALIGN_LEFT;
                BRANCHINFO.Add(customername);
                BRANCHINFO.Add(add_newline);
                ListItem customeremailaddress = new ListItem("CUSTOMER EMAILADDRESS :    " + selectedcustomerobj.getcustomeremail());
                customeremailaddress.Alignment = Element.ALIGN_LEFT;
                BRANCHINFO.Add(customeremailaddress);
                BRANCHINFO.Add(add_newline);
                ListItem customermobilenumber = new ListItem("CUSTOMER MOBILENUMBER :    " + selectedcustomerobj.getcontactnumber().ToString());
                customermobilenumber.Alignment = Element.ALIGN_LEFT;
                BRANCHINFO.Add(customermobilenumber);

                ListItem billinfotitle = new ListItem();
                billinfotitle.Add("BILL DETAILS :    ");
                billinfotitle.Alignment = Element.ALIGN_CENTER;
                BRANCHINFO.Add(billinfotitle);
                BRANCHINFO.Add(add_newline);

                BRANCHINFO.Add(add_newline);
                BRANCHINFO.Add(add_newline);
                finalReport.Add(BRANCHINFO);
                int getColumnCountOfProductsBought = 0;
                getColumnCountOfProductsBought = currentSaleGrid.ColumnCount;
                PdfPTable productsboughtpdftable = new PdfPTable(getColumnCountOfProductsBought);




                for (int i = 0; i < getColumnCountOfProductsBought; i++)
                {
                    productsboughtpdftable.AddCell(this.currentSaleGrid.Columns[i].HeaderText);
                }

                   


                  
                
                for (int rows = 0; rows < currentSaleGrid.RowCount; rows++)
                {
                    
                  
                    for (int cols = 0; cols < currentSaleGrid.ColumnCount; cols++)
                    {
                        
                        productsboughtpdftable.AddCell(Convert.ToString(currentSaleGrid.Rows[rows].Cells[cols].Value));
                        
                    }
                }
               
                
                
                

                //MIDDLE SECTION OF REPORT
                finalReport.Add(productsboughtpdftable);


                //ENDING SECTION OF REPORT
                List BillDetails = new List(List.UNORDERED);
                BillDetails.SetListSymbol("");
                

               
                ListItem billid_display = new ListItem();
                billid_display.Add(new Chunk("BILL NUMBER :    " + Convert.ToString(billnumber), boldFont));
                billid_display.Alignment = Element.ALIGN_RIGHT;


                BillDetails.Add(billid_display);
                BillDetails.Add(add_newline);
                
                ListItem totalchargesdisplay = new ListItem();
                totalchargesdisplay.Add(new Chunk("TOTAL CHARGES :      " + Convert.ToString(total), boldFont));
                totalchargesdisplay.Alignment = Element.ALIGN_RIGHT;
                BillDetails.Add(totalchargesdisplay);
                BillDetails.Add(add_newline);
                string date2 = DateTime.Now.ToString();

                ListItem currentdatedisplay = new ListItem();
                currentdatedisplay.Add(new Chunk("PURCHASED DATE :  " + date2, boldFont));
                
                currentdatedisplay.Alignment = Element.ALIGN_RIGHT;
                BillDetails.Add(currentdatedisplay);
                BillDetails.Add(add_newline);
                BillDetails.Add(add_newline);
                BillDetails.Add(add_newline);


                ListItem currentusernamedisplay = new ListItem();
                currentusernamedisplay.Add(new Chunk("SALESMAN NAME :   " + empcurrent.getUsername(), boldFont));

                currentusernamedisplay.Alignment = Element.ALIGN_RIGHT;
                BillDetails.Add(currentusernamedisplay);
                BillDetails.Add(add_newline);
                BillDetails.Add(add_newline);
                BillDetails.Add(add_newline);
                ListItem salesmansignature = new ListItem();
                salesmansignature.Add(new Chunk("SALESMAN SIGNATURE : _______________________________", boldFont));

                salesmansignature.Alignment = Element.ALIGN_RIGHT;
                BillDetails.Add(salesmansignature);
                BillDetails.Add(add_newline);
                BillDetails.Add(add_newline);
                BillDetails.Add(add_newline);
                BillDetails.Add(add_newline);
                

                ListItem currentbuyersignature = new ListItem();
                currentbuyersignature.Add(new Chunk("CUSTOMER SIGNATURE : _______________________________", boldFont));

                currentbuyersignature.Alignment = Element.ALIGN_RIGHT;
                BillDetails.Add(currentbuyersignature);
                BillDetails.Add(add_newline);
                BillDetails.Add(add_newline);
                BillDetails.Add(add_newline);

                finalReport.Add(BillDetails);
                finalReport.Close();

                string pathfinalofbill = path + "/Bills/" + selectedcustomerobj.getcontactnumber().ToString() + dt.Day.ToString() + "-" + dt.Month.ToString() + "-" + dt.Year.ToString() + Convert.ToString(billnumber) + ".pdf";

                System.Diagnostics.Process.Start(@pathfinalofbill);
                
                
               
               
               
            }
                }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void metroTabPage1_Click(object sender, EventArgs e)
        {
        }
        private void metroLabel53_Click(object sender, EventArgs e)
        {
        }
        private void metroTextBox1_Click(object sender, EventArgs e)
        {
        }
        private void dashboard_Click(object sender, EventArgs e)
        {
        }
        private void Form_Homepage_Load(object sender, EventArgs e)
        {
        }
        private void openbtn_Click(object sender, EventArgs e)
        {
            filewebBrowser1.Url = new Uri("D:\\ETL\\");
            //;
            //Open browser dialog allows you to select the path
            /* using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path." })
             {
                 if (fbd.ShowDialog() == DialogResult.OK)
                 {
                     filewebBrowser1.Url = new Uri(fbd.SelectedPath);
                     pathoffiletxtbox.Text = fbd.SelectedPath;
                 }
             }
             */
            pathoffiletxtbox.Text = filewebBrowser1.Url.ToString();
        }
        private void prevfilebtn_Click(object sender, EventArgs e)
        {
                filewebBrowser1.GoBack();
        }
        private void nextfilebtn_Click(object sender, EventArgs e)
        {
                filewebBrowser1.GoForward();
        }
        private void filewebBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            //pathoffiletxtbox.Text = filewebBrowser1.Url.ToString();
        }
        private void filewebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
           // pathoffiletxtbox.Text = filewebBrowser1.Url.ToString();
        }

        private void updateCustomerCityComboBox_StyleChanged(object sender, EventArgs e)
        {

        }
    }
}