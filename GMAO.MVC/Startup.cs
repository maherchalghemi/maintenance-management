using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GMAO.MVC.Startup))]
namespace GMAO.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
