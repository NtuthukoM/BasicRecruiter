namespace BasicRecruiter.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public string? CreateUserId { get; set; }
        public string? UpdateUserId { get; set; }
        public bool Deleted { get; set; }

    }
}