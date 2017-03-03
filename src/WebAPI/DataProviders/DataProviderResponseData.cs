using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DataProviders
{
    public abstract class DataProviderResponseData
    {
        public override string ToString() {
            return this.GetStringData();
        }

        protected abstract string GetStringData();
    }
}
