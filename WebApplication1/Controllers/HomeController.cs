using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Xml.Serialization;
using StudentCard.Models;
using OfficeOpenXml;

namespace StudentCard.Controllers
{
    public class HomeController : Controller
    {
        DataBaseForStudContext DataBaseForStud = new DataBaseForStudContext();
        public ActionResult Index()
        {
            IEnumerable<DataBaseForStud> DataBase = DataBaseForStud.DataBase;
            ViewBag.DataBase = DataBase;
            return View();
        }
        //загрузка файлов с базой данных на сайт
        [HttpPost]
        public void Upload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                using (Stream myStream = file.InputStream)
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(DataBaseForStud));
                    DataBaseForStud data = (DataBaseForStud)formatter.Deserialize(myStream);

                    DataBaseForStud.DataBase.Add(data);
                    DataBaseForStud.SaveChanges();
                }
            }
            Response.Redirect("Index");
        }
        //метод для загрузки файлов в excel
        [HttpPost]
        public void ToExcelFromDataBaseForStud()
        {
            List<DataBaseForStud> database = new List<DataBaseForStud>(DataBaseForStud.DataBase.ToArray());
            FileInfo Excel = new FileInfo(Server.MapPath("~/StudentCard.xlsx"));
            if (Excel.Exists)
            {
                Excel.Delete();
            }
            ExcelPackage newPackage = new ExcelPackage(Excel);
            int workSheetNumber = 1;
            foreach (DataBaseForStud d in database)
            {
                ExcelWorksheet worksheet = newPackage.Workbook.Worksheets.Add(workSheetNumber.ToString());
                workSheetNumber++;
                var cell1 = worksheet.Cells[1, 1];
                var cell2 = worksheet.Cells[2, 1];
                var cell3 = worksheet.Cells[3, 1];
                var cell4 = worksheet.Cells[4, 1];
                var cell5 = worksheet.Cells[5, 1];
                var cell6 = worksheet.Cells[6, 1];



                cell1.Value = "Студент";
                cell2.Value = "Возраст";
                cell3.Value = "Факультет";
                cell4.Value = "Номер курса";
                cell5.Value = "Направление подготовки";
                cell6.Value = "Опыт участия в конкурсах";


                var znach1 = worksheet.Cells[1, 2];
                var znach2 = worksheet.Cells[2, 2];
                var znach3 = worksheet.Cells[3, 2];
                var znach4 = worksheet.Cells[4, 2];
                var znach5 = worksheet.Cells[5, 2];
                var znach6 = worksheet.Cells[6, 2];



                znach1.Value = d.fio;
                znach2.Value = d.age;
                znach3.Value = d.fak;
                znach4.Value = d.course;
                znach5.Value = d.direction;
                znach6.Value = d.expirience;
            }
            newPackage.Save();
        }
        //загрузка файлов в excel
        [HttpPost]
        public FileResult DownLoadExcelFile()
        {
            ToExcelFromDataBaseForStud();
            string path = Server.MapPath("~/StudentCard.xlsx");
            string file_type = "application/xlsx";
            string file_name = "StudentCard.xlsx";
            return File(path, file_type, file_name);
        }
        //Очистка БД с сайта
        [HttpPost]
        public void DropTable()
        {
            DataBaseForStud.Database.Delete();
            DataBaseForStud.SaveChanges();
            Response.Redirect("Index");
        }
    }
}