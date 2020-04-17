using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogPostWebsite.Startup))]
namespace BlogPostWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
