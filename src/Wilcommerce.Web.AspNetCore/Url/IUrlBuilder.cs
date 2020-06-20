namespace Wilcommerce.Web.AspNetCore.Url
{
    public interface IUrlBuilder
    {
        public string ApiPrefix { get; }

        public string ResourceName { get; }
    }
}
