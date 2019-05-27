using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OtpWebApi.DAL;
using TOTP_Framework1;
using TOTP_Framework1.Algorithms;

namespace OtpWebApi.Controllers
{
    [Route("api/[controller]")]
    public class OtpController : Controller
    {
        private IConfiguration configuration { get; set; }

        public OtpController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        /// <summary>
        /// Сравнивает два кода, если все верно отправляет 200, иначе 403
        /// </summary>
        /// <param name="otp"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpStatusCode ComparePasswords([FromBody]JObject json)
        {
            if (json == null)
            {
                return HttpStatusCode.NoContent;
            }
            
            using (var context = new OtpContext(configuration))
            {
                var userSecret = context.AspNetUsers.Where(u => u.Id.Equals(json["userId"].ToString())).First();
                var generator = new OtpGenerator(userSecret.Secret, 30, 10, 6, new HmacSha256());

                if (generator.GenerateCode().Equals(json["otp"].ToString()))
                {
                    return HttpStatusCode.OK;
                }

                return HttpStatusCode.Forbidden;
            }
        }

        [HttpGet]
        public string Test()
        {
            return new OtpGenerator("ambayazitov", 30, 10, 6, new HmacSha256()).GenerateCode();
        }
    }
}
