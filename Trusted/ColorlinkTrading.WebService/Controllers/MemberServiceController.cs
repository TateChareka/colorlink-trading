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
    [RoutePrefix("MemberService")]
    [AuthenticationFilter]
    [TraceFilter]
    public class MemberServiceController : Controller
    {

        [Route("NedbankDownloadForFTPTransmissionSearch")]
        [HttpPost]
        public JsonResult NedbankDownloadForFTPTransmissionSearch(GenericSearchRequestModel request)
        {
            return Json(MembersLogic.SearchNedbankFTPTransmission(request), JsonRequestBehavior.DenyGet);
        }

        [Route("NedbankActivationStatusSearch")]
        [HttpPost]
        public JsonResult NedbankActivationStatusList(GenericSearchRequestModel request)
        {
            return Json(MembersLogic.SearchNedbankActivationStatus(request), JsonRequestBehavior.DenyGet);
        }

        [Route("DischemActivationStatusSearch")]
        [HttpPost]
        public JsonResult DischemActivationStatusList(GenericSearchRequestModel request)
        {
            return Json(MembersLogic.SearchDischemActivationStatus(request), JsonRequestBehavior.DenyGet);
        }

        [Route("StatementRunsSearch")]
        [HttpPost]
        public JsonResult StatementRunsSearch(GenericSearchRequestModel request)
        {
            return Json(MembersLogic.SearchStatementRuns(request), JsonRequestBehavior.DenyGet);
        }

        [Route("AcceleratorListingsSearch")]
        [HttpPost]
        public JsonResult AcceleratorListingsSearch(GenericSearchRequestModel request)
        {
            return Json(MembersLogic.SearchAcceleratorListings(request), JsonRequestBehavior.DenyGet);
        }

        [Route("MemberStatementsSearch")]
        [HttpPost]
        public JsonResult MemberStatementsSearch(GenericSearchRequestModel request)
        {
            return Json(MembersLogic.SearchMemberStatements(request), JsonRequestBehavior.DenyGet);
        }

        [Route("DisableCommunications")]
        [HttpPost]
        public JsonResult DisableCommunications(GenericItemRequestModel request)
        {
            return Json(MembersLogic.DisableCommunicatons(request), JsonRequestBehavior.DenyGet);
        }

        [Route("EnableCommunications")]
        [HttpPost]
        public JsonResult EnableCommunications(GenericItemRequestModel request)
        {
            return Json(MembersLogic.EnableCommunicatons(request), JsonRequestBehavior.DenyGet);
        }

        [Route("DeleteMember")]
        [HttpPost]
        public JsonResult DeleteMember(GenericItemRequestModel request)
        {
            return Json(MembersLogic.DeleteMember(request), JsonRequestBehavior.DenyGet);
        }

        [Route("MemberSearch")]
        [HttpPost]
        public JsonResult MemberListSearch(GenericSearchRequestModel request)
        {
            return Json(MembersLogic.SearchMemberList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("MemberExport")]
        [HttpPost]
        public JsonResult MemberListExport(GenericSearchRequestModel request)
        {
            return Json(MembersExportLogic.ExportMemberList(request), JsonRequestBehavior.DenyGet);
        }

        [Route("NedbankFTPTransmissionExport")]
        [HttpPost]
        public JsonResult NedbankFTPTransmissionExport(GenericSearchRequestModel request)
        {
            return Json(MembersExportLogic.ExportNedbankFTPTransmission(request), JsonRequestBehavior.DenyGet);
        }

        [Route("AcceleratorListingsExport")]
        [HttpPost]
        public JsonResult AcceleratorListingsExport(GenericSearchRequestModel request)
        {
            return Json(MembersExportLogic.ExportAcceleratorListings(request), JsonRequestBehavior.DenyGet);
        }

        [Route("DischemActivationStatusExport")]
        [HttpPost]
        public JsonResult DischemActivationStatusExport(GenericSearchRequestModel request)
        {
            return Json(MembersExportLogic.ExportDischemActivationStatus(request), JsonRequestBehavior.DenyGet);
        }

        [Route("MemberStatementsExport")]
        [HttpPost]
        public JsonResult MemberStatementsExport(GenericSearchRequestModel request)
        {
            return Json(MembersExportLogic.ExportMemberStatements(request), JsonRequestBehavior.DenyGet);
        }

        [Route("NedbankActivationStatusExport")]
        [HttpPost]
        public JsonResult NedbankActivationStatusExport(GenericSearchRequestModel request)
        {
            return Json(MembersExportLogic.ExportNedbankActivationStatus(request), JsonRequestBehavior.DenyGet);
        }

        [Route("StatementRunsExport")]
        [HttpPost]
        public JsonResult StatementRunsExport(GenericSearchRequestModel request)
        {
            return Json(MembersExportLogic.ExportStatementRuns(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetAcceleratorStatus")]
        [HttpPost]
        public JsonResult GetAcceleratorStatus(GenericItemRequestModel request)
        {
            return Json(MembersLogic.GetAcceleratorStatus(request), JsonRequestBehavior.DenyGet);
        }

        [Route("WriteAcceleratorStatus")]
        [HttpPost]
        public JsonResult WriteAcceleratorStatus(AcceleratorItemRequestModel request)
        {
            return Json(MembersLogic.WriteAcceleratorStatus(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetAcceleratorItem")]
        [HttpPost]
        public JsonResult GetAcceleratorItem(GenericItemRequestModel request)
        {
            return Json(MembersLogic.GetAcceleratorItem(request), JsonRequestBehavior.DenyGet);
        }

        [Route("GetMemberStatementsItem")]
        [HttpPost]
        public JsonResult GetMemberStatementsItem(GenericItemRequestModel request)
        {
            return Json(MembersLogic.GetMemberStatementsItem(request), JsonRequestBehavior.DenyGet);
        }


    }
}