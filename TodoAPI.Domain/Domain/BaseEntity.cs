namespace TodoAPI.Domain.Domain
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
