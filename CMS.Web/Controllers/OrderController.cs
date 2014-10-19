using CMS.BLL.Services;
using Microsoft.Reporting.WebForms;
using Novacode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var models = OrderService.GetCustomerOrders();
            return View(models);
        }

        public ActionResult Export(string type)
        {
            // 讀取.rdlc檔
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Rdlc"), "rdlcOrders.rdlc");
            lr.ReportPath = path;

            // 取得訂單資料
            var list = OrderService.GetCustomerOrders();
            // 設定資料集
            ReportDataSource rd = new ReportDataSource("DataSet1", list);
            lr.DataSources.Add(rd);
            // 檔案類型，從參數指定:Excel.pdf.word
            string reportType = type;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + type + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            // 回傳檔案
            return File(renderedBytes, mimeType, "Report");
        }

        public ActionResult ExportByDocx()
        {
            // 樣板路徑
            string TemplatePath = Server.MapPath("~/Templates/TestTemplate.docx");
            // 儲存路徑
            string SavePath = @"D:/test.docx";
            DocX document = DocX.Load(TemplatePath);
            document.ReplaceText("{{OrderNumber}}", "555555");
            document.ReplaceText("{{Name}}", "Kyle");
            document.ReplaceText("{{CurrTime}}", DateTime.Now.ToShortTimeString());
            document.SaveAs(SavePath);
            return File(SavePath, "application/docx", "Report.docx");
        }
    }
}