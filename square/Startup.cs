using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(square.Startup))]
namespace square
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
