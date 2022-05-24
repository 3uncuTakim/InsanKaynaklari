using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Filters
{
    public class NewAuthorizationAttribute :ActionFilterAttribute
    {
        public string Role { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userRole = context.HttpContext.Session.GetString("userrole");
            bool isAuthority = userRole == Role ? true : false;
            if (!isAuthority || string.IsNullOrEmpty(userRole))
            {
                var referer = context.HttpContext.Request.GetTypedHeaders().Referer;
                string action = "Index";
                string controller = userRole;
                try
                {
                    controller = (referer.Segments.Skip(1).Take(1).SingleOrDefault() ?? userRole).Trim('/');
                    action = (referer.Segments.Skip(2).Take(1).SingleOrDefault() ?? "Index").Trim('/');
                }
                catch (Exception)
                {
                    Console.WriteLine("Yönlemdirmede hata yakalandı.");
                }
                context.HttpContext.Session.SetString("message", "Yetkiniz Bulunmamaktadır.");
                context.Result = new RedirectToActionResult(action, controller, null);

            }
        }
    }
}
