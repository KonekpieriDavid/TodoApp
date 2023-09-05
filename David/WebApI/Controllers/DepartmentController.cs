using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace WebApI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IConfiguration _configuration;
     public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                SELECT  DapartmentId,DepartmentName from  dbo.Department
            ";
        }
        
    }
}
