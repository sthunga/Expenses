using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Expenses.Startup))]
namespace Expenses
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
