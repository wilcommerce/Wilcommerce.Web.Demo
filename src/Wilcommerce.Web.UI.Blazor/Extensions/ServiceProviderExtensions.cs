using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using System;

namespace Wilcommerce.Web.UI.Blazor
{
    public static class ServiceProviderExtensions
    {
        public static IServiceProvider UseWilcommerceBlazorUI(this IServiceProvider serviceProvider)
        {
            if (serviceProvider is null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            serviceProvider
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();

            return serviceProvider;
        }
    }
}
