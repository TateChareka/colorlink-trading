using ColorlinkTrading.DataAccess;
using ColorlinkTrading.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ColorlinkTrading.Logic
{
    public static class GeneralLogic
    {
        
        public static GenericMediaResultModel GetMediaExport(GenericMediaRequestModel model)
        {
            var result = new GenericMediaResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false
            };
            try
            {
                using (var dm = new DataModelEntities(model.SessionUserName))
                {
                    var m = dm.MediaFiles.Where(a => a.MediaGUID == model.MediaGUID).FirstOrDefault();
                    if (m != null)
                    {
                        var fileName = Path.Combine(model.RootWebFolder, "mediaDownloads", m.MediaGUID + ".xlsx");
                        if (File.Exists(fileName))
                        {
                            result.MediaData = File.ReadAllBytes(fileName);
                            result.MediaFileName = m.MediaDescription;
                            File.Delete(fileName);
                            dm.MediaFiles.Remove(m);
                            dm.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Media Download not found");
                        }
                    }
                    else
                    {
                        throw new Exception("Media Download not found");
                    }
                }
            }
            catch (Exception error)
            {
                var errorState = ErrorHandling.HandleError(error);
                result.Feedback = errorState.ErrorMessage;
                result.IsValidationError = errorState.IsValidationError;
                result.HasError = true;
            }
            return result;
        }

        public static GenericItemResultModel UploadFile(GenericRequestModel request, byte[] fileContent, string fileName)
        {
            GenericItemResultModel result = new GenericItemResultModel()
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false
            };
            try
            {
                //create the directory
                if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                }
                var fullPath = fileName;
                File.WriteAllBytes(fileName, fileContent);
                using (DataModelEntities dm = new DataModelEntities(request.SessionUserName))
                {
                    FileUpload fu = new FileUpload()
                    {
                        FileGUID = Guid.NewGuid().ToString(),
                        FileName = fileName
                    };
                    dm.FileUploads.Add(fu);
                    dm.SaveChanges();
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    result.ItemGUID = Path.GetFileName(fileName);
                    result.Feedback = fullPath;
                    result.ItemId = fu.FileUploadId;
                    return result;
                }
            }
            catch (Exception error)
            {
                ErrorResultObject errorState = ErrorHandling.HandleError(error);
                result.Feedback = errorState.ErrorMessage;
                result.IsValidationError = errorState.IsValidationError;
                result.HasError = true;
            }
            return result;
        }

        public static void WriteRequestLog(string ipAddress, string userAgent, string url, string queryString, int totalBytes,
            string httpMethod, string parameters, string userName, string userGUID)
        {
            try
            {
                using (DataModelEntities dm = new DataModelEntities(userName))
                {
                    dm.SYSLOGRequestHistories.Add(new SYSLOGRequestHistory()
                    {
                        IPAddress = ipAddress,
                        UserAgent = userAgent,
                        URL = url,
                        QueryString = queryString,
                        TotalBytes = totalBytes,
                        HTTPMethod = httpMethod,
                        FormParameters = parameters,
                        SystemUserGUID = (userGUID ?? "")
                    });
                    dm.SaveChanges();
                }
            }
            catch { }
        }

        public static string GenerateExcelExport<T>(List<T> data, string sheetName, string folderName)
        {
            return GenerateExcelExport(data, sheetName, folderName, null, null);
        }
        public static string GenerateExcelExport<T>(List<T> data, string sheetName, string folderName, Dictionary<string, string> captions, List<string> captionsToTotal)
        {
            var fileIdentifier = Guid.NewGuid().ToString();
            var fileName = Path.Combine(folderName, fileIdentifier + ".xlsx");
            CreateExcelFile.CreateExcelDocument(data, fileName, sheetName, captions, captionsToTotal,
                "ItemGUID", "ItemDescriptor", "ItemId", "HasError", "IsValidationError", "Feedback");
            return fileIdentifier;
        }

        

    }
}
