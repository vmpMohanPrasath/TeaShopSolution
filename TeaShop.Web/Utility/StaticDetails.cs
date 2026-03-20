namespace TeaShop.Web.Utility
{
    public class StaticDetails
    {
        public static string CouponAPIBase { get; set; }
        public enum ApiType
        {
            Get,
            Post,
            Put,
            Delete
        }
    }
}
