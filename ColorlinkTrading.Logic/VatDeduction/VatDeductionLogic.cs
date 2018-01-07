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
    public class VatDeductionLogic
    {
        //timeout to make sure this completes
        public static int globalTimeOut = 300;

        public static int VatDeductionCount(GenericRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                //timeout to make sure this completes
                dm.Database.CommandTimeout = globalTimeOut;
                var count = dm.VATDeductions.Count();
                return count;
            }
        }

        public static VATDeductionListResultModel VatDeductionList(GenericSearchRequestModel request)
        {
            var result = new VATDeductionListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                VATDeductions = new List<VATDeductionItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;
                    var data = dm.VATDeductions.ToList();

                    foreach (var item in data)
                    {
                        VATDeductionItemResultModel vatdeduction = new VATDeductionItemResultModel
                        {
                            TransactionDate = item.TransactionDate,
                            VatAmount = item.VatAmount,
                            VATDeductionDescription = item.VATDeductionDescription,
                            VATDeductionId = item.VATDeductionId,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate
                        };
                        result.VATDeductions.Add(vatdeduction);
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


        public static VATDeductionListResultModel SearchVatDeductionList(GenericSearchRequestModel request)
        {
            var result = new VATDeductionListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                VATDeductions = new List<VATDeductionItemResultModel>()
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


                    var count = dm.VATDeductions
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.VATDeductionDescription.Contains(searchCriteria)
                                                          )
                                )
                                //date from
                                && (dateFrom == null || b.TransactionDate >= dateFrom)
                                //date to
                                && (dateTo == null || b.TransactionDate <= dateTo)
                               ).OrderBy(orderingBy)
                         .Count();


                    var pages = Convert.ToInt32(Math.Floor((decimal)count / (decimal)pageSize));
                    if ((pages * pageSize) < count)
                    {
                        pages++;
                    }

                    var data = dm.VATDeductions
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.VATDeductionDescription.Contains(searchCriteria)
                                                          )
                                )
                                //date from
                                && (dateFrom == null || b.TransactionDate >= dateFrom)
                                //date to
                                && (dateTo == null || b.TransactionDate <= dateTo)
                               ).ToList();


                    foreach (var item in data)
                    {
                        VATDeductionItemResultModel vatdeduction = new VATDeductionItemResultModel
                        {
                            TransactionDate = item.TransactionDate,
                            VatAmount = item.VatAmount,
                            VATDeductionDescription = item.VATDeductionDescription,
                            VATDeductionId = item.VATDeductionId,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate
                        };
                        result.VATDeductions.Add(vatdeduction);
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

        public static VATDeductionItemResultModel GetVATDeduction(VATDeductionRequestModel request)
        {
            var result = new VATDeductionItemResultModel
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

                    var vatdeductionid = request.VATDeductionId;

                    var data = dm.VATDeductions.Where(b => b.VATDeductionId == vatdeductionid).FirstOrDefault();

                    result.CreatedByUserName = data.CreatedByUserName;
                    result.CreatedDate = data.CreatedDate;
                    result.UpdatedByUserName = data.UpdatedByUserName;
                    result.UpdatedDate = data.UpdatedDate;
                    result.TransactionDate = data.TransactionDate;
                    result.VatAmount = data.VatAmount;
                    result.VATDeductionDescription = data.VATDeductionDescription;
                    result.VATDeductionId = data.VATDeductionId;


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

        public static GenericItemResultModel WriteVatDeduction(VATDeductionRequestModel request)
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

                    var vatdeductionid = request.VATDeductionId;

                    var data = (from a in dm.VATDeductions
                                where a.VATDeductionId == vatdeductionid
                                select a).FirstOrDefault();


                    if (data == null)
                    {
                        data = new VATDeduction();
                        dm.VATDeductions.Add(data);
                        result.Feedback = "Deduction Successfully Added";
                    }
                    else
                    {
                        result.Feedback = "Edit Deduction Successful";
                    }
                    data.CreatedByUserName = request.CreatedByUserName;
                    data.CreatedDate = request.CreatedDate;
                    data.UpdatedByUserName = request.UpdatedByUserName;
                    data.UpdatedDate = request.UpdatedDate;
                    data.TransactionDate = request.TransactionDate;
                    data.VatAmount = request.VatAmount;
                    data.VATDeductionDescription = request.VATDeductionDescription;
                    data.VATDeductionId = request.VATDeductionId;



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

        public static ZimraStatementListResultModel ZimraStatementList(GenericSearchRequestModel request)
        {
            var result = new ZimraStatementListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                ZimraStatement = new List<ZimraStatementItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var data = dm.ZimraStatements.ToList();
                    var customers = dm.Customers.ToList();
                    var statementDetails = dm.ZimraStatementsDetails.ToList();

                    foreach (var item in data)
                    {

                        ZimraStatementItemResultModel zimraStatement = new ZimraStatementItemResultModel
                        {
                            AmountDue = item.AmountDue,
                            EndDate = item.EndDate,                              
                            StartDate = item.StartDate,
                            StatementId = item.StatementId,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate,
                            ZimraStatementDetails = new List<ZimraStateDetailsItemResultModel>()
                        };
                        var statements = statementDetails.Where(b => b.StatementId == zimraStatement.StatementId).ToList();
                        foreach (var requestVatProduct in statements)
                        {
                            ZimraStateDetailsItemResultModel statementDet = new ZimraStateDetailsItemResultModel
                            {
                                CreatedByUserName = requestVatProduct.CreatedByUserName,
                                CreatedDate = requestVatProduct.CreatedDate,
                                UpdatedByUserName = requestVatProduct.UpdatedByUserName,
                                UpdatedDate = requestVatProduct.UpdatedDate,
                                TransactionDate = requestVatProduct.TransactionDate,
                                StatementId = requestVatProduct.StatementId,
                                StatementBalance = requestVatProduct.StatementBALANCE,
                                StatementCREDIT = requestVatProduct.StatementCREDIT,
                                StatementDEBIT = requestVatProduct.StatementDEBIT,
                                StatementDescription = requestVatProduct.StatementDescription
                            };
                            zimraStatement.ZimraStatementDetails.Add(statementDet);
                        }
                        result.ZimraStatement.Add(zimraStatement);
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

        public static ZimraStatementItemResultModel GetZimraStatement(ZimraStatementRequestModel request)
        {
            var result = new ZimraStatementItemResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                ZimraStatementDetails = new List<ZimraStateDetailsItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var statementid = request.StatementId;

                    var data = dm.ZimraStatements.Where(b => b.StatementId == statementid).FirstOrDefault();

                    result.CreatedByUserName = data.CreatedByUserName;
                    result.CreatedDate = data.CreatedDate;
                    result.UpdatedByUserName = data.UpdatedByUserName;
                    result.UpdatedDate = data.UpdatedDate;
                    result.AmountDue = data.AmountDue;
                    result.EndDate = data.EndDate;
                    result.StartDate = data.StartDate;
                    result.StatementId = data.StatementId;
                    result.ZimraStatementDetails = new List<ZimraStateDetailsItemResultModel>();

                    var statements = dm.ZimraStatementsDetails.Where(b => b.StatementId == statementid).ToList();
                    foreach (var requestVatProduct in statements)
                    {
                        ZimraStateDetailsItemResultModel statementDet = new ZimraStateDetailsItemResultModel
                        {
                            CreatedByUserName = requestVatProduct.CreatedByUserName,
                            CreatedDate = requestVatProduct.CreatedDate,
                            UpdatedByUserName = requestVatProduct.UpdatedByUserName,
                            UpdatedDate = requestVatProduct.UpdatedDate,
                            TransactionDate = requestVatProduct.TransactionDate,
                            StatementId = requestVatProduct.StatementId,
                            ZimraStatementId = requestVatProduct.ZimraStatementId,
                            StatementBalance = requestVatProduct.StatementBALANCE,
                            StatementCREDIT = requestVatProduct.StatementCREDIT,
                            StatementDEBIT = requestVatProduct.StatementDEBIT,
                            StatementDescription = requestVatProduct.StatementDescription
                        };
                        result.ZimraStatementDetails.Add(statementDet);
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

        public static GenericItemResultModel WriteZimraStatement(ZimraStatementRequestModel request)
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

                    var statementid = request.StatementId;

                    var data = (from a in dm.ZimraStatements
                                where a.StatementId == statementid
                                select a).FirstOrDefault();

                    if (data == null)
                    {
                        data = new ZimraStatement();
                        dm.ZimraStatements.Add(data);
                        result.Feedback = "Zimra Statement Successfully Added";
                    }
                    else
                    {
                        result.Feedback = "Edit Zimra Statement Successful";
                    }

                    data.CreatedByUserName = request.CreatedByUserName;
                    data.CreatedDate = request.CreatedDate;
                    data.UpdatedByUserName = request.UpdatedByUserName;
                    data.UpdatedDate = request.UpdatedDate;
                    data.AmountDue = request.AmountDue;
                    data.EndDate = request.EndDate;
                    data.StartDate = request.StartDate;
                    data.StatementId = request.StatementId;

                    foreach (var item in request.ZimraStatementDetails)
                    {
                        writeStatementDetails(item, request);
                    }
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

        private static void writeStatementDetails(ZimraStateDetailsItemResultModel requestVatProduct, GenericRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                var data = (from a in dm.ZimraStatementsDetails
                            where a.ZimraStatementId == requestVatProduct.ZimraStatementId
                            select a).FirstOrDefault();

                if (data == null)
                {
                    data = new ZimraStatementsDetail();
                    dm.ZimraStatementsDetails.Add(data);
                }

                data.TransactionDate = requestVatProduct.TransactionDate;
                data.StatementBALANCE = requestVatProduct.StatementBalance;
                data.StatementCREDIT = requestVatProduct.StatementCREDIT;
                data.StatementDEBIT = requestVatProduct.StatementDEBIT;
                data.StatementId = requestVatProduct.StatementId;
                data.ZimraStatementId = requestVatProduct.ZimraStatementId;
                data.StatementDescription = requestVatProduct.StatementDescription;
                dm.SaveChanges();

            }
        }

    }
}