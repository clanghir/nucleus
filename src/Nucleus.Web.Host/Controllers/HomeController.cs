using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp;
using Abp.Extensions;
using Abp.Notifications;
using Abp.Timing;
using Nucleus.Controllers;
using Abp.Runtime.Caching;
using System;

namespace Nucleus.Web.Host.Controllers
{
    public class HomeController : NucleusControllerBase
    {
        private readonly INotificationPublisher _notificationPublisher;
        private readonly ICacheManager _cacheManager;


        public HomeController(INotificationPublisher notificationPublisher, ICacheManager cacheManager)
        {
            _notificationPublisher = notificationPublisher;
            _cacheManager = cacheManager;
        }

        public IActionResult Index()
        {

            _cacheManager.GetCache("MyCache").Set("startup", DateTime.Now.ToLongTimeString());

            return Redirect("/swagger");
        }

        /// <summary>
        /// This is a demo code to demonstrate sending notification to default tenant admin and host admin uers.
        /// Don't use this code in production !!!
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<ActionResult> TestNotification(string message = "")
        {
            if (message.IsNullOrEmpty())
            {
                message = "This is a test notification, created at " + Clock.Now;
            }

            var defaultTenantAdmin = new UserIdentifier(1, 2);
            var hostAdmin = new UserIdentifier(null, 1);

            await _notificationPublisher.PublishAsync(
                "App.SimpleMessage",
                new MessageNotificationData(message),
                severity: NotificationSeverity.Info,
                userIds: new[] { defaultTenantAdmin, hostAdmin }
            );

            return Content("Sent notification: " + message);
        }
    }
}
