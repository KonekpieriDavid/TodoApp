using Azure.FunctionApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Azure.FunctionApp1
{
    public class AzureFunctionV2
    {
        private readonly DataAccess.IDapperConnService _db;
        public AzureFunctionV2(DataAccess.IDapperConnService db)
        {
            _db = db;
        }
    }
}
