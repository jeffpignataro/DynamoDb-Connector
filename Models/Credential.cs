using System;

namespace commitment_database_connector.Models
{
    public class Credential
    {
        public AWS AWS { get; set; }
    }

    public class AWS
    {
        public string Region { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
    }
}
