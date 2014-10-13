using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain;

namespace CMS.BLL.Services
{
    public class OrderService
    {
        public static List<sp_Customer_Orders_Result> GetCustomerOrders()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                return db.sp_Customer_Orders().ToList();
            }
        }

    }
}
