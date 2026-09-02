namespace Hospital_ERP_Backend.API
{
    public class ApiResponse<T>
    {
        public int statusCode { get; set; }
        public string message { get; set; } = string.Empty;
        public T? data { get; set; }
    }
}
