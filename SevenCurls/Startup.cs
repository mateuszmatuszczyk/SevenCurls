using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SevenCurls.Startup))]
namespace SevenCurls
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
