using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VisualProgProject
{
    public class Class_SelectedCustomer
    {
        int customerid = 0;
        string customername = "";
        long contactnumber = 0;
        string email = "";
        public Class_SelectedCustomer()
        {
        }
        public Class_SelectedCustomer(int c, string custname, long custmobnum, string custemail)
        {
            this.customerid = c;
            this.customername = custname;
            this.contactnumber = custmobnum;
            this.email = custemail;
        }
        public int getCustomerID()
        {
            return this.customerid;
        }
        public string getcustomername()
        {
            return this.customername;
        }
        public string getcustomeremail()
        {
            return this.email;
        }
        public long getcontactnumber()
        {
            return this.contactnumber;
        }
        public void setcustomername(string c)
        {
            this.customername = c;
        }
        public void setcustomerID(int c)
        {
            this.customerid = c;
        }
        public void setcustomeremail(string d)
        {
            this.email = d;
        }
        public void setcustomercontactnumber(long e)
        {
            this.contactnumber = e;
        }
    }
}