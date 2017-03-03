using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DataProviders
{
    public class DataProviderResponse<T>
    {
        public DataProviderResponse(ICollection<string> errorInFields,
            T responseData, ResponseStatusEnum status, string errorMessage)
        {
            this._responseData = responseData;
            this._errorInFields = errorInFields;
            this._status = status;
            this._errorMessage = errorMessage;
        }

        private ResponseStatusEnum _status;
        public ResponseStatusEnum Status
        {
            get
            {
                return this._status;
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get {
                return this._errorMessage;
            }
        }

        public ICollection<string> _errorInFields = null;
        public ICollection<string> ErrorInFields
        {
            get {
                return this._errorInFields;
            }
        }

        private T _responseData;
        public T ResponseData
        {
            get
            {
                return this._responseData;
            }
        }
    }
}
