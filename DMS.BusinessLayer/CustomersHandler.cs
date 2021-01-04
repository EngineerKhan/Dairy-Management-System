using DMS.DataLayer;
using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DMS.BusinessLayer
{
    public class CustomersHandler
    {
        public void AddCustomer(Customer cust)
        {
            new CustomersDAL().Insert(cust);
        }

        /// <summary>
        /// March 18
        /// </summary>
        /// <param name="col"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Customer> GetCustomers(string col, string param)
        {
            return new CustomersDAL().GetCustomers(col,param);
        }

        public List<Customer> GetCustomers()
        {
            return new CustomersDAL().GetCustomers();
        }

        public List<MasterTables> GetPriceCategories()
        {
            return new CustomersDAL().GetPriceCategories();
        }

        public List<MasterTables> GetTimeCategories()
        {
            return new CustomersDAL().GetTimeCategories();
        }
    }
}
