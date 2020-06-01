namespace Wilcommerce.Web.Admin.Services.Url
{
    public interface IUrlBuilder
    {
        public string ApiPrefix { get; }

        public string ResourceName { get; }
    }
}
