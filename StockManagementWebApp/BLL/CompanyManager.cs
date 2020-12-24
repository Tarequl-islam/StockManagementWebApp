using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.BLL
{
    public class CompanyManager
    {
        CompanyGateWay companyGateWay = new CompanyGateWay();

        public string Save(CompanySetUp companySetUp)
        {
            if (companyGateWay.IsExistName(companySetUp.Name))
            {
                return "Company Name already Exist";
            }
            else
            {
                int rowAffect = companyGateWay.Save(companySetUp);

                if (rowAffect>0)
                {
                    return "Save successfull";
                }
                else
                {
                    return "Save failed";   
                }
            }            
        }

        public List<CompanySetUp> AllCompanyName()
        {
            return companyGateWay.CompanylList();
        }
    }
}