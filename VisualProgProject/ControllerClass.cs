using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Diagnostics;
namespace VisualProgProject
{
    public class ControllerClass
    {
        public string localDbConnectionString;
        public ControllerClass()
        {
            localDbConnectionString = "User Id=ESHOP_OLTP;Password=eshop;Data Source=PC";
        }
        public Class_EmployeeDataDisplay loginverify(string username, string password)
        {
            string pas = "";
            int branchid = 0;
            string city = "";
            string branchname = "";
            string job = null;
            double sal = 0.0;
            string hiredate = null;
            string user_name = "";
            Class_EmployeeDataDisplay employeedisplayobject = new Class_EmployeeDataDisplay();
            using (OracleConnection connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleCommand checkusernamepasswordindb = new OracleCommand();
                    checkusernamepasswordindb.CommandText = "select USERNAME,PASSWORD from EMPLOYEESOLTP where USERNAME=:Username AND PASSWORD=:Password";
                    checkusernamepasswordindb.Connection = connection;
                    OracleParameter usernamesuppliedparameter = new OracleParameter();
                    usernamesuppliedparameter.ParameterName = ":Username";
                    usernamesuppliedparameter.Value = username;
                    checkusernamepasswordindb.Parameters.Add(usernamesuppliedparameter);
                    OracleParameter passwordsuppliedparameter = new OracleParameter();
                    passwordsuppliedparameter.ParameterName = ":Password";
                    passwordsuppliedparameter.Value = password;
                    checkusernamepasswordindb.Parameters.Add(passwordsuppliedparameter);
                    OracleDataReader sdr_checkusernamepassword = checkusernamepasswordindb.ExecuteReader();
                    if (sdr_checkusernamepassword.Read())
                    {
                        user_name = sdr_checkusernamepassword["USERNAME"].ToString();
                        pas = sdr_checkusernamepassword["PASSWORD"].ToString();
                        employeedisplayobject.setUsername(user_name);
                    }
                    sdr_checkusernamepassword.Close();
                }
                catch (Exception e)
                {
                    
                }
                finally
                {
                    connection.Close();
                }
                using (OracleConnection emp_displayconnection = new OracleConnection(localDbConnectionString))
                {
                    try
                    {
                        emp_displayconnection.Open();
                        OracleCommand getemployeedatafromdb = new OracleCommand();
                        getemployeedatafromdb.CommandText = "SELECT E.USERNAME,E.JOB,E.SALARY,E.HIREDATE,B.BRANCHID,B.BRANCHNAME,B.CITY FROM BRANCHOLTP B , EMPLOYEESOLTP E WHERE E.BRANCHID=B.BRANCHID AND E.USERNAME=:Username and E.PASSWORD=:Password";
                        getemployeedatafromdb.Connection = emp_displayconnection;
                        OracleParameter usernamefromdbparameter = new OracleParameter();
                        usernamefromdbparameter.ParameterName = ":Username";
                        usernamefromdbparameter.Value = user_name;
                        getemployeedatafromdb.Parameters.Add(usernamefromdbparameter);
                        OracleParameter passwordfrmdbparameter = new OracleParameter();
                        passwordfrmdbparameter.ParameterName = ":Password";
                        passwordfrmdbparameter.Value = pas;
                        getemployeedatafromdb.Parameters.Add(passwordfrmdbparameter);
                        OracleDataReader sdr_getemployeedatafromdb = getemployeedatafromdb.ExecuteReader();
                        if (sdr_getemployeedatafromdb.Read())
                        {
                            user_name = sdr_getemployeedatafromdb["USERNAME"].ToString();
                            job = sdr_getemployeedatafromdb["JOB"].ToString();
                            sal = Convert.ToDouble(sdr_getemployeedatafromdb["SALARY"].ToString());
                            hiredate = sdr_getemployeedatafromdb["HIREDATE"].ToString();
                            branchname = sdr_getemployeedatafromdb["BRANCHNAME"].ToString();
                            city = sdr_getemployeedatafromdb["CITY"].ToString();
                            branchid = Convert.ToInt32(sdr_getemployeedatafromdb["BRANCHID"].ToString());
                        }
                        employeedisplayobject.setUsername(user_name);
                        employeedisplayobject.setJob(job);
                        employeedisplayobject.setSalary(sal);
                        employeedisplayobject.setHiredate(hiredate);
                        employeedisplayobject.setBranchName(branchname);
                        employeedisplayobject.setCity(city);
                        employeedisplayobject.setBranchID(branchid);
                        sdr_getemployeedatafromdb.Close();
                    }
                    catch (Exception e)
                    {
                        
                    }
                    finally
                    {
                        emp_displayconnection.Close();
                    }
                }
                return employeedisplayobject;
            }
        }
        public void getbranchesInDataGrid(MetroFramework.Controls.MetroGrid branchesGrid)
        {
            using (OracleConnection sctable_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    sctable_connection.Open();
                    OracleDataAdapter sda = new OracleDataAdapter("SELECT BRANCHID,BRANCHNAME,CITY from BRANCHOLTP ORDER BY BRANCHID", sctable_connection);
                    DataTable dt = new DataTable();
                    branchesGrid.DataSource = null;
                    branchesGrid.Rows.Clear();
                    sda.Fill(dt);
                    branchesGrid.DataSource = dt;
                }
                catch (Exception e)
                {
                   
                }
                finally
                {
                    sctable_connection.Close();
                }
            }
        }
        public void getCitiesInComboBox(MetroFramework.Controls.MetroComboBox combobox)
        {
            using (OracleConnection getcitiesincombobox_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    getcitiesincombobox_connection.Open();
                    OracleCommand cityComboboxDisplay = new OracleCommand();
                    cityComboboxDisplay.CommandText = "select DISTINCT CITY from brancholtp";
                    cityComboboxDisplay.Connection = getcitiesincombobox_connection;
                    OracleDataReader sdr_citycomboboxdisplay = cityComboboxDisplay.ExecuteReader();
                    while (sdr_citycomboboxdisplay.Read())
                    {
                        combobox.Items.Add(sdr_citycomboboxdisplay["CITY"].ToString());
                    }
                }
                catch (Exception e)
                {
                    
                }
                finally
                {
                    getcitiesincombobox_connection.Close();
                }
            }
        }
        public string getCompanyName(int BranchID)
        {
            string companyname = "";
            using (OracleConnection getCompanyName = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    getCompanyName.Open();
                    OracleCommand cityComboboxDisplay = new OracleCommand();
                    cityComboboxDisplay.CommandText = "select C.companyName from PRODUCTSOLTP P WHERE P.BRANCHID=" + BranchID + "";
                    cityComboboxDisplay.Connection = getCompanyName;
                    OracleDataReader sdr_citycomboboxdisplay = cityComboboxDisplay.ExecuteReader();
                    while (sdr_citycomboboxdisplay.Read())
                    {
                        companyname = sdr_citycomboboxdisplay["companyName"].ToString();
                    }
                }
                catch (Exception e)
                {
                    
                }
                finally
                {
                    getCompanyName.Close();
                }
            }
            return companyname;
        }
        public void searchbranches(String chosencity, MetroFramework.Controls.MetroGrid grid)
        {
            using (OracleConnection getservicecentersingrid_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    getservicecentersingrid_connection.Open();
                    OracleCommand serviceCenterDisplay = new OracleCommand();
                    serviceCenterDisplay.Connection = getservicecentersingrid_connection;
                    OracleDataAdapter sda_scDisplay = new OracleDataAdapter("SELECT BRANCHID,BRANCHNAME,CITY FROM  brancholtp where city='" + chosencity + "'", getservicecentersingrid_connection);
                    DataTable dt = new DataTable();
                    grid.DataSource = null;
                    grid.Rows.Clear();
                    sda_scDisplay.Fill(dt);
                    grid.DataSource = dt;
                }
                catch (Exception e)
                {
                    
                }
                finally
                {
                    getservicecentersingrid_connection.Close();
                }
            }
        }
        public void getEmployees(MetroFramework.Controls.MetroGrid grid)
        {
            using (OracleConnection employeegrid_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    employeegrid_connection.Open();
                    OracleDataAdapter sda = new OracleDataAdapter("SELECT E.username,E.job,E.salary,E.hiredate,B.BRANCHNAME FROM EMPLOYEESOLTP E , BRANCHOLTP B WHERE E.BRANCHID=B.BRANCHID", employeegrid_connection);
                    DataTable dt = new DataTable();
                    grid.DataSource = null;
                    grid.Rows.Clear();
                    sda.Fill(dt);
                    grid.DataSource = dt;
                }
                catch (Exception e)
                {
                    
                }
                finally
                {
                    employeegrid_connection.Close();
                }
            }
        }
        public int getbranchid(string branchname)
        {
            int branchid = 0;
            using (OracleConnection getCompanyName = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    getCompanyName.Open();
                    OracleCommand cityComboboxDisplay = new OracleCommand();
                    cityComboboxDisplay.CommandText = "select BRANCHID FROM BRANCHOLTP WHERE BRANCHNAME='" + branchname + "'";
                    cityComboboxDisplay.Connection = getCompanyName;
                    OracleDataReader sdr_citycomboboxdisplay = cityComboboxDisplay.ExecuteReader();
                    while (sdr_citycomboboxdisplay.Read())
                    {
                        branchid = Convert.ToInt32(sdr_citycomboboxdisplay["BRANCHID"].ToString());
                    }
                }
                catch (Exception e)
                {
                    
                }
                finally
                {
                    getCompanyName.Close();
                }
            }
            return branchid;
        }
        public void getProducts(MetroFramework.Controls.MetroGrid grid)
        {
            using (OracleConnection productsgrid_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    productsgrid_connection.Open();
                    string query = "SELECT P.productID,P.productName,P.retailprice,P.costprice,P.stock,C.companyName,CAT.categoryID,B.branchName,CAT.CATEGORYNAME FROM PRODUCTSOLTP p ,COMPANYOLTP c, CATEGORIESOLTP cat, brancholtp b WHERE P.companyName = C.companyName AND P.CATEGORYID = CAT.CATEGORYID AND P.branchid = b.branchid ORDER BY P.PRODUCTID";
                    OracleDataAdapter sda = new OracleDataAdapter(query, productsgrid_connection);
                    DataTable dt = new DataTable();
                    grid.DataSource = null;
                    grid.Rows.Clear();
                    sda.Fill(dt);
                    grid.DataSource = dt;
                }
                catch (Exception e)
                {
                    
                }
                finally
                {
                    productsgrid_connection.Close();
                }
            }
        }
        public void getCategoriesInComboBox(MetroFramework.Controls.MetroComboBox combobox)
        {
            using (OracleConnection getcategoriescombobox_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    getcategoriescombobox_connection.Open();
                    OracleCommand categoriesComboboxDisplay = new OracleCommand();
                    categoriesComboboxDisplay.CommandText = "select categoryName from categoriesoltp order by categoryID";
                    categoriesComboboxDisplay.Connection = getcategoriescombobox_connection;
                    OracleDataReader sdr_citycomboboxdisplay = categoriesComboboxDisplay.ExecuteReader();
                    while (sdr_citycomboboxdisplay.Read())
                    {
                        combobox.Items.Add(sdr_citycomboboxdisplay["categoryName"].ToString());
                    }
                }
                catch (Exception e)
                {
                   
                }
                finally
                {
                    getcategoriescombobox_connection.Close();
                }
            }
        }
      
        public void searchByCategoryAndSubCategory(String category, MetroFramework.Controls.MetroGrid grid)
        {
            int catid = 0;
            using (OracleConnection getcategoryid_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    getcategoryid_connection.Open();
                    OracleCommand categoriesComboboxDisplay = new OracleCommand();
                    categoriesComboboxDisplay.CommandText = "select categoryID from categoriesoltp WHERE categoryName ='" + category + "'";
                    categoriesComboboxDisplay.Connection = getcategoryid_connection;
                    OracleDataReader sdr_categorydisplay = categoriesComboboxDisplay.ExecuteReader();
                    while (sdr_categorydisplay.Read())
                    {
                        catid = Convert.ToInt32(sdr_categorydisplay["categoryID"].ToString());
                    }
                }
                catch (Exception e)
                {
                   
                }
                finally
                {
                    getcategoryid_connection.Close();
                }
            }
            
            using (OracleConnection productsgrid_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    productsgrid_connection.Open();
                    string query = "SELECT P.productID,P.productName,P.retailprice,P.costprice,P.stock,C.companyName,B.branchName,CAT.CATEGORYNAME FROM PRODUCTSOLTP p ,COMPANYOLTP c, CATEGORIESOLTP cat, brancholtp b WHERE P.companyName = C.companyName AND P.CATEGORYID = CAT.CATEGORYID AND P.branchid = b.branchid AND P.CATEGORYID ='"+catid+"' ORDER BY P.PRODUCTID";

                    OracleDataAdapter sda = new OracleDataAdapter(query, productsgrid_connection);
                    DataTable dt = new DataTable();
                    grid.DataSource = null;
                    grid.Rows.Clear();
                    sda.Fill(dt);
                    grid.DataSource = dt;
                }
                catch (Exception e)
                {
                    
                }
                finally
                {
                    productsgrid_connection.Close();
                }
            }
        }
        public void searchPartByNameOrNumber(int searchedstring, MetroFramework.Controls.MetroGrid grid)
        {
            using (OracleConnection productsgrid_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    productsgrid_connection.Open();
                    OracleDataAdapter sda = new OracleDataAdapter("SELECT P.PRODUCTID,P.PRODUCTNAME,P.COSTPRICE,P.RETAILPRICE,P.STOCK,P.COMPANYNAME,P.CATEGORYID,P.BRANCHID,B.BRANCHNAME,CAT.CATEGORYNAME,CAT.CATEGORYID FROM PRODUCTSOLTP P, CATEGORIESOLTP CAT,BRANCHOLTP B WHERE P.CATEGORYID = CAT.CATEGORYID AND P.BRANCHID=B.BRANCHID AND P.PRODUCTID="+Convert.ToInt32(searchedstring)+" ORDER BY P.PRODUCTID", productsgrid_connection);
                    DataTable dt = new DataTable();
                    grid.DataSource = null;
                    grid.Rows.Clear();
                    sda.Fill(dt);
                    grid.DataSource = dt;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace);
                }
                finally
                {
                    productsgrid_connection.Close();
                }
            }
        }
        public void removeProduct(int pid, MetroFramework.Controls.MetroGrid grid)
        {
            using (OracleConnection removeproductgrid_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    removeproductgrid_connection.Open();
                    OracleCommand cmdDeleteProduct = new OracleCommand();
                    cmdDeleteProduct.CommandText = "DELETE FROM PRODUCTSOLTP WHERE PRODUCTID=" + pid + "";
                    cmdDeleteProduct.Connection = removeproductgrid_connection;
                    cmdDeleteProduct.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted");
                    string query = "SELECT P.productID,P.productName,P.retailprice,P.costprice,P.stock,C.companyName,CAT.categoryID,B.branchName,CAT.CATEGORYNAME FROM PRODUCTSOLTP p ,COMPANYOLTP c, CATEGORIESOLTP cat, brancholtp b WHERE P.companyName = C.companyName AND P.CATEGORYID = CAT.CATEGORYID AND P.branchid = b.branchid ORDER BY P.PRODUCTID";

                    OracleDataAdapter sda = new OracleDataAdapter(query, removeproductgrid_connection);
                    DataTable dt = new DataTable();
                    grid.DataSource = null;
                    grid.Rows.Clear();
                    sda.Fill(dt);
                    grid.DataSource = dt;
                }
                catch (Exception e)
                {
                   MessageBox.Show("Could Not Delete Product" + e.Message);
                }
                finally
                {
                    removeproductgrid_connection.Close();
                }
            }
        }
        public void getStoreBranchesInComboBox(String chosencity, MetroFramework.Controls.MetroComboBox combobox)
        {
            using (OracleConnection getStoreBranchesInComboBox_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    getStoreBranchesInComboBox_connection.Open();
                    OracleCommand storeBranchesDisplay = new OracleCommand();
                    storeBranchesDisplay.CommandText = "Select branchName from brancholtp where CITY='" + chosencity + "'";
                    storeBranchesDisplay.Connection = getStoreBranchesInComboBox_connection;
                    OracleDataReader sdr_storeBranchesDisplay = storeBranchesDisplay.ExecuteReader();
                    while (sdr_storeBranchesDisplay.Read())
                    {
                        combobox.Items.Add(sdr_storeBranchesDisplay["branchNAME"].ToString());
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could Not Obtain Store Branch Data" + e.Message);
                }
                finally
                {
                    getStoreBranchesInComboBox_connection.Close();
                }
            }
        }
        public int getCatId(string category)
        {
            int catid = 0;
            using (OracleConnection getcatid_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    getcatid_connection.Open();
                    OracleCommand getmanidCmd = new OracleCommand();
                    getmanidCmd.CommandText = "SELECT categoryID FROM categoriesoltp WHERE categoryName='" + category + "'";
                    getmanidCmd.Connection = getcatid_connection;
                    OracleDataReader sdr_getcatiddisplay = getmanidCmd.ExecuteReader();
                    while (sdr_getcatiddisplay.Read())
                    {
                        catid = Convert.ToInt32(sdr_getcatiddisplay["categoryID"].ToString());
                    }
                }
                catch (Exception e)
                {
                    //MessageBox.Show("Could Not Obtain cat ID");
                }
                finally
                {
                    getcatid_connection.Close();
                }
            }
            return catid;
        }
        
        public void addProduct(int pid,string productname, double costprice, double retailprice,int stock, string companyName,int categoryID,int branchid,MetroFramework.Controls.MetroGrid grid)
        {
            using (OracleConnection addproductgrid_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    addproductgrid_connection.Open();
                    OracleCommand cmdAddProduct = new OracleCommand();
                    cmdAddProduct.CommandText = "INSERT INTO PRODUCTSOLTP(PRODUCTID,PRODUCTNAME,COSTPRICE,RETAILPRICE,STOCK,COMPANYNAME,CATEGORYID,BRANCHID)" +
                    "VALUES('" + pid + "','" + productname + "','" + costprice + "','" + retailprice + "','" + stock + "','" + companyName + "','" + categoryID + "','" + branchid +"')";
                    cmdAddProduct.Connection = addproductgrid_connection;
                    cmdAddProduct.ExecuteNonQuery();
                    MessageBox.Show("Product Added");
                    string query = "SELECT P.productID,P.productName,P.retailprice,P.costprice,P.stock,C.companyName,CAT.categoryID,B.branchName,CAT.CATEGORYNAME FROM PRODUCTSOLTP p ,COMPANYOLTP c, CATEGORIESOLTP cat, brancholtp b WHERE P.companyName = C.companyName AND P.CATEGORYID = CAT.CATEGORYID AND P.branchid = b.branchid ORDER BY P.PRODUCTID";

                    OracleDataAdapter sda = new OracleDataAdapter(query, addproductgrid_connection);
                    DataTable dt = new DataTable();
                    grid.DataSource = null;
                    grid.Rows.Clear();
                    sda.Fill(dt);
                    grid.DataSource = dt;
                }
                catch (Exception e)
                {
                    //MessageBox.Show("Could Not Add Products to grid" + e.Message);
                }
                finally
                {
                    addproductgrid_connection.Close();
                }
            }
        }
        
        public void updateProduct(int pid,string productname, double costprice, double retailprice, int stock, string companyName, int categoryID, int branchid, MetroFramework.Controls.MetroGrid grid)
        {
            using (OracleConnection updateproduct_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    updateproduct_connection.Open();
                    OracleCommand cmdUpdateProduct = new OracleCommand();
                    cmdUpdateProduct.CommandText = "UPDATE PRODUCTSOLTP SET PRODUCTNAME='" + productname + "'," + "COSTPRICE='" + costprice + "'," +
                        "RETAILPRICE='" + retailprice + "'," + "STOCK='" + stock + "'," + "COMPANYNAME='" + companyName + "'," + "categoryID='" + categoryID + "'," + "BRANCHID='" + "' WHERE PRODUCTID='" + pid + "'";
                    cmdUpdateProduct.Connection = updateproduct_connection;
                    cmdUpdateProduct.ExecuteNonQuery();
                    MessageBox.Show("Product Updated");

                    string query = "SELECT P.productID,P.productName,P.retailprice,P.costprice,P.stock,C.companyName,CAT.categoryID,B.branchName,CAT.CATEGORYNAME FROM PRODUCTSOLTP p ,COMPANYOLTP c, CATEGORIESOLTP cat, brancholtp b WHERE P.companyName = C.companyName AND P.CATEGORYID = CAT.CATEGORYID AND P.branchid = b.branchid ORDER BY P.PRODUCTID";

                    OracleDataAdapter sda = new OracleDataAdapter(query, updateproduct_connection);
                    DataTable dt = new DataTable();
                    grid.DataSource = null;
                    grid.Rows.Clear();
                    sda.Fill(dt);
                    grid.DataSource = dt;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace);
                }
                finally
                {
                    updateproduct_connection.Close();
                }
            }
        }
        public void getCustomers(MetroFramework.Controls.MetroGrid grid)
        {
            using (OracleConnection displaycustomers_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    displaycustomers_connection.Open();
                    OracleDataAdapter sda = new OracleDataAdapter("SELECT * FROM customersoltp ORDER BY CUSTOMERID", displaycustomers_connection);
                    DataTable dt = new DataTable();
                    grid.DataSource = null;
                    grid.Rows.Clear();
                    sda.Fill(dt);
                    grid.DataSource = dt;
                }
                catch (Exception e)
                {
                    
                }
                finally
                {
                    displaycustomers_connection.Close();
                }
            }
        }
        public void removeCustomer(int customerid, MetroFramework.Controls.MetroGrid grid)
        {
            using (OracleConnection removecustomergrid_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    removecustomergrid_connection.Open();
                    OracleCommand cmdDeleteCustomer = new OracleCommand();
                    cmdDeleteCustomer.CommandText = "DELETE FROM customersoltp WHERE customerID=" + customerid + "";
                    cmdDeleteCustomer.Connection = removecustomergrid_connection;
                    cmdDeleteCustomer.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted");
                    OracleDataAdapter sda = new OracleDataAdapter("SELECT * FROM customersoltp ORDER BY CUSTOMERID", removecustomergrid_connection);
                    DataTable dt = new DataTable();
                    grid.DataSource = null;
                    grid.Rows.Clear();
                    sda.Fill(dt);
                    grid.DataSource = dt;
                }
                catch (Exception e)
                {
                    //MessageBox.Show("Could Not Delete Customer" + e.Message);
                }
                finally
                {
                    removecustomergrid_connection.Close();
                }
            }
        }
        public void addCustomer(int cid,string customername, long contactnumber, string email, MetroFramework.Controls.MetroGrid grid)
        {
            using (OracleConnection addcustomergrid_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    addcustomergrid_connection.Open();
                    OracleCommand cmdAddCustomer = new OracleCommand();
                    cmdAddCustomer.CommandText = "INSERT INTO customersoltp(CUSTOMERID,customername,contactnumber,email)" +
                    "VALUES('" + cid + "','"+customername + "','" + contactnumber + "','" + email + "')";
                    cmdAddCustomer.Connection = addcustomergrid_connection;
                    cmdAddCustomer.ExecuteNonQuery();
                    MessageBox.Show("Customer Added");
                    OracleDataAdapter sda = new OracleDataAdapter("SELECT * FROM customersoltp ORDER BY CUSTOMERID", addcustomergrid_connection);
                    DataTable dt = new DataTable();
                    grid.DataSource = null;
                    grid.Rows.Clear();
                    sda.Fill(dt);
                    grid.DataSource = dt;
                }
                catch (Exception e)
                {
                   
                }
                finally
                {
                    addcustomergrid_connection.Close();
                }
            }
        }
        public void updateCustomer(int customeridToBeUpdated, string customername, long contactnumber, string email, MetroFramework.Controls.MetroGrid grid)
        {
            using (OracleConnection updatecustomer_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    updatecustomer_connection.Open();
                    OracleCommand cmdUpdateCustomer = new OracleCommand();
                    cmdUpdateCustomer.CommandText = "UPDATE customersoltp SET  customername='" + customername + "'," + "contactnumber='" + contactnumber + "'," + "email='" + email + "' WHERE customerID='" + customeridToBeUpdated + "'";
                    cmdUpdateCustomer.Connection = updatecustomer_connection;
                    cmdUpdateCustomer.ExecuteNonQuery();
                    MessageBox.Show("Customer Updated");
                    OracleDataAdapter sda = new OracleDataAdapter("SELECT * FROM customersoltp ORDER BY CUSTOMERID", updatecustomer_connection);
                    DataTable dt = new DataTable();
                    grid.DataSource = null;
                    grid.Rows.Clear();
                    sda.Fill(dt);
                    grid.DataSource = dt;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could Not Update Customer" + e.Message);
                }
                finally
                {
                    updatecustomer_connection.Close();
                }
            }
        }
        public Class_SelectedCustomer searchcustomerbycontactnumber(long contactnumber)
        {
            Class_SelectedCustomer sc = new Class_SelectedCustomer();
            if (contactnumber==0)
            {
                MessageBox.Show("You Did Not Enter Customer Mobile Number");
            }
            if (!(contactnumber==0))
            {
                using (OracleConnection searchcustbymobile_connection = new OracleConnection(localDbConnectionString))
                {
                    try
                    {
                        searchcustbymobile_connection.Open();
                        OracleCommand getcustomerdataCmd = new OracleCommand();
                        getcustomerdataCmd.CommandText = "SELECT * FROM customersoltp WHERE CONTACTNUMBER='" + contactnumber + "'";
                        getcustomerdataCmd.Connection = searchcustbymobile_connection;
                        OracleDataReader sdr_getcustomerdatadisplay_rdr = getcustomerdataCmd.ExecuteReader();
                        while (sdr_getcustomerdatadisplay_rdr.Read())
                        {
                            sc.setcustomerID(Convert.ToInt32(sdr_getcustomerdatadisplay_rdr["CUSTOMERID"].ToString()));
                            sc.setcustomername(sdr_getcustomerdatadisplay_rdr["customername"].ToString());
                            sc.setcustomeremail(sdr_getcustomerdatadisplay_rdr["email"].ToString());
                            sc.setcustomercontactnumber(Convert.ToInt64(sdr_getcustomerdatadisplay_rdr["contactnumber"].ToString()));
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Could Not Obtain Customer Data");
                    }
                    finally
                    {
                        searchcustbymobile_connection.Close();
                    }
                }
            }
            return sc;
        }
        public Class_SelectedCustomer searchcustomerbyemailaddress(string custemailaddress)
        {
            Class_SelectedCustomer sc = new Class_SelectedCustomer();
            if (string.IsNullOrEmpty(custemailaddress) || string.IsNullOrWhiteSpace(custemailaddress))
            {
                MessageBox.Show("You Did Not Enter Customer Email Address");
            }
            if (!string.IsNullOrEmpty(custemailaddress) && !string.IsNullOrWhiteSpace(custemailaddress))
            {
                using (OracleConnection searchcustbyemail_connection = new OracleConnection(localDbConnectionString))
                {
                    try
                    {
                        searchcustbyemail_connection.Open();
                        OracleCommand getcustomerdataCmd = new OracleCommand();
                        getcustomerdataCmd.CommandText = "SELECT * from customersoltp WHERE email='" + custemailaddress + "'";
                        getcustomerdataCmd.Connection = searchcustbyemail_connection;
                        OracleDataReader sdr_getcustomerdatadisplay_rdr = getcustomerdataCmd.ExecuteReader();
                        while (sdr_getcustomerdatadisplay_rdr.Read())
                        {
                            sc.setcustomerID(Convert.ToInt32(sdr_getcustomerdatadisplay_rdr["CUSTOMERID"]));
                            sc.setcustomername(sdr_getcustomerdatadisplay_rdr["CUSTOMERNAME"].ToString());
                            sc.setcustomeremail(sdr_getcustomerdatadisplay_rdr["email"].ToString());
                            sc.setcustomercontactnumber(Convert.ToInt64(sdr_getcustomerdatadisplay_rdr["contactnumber"].ToString()));
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Could Not Obtain Customer Data");
                    }
                    finally
                    {
                        searchcustbyemail_connection.Close();
                    }
                }
            }
            return sc;
        }
        public void insertBillRecord(int billnumber, int customerid, int branchid, string username)
        {

            Debug.WriteLine("BILLNUMBER : " + billnumber.ToString());
            Debug.WriteLine("customerid : " + customerid.ToString());
            Debug.WriteLine("branchid : " + branchid.ToString());
            Debug.WriteLine("username : " + username);
            


            using (OracleConnection insertBill_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    insertBill_connection.Open();
                    string currentdate = DateTime.Now.ToString("dd-MMM-yyyy");
                    OracleCommand cmdAddBill = new OracleCommand();
                    cmdAddBill.CommandText = "INSERT INTO BILLSOLTP(BILLNUMBER,CUSTOMERID,BRANCHID,PURCHASEDDATE,USERNAME) VALUES(" + billnumber + "," + customerid + "," + branchid + ",to_date(:currentdate, 'dd-MM-yyyy'),'" + username + "')";
                    OracleParameter currentdatePARAM = new OracleParameter();
                    currentdatePARAM.ParameterName = ":currentdate";
                    currentdatePARAM.Value = currentdate;
                    cmdAddBill.Parameters.Add(currentdatePARAM);
                    cmdAddBill.Connection = insertBill_connection;
                    cmdAddBill.ExecuteNonQuery();
                   
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could Not Add Bill Information" + e.InnerException);
                    MessageBox.Show(e.Source);
                    MessageBox.Show(e.TargetSite.ToString());
                    MessageBox.Show(e.StackTrace);
                }
                finally
                {
                    insertBill_connection.Close();
                }
            }
        }

        
                   

            public void insertBillDetailsRecord(int billnumber, int linenumber, int productid, int categoryid,string companyname,int quantity,int discount)
        {
            
            using (OracleConnection insertBill_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    insertBill_connection.Open();
                    OracleCommand cmdAddBill = new OracleCommand();
                    cmdAddBill.CommandText = "INSERT INTO BILLDETAILSOLTP(BILLNUMBER,LINENUMBER,PRODUCTID,CATEGORYID,COMPANYNAME,QUANTITY,DISCOUNT) VALUES('" + billnumber + "','" + linenumber + "','" + productid + "','" + categoryid + "','" + companyname  + "','" +quantity+ "','" +discount+"')";
                    cmdAddBill.Connection = insertBill_connection;
                cmdAddBill.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could Not Add Bill DETAILS Information" + e.Message);
                }
                finally
                {
                    insertBill_connection.Close();
                }
            }
        }
        public void updateProductQuantity(int productid, int quantitybought, MetroFramework.Controls.MetroGrid grid)
        {
            int previousquantity = 0;
            int currentquantity = 0;
            using (OracleConnection selectpreviousproductquantity = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    selectpreviousproductquantity.Open();
                    OracleCommand cmdpreviousquantityselect = new OracleCommand();
                    cmdpreviousquantityselect.CommandText = "SELECT stock FROM PRODUCTSOLTP WHERE PRODUCTID='" + productid + "'";
                    cmdpreviousquantityselect.Connection = selectpreviousproductquantity;
                    OracleDataReader sdr = cmdpreviousquantityselect.ExecuteReader();
                    while (sdr.Read())
                    {
                        previousquantity = Convert.ToInt32(sdr["stock"].ToString());
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could Not Select Product Quantity" + e.Message);
                }
                finally
                {
                    selectpreviousproductquantity.Close();
                }
            }
            currentquantity = previousquantity - quantitybought;
            using (OracleConnection updateProductQuantity_connection = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    updateProductQuantity_connection.Open();
                    OracleCommand cmdUpdateCustomer = new OracleCommand();
                    cmdUpdateCustomer.CommandText = "UPDATE PRODUCTSOLTP SET stock='" + currentquantity + "' WHERE PRODUCTID='" + productid + "'";
                    cmdUpdateCustomer.Connection = updateProductQuantity_connection;
                    cmdUpdateCustomer.ExecuteNonQuery();
                    string query = "SELECT P.productID,P.productName,P.retailprice,P.costprice,P.stock,C.companyName,CAT.categoryID,B.branchName,CAT.CATEGORYNAME FROM PRODUCTSOLTP p ,COMPANYOLTP c, CATEGORIESOLTP cat, brancholtp b WHERE P.companyName = C.companyName AND P.CATEGORYID = CAT.CATEGORYID AND P.branchid = b.branchid ORDER BY P.PRODUCTID";

                    OracleDataAdapter sda = new OracleDataAdapter(query, updateProductQuantity_connection);
                    DataTable dt = new DataTable();
                    grid.DataSource = null;
                    grid.Rows.Clear();
                    sda.Fill(dt);
                    grid.DataSource = dt;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could Not Update Product Quantity" + e.Message);
                }
                finally
                {
                    updateProductQuantity_connection.Close();
                }
            }
        }
       
        public Class_CurrentBranch getCurrentbranchData(string branchname)
        {
            Class_CurrentBranch branchobj = new Class_CurrentBranch();
            using (OracleConnection selectcurrentbranchinfo = new OracleConnection(localDbConnectionString))
            {
                try
                {
                    selectcurrentbranchinfo.Open();
                    OracleCommand selectcurrentbranchinfo_cmd = new OracleCommand();
                    selectcurrentbranchinfo_cmd.CommandText = "SELECT * FROM  brancholtp WHERE  branchName='" + branchname + "'";
                    selectcurrentbranchinfo_cmd.Connection = selectcurrentbranchinfo;
                    OracleDataReader sdr = selectcurrentbranchinfo_cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        branchobj.setbranchname(sdr["BRANCHNAME"].ToString());
                        branchobj.setbranchcity(sdr["CITY"].ToString());
                        branchobj.setbranchid(Convert.ToInt32(sdr["BRANCHID"].ToString()));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could Not Select  branch Info" + e.Message);
                }
                finally
                {
                    selectcurrentbranchinfo.Close();
                }
            }
            return branchobj;
        }
    }
}