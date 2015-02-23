using CMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL.Services
{
    public class PermissionService
    {
        /// <summary>取得選單<summary>
        /// <returns></returns>
        public static List<sp_Permission_GetMenuList_Result> GetMenu()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                return db.sp_Permission_GetMenuList().ToList();
            }
        }
    }
}
