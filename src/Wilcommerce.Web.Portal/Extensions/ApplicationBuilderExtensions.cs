using Microsoft.AspNetCore.Builder;

namespace Wilcommerce.Web.Portal
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWilcommerceAdmin(this IApplicationBuilder app, string urlPrefix)
        {
            app.Map(urlPrefix, adminApp =>
            {
                adminApp.UseBlazorFrameworkFiles();
                adminApp.UseRouting();

                adminApp.UseAuthorization();

                adminApp.UseEndpoints(endpoints =>
                {
                    endpoints.MapFallbackToFile("index.html");
                });
            });

            return app;
        }
    }
}
