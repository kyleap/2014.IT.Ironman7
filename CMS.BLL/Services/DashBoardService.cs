using CMS.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain;
using CMS.DAL.Interfaces;
using CMS.DAL.Repository;
using AutoMapper;

namespace CMS.BLL.Services
{
    public class DashBoardService
    {
        private IRepository<Employees> db;

        public DashBoardService()
        {
            db = new GenericRepository<Employees>();
        }

        public List<EmpOrdersViewModel> GetEmpOrders()
        {
            List<EmpOrdersViewModel> models = new List<EmpOrdersViewModel>();

            // 取得所有員工資料
            var DbResult = db.Get().ToList();
            // Mapping
            Mapper.CreateMap<Employees, EmpOrdersViewModel>()
                .ForMember(c => c.EmployeeName
                , x => x.MapFrom(d => string.Format("{0} {1}", d.FirstName, d.LastName)))
                .ForMember(c => c.OrderCount, x => x.MapFrom(d => d.Orders.Count()));
            return Mapper.Map<List<Employees>, List<EmpOrdersViewModel>>(DbResult)
                .OrderByDescending(c => c.OrderCount).ToList(); //按訂單數量排序
        }
    }
}
