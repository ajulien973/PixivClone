using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PixivClone.Startup))]
namespace PixivClone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
