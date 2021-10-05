using ElsaDemo.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ElsaDemo.Blazor
{
    public abstract class ElsaDemoComponentBase : AbpComponentBase
    {
        protected ElsaDemoComponentBase()
        {
            LocalizationResource = typeof(ElsaDemoResource);
        }
    }
}
