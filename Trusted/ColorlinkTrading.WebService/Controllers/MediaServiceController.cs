using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trusted.GENIE.Logic;
using Trusted.GENIE.Models;
using Trusted.GENIE.WebService.ActionFilters;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace Trusted.GENIE.WebService.Controllers
{
    [RoutePrefix("MediaService")]
    public class MediaServiceController : Controller
    {
        [Route("UploadFile")]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult UploadFile(GenericRequestModel request)
        {
            // for this example; processing just the first file
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                if (file.ContentLength != 0)
                {
                    // throw an error here if content length is not > 0
                    // you'll probably want to do something with file.ContentType and file.FileName
                    byte[] fileContent = new byte[file.ContentLength];
                    file.InputStream.Read(fileContent, 0, file.ContentLength);
                    // fileContent now contains the byte[] of your attachment...
                    var extension = Path.GetExtension(file.FileName);
                    var fileName = Path.Combine(Server.MapPath("~/uploads"), Guid.NewGuid().ToString() + extension);
                    return Json(GeneralLogic.UploadFile(request, fileContent, fileName), JsonRequestBehavior.DenyGet);
                }
            }
            return null;
        }

        [Route("UploadFileUsingIdentifier")]
        [AuthenticationFilter]
        [TraceFilter]
        public JsonResult UploadFileUsingIdentifier(FileUploadRequestModel request)
        {
            GenericItemResultModel result = new GenericItemResultModel() { Feedback = "No file uploaded", HasError = true };

            // for this example; processing just the first file
            try
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if (file.ContentLength != 0)
                    {
                        // throw an error here if content length is not > 0
                        // you'll probably want to do something with file.ContentType and file.FileName
                        byte[] fileContent = new byte[file.ContentLength];
                        file.InputStream.Read(fileContent, 0, file.ContentLength);
                        // fileContent now contains the byte[] of your attachment...
                        var extension = Path.GetExtension(file.FileName);
                        var fileName = Path.Combine(Server.MapPath("~/uploads"), request.FileTypeIdentifier, Guid.NewGuid().ToString() + extension);
                        return Json(GeneralLogic.UploadFile(request, fileContent, fileName), JsonRequestBehavior.DenyGet);
                    }
                }
                else
                {
                    throw new Exception("No Files Selected");
                }
            }
            catch (Exception error)
            {
                result.Feedback = error.Message;
            }

            return Json(result, JsonRequestBehavior.DenyGet);
        }


        [Route("DownloadFile")]
        [TraceFilter]
        public FileContentResult DownloadFile(string q)
        {
            GenericMediaRequestModel model = new GenericMediaRequestModel
            {
                MediaGUID = q,
                RootWebFolder = Server.MapPath("~")
            };
            var response = GeneralLogic.GetMediaExport(model);

            //send the response
            var stream = new MemoryStream(response.MediaData, 0, response.MediaData.Length, true, true);
            return File(stream.GetBuffer(), "application/octet-stream", response.MediaFileName);
        }
    }
}