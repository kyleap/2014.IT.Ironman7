using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DAL;
using CMS.DAL.Repository;
using CMS.Domain;
using CMS.DAL.Interfaces;
using CMS.Domain.ViewModels;
using AutoMapper;

namespace CMS.BLL.Services
{
    public class CustomerService
    {
        private IRepository<Customers> db;

        public CustomerService()
        {
            db = new GenericRepository<Customers>();
        }

        /// <summary>取得所有客戶資料</summary>
        /// <returns></returns>
        public List<CustomerViewModel> Get()
        {
            var DbResult = db.Get().ToList();
            Mapper.CreateMap<Customers, CustomerViewModel>();
            return Mapper.Map<List<Customers>, List<CustomerViewModel>>(DbResult);
        }

        // <summary>取得所有客戶資料(分頁)</summary>
        /// <returns></returns>
        public IQueryable<CustomerViewModel> Get(int CurrPage, int PageSize, out int TotalRow)
        {
            // 取得所有筆數
            TotalRow = db.Get().ToList().Count();
            // 使用Linq篩選分頁
            var DbResult = db.Get().ToList().Skip((CurrPage - 1) * PageSize).Take(PageSize).ToList();
            // Mapping到ViewModel
            Mapper.CreateMap<Customers, CustomerViewModel>();
            return Mapper.Map<List<Customers>, List<CustomerViewModel>>(DbResult).AsQueryable();
        }

        /// <summary>取得客戶資訊</summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public CustomerViewModel Get(string CustomerID)
        {
            var DbResult = db.Get().Where(c => c.CustomerID.Trim() == CustomerID.Trim()).FirstOrDefault(); 
            Mapper.CreateMap<Customers, CustomerViewModel>();
            return Mapper.Map<Customers, CustomerViewModel>(DbResult);
        }

        // <summary>新增客戶資料</summary>
        /// <returns></returns>
        public void AddCustomer(CustomerViewModel models)
        {
            Mapper.CreateMap<CustomerViewModel, Customers>();
            var cust = Mapper.Map<CustomerViewModel, Customers>(models);
            db.Insert(cust);
        }

        /// <summary>儲存客戶資訊</summary>
        /// <param name="models"></param>
        public void SaveCustomer(CustomerViewModel models)
        {
            Mapper.CreateMap<CustomerViewModel, Customers>();
            var cust = Mapper.Map<CustomerViewModel, Customers>(models);
            db.Update(cust);
        }

        /// <summary>刪除客戶資訊</summary>
        /// <param name="CustomerID"></param>
        public void Delete(string CustomerID)
        {
            var Customer = db.GetByID(CustomerID);
            db.Delete(Customer);
        }

    }
}
