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
    public class DeliveryNoteLogic
    {
        //timeout to make sure this completes
        public static int globalTimeOut = 600;

        public static int DeliveryNoteCount(GenericRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                //timeout to make sure this completes
                dm.Database.CommandTimeout = globalTimeOut;
                var count = dm.DeliveryNotes.Count();
                return count;
            }
        }

        public static DNoteListResultModel DeliveryNoteList(GenericSearchRequestModel request)
        {
            var result = new DNoteListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                DeliveryNotes = new List<DNoteItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var data = dm.DeliveryNotes.ToList();
                    var customers = dm.Customers.ToList();
                    var products = dm.Products.ToList();


                    foreach (var item in data)
                    {

                        DNoteItemResultModel deliveryNote = new DNoteItemResultModel
                        {
                            ProductDnotes = new List<DNoteProductItemResultModel>(),
                            CustomerId = item.CustomerId,
                            CustomerName = customers.Where(b => b.CustomerId == item.CustomerId).FirstOrDefault().CustomerName,
                            ExtraDetails = item.ExtraDetails,
                            DnoteDate = item.DnoteDate,
                            DnoteId = item.DnoteId,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            UpdatedByUserName = item.UpdatedByUserName,
                            UpdatedDate = item.UpdatedDate,
                        };
                        result.DeliveryNotes.Add(deliveryNote);
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

        public static DNoteItemResultModel GetDeliveryNote(DNoteRequestModel request)
        {
            var result = new DNoteItemResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                ProductDnotes = new List<DNoteProductItemResultModel>()
            };
            try
            {
                using (var dm = new DataModelEntities(request.SessionUserName))
                {
                    //timeout to make sure this completes
                    dm.Database.CommandTimeout = globalTimeOut;

                    var vatinvoiceid = request.DnoteId;

                    var data = dm.DeliveryNotes.Where(b => b.DnoteId == vatinvoiceid).FirstOrDefault();

                    result.CreatedByUserName = data.CreatedByUserName;
                    result.CreatedDate = data.CreatedDate;
                    result.UpdatedByUserName = data.UpdatedByUserName;
                    result.UpdatedDate = data.UpdatedDate;
                    result.CustomerId = data.CustomerId;
                    result.ExtraDetails = data.ExtraDetails;
                    result.CustomerName = dm.Customers.Where(b => b.CustomerId == data.CustomerId).FirstOrDefault().CustomerName;
                    result.DnoteDate = data.DnoteDate;
                    result.DnoteId = data.DnoteId;

                    var vatProducts = dm.ProductDnotes.Where(b => b.DnoteNo == result.DnoteId).ToList();
                    result.NumberOfProducts = vatProducts.Count();
                    foreach (var vatproduct in vatProducts)
                    {
                        result.ProductDnotes.Add(
                            new DNoteProductItemResultModel()
                            {
                                CreatedByUserName = vatproduct.CreatedByUserName,
                                CreatedDate = vatproduct.CreatedDate,
                                ProdId = vatproduct.ProdId,
                                DnoteNo = vatproduct.DnoteNo,
                                OldNumber = vatproduct.OLDNo,
                                ProductDnoteId = vatproduct.ProductDnoteId,
                                ProductName = dm.Products.Where(b => b.ProductId == vatproduct.ProdId).FirstOrDefault().ProductName,
                                Quantity = vatproduct.Quantity,
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

        public static GenericItemResultModel WriteDeliveryNotee(DNoteRequestModel request)
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

                    var vatinvoiceid = request.DnoteId;

                    var data = (from a in dm.DeliveryNotes
                                where a.DnoteId == vatinvoiceid
                                select a).FirstOrDefault();

                    if (data == null)
                    {
                        data = new DeliveryNote();
                        dm.DeliveryNotes.Add(data);
                        result.Feedback = "DNote Successfully Added";
                    }
                    else
                    {
                        result.Feedback = "DNote Invoice Successful";
                    }

                    data.CustomerId = request.CustomerId;
                    data.ExtraDetails = request.ExtraDetails;
                    data.DnoteDate = request.DnoteDate;
                    data.DnoteId = request.DnoteId;

                    resetDNoteProduct(request);

                    foreach (var item in request.ProductDnotes)
                    {
                        writeDNoteProduct(item, request);
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

        private static void resetDNoteProduct(DNoteRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                var data = (from a in dm.ProductDnotes
                            where a.DnoteNo == request.DnoteId
                            select a).ToList();
                foreach (var item in data)
                {
                    item.OLDNo = item.DnoteNo + "";
                    item.DnoteNo = 0;
                    dm.SaveChanges();
                }
            }
        }

        private static void writeDNoteProduct(DNoteProductItemResultModel requestvatProducts, GenericRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                var data = (from a in dm.ProductDnotes
                            where a.ProductDnoteId == requestvatProducts.ProductDnoteId
                            select a).FirstOrDefault();

                if (data == null)
                {
                    data = new ProductDnote();
                    dm.ProductDnotes.Add(data);
                }

                data.ProdId = requestvatProducts.ProdId;
                data.Quantity = requestvatProducts.Quantity;
                data.DnoteNo = requestvatProducts.DnoteNo;
                data.ProductDnoteId = requestvatProducts.ProductDnoteId;
                data.OLDNo = requestvatProducts.OldNumber;

                dm.SaveChanges();

            }
        }
    }
}