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


    }
}
