using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Logic
{
    public class ErrorHandling
    {
        public static void ThrowValidationError(string message)
        {
            throw new SystemValidationException(message);
        }

        public static ErrorResultObject HandleError(Exception error)
        {
            ErrorResultObject result = new ErrorResultObject() { ErrorMessage="", IsValidationError=false};
            if (error.GetType().ToString().Contains("SystemValidationException"))
            //if (error.Message.Contains(validationErrorCode))
            {
                result.IsValidationError = true;
                result.ErrorMessage = error.ToString();
            }
            else
            {
                result.IsValidationError = false;
                //TO DO: Log error and return reference
                string errorCode = DateTime.Now.Ticks.ToString();
                if (ApplicationSettings.IsDebugMode())
                {
                    if (error.GetType().ToString().Contains("DbEntityValidationException"))
                    {
                        var err = error as System.Data.Entity.Validation.DbEntityValidationException;
                        var entityErrors = "";
                        foreach (var item in err.EntityValidationErrors)
                        {
                            foreach (var dberr in item.ValidationErrors)
                            {
                                entityErrors += String.Format("{0}: {1}{2}", dberr.PropertyName, dberr.ErrorMessage, Environment.NewLine);
                            }
                        }
                        result.ErrorMessage = entityErrors + error.ToString();
                    }
                    else
                    {
                        result.ErrorMessage = error.ToString();
                    }
                }
                else
                {
                    result.ErrorMessage = String.Format("An internal system error has occurred. Error Reference: {0}",errorCode);
                }
            }

            return result;
        }
    }
}
