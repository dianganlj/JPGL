using JPGL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        JPGL.BLL.tbStu stu = new JPGL.BLL.tbStu();
        JPGL.BLL.tbMajor major = new JPGL.BLL.tbMajor();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowNewsList()
        {

            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            var searchNo = Request["StuNo"];
            var searchName = Request["StuName"];
            var searchMajor = Request["MajorNo"];
            var searchTel = Request["StuTel"];
            var searchGrade = Request["StuGrade"];
            var searchCredit = Request["StuCredit"];

            string str = "";
            List<string> wheres = new List<string>();
            if (searchNo != "")
            {
                wheres.Add("StuNo like '%" + searchNo + "%'");
            }
            if (searchName != "")
            {
                wheres.Add("StuName like '%" + searchName + "%'");
            }
            if (searchMajor != "")
            {
                wheres.Add("MajorNo =" + searchMajor);
            }
            if (searchTel != "")
            {
                wheres.Add("StuGrade like '%" + searchTel + "%'");
            }
            if (searchGrade != "")
            {
                wheres.Add("StuTel =" + searchGrade);
            }
            if (searchCredit != "")
            {
                wheres.Add("StuCredit =" + searchCredit);
            }

            if (wheres.Count > 0)
            {
                str = string.Join(" and ", wheres.ToArray());
            }
            DataSet ds = stu.GetListByPage(str, "StuNo", (pageIndex - 1) * pageSize + 1, pageSize * pageIndex);
            List<tbStu> list = stu.DataTableToList(ds.Tables[0]);
            var total = stu.GetRecordCount("");
            var dataJson = new { total = total, rows = list };
            var json = Json(dataJson, JsonRequestBehavior.AllowGet);
            return json;

        }

        public ActionResult InitType()
        {
            List<JPGL.Model.tbMajor> list = major.GetModelList(string.Empty);
            var json = Json(list, JsonRequestBehavior.AllowGet);
            return json;
        }

        public ActionResult GetModelById()
        {
           string  stuno = Request["StuNo"];
            tbStu stuInfo = new tbStu();
            stuInfo = stu.GetModel(stuno);
            var json = Json(stuInfo,JsonRequestBehavior.AllowGet);
            return json;
        }

        public string Edit()
        {
            tbStu stuInfo = new tbStu();
            var   StuNo = Request["id"];
            var StuName = Request["StuName"];
            var StuGrade = Request["SruGrade"];
            var StuTel = Request["StuTel"];
            decimal StuCredit = Convert.ToDecimal(Request["StuCredit"]);
             var StuMajor = Request["StuMajor"];
            stuInfo = stu.GetModel(StuNo);
            JPGL.Model.tbMajor majormodel = new JPGL.Model.tbMajor();
            if(StuMajor==stuInfo.tbMajor.MajorName)
            {
                majormodel = major.GetModel(StuMajor);
            }
            else
            {
                int MajorNo = int.Parse(StuMajor);
                majormodel = major.GetModel(MajorNo);
            }
            stuInfo.StuName = StuName;
            stuInfo.StuNo = StuNo;
            stuInfo.StuGrade = StuGrade;
            stuInfo.StuTel = StuTel;
            stuInfo.StuCredit = StuCredit;
            stuInfo.tbMajor.MajorName = StuMajor;
            stuInfo.tbMajor = majormodel;
            bool b = stu.Update(stuInfo);
                if (b)
                {
                    return "ok";
                }
                else
                {
                    return "no";
                }
            }
        }
}
