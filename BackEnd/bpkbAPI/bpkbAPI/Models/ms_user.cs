namespace bpkbAPI.Models
{
    public class ms_user
    {
        public long user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public bool is_active { get; set; }
    }

    public class user
    {
        public string user_name { get; set; }
        public string password { get; set; }
    }

}
