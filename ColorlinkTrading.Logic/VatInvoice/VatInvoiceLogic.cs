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
    public class VatInvoiceLogic
    {
        //timeout to make sure this completes
        public static int globalTimeOut = 600;

        public static int VatInvoiceCount(GenericRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                //timeout to make sure this completes
                dm.Database.CommandTimeout = globalTimeOut;
                var count = dm.InvoicesVats.Count();
                return count;
            }
        }

        public static VatInvoiceListResultModel VATInvoiceList(GenericSearchRequestModel request)
        {
            var result = new VatInvoiceListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                VatInvoices = new List<VatInvoiceItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var data = dm.InvoicesVats.ToList();
                    var customers = dm.Customers.ToList();
                    var products = dm.Products.ToList();


                    foreach (var item in data)
                    {

                        VatInvoiceItemResultModel vatinvoice = new VatInvoiceItemResultModel
                        {
                            ProductVat = new List<VatInvoiceProductItemResultModel>(),
                            CustomerId = item.CustomerId,
                            CustomerName = customers.Where(b => b.CustomerId == item.CustomerId).FirstOrDefault().CustomerName,
                            DisplayValue = item.DisplayValue,
                            Discount = item.Discount,
                            CreditValidation = item.CreditValidation,
                            ExtraDetails = item.ExtraDetails,
                            InvoiceDate = item.InvoiceDate,
                            InvoiceNumber = item.InvoiceNumber,
                            Reference = item.Reference,
                            SubTotal = item.SubTotal,
                            TotalAmount = item.TotalAmount,
                            VatAmount = item.VatAmount,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate,
                        };
                        result.VatInvoices.Add(vatinvoice);
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

        public static VatInvoiceListResultModel SearchVatInvoiceList(GenericSearchRequestModel request)
        {
            var result = new VatInvoiceListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                VatInvoices = new List<VatInvoiceItemResultModel>()
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


                    var count = dm.InvoicesVats
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.InvoiceNumber.Equals(searchCriteria)
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

                    var data = dm.InvoicesVats
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.InvoiceNumber.Equals(searchCriteria)
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

                        VatInvoiceItemResultModel vatinvoice = new VatInvoiceItemResultModel
                        {
                            ProductVat = new List<VatInvoiceProductItemResultModel>(),
                            CustomerId = item.CustomerId,
                            CustomerName = customers.Where(b => b.CustomerId == item.CustomerId).FirstOrDefault().CustomerName,
                            DisplayValue = item.DisplayValue,
                            Discount = item.Discount,
                            CreditValidation = item.CreditValidation,
                            ExtraDetails = item.ExtraDetails,
                            InvoiceDate = item.InvoiceDate,
                            InvoiceNumber = item.InvoiceNumber,
                            Reference = item.Reference,
                            SubTotal = item.SubTotal,
                            TotalAmount = item.TotalAmount,
                            VatAmount = item.VatAmount,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate,
                        };
                        var vatProducts = dm.ProductInvoiceVats.Where(b => b.InvoiceNo == vatinvoice.InvoiceNumber).ToList();
                        vatinvoice.NumberOfProducts = vatProducts.Count();
                        foreach (var vatproduct in vatProducts)
                        {
                            vatinvoice.ProductVat.Add(
                                new VatInvoiceProductItemResultModel()
                                {
                                    Amount = vatproduct.Amount,
                                    CreatedByUserName = vatproduct.CreatedByUserName,
                                    CreatedDate = vatproduct.CreatedDate,
                                    OldNumber = vatproduct.OLDNo,
                                    InvoiceNo = vatproduct.InvoiceNo,
                                    ProdId = vatproduct.ProdId,
                                    ProductName = products.Where(b => b.ProductId == vatproduct.ProdId).FirstOrDefault().ProductName,
                                    ProductInvoiceVatId = vatproduct.ProductInvoiceVatId,
                                    Quantity = vatproduct.Quantity,
                                    UnitPrice = vatproduct.UnitPrice,
                                    UpdatedByUserName = vatproduct.UpdatedByUserName,
                                    UpdatedDate = vatproduct.UpdatedDate
                                });
                        }
                        result.VatInvoices.Add(vatinvoice);
                    }
                    // result.NumberOfRecords = count;
                    // result.NumberOfPages = pages;
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

        public static VatInvoiceItemResultModel GetVatInvoice(VatInvoiceRequestModel request)
        {
            var result = new VatInvoiceItemResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                ProductVat = new List<VatInvoiceProductItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var vatinvoiceid = request.InvoiceNumber + "";

                    var data = dm.InvoicesVats.Where(b => b.DisplayValue == vatinvoiceid).FirstOrDefault();
                    result.CreatedByUserName = data.CreatedByUserName;
                    result.CreatedDate = data.CreatedDate;
                    result.UpdatedByUserName = data.UpdatedByUserName;
                    result.UpdatedDate = data.UpdatedDate;
                    result.CustomerId = data.CustomerId;
                    result.DisplayValue = data.DisplayValue;
                    result.Discount = data.Discount;
                    result.CreditValidation = data.CreditValidation;
                    result.ExtraDetails = data.ExtraDetails;
                    result.InvoiceDate = data.InvoiceDate;
                    result.InvoiceNumber = data.InvoiceNumber;
                    result.Reference = data.Reference;
                    result.SubTotal = data.SubTotal;
                    result.TotalAmount = data.TotalAmount;
                    result.CustomerName = dm.Customers.Where(b => b.CustomerId == data.CustomerId).FirstOrDefault().CustomerName;

                    var vatProducts = dm.ProductInvoiceVats.Where(b => b.InvoiceNo == Int32.Parse(data.DisplayValue)).ToList();

                    result.VatAmount = data.VatAmount;

                    var tate = true;
                    if (vatProducts != null)
                    {
                        result.NumberOfProducts = vatProducts.Count();
                        foreach (var vatproduct in vatProducts)
                        {
                            result.ProductVat.Add(
                                new VatInvoiceProductItemResultModel()
                                {
                                    Amount = vatproduct.Amount,
                                    CreatedByUserName = vatproduct.CreatedByUserName,
                                    CreatedDate = vatproduct.CreatedDate,
                                    InvoiceNo = vatproduct.InvoiceNo,
                                    OldNumber = vatproduct.OLDNo,
                                    ProdId = vatproduct.ProdId,
                                    ProductName = dm.Products.Where(b => b.ProductId == vatproduct.ProdId).FirstOrDefault().ProductName,
                                    ProductInvoiceVatId = vatproduct.ProductInvoiceVatId,
                                    Quantity = vatproduct.Quantity,
                                    UnitPrice = vatproduct.UnitPrice,
                                    UpdatedByUserName = vatproduct.UpdatedByUserName,
                                    UpdatedDate = vatproduct.UpdatedDate
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

        public static GenericItemResultModel WriteVatInvoice(VatInvoiceRequestModel request)
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

                    var vatinvoiceid = request.InvoiceNumber + "";

                    var data = (from a in dm.InvoicesVats
                                where a.DisplayValue == vatinvoiceid
                                select a).FirstOrDefault();

                    if (data == null)
                    {
                        data = new InvoicesVat();
                        dm.InvoicesVats.Add(data);
                        result.Feedback = "Invoice Successfully Added";
                    }
                    else
                    {
                        result.Feedback = "Edit Invoice Successful";
                    }

                    data.CustomerId = request.CustomerId;
                    data.DisplayValue = request.DisplayValue;
                    data.Discount = request.Discount;
                    data.ExtraDetails = request.ExtraDetails;
                    data.InvoiceDate = request.InvoiceDate;
                    data.InvoiceNumber = request.InvoiceNumber;
                    data.Reference = request.Reference;
                    data.SubTotal = request.SubTotal;
                    data.CreditValidation = request.CreditValidation;
                    data.TotalAmount = request.TotalAmount;
                    data.VatAmount = request.VatAmount;
                    resetVatProduct(request);

                    foreach (var item in request.ProductVat)
                    {
                        writeVatProduct(item, request, Int32.Parse(request.DisplayValue));
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

        private static void resetVatProduct(VatInvoiceRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                var data = (from a in dm.ProductInvoiceVats
                            where a.InvoiceNo == Int32.Parse(request.DisplayValue)
                            select a).ToList();
                foreach (var item in data)
                {
                    item.OLDNo = item.InvoiceNo + "";
                    item.InvoiceNo = 0;
                    dm.SaveChanges();
                }
            }
        }

        private static void writeVatProduct(VatInvoiceProductItemResultModel requestvatProducts, GenericRequestModel request, int invNo)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                var data = (from a in dm.ProductInvoiceVats
                            where a.ProductInvoiceVatId == requestvatProducts.ProductInvoiceVatId
                            select a).FirstOrDefault();

                if (data == null)
                {
                    data = new ProductInvoiceVat();
                    dm.ProductInvoiceVats.Add(data);
                }

                data.Amount = requestvatProducts.Amount;
                data.InvoiceNo = invNo;
                data.ProdId = requestvatProducts.ProdId;
                data.ProductInvoiceVatId = requestvatProducts.ProductInvoiceVatId;
                data.Quantity = requestvatProducts.Quantity;
                data.UnitPrice = requestvatProducts.UnitPrice;
                dm.SaveChanges();

            }
        }
    }
}