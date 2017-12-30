using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trusted.GENIE.Logic;
using Trusted.GENIE.Models;
using Trusted.GENIE.WebService.ActionFilters;

namespace Trusted.GENIE.WebService.Controllers
{
    public class TestController : Controller
    {
        public static List<TestGridModelItem> FakeTestData = new List<TestGridModelItem>();
        private void GenerateFakeData()
        {
            FakeTestData = new List<TestGridModelItem>();
            for (int x = 0; x < 50; x++)
            {
                FakeTestData.Add(new TestGridModelItem() { ItemID = x, ItemName = "Item " + x });
            }
        }

        [AuthenticationFilter]
        public JsonResult GetTestItems(TestGridModelItem request)
        {
            int currentUser = request.SessionUserId;

            if (FakeTestData == null)
            {
                GenerateFakeData();
            }

            if (FakeTestData.Count == 0)
            {
                GenerateFakeData();
            }

            TestDataResultModel result = new TestDataResultModel { Feedback = "", HasError = false, IsValidationError = false };
            result.Data = FakeTestData;

            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [AuthenticationFilter]
        public JsonResult AddtTestItem(TestGridModelItem request)
        {
            int currentUser = request.SessionUserId;

            GenericResultModel result = new GenericResultModel() { Feedback = "", HasError = false, IsValidationError = false };
            try
            {
                FakeTestData.Add(new TestGridModelItem() { ItemID = FakeTestData.Count, ItemName = request.ItemName });
            }
            catch (Exception error)
            {
                result.HasError = true;
                result.Feedback = error.Message;
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [AuthenticationFilter]
        public JsonResult EditTestItem(TestGridModelItem request)
        {
            int currentUser = Convert.ToInt32(RouteData.Values["UserData"].ToString());

            GenericResultModel result = new GenericResultModel() { Feedback = "", HasError = false, IsValidationError = false };
            try
            {
                FakeTestData[request.ItemID].ItemName = request.ItemName;
            }
            catch (Exception error)
            {
                result.HasError = true;
                result.Feedback = error.Message;
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }

    public class TestDataResultModel : GenericResultModel
    {
        public List<TestGridModelItem> Data { get; set; }
    }

    public class TestGridModelItem : GenericRequestModel
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
    }
}