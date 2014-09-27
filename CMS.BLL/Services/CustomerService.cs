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


    }
}
