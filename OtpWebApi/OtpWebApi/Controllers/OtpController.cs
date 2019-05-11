using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            
            using (var context = new OtpContext())
            {
                var userSecret = context.OtpUsers.Where(u => u.Id == json["userId"].ToString()).Select(u => u.Secret).ToList()[0];
                var generator = new OtpGenerator(userSecret, 30, 10, 6, new HmacSha256());

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
