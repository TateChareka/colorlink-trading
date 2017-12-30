﻿using System;
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

                    var data = dm.InvoicesVats
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

                        VatInvoiceItemResultModel vatinvoice = new VatInvoiceItemResultModel
                        {
                            ProductVat = new List<VatInvoiceProductItemResultModel>(),
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

                    var vatinvoiceid = request.InvoiceNumber;

                    var data = dm.InvoicesVats.Where(b => b.InvoiceNumber == vatinvoiceid).FirstOrDefault();

                    result.CreatedByUserName = data.CreatedByUserName;
                    result.CreatedDate = data.CreatedDate;
                    result.UpdatedByUserName = data.UpdatedByUserName;
                    result.UpdatedDate = data.UpdatedDate;
                    result.CustomerId = data.CustomerId;
                    result.DisplayValue = data.DisplayValue;
                    result.Discount = data.Discount;
                    result.ExtraDetails = data.ExtraDetails;
                    result.InvoiceDate = data.InvoiceDate;
                    result.InvoiceNumber = data.InvoiceNumber;
                    result.Reference = data.Reference;
                    result.SubTotal = data.SubTotal;
                    result.TotalAmount = data.TotalAmount;
                    result.VatAmount = data.VatAmount;
                    result.CustomerName = dm.Customers.Where(b => b.CustomerId == data.CustomerId).FirstOrDefault().CustomerName;
                    var vatProducts = dm.ProductInvoiceVats.Where(b => b.InvoiceNo == result.InvoiceNumber).ToList();
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
                                ProdId = vatproduct.ProdId,
                                ProductName = dm.Products.Where(b => b.ProductId == vatproduct.ProdId).FirstOrDefault().ProductName,
                                ProductInvoiceVatId = vatproduct.ProductInvoiceVatId,
                                Quantity = vatproduct.Quantity,
                                UnitPrice = vatproduct.UnitPrice,
                                UpdatedByUserName = vatproduct.UpdatedByUserName,
                                UpdatedDate = vatproduct.UpdatedDate
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

                    var vatinvoiceid = request.InvoiceNumber;

                    var data = (from a in dm.InvoicesVats
                                where a.InvoiceNumber == vatinvoiceid
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
                    data.VatAmount = request.VatAmount;

                    foreach (var vatproduct in request.ProductVat)
                    {
                        var productV = (from a in dm.ProductInvoiceVats
                                        where a.InvoiceNo == vatinvoiceid
                                        select a).FirstOrDefault();
                        if (productV == null)
                        {
                            productV = new ProductInvoiceVat();
                            dm.ProductInvoiceVats.Add(productV);
                        }

                        if (vatproduct.Quantity == 0)
                        {
                            productV.InvoiceNo = 0;
                            dm.ProductInvoiceVats.Remove(productV);
                        }
                        else
                        {
                            productV.InvoiceNo = vatproduct.InvoiceNo;
                        }

                        productV.Amount = vatproduct.Amount;
                        productV.CreatedByUserName = vatproduct.CreatedByUserName;
                        productV.CreatedDate = vatproduct.CreatedDate;
                        productV.InvoiceNo = vatproduct.InvoiceNo;
                        productV.ProdId = vatproduct.ProdId;
                        productV.ProductInvoiceVatId = vatproduct.ProductInvoiceVatId;
                        productV.Quantity = vatproduct.Quantity;
                        productV.UnitPrice = vatproduct.UnitPrice;
                        productV.UpdatedByUserName = vatproduct.UpdatedByUserName;
                        productV.UpdatedDate = vatproduct.UpdatedDate;
                        dm.SaveChanges();
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

    }
}