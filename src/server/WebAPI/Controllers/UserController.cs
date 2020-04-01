using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UserController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet("get")]
        public IActionResult Get()
        {
            return base.Success(new { name = "hüseyin" });
        }


    }
}