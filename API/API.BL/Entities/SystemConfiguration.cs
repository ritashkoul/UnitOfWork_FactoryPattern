using Dapper;

namespace API.BL.Entities
{
    public class SystemConfiguration
    {
        //[Key]
        //public int Id { get; set; }
        public int SortOrder { get; set; }
        public string CurrentValue { get; set; }
        public string PreviousValue { get; set; }
    }
}
