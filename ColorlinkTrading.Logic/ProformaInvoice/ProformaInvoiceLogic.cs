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
    public class ProformaInvoiceLogic
    {
        //timeout to make sure this completes
        public static int globalTimeOut = 600;

        public static int ProformaInvoiceCount(GenericRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                //timeout to make sure this completes
                dm.Database.CommandTimeout = globalTimeOut;
                var count = dm.ProformaInvoices.Count();
                return count;
            }
        }

        public static ProformaListResultModel SearchProformaList(GenericSearchRequestModel request)
        {
            var result = new ProformaListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                ProformaInvoices = new List<ProformaItemResultModel>()
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


                    var count = dm.ProformaInvoices
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.DisplayValue.Contains(searchCriteria)
                                                          )
                                )
                                //date from
                                && (dateFrom == null || b.ProformaDate >= dateFrom)
                                //date to
                                && (dateTo == null || b.ProformaDate <= dateTo)
                               ).OrderBy(orderingBy)
                         .Count();


                    var pages = Convert.ToInt32(Math.Floor((decimal)count / (decimal)pageSize));
                    if ((pages * pageSize) < count)
                    {
                        pages++;
                    }

                    var data = dm.ProformaInvoices
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.DisplayValue.Contains(searchCriteria)
                                                          )
                                )
                                //date from
                                && (dateFrom == null || b.ProformaDate >= dateFrom)
                                //date to
                                && (dateTo == null || b.ProformaDate <= dateTo)
                               ).OrderBy(orderingBy)
                        .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

                    var customers = dm.Customers.ToList();
                    var products = dm.Products.ToList();


                    foreach (var item in data)
                    {
                        ProformaItemResultModel proforma = new ProformaItemResultModel
                        {
                            ProductProforma = new List<ProformaProductItemResultModel>(),
                            CustomerId = item.CustomerId,
                            CustomerName = customers.Where(b => b.CustomerId == item.CustomerId).FirstOrDefault().CustomerName,
                            DisplayValue = item.DisplayValue,
                            Discount = item.Discount,
                            ExtraDetails = item.ExtraDetails,
                            ProformaDate = item.ProformaDate,
                            ProformaNumber = item.ProformaNumber,
                            Reference = item.Reference,
                            SubTotal = item.SubTotal,
                            TotalAmount = item.TotalAmount,
                            VatAmount = item.VatAmount,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate,
                        };
                        var proformaProducts = dm.ProductProformas.Where(b => b.ProfornaNo == proforma.ProformaNumber).ToList();
                        proforma.NumberOfProducts = proformaProducts.Count();
                        foreach (var proformaproduct in proformaProducts)
                        {
                            proforma.ProductProforma.Add(
                                new ProformaProductItemResultModel()
                                {
                                    Amount = proformaproduct.Amount,
                                    CreatedByUserName = proformaproduct.CreatedByUserName,
                                    CreatedDate = proformaproduct.CreatedDate,
                                    ProformaNo = proformaproduct.ProfornaNo,
                                    ProdId = proformaproduct.ProdId,
                                    ProductName = products.Where(b => b.ProductId == proformaproduct.ProdId).FirstOrDefault().ProductName,
                                    ProductProformaId = proformaproduct.ProductProformaId,
                                    Quantity = proformaproduct.Quantity,
                                    UnitPrice = proformaproduct.UnitPrice,
                                    UpdatedByUserName = proformaproduct.UpdatedByUserName,
                                    UpdatedDate = proformaproduct.UpdatedDate
                                });
                        }
                        result.ProformaInvoices.Add(proforma);
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

        public static ProformaItemResultModel GetProforma(ProformaRequestModel request)
        {
            var result = new ProformaItemResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                ProductProforma = new List<ProformaProductItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var proformid = request.ProformaNumber;

                    var data = dm.ProformaInvoices.Where(b => b.ProformaNumber == proformid).FirstOrDefault();

                    result.CreatedByUserName = data.CreatedByUserName;
                    result.CreatedDate = data.CreatedDate;
                    result.UpdatedByUserName = data.UpdatedByUserName;
                    result.UpdatedDate = data.UpdatedDate;
                    result.CustomerId = data.CustomerId;
                    result.DisplayValue = data.DisplayValue;
                    result.Discount = data.Discount;
                    result.ExtraDetails = data.ExtraDetails;
                    result.ProformaDate = data.ProformaDate;
                    result.ProformaNumber = data.ProformaNumber;
                    result.Reference = data.Reference;
                    result.SubTotal = data.SubTotal;
                    result.TotalAmount = data.TotalAmount;
                    result.VatAmount = data.VatAmount;
                    result.CustomerName = dm.Customers.Where(b => b.CustomerId == data.CustomerId).FirstOrDefault().CustomerName;
                    var proformaProducts = dm.ProductProformas.Where(b => b.ProfornaNo == result.ProformaNumber).ToList();
                    result.NumberOfProducts = proformaProducts.Count();
                    foreach (var proformaproduct in proformaProducts)
                    {
                        result.ProductProforma.Add(
                            new ProformaProductItemResultModel()
                            {
                                Amount = proformaproduct.Amount,
                                CreatedByUserName = proformaproduct.CreatedByUserName,
                                CreatedDate = proformaproduct.CreatedDate,
                                ProformaNo = proformaproduct.ProfornaNo,
                                ProdId = proformaproduct.ProdId,
                                ProductName = dm.Products.Where(b => b.ProductId == proformaproduct.ProdId).FirstOrDefault().ProductName,
                                ProductProformaId = proformaproduct.ProductProformaId,
                                Quantity = proformaproduct.Quantity,
                                UnitPrice = proformaproduct.UnitPrice,
                                UpdatedByUserName = proformaproduct.UpdatedByUserName,
                                UpdatedDate = proformaproduct.UpdatedDate
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

        public static GenericItemResultModel WriteProforma(ProformaRequestModel request)
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

                    var proformaid = request.ProformaNumber;

                    var data = (from a in dm.ProformaInvoices
                                where a.ProformaNumber == proformaid
                                select a).FirstOrDefault();

                    if (data == null)
                    {
                        data = new ProformaInvoice();
                        dm.ProformaInvoices.Add(data);
                        result.Feedback = "Proforma Successfully Added";
                    }
                    else
                    {
                        result.Feedback = "Edit Proforma Successful";
                    }

                    data.CreatedByUserName = request.CreatedByUserName;
                    data.CreatedDate = request.CreatedDate;
                    data.UpdatedByUserName = request.UpdatedByUserName;
                    data.UpdatedDate = request.UpdatedDate;
                    data.CustomerId = request.CustomerId;
                    data.DisplayValue = request.DisplayValue;
                    data.Discount = request.Discount;
                    data.ExtraDetails = request.ExtraDetails;
                    data.ProformaDate = request.ProformaDate;
                    data.ProformaNumber = request.ProformaNumber;
                    data.Reference = request.Reference;
                    data.SubTotal = request.SubTotal;
                    data.TotalAmount = request.TotalAmount;
                    data.VatAmount = request.VATAmount;

                    foreach (var proformaproduct in request.ProductProforma)
                    {
                        var productV = (from a in dm.ProductProformas
                                        where a.ProfornaNo == proformaid
                                        select a).FirstOrDefault();
                        if (productV == null)
                        {
                            productV = new ProductProforma();
                            dm.ProductProformas.Add(productV);
                        }

                        if (proformaproduct.Quantity == 0)
                        {
                            productV.ProfornaNo = 0;
                            dm.ProductProformas.Remove(productV);
                        }
                        else
                        {
                            productV.ProfornaNo = proformaproduct.ProformaNo;
                        }

                        productV.Amount = proformaproduct.Amount;
                        productV.CreatedByUserName = proformaproduct.CreatedByUserName;
                        productV.CreatedDate = proformaproduct.CreatedDate;
                        productV.ProfornaNo = proformaproduct.ProformaNo;
                        productV.ProdId = proformaproduct.ProdId;
                        productV.ProductProformaId = proformaproduct.ProductProformaId;
                        productV.Quantity = proformaproduct.Quantity;
                        productV.UnitPrice = proformaproduct.UnitPrice;
                        productV.UpdatedByUserName = proformaproduct.UpdatedByUserName;
                        productV.UpdatedDate = proformaproduct.UpdatedDate;
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