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
    public class CustomerLogic
    {
        //timeout to make sure this completes
        public static int globalTimeOut = 300;

        public static int CustomerCount(GenericRequestModel request)
        {
            using (var dm = new DataModelEntities(request.SessionUserName))
            {
                //timeout to make sure this completes
                dm.Database.CommandTimeout = globalTimeOut;
                var count = dm.Customers.Count();
                return count;
            }
        }

        public static CustomerListResultModel SearchCustomerList(GenericSearchRequestModel request)
        {
            var result = new CustomerListResultModel
            {
                Feedback = "",
                HasError = false,
                IsValidationError = false,
                NumberOfPages = 0,
                NumberOfRecords = 0,
                Customers = new List<CustomerItemResultModel>()
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


                    var count = dm.Customers
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                            b.CustomerName.Contains(searchCriteria) ||
                                                            b.EmailAddress.Contains(searchCriteria) ||
                                                            b.VatRegistrationNumber.Equals(searchCriteria) ||
                                                            b.PhoneNumber.Equals(searchCriteria)
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

                    var data = dm.Customers
                                .Where(b =>
                                //search criteria
                                (searchCriteria == null ||
                                                          (
                                                             b.CustomerName.Contains(searchCriteria) ||
                                                            b.EmailAddress.Contains(searchCriteria) ||
                                                            b.VatRegistrationNumber.Equals(searchCriteria) ||
                                                            b.PhoneNumber.Equals(searchCriteria)
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
                        CustomerItemResultModel customer = new CustomerItemResultModel
                        {
                            CustomerName = item.CustomerName,
                            CreatedByUserName = item.CreatedByUserName,
                            CreatedDate = item.CreatedDate,
                            OtherDetails = item.OtherDetails,
                            PhoneNumber = item.PhoneNumber,
                            EmailAddress = item.EmailAddress,
                            UpdatedByUserName = item.UpdatedByUserName,
                            VatRegistrationNumber = item.VatRegistrationNumber,
                            CustomerAddress = item.CustomerAddress,
                            CustomerId = item.CustomerId,
                            UpdatedDate = item.UpdatedDate
                        };
                        result.Customers.Add(customer);
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

        public static CustomerItemResultModel GetCustomer(CustomerRequestModel request)
        {
            var result = new CustomerItemResultModel
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

                    var customerId = request.CustomerId;



                    var data = dm.Customers.Where(b => b.CustomerId == customerId).FirstOrDefault();

                    result.CustomerName = data.CustomerName;
                    result.CustomerId = data.CustomerId;
                    result.CreatedByUserName = data.CreatedByUserName;
                    result.CreatedDate = data.CreatedDate;
                    result.OtherDetails = data.OtherDetails;
                    result.PhoneNumber = data.PhoneNumber;
                    result.EmailAddress = data.EmailAddress;
                    result.UpdatedByUserName = data.UpdatedByUserName;
                    result.VatRegistrationNumber = data.VatRegistrationNumber;
                    result.CustomerAddress = data.CustomerAddress;
                    result.UpdatedDate = data.UpdatedDate;


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

        public static GenericItemResultModel WriteCustomer(CustomerRequestModel request)
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

                    var customerId = request.CustomerId;

                    var cust = (from a in dm.Customers
                                where a.CustomerId == customerId
                                select a).FirstOrDefault();


                    if (cust == null)
                    {
                        cust = new Customer();
                        dm.Customers.Add(cust);
                        result.Feedback = "Customer Successfully Added";
                    }
                    else
                    {
                        result.Feedback = "Edit Customer Successful";
                    }

                    cust.CustomerName = request.CustomerName;
                    cust.OtherDetails = request.OtherDetails;
                    cust.PhoneNumber = request.PhoneNumber;
                    cust.EmailAddress = request.EmailAddress;
                    cust.VatRegistrationNumber = request.VatRegistrationNumber;
                    cust.CustomerAddress = request.CustomerAddress;

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

        public static CustomerItemResultModel ValidateCustomer(CustomerRequestModel request)
        {
            var result = new CustomerItemResultModel
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

                    var customerId = request.CustomerId;

                    var data = dm.Customers.Where(b =>
                                //search criteria
                                (
                                  b.CustomerName.Equals(request.CustomerName)
                                )).FirstOrDefault();

                    if (data != null)
                    {
                        result.CustomerName = data.CustomerName;
                        result.CustomerId = data.CustomerId;
                        result.CreatedByUserName = data.CreatedByUserName;
                        result.CreatedDate = data.CreatedDate;
                        result.OtherDetails = data.OtherDetails;
                        result.PhoneNumber = data.PhoneNumber;
                        result.EmailAddress = data.EmailAddress;
                        result.UpdatedByUserName = data.UpdatedByUserName;
                        result.VatRegistrationNumber = data.VatRegistrationNumber;
                        result.CustomerAddress = data.CustomerAddress;
                        result.UpdatedDate = data.UpdatedDate;

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