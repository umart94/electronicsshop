using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VisualProgProject
{
    public class Class_CurrentBranch
    {
        public int branchid = 0;
        public string branchname = "";
        public string  branchcity = "";
        public Class_CurrentBranch()
        {
        }
        public Class_CurrentBranch(int b, string branchn, string scity)
        {
            this.branchid = b;
            this.branchname = branchn;
            this.branchcity = scity;
        }
        public string getbranchname() { return this.branchname; }
        public string getbranchcity() { return this.branchcity; }
        public void setbranchname(string bname) { this.branchname= bname; }
        public void setbranchcity(string bcity) { this.branchcity = bcity; }
        public int getbranchid() { return this.branchid; }
        public void setbranchid(int bid) { this.branchid = bid; }
    }
}