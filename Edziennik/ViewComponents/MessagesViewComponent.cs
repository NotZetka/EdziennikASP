using Edziennik.Data;
using Edziennik.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Edziennik.ViewComponents
{
    public class MessagesViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext dbContext;

        public MessagesViewComponent(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claim = SharedFunctions.getClaim((ClaimsPrincipal)User);
            if(claim != null)
            {
                var messages = dbContext.Messages.Where(u=>u.ReciverId==claim.Value).Where(x=>x.Opened==false).ToList();
                HttpContext.Session.SetInt32(SD.Messages, messages.Count);
                return View(HttpContext.Session.GetInt32(SD.Messages));
            }
            else
            {
                HttpContext.Session.Clear();
                return View(0);
            }
        }
    }
}
