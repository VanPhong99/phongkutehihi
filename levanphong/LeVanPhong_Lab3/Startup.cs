using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeVanPhong_Lab3.Startup))]
namespace LeVanPhong_Lab3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
