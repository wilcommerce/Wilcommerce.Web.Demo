using System.Collections.Generic;
using System.Reflection;

namespace Wilcommerce.Web.Admin
{
    public static class ModulesProvider
    {
        public static IEnumerable<Assembly> AvailableModules => new[]
        {
            typeof(Wilcommerce.Catalog.Admin.UI.Blazor._Imports).Assembly
        };
    }
}
