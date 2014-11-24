using CMS.BLL.Services;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web.Models
{
    public class PageDynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodes)
        {
            var returnValue = new List<DynamicNode>();
            
            // 向BLL層取得選單
            foreach (var item in PermissionService.GetMenu())
            {
                DynamicNode node = new DynamicNode();
                // 選單名稱
                node.Title = item.Name; 
                // 有無父類別，沒有的話則傳空字串
                node.ParentKey = item.ParentID == 0 ? "" : item.ParentID.ToString();
                // 唯一值
                node.Key = item.MenuID.ToString();
                // MVC的View
                node.Action = item.Action;
                // MVC的Controller
                node.Controller = item.Controller;
                // 選單所分配的腳色，逗號分隔
                node.Roles = item.Roles.Split(',').Where(c => !string.IsNullOrEmpty(c)).ToList();
                // 
                node.RouteValues.Add("id", item.MenuID);
                returnValue.Add(node);
            }
            // Return
            return returnValue;
        }
    }
}