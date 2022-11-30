namespace ShopAPI.Helper
{
    public class ResponseApi<T>
    {
        public bool Status { get; set; }
        public string? Msg { get; set; }
        public T? Vaule { get; set; }
    }
}
