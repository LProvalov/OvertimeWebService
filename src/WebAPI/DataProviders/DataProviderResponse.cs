using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DataProviders
{
    public class DataProviderResponse
    {
        public ResponseStatusEnum Status { get; set; }

        public string ErrorMessage { get; set; }

        public ICollection<string> Fields { get; set; }
    }
}
