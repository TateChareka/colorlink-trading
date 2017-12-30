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
    public class ProductLogic
    {
        //timeout to make sure this completes
        public static int globalTimeOut = 300;

        public static int ProductCount(GenericRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                //timeout to make sure this completes
                dm.Database.CommandTimeout = globalTimeOut;
                var count = dm.Products.Count();
                return count;
            }
        }

        public static ProductListResultModel SearchProductList(GenericSearchRequestModel request)
        {
            var result = new ProductListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                Products = new List<ProductItemResultModel>()
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


                    var count = dm.Products
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.ProductName.Contains(searchCriteria)
                                                          )
                                )
                                //date from
                                && (dateFrom == null || b.CreatedDate >= dateFrom)
                                //date to
                                && (dateTo == null || b.CreatedDate <= dateTo)
                               ).OrderBy(orderingBy)
                         .Count();


                    var pages = Convert.ToInt32(Math.Floor((decimal)count / (decimal)pageSize));
                    if ((pages * pageSize) < count)
                    {
                        pages++;
                    }

                    var data = dm.Products
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.ProductName.Contains(searchCriteria)
                                                          )
                                )
                                //date from
                                && (dateFrom == null || b.CreatedDate >= dateFrom)
                                //date to
                                && (dateTo == null || b.CreatedDate <= dateTo)
                               ).OrderBy(orderingBy)
                        .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();


                    foreach (var item in data)
                    {
                        ProductItemResultModel product = new ProductItemResultModel
                        {
                            CashPrice = item.CashPrice,
                            MarkUpPercentage = item.MarkUpPercentage,
                            PriceIncVat = item.PriceIncVat,
                            ProductId = item.ProductId,
                            ProductName = item.ProductName,
                            Comments = item.Comments,
                            CompetitorDetails = item.CompetitorDetails,
                            CompetitorPrice = item.CompetitorPrice,
                            ExchangeRate = item.ExchangeRate,
                            RandPricePostMarkup = item.RandPricePostMarkup,
                            RandPricePostVat = item.RandPricePostVat,
                            RandPricePreVat = item.RandPricePreVat,
                            VatAmount = item.VatAmount,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate
                        };
                        result.Products.Add(product);
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

        public static ProductItemResultModel GetProduct(ProductRequestModel request)
        {
            var result = new ProductItemResultModel
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

                    var productid = request.ProductId;

                    var data = dm.Products.Where(b => b.ProductId == productid).FirstOrDefault();

                    result.CreatedByUserName = data.CreatedByUserName;
                    result.CreatedDate = data.CreatedDate;
                    result.UpdatedByUserName = data.UpdatedByUserName;
                    result.UpdatedDate = data.UpdatedDate;
                    result.CashPrice = data.CashPrice;
                    result.MarkUpPercentage = data.MarkUpPercentage;
                    result.PriceIncVat = data.PriceIncVat;
                    result.ProductId = data.ProductId;
                    result.ProductName = data.ProductName;
                    result.Comments = data.Comments;
                    result.CompetitorDetails = data.CompetitorDetails;
                    result.CompetitorPrice = data.CompetitorPrice;
                    result.ExchangeRate = data.ExchangeRate;
                    result.RandPricePostMarkup = data.RandPricePostMarkup;
                    result.RandPricePostVat = data.RandPricePostVat;
                    result.RandPricePreVat = data.RandPricePreVat;
                    result.VatAmount = data.VatAmount;


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

        public static GenericItemResultModel WriteProduct(ProductRequestModel request)
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

                    var productid = request.ProductId;

                    var data = (from a in dm.Products
                                where a.ProductId == productid
                                select a).FirstOrDefault();


                    if (data == null)
                    {
                        data = new Product();
                        dm.Products.Add(data);
                        result.Feedback = "Product Successfully Added";
                    }
                    else
                    {
                        result.Feedback = "Edit Product Successful";
                    }

                    data.CashPrice = request.CashPrice;
                    data.MarkUpPercentage = request.MarkUpPercentage;
                    data.PriceIncVat = request.PriceIncVat;
                    data.ProductId = request.ProductId;
                    data.ProductName = request.ProductName;
                    data.Comments = request.Comments;
                    data.CompetitorDetails = request.CompetitorDetails;
                    data.CompetitorPrice = request.CompetitorPrice;
                    data.ExchangeRate = request.ExchangeRate;
                    data.RandPricePostMarkup = request.RandPricePostMarkup;
                    data.RandPricePostVat = request.RandPricePostVat;
                    data.RandPricePreVat = request.RandPricePreVat;
                    data.VatAmount = request.VatAmount;

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

        public static ProductItemResultModel ValidateProduct(ProductRequestModel request)
        {
            var result = new ProductItemResultModel
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

                    var productId = request.ProductId;

                    var data = dm.Products.Where(b =>
                                //search criteria
                                (
                                  b.ProductName.Equals(request.ProductName)
                                )).FirstOrDefault();

                    if (data != null)
                    {
                        result.CreatedByUserName = data.CreatedByUserName;
                        result.CreatedDate = data.CreatedDate;
                        result.UpdatedByUserName = data.UpdatedByUserName;
                        result.UpdatedDate = data.UpdatedDate;
                        result.CashPrice = data.CashPrice;
                        result.MarkUpPercentage = data.MarkUpPercentage;
                        result.PriceIncVat = data.PriceIncVat;
                        result.ProductId = data.ProductId;
                        result.ProductName = data.ProductName;
                        result.Comments = data.Comments;
                        result.CompetitorDetails = data.CompetitorDetails;
                        result.CompetitorPrice = data.CompetitorPrice;
                        result.ExchangeRate = data.ExchangeRate;
                        result.RandPricePostMarkup = data.RandPricePostMarkup;
                        result.RandPricePostVat = data.RandPricePostVat;
                        result.RandPricePreVat = data.RandPricePreVat;
                        result.VatAmount = data.VatAmount;
                        return result;
                    }
                    else
                    {
                        result.ProductId = null;
                    }
                    return result;
                    
                }
            }
            catch (Exception error)
            {
                Console.Write(error.ToString());
                var errorState = ErrorHandling.HandleError(error);
                result.Feedback = errorState.ErrorMessage;
                result.IsValidationError = errorState.IsValidationError;
                result.HasError = true;
            }
            return result;
        }

    }
}