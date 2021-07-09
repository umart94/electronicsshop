using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VisualProgProject
{
    public class Class_EmployeeDataDisplay
    {
        public string username;
        public string branchname;
        public string city;
        public string job;
        public double salary;
        public string hiredate;
        public int branchid;
        public Class_EmployeeDataDisplay()
        {
        }
        public Class_EmployeeDataDisplay(Class_EmployeeDataDisplay abc) {
            this.username=abc.username;
        this.branchname=abc.branchname;
        this.city=abc.city;
        this.job=abc.job;
        this.salary=abc.salary;
        this.hiredate = abc.hiredate;
        this.branchid = abc.branchid;
    }
        public Class_EmployeeDataDisplay(int bhid,string username, string jb,double salary, string hiredate,string branchname)
        {
            this.username = username;
            this.job = jb;
            this.salary = salary;
            this.hiredate = hiredate;
            this.branchname = branchname;
            this.branchid = bhid;
        }
        public string getUsername()
        {
            return username;
        }
        public string getCity()
        {
            return city;
        }
        public void setUsername(string username)
        {
            this.username = username;
        }
        public string getBranchName()
        {
            return branchname;
        }
        public void setBranchName(string bname)
        {
            this.branchname = bname;
        }
        public void setCity(string city)
        {
            this.city = city;
        }
        public string getJob()
        {
            return job;
        }
        public void setJob(string job)
        {
            this.job = job;
        }
        public double getSalary()
        {
            return salary;
        }
        public void setSalary(double x)
        {
            this.salary = x;
        }
        public string getHiredate()
        {
            return hiredate;
        }
        public void setHiredate(string x)
        {
            this.hiredate = x;
        }
        public void setBranchID(int b)
        {
            this.branchid = b;
        }
        public int getbranchid()
        {
            return this.branchid;
        }
    }
}