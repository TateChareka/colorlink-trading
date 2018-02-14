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
    public class QoutationLogic
    {
        //timeout to make sure this completes
        public static int globalTimeOut = 600;

        public static int QoutationCount(GenericRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                //timeout to make sure this completes
                dm.Database.CommandTimeout = globalTimeOut;
                var count = dm.Qoutations.Count();
                return count;
            }
        }

        public static QoutationListResultModel SearchQoutationList(GenericSearchRequestModel request)
        {
            var result = new QoutationListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                Qoutations = new List<QoutationItemResultModel>()
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


                    var count = dm.Qoutations
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.DisplayValue.Contains(searchCriteria)
                                                          )
                                )
                                //date from
                                && (dateFrom == null || b.InvoiceDate >= dateFrom)
                                //date to
                                && (dateTo == null || b.InvoiceDate <= dateTo)
                               ).OrderBy(orderingBy)
                         .Count();


                    var pages = Convert.ToInt32(Math.Floor((decimal)count / (decimal)pageSize));
                    if ((pages * pageSize) < count)
                    {
                        pages++;
                    }

                    var data = dm.Qoutations
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.DisplayValue.Contains(searchCriteria)
                                                          )
                                )
                                //date from
                                && (dateFrom == null || b.InvoiceDate >= dateFrom)
                                //date to
                                && (dateTo == null || b.InvoiceDate <= dateTo)
                               ).ToList();

                    var customers = dm.Customers.ToList();
                    var products = dm.Products.ToList();


                    foreach (var item in data)
                    {

                        QoutationItemResultModel qoutation = new QoutationItemResultModel
                        {
                            ProductQoutations = new List<QoutationProductItemResultModel>(),
                            CustomerId = item.CustomerId,
                            CustomerName = customers.Where(b => b.CustomerId == item.CustomerId).FirstOrDefault().CustomerName,
                            DisplayValue = item.DisplayValue,
                            Discount = item.Discount,
                            ExtraDetails = item.ExtraDetails,
                            InvoiceDate = item.InvoiceDate,
                            QouteNumber = item.QouteNumber,
                            Reference = item.Reference,
                            SubTotal = item.SubTotal,
                            TotalAmount = item.TotalAmount,
                            VatAmount = item.VatAmount,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate,
                        };
                        var qouteProducts = dm.ProductQoutes.Where(b => b.QouteNo == qoutation.QouteNumber).ToList();
                        qoutation.NumberOfProducts = qouteProducts.Count();
                        foreach (var qouteproduct in qouteProducts)
                        {
                            qoutation.ProductQoutations.Add(
                                new QoutationProductItemResultModel()
                                {
                                    Amount = qouteproduct.Amount,
                                    CreatedByUserName = qouteproduct.CreatedByUserName,
                                    CreatedDate = qouteproduct.CreatedDate,
                                    QouteNo = qouteproduct.QouteNo,
                                    ProdId = qouteproduct.ProdId,
                                    ProductName = products.Where(b => b.ProductId == qouteproduct.ProdId).FirstOrDefault().ProductName,
                                    ProductQouteId = qouteproduct.ProductQouteId,
                                    Quantity = qouteproduct.Quantity,
                                    UnitPrice = qouteproduct.UnitPrice,
                                    UpdatedByUserName = qouteproduct.UpdatedByUserName,
                                    UpdatedDate = qouteproduct.UpdatedDate
                                });
                        }
                        result.Qoutations.Add(qoutation);
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

        public static QoutationListResultModel QoutationList(GenericSearchRequestModel request)
        {
            var result = new QoutationListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                Qoutations = new List<QoutationItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var data = dm.Qoutations.ToList();
                    var customers = dm.Customers.ToList();
                    var products = dm.Products.ToList();


                    foreach (var item in data)
                    {

                        QoutationItemResultModel qoutation = new QoutationItemResultModel
                        {
                            ProductQoutations = new List<QoutationProductItemResultModel>(),
                            CustomerId = item.CustomerId,
                            CustomerName = customers.Where(b => b.CustomerId == item.CustomerId).FirstOrDefault().CustomerName,
                            DisplayValue = item.DisplayValue,
                            Discount = item.Discount,
                            ExtraDetails = item.ExtraDetails,
                            InvoiceDate = item.InvoiceDate,
                            QouteNumber = item.QouteNumber,
                            Reference = item.Reference,
                            SubTotal = item.SubTotal,
                            TotalAmount = item.TotalAmount,
                            VatAmount = item.VatAmount,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate,
                        };
                        result.Qoutations.Add(qoutation);
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

        public static QoutationItemResultModel GetQoutation(QoutationRequestModel request)
        {
            var result = new QoutationItemResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                ProductQoutations = new List<QoutationProductItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var qouteid = request.QouteNumber+"";

                    var data = dm.Qoutations.Where(b => b.DisplayValue == qouteid).FirstOrDefault();

                    result.CreatedByUserName = data.CreatedByUserName;
                    result.CreatedDate = data.CreatedDate;
                    result.UpdatedByUserName = data.UpdatedByUserName;
                    result.UpdatedDate = data.UpdatedDate;
                    result.CustomerId = data.CustomerId;
                    result.DisplayValue = data.DisplayValue;
                    result.Discount = data.Discount;
                    result.ExtraDetails = data.ExtraDetails;
                    result.InvoiceDate = data.InvoiceDate;
                    result.QouteNumber = data.QouteNumber;
                    result.Reference = data.Reference;
                    result.SubTotal = data.SubTotal;
                    result.TotalAmount = data.TotalAmount;
                    result.VatAmount = data.VatAmount;
                    result.CustomerName = dm.Customers.Where(b => b.CustomerId == data.CustomerId).FirstOrDefault().CustomerName;
                    var invNo = Int32.Parse(data.DisplayValue.Trim());
                    var qouteProducts = dm.ProductQoutes.Where(b => b.QouteNo == invNo).ToList();
                    if (qouteProducts != null)
                    {
                        result.NumberOfProducts = qouteProducts.Count();
                        foreach (var qouteproduct in qouteProducts)
                        {
                            result.ProductQoutations.Add(
                                new QoutationProductItemResultModel()
                                {
                                    Amount = qouteproduct.Amount,
                                    CreatedByUserName = qouteproduct.CreatedByUserName,
                                    CreatedDate = qouteproduct.CreatedDate,
                                    QouteNo = qouteproduct.QouteNo,
                                    ProdId = qouteproduct.ProdId,
                                    ProductName = dm.Products.Where(b => b.ProductId == qouteproduct.ProdId).FirstOrDefault().ProductName,
                                    ProductQouteId = qouteproduct.ProductQouteId,
                                    Quantity = qouteproduct.Quantity,
                                    UnitPrice = qouteproduct.UnitPrice,
                                    UpdatedByUserName = qouteproduct.UpdatedByUserName,
                                    UpdatedDate = qouteproduct.UpdatedDate
                                });
                        }
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

        public static GenericItemResultModel WriteQoutation(QoutationRequestModel request)
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

                    var qouteid = request.QouteNumber+"";

                    var data = (from a in dm.Qoutations
                                where a.DisplayValue == qouteid
                                select a).FirstOrDefault();

                    if (data == null)
                    {
                        data = new Qoutation();
                        dm.Qoutations.Add(data);
                        result.Feedback = "Qouation Successfully Added";
                    }
                    else
                    {
                        result.Feedback = "Edit Qoutation Successful";
                    }

                    data.CreatedByUserName = request.CreatedByUserName;
                    data.CreatedDate = request.CreatedDate;
                    data.UpdatedByUserName = request.UpdatedByUserName;
                    data.UpdatedDate = request.UpdatedDate;
                    data.CustomerId = request.CustomerId;
                    data.DisplayValue = request.DisplayValue;
                    data.Discount = request.Discount;
                    data.ExtraDetails = request.ExtraDetails;
                    data.InvoiceDate = request.InvoiceDate;
                    data.QouteNumber = request.QouteNumber;
                    data.Reference = request.Reference;
                    data.SubTotal = request.SubTotal;
                    data.TotalAmount = request.TotalAmount;
                    data.VatAmount = request.VatAmount;

                    resetQouteProduct(request);

                    foreach (var item in request.ProductQoutations)
                    {
                        writeQouteProduct(item, request, Int32.Parse(request.DisplayValue));
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
        private static void resetQouteProduct(QoutationRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                var data = (from a in dm.ProductQoutes
                            where a.QouteNo == Int32.Parse(request.DisplayValue)
                            select a).ToList();
                foreach (var item in data)
                {
                    item.OLDNo = item.QouteNo + "";
                    item.QouteNo = 0;
                    dm.SaveChanges();
                }
            }
        }

        private static void writeQouteProduct(QoutationProductItemResultModel requestvatProducts, GenericRequestModel request,int invNo)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                var data = (from a in dm.ProductQoutes
                            where a.ProductQouteId == requestvatProducts.ProductQouteId
                            select a).FirstOrDefault();

                if (data == null)
                {
                    data = new ProductQoute();
                    dm.ProductQoutes.Add(data);
                }

                data.Amount = requestvatProducts.Amount;
                data.QouteNo = invNo;
                data.ProdId = requestvatProducts.ProdId;
                data.ProductQouteId = requestvatProducts.ProductQouteId;
                data.Quantity = requestvatProducts.Quantity;
                data.UnitPrice = requestvatProducts.UnitPrice;
                dm.SaveChanges();

            }
        }


    }
}