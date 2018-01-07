using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using ColorlinkTrading.DataAccess;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using ColorlinkTrading.Models;

namespace ColorlinkTrading.Logic
{
    public class LetterLogic
    {
        //timeout to make sure this completes
        public static int globalTimeOut = 300;

        public static int LetterCount(GenericRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                //timeout to make sure this completes
                dm.Database.CommandTimeout = globalTimeOut;
                var count = dm.Letters.Count();
                return count;
            }
        }

        public static LetterListResultModel SearchLetterList(GenericSearchRequestModel request)
        {
            var result = new LetterListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                Letters = new List<LetterItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var searchCriteria = request.SearchCriteria;
                    var dateFrom = request.DateFrom;
                    var dateTo = request.DateTo;

                    var pageNumber = request.PageNumber;
                    var pageSize = request.PageSize;
                    var orderingBy = request.OrderField + " " + request.OrderDirection;


                    var count = dm.Letters
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.LetterRecipient.Contains(searchCriteria)
                                                          )
                                )
                                //date from
                                && (dateFrom == null || b.LetterDate >= dateFrom)
                                //date to
                                && (dateTo == null || b.LetterDate <= dateTo)
                               ).OrderBy(orderingBy)
                         .Count();


                    var pages = Convert.ToInt32(Math.Floor((decimal)count / (decimal)pageSize));
                    if ((pages * pageSize) < count)
                    {
                        pages++;
                    }

                    var data = dm.Letters
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.LetterRecipient.Contains(searchCriteria)
                                                          )
                                )
                                //date from
                                && (dateFrom == null || b.LetterDate >= dateFrom)
                                //date to
                                && (dateTo == null || b.LetterDate <= dateTo)
                               ).ToList();


                    foreach (var item in data)
                    {
                        LetterItemResultModel letter = new LetterItemResultModel
                        {
                            LetterContent = item.LetterContent,
                            LetterDate = item.LetterDate,
                            LetterRecipient = item.LetterRecipient,
                            LetterId = item.LetterId,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate
                        };
                        result.Letters.Add(letter);
                    }
                    result.NumberOfRecords = count;
                    result.NumberOfPages = pages;
                    return result;
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

        public static LetterItemResultModel GetLetter(LetterRequestModel request)
        {
            var result = new LetterItemResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var letterid = request.LetterId;

                    var data = dm.Letters.Where(b => b.LetterId == letterid).FirstOrDefault();

                    result.CreatedByUserName = data.CreatedByUserName;
                    result.CreatedDate = data.CreatedDate;
                    result.UpdatedByUserName = data.UpdatedByUserName;
                    result.UpdatedDate = data.UpdatedDate;
                    result.LetterContent = data.LetterContent;
                    result.LetterDate = data.LetterDate;
                    result.LetterRecipient = data.LetterRecipient;
                    result.LetterId = data.LetterId;


                    return result;
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

        public static GenericItemResultModel WriteLetter(LetterRequestModel request)
        {
            var result = new GenericItemResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var letterid = request.LetterId;

                    var data = (from a in dm.Letters
                                where a.LetterId == letterid
                                select a).FirstOrDefault();


                    if (data == null)
                    {
                        data = new Letter();
                        dm.Letters.Add(data);
                        result.Feedback = "Letter Successfully Added";
                    }
                    else
                    {
                        result.Feedback = "Edit Letter Successful";
                    }

                    data.LetterContent = request.LetterContent;
                    data.LetterDate = request.LetterDate;
                    data.LetterRecipient = request.LetterRecipient;
                    data.LetterId = request.LetterId;


                    dm.SaveChanges();
                    return result;
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
        
    }
}