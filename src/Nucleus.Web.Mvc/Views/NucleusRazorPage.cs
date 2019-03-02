using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace Nucleus.Web.Views
{
    public abstract class NucleusRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected NucleusRazorPage()
        {
            LocalizationSourceName = NucleusConsts.LocalizationSourceName;
        }
    }
}
