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
    public class PaymentLogic
    {
        //timeout to make sure this completes
        public static int globalTimeOut = 300;

        public static int PaymentCount(GenericRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                //timeout to make sure this completes
                dm.Database.CommandTimeout = globalTimeOut;
                var count = dm.Payments.Count();
                return count;
            }
        }

        public static PaymentListResultModel PaymentList(GenericSearchRequestModel request)
        {
            var result = new PaymentListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                Payments = new List<PaymentItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;
                    
                    var data = dm.Payments.ToList();
                    
                    foreach (var item in data)
                    {
                        PaymentItemResultModel payment = new PaymentItemResultModel
                        {
                            BalanceAfterPayment = item.BalanceAfterPayment,
                            PaymentDate = item.PaymentDate,
                            PaymentDescription = item.PaymentDescription,
                            PaymentId = item.PaymentId,
                            CustomerId = item.CustomerId,
                            PaymentAmount = item.PaymentAmount,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate
                        };
                        result.Payments.Add(payment);
                    }                    
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


        public static PaymentListResultModel SearchPaymentList(GenericSearchRequestModel request)
        {
            var result = new PaymentListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                Payments = new List<PaymentItemResultModel>()
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


                    var count = dm.Payments
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.PaymentDescription.Contains(searchCriteria)
                                                          )
                                )
                                //date from
                                && (dateFrom == null || b.PaymentDate >= dateFrom)
                                //date to
                                && (dateTo == null || b.PaymentDate <= dateTo)
                               ).OrderBy(orderingBy)
                         .Count();


                    var pages = Convert.ToInt32(Math.Floor((decimal)count / (decimal)pageSize));
                    if ((pages * pageSize) < count)
                    {
                        pages++;
                    }

                    var data = dm.Payments
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.PaymentDescription.Contains(searchCriteria)
                                                          )
                                )
                                //date from
                                && (dateFrom == null || b.PaymentDate >= dateFrom)
                                //date to
                                && (dateTo == null || b.PaymentDate <= dateTo)
                               ).OrderBy(orderingBy)
                        .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();


                    foreach (var item in data)
                    {
                        PaymentItemResultModel payment = new PaymentItemResultModel
                        {
                            BalanceAfterPayment = item.BalanceAfterPayment,
                            PaymentDate = item.PaymentDate,
                            PaymentDescription = item.PaymentDescription,
                            PaymentId = item.PaymentId,
                            CustomerId=item.CustomerId,
                            PaymentAmount = item.PaymentAmount,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate
                        };
                        result.Payments.Add(payment);
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

        public static PaymentItemResultModel GetPayment(PaymentRequestModel request)
        {
            var result = new PaymentItemResultModel
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

                    var paymentid = request.PaymentId;

                    var data = dm.Payments.Where(b => b.PaymentId == paymentid).FirstOrDefault();

                    result.CreatedByUserName = data.CreatedByUserName;
                    result.CreatedDate = data.CreatedDate;
                    result.UpdatedByUserName = data.UpdatedByUserName;
                    result.UpdatedDate = data.UpdatedDate;
                    result.BalanceAfterPayment = data.BalanceAfterPayment;
                    result.PaymentDate = data.PaymentDate;
                    result.PaymentDescription = data.PaymentDescription;
                    result.PaymentId = data.PaymentId;
                    result.CustomerId = data.CustomerId;
                    result.PaymentAmount = data.PaymentAmount;


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

        public static GenericItemResultModel WritePayment(PaymentRequestModel request)
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

                    var paymentid = request.PaymentId;

                    var data = (from a in dm.Payments
                                where a.PaymentId == paymentid
                                select a).FirstOrDefault();


                    if (data == null)
                    {
                        data = new Payment();
                        dm.Payments.Add(data);
                        result.Feedback = "Payment Successfully Added";
                    }
                    else
                    {
                        result.Feedback = "Edit Payment Successful";
                    }
                    data.CreatedByUserName = request.CreatedByUserName;
                    data.CreatedDate = request.CreatedDate;
                    data.UpdatedByUserName = request.UpdatedByUserName;
                    data.UpdatedDate = request.UpdatedDate;
                    data.BalanceAfterPayment = request.BalanceAfterPayment;
                    data.PaymentDate = request.PaymentDate;
                    data.PaymentDescription = request.PaymentDescription;
                    data.PaymentId = request.PaymentId;
                    data.CustomerId = request.CustomerId;
                    data.PaymentAmount = request.PaymentAmount;



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