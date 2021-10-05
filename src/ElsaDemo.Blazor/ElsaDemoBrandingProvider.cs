using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ElsaDemo.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class ElsaDemoBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ElsaDemo";
    }
}
