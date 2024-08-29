namespace bpkbAPI.Models
{
    public class ReturnStatus
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class ReturnStatusLogin
    {
        public bool IsSuccess { get; set; }
        public string username { get; set; }
        public string Message { get; set; }
    }

}
