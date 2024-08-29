namespace bpkbFrontEnd.Models
{
    public class BPKBModel
    {
        public string agreement_number { get; set; }
        public string bpkb_no { get; set; }
        public string branch_id { get; set; }
        public DateTime? bpkb_date { get; set; }
        public string faktur_no { get; set; }
        public DateTime? faktur_date { get; set; }
        public string location_id { get; set; }
        public string police_no { get; set; }
        public DateTime? bpkb_date_in { get; set; }
        public string created_by { get; set; }
        public DateTime? created_on { get; set; }
        public string last_updated_by { get; set; }
        public DateTime? last_updated_on { get; set; }
    }

    public class BPKBCreateViewModel
    {
        public BPKBModel BPKB { get; set; }
        public List<StorageLocationModel> Locations { get; set; }
    }

    public class StorageLocationModel
    {
        public string location_id { get; set; }
        public string location_name { get; set; }

    }

    public class BPKBval
    {
        public string agreement_number { get; set; }
        public string bpkb_no { get; set; }
        public string branch_id { get; set; }
        public DateTime? bpkb_date { get; set; }
        public string faktur_no { get; set; }
        public DateTime? faktur_date { get; set; }
        public string location_id { get; set; }
        public string police_no { get; set; }
        public DateTime? bpkb_date_in { get; set; }
        public string user { get; set; }
    }

}

