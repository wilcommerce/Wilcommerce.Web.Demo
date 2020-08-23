namespace Wilcommerce.Web.AspNetCore.Url
{
    public interface IUrlBuilder
    {
        string ApiPrefix { get; }

        string ResourceName { get; }
    }
}
