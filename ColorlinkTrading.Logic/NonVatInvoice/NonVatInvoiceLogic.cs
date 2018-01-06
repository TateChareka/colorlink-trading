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
    public class NonVatInvoiceLogic
    {
        //timeout to make sure this completes
        public static int globalTimeOut = 600;

        public static int NonVatInvoiceCount(GenericRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                //timeout to make sure this completes
                dm.Database.CommandTimeout = globalTimeOut;
                var count = dm.InvoiceNonVats.Count();
                return count;
            }
        }

        public static NonVatInvoiceListResultModel SearchNonVatInvoiceList(GenericSearchRequestModel request)
        {
            var result = new NonVatInvoiceListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                NonVatInvoices = new List<NonVatInvoiceItemResultModel>()
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


                    var count = dm.InvoiceNonVats
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

                    var data = dm.InvoiceNonVats
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
                        .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

                    var customers = dm.Customers.ToList();
                    var products = dm.Products.ToList();


                    foreach (var item in data)
                    {
                        NonVatInvoiceItemResultModel nonVat = new NonVatInvoiceItemResultModel
                        {
                            ProductNonVat = new List<NonVatInvoiceProductItemResultModel>(),
                            CustomerId = item.CustomerId,
                            CustomerName = customers.Where(b => b.CustomerId == item.CustomerId).FirstOrDefault().CustomerName,
                            DisplayValue = item.DisplayValue,
                            Discount = item.Discount,
                            ExtraDetails = item.ExtraDetails,
                            InvoiceDate = item.InvoiceDate,
                            InvoiceNumber = item.InvoiceNumber,
                            Reference = item.Reference,
                            SubTotal = item.SubTotal,
                            TotalAmount = item.TotalAmount,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate,
                        };
                        var nonVatProducts = dm.ProductInvoiceNonVats.Where(b => b.InvoiceNo == nonVat.InvoiceNumber).ToList();
                        nonVat.NumberOfProducts = nonVatProducts.Count();
                        foreach (var product in nonVatProducts)
                        {
                            nonVat.ProductNonVat.Add(
                                new NonVatInvoiceProductItemResultModel()
                                {
                                    Amount = product.Amount,
                                    CreatedByUserName = product.CreatedByUserName,
                                    CreatedDate = product.CreatedDate,
                                    InvoiceNo = product.InvoiceNo,
                                    ProdId = product.ProdId,
                                    ProductName = products.Where(b => b.ProductId == product.ProdId).FirstOrDefault().ProductName,
                                    ProductInvoiceNonVatId = product.ProductInvoiceNonVatId,
                                    Quantity = product.Quantity,
                                    UnitPrice = product.UnitPrice,
                                    UpdatedByUserName = product.UpdatedByUserName,
                                    UpdatedDate = product.UpdatedDate
                                });
                        }
                        result.NonVatInvoices.Add(nonVat);
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

        public static NonVatInvoiceListResultModel NonVatInvoiceList(GenericSearchRequestModel request)
        {
            var result = new NonVatInvoiceListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                NonVatInvoices = new List<NonVatInvoiceItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var data = dm.InvoiceNonVats.ToList();
                    var customers = dm.Customers.ToList();
                    var products = dm.Products.ToList();


                    foreach (var item in data)
                    {
                        NonVatInvoiceItemResultModel nonVat = new NonVatInvoiceItemResultModel
                        {
                            ProductNonVat = new List<NonVatInvoiceProductItemResultModel>(),
                            CustomerId = item.CustomerId,
                            CustomerName = customers.Where(b => b.CustomerId == item.CustomerId).FirstOrDefault().CustomerName,
                            DisplayValue = item.DisplayValue,
                            Discount = item.Discount,
                            ExtraDetails = item.ExtraDetails,
                            InvoiceDate = item.InvoiceDate,
                            InvoiceNumber = item.InvoiceNumber,
                            Reference = item.Reference,
                            SubTotal = item.SubTotal,
                            TotalAmount = item.TotalAmount,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate,
                        };
                        result.NonVatInvoices.Add(nonVat);
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

        public static NonVatInvoiceItemResultModel GetNonVatInvoice(NonVatInvoiceRequestModel request)
        {
            var result = new NonVatInvoiceItemResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                ProductNonVat = new List<NonVatInvoiceProductItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var nonvatInvoiceid = request.InvoiceNumber;

                    var data = dm.InvoiceNonVats.Where(b => b.InvoiceNumber == nonvatInvoiceid).FirstOrDefault();

                    result.CreatedByUserName = data.CreatedByUserName;
                    result.CreatedDate = data.CreatedDate;
                    result.UpdatedByUserName = data.UpdatedByUserName;
                    result.UpdatedDate = data.UpdatedDate;
                    result.CustomerId = data.CustomerId;
                    result.DisplayValue = data.DisplayValue;
                    result.Discount = data.Discount;
                    result.ExtraDetails = data.ExtraDetails;
                    result.InvoiceNumber = data.InvoiceNumber;
                    result.InvoiceDate = data.InvoiceDate;
                    result.Reference = data.Reference;
                    result.SubTotal = data.SubTotal;
                    result.TotalAmount = data.TotalAmount;
                    result.CustomerName = dm.Customers.Where(b => b.CustomerId == data.CustomerId).FirstOrDefault().CustomerName;
                    var nonVatProducts = dm.ProductInvoiceNonVats.Where(b => b.InvoiceNo == result.InvoiceNumber).ToList();
                    result.NumberOfProducts = nonVatProducts.Count();
                    foreach (var product in nonVatProducts)
                    {
                        result.ProductNonVat.Add(
                            new NonVatInvoiceProductItemResultModel()
                            {
                                Amount = product.Amount,
                                CreatedByUserName = product.CreatedByUserName,
                                CreatedDate = product.CreatedDate,
                                InvoiceNo = product.InvoiceNo,
                                ProdId = product.ProdId,
                                ProductName = dm.Products.Where(b => b.ProductId == product.ProdId).FirstOrDefault().ProductName,
                                ProductInvoiceNonVatId = product.ProductInvoiceNonVatId,
                                Quantity = product.Quantity,
                                UnitPrice = product.UnitPrice,
                                UpdatedByUserName = product.UpdatedByUserName,
                                UpdatedDate = product.UpdatedDate
                            });
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

        public static GenericItemResultModel WriteNonVat(NonVatInvoiceRequestModel request)
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

                    var nonvatid = request.InvoiceNumber;

                    var data = (from a in dm.InvoiceNonVats
                                where a.InvoiceNumber == nonvatid
                                select a).FirstOrDefault();

                    if (data == null)
                    {
                        data = new InvoiceNonVat();
                        dm.InvoiceNonVats.Add(data);
                        result.Feedback = "Invoice Successfully Added";
                    }
                    else
                    {
                        result.Feedback = "Edit Invoice Successful";
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
                    data.InvoiceNumber = request.InvoiceNumber;
                    data.Reference = request.Reference;
                    data.SubTotal = request.SubTotal;
                    data.TotalAmount = request.TotalAmount;

                    resetNonVatProduct(request);

                    foreach (var item in request.ProductNonVat)
                    {
                        writeNonVatProduct(item, request);
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
        private static void resetNonVatProduct(NonVatInvoiceRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                var data = (from a in dm.ProductInvoiceNonVats
                            where a.InvoiceNo == request.InvoiceNumber
                            select a).ToList();
                foreach (var item in data)
                {
                    item.OLDNo = item.InvoiceNo + "";
                    item.InvoiceNo = 0;
                    dm.SaveChanges();
                }
            }
        }

        private static void writeNonVatProduct(NonVatInvoiceProductItemResultModel requestvatProducts, GenericRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                var data = (from a in dm.ProductInvoiceNonVats
                            where a.ProductInvoiceNonVatId == requestvatProducts.ProductInvoiceNonVatId
                            select a).FirstOrDefault();

                if (data == null)
                {
                    data = new ProductInvoiceNonVat();
                    dm.ProductInvoiceNonVats.Add(data);
                }

                data.Amount = requestvatProducts.Amount;
                data.InvoiceNo = requestvatProducts.InvoiceNo;
                data.ProdId = requestvatProducts.ProdId;
                data.ProductInvoiceNonVatId = requestvatProducts.ProductInvoiceNonVatId;
                data.Quantity = requestvatProducts.Quantity;
                data.UnitPrice = requestvatProducts.UnitPrice;
                dm.SaveChanges();

            }
        }

    }
}