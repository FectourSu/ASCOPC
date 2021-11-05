namespace ASCOPC.Infrastructure.Data.Entities
{
    public class UserBuilds
    {
        public virtual Builds Builds { get; set; }
        public virtual User User { get; set; }
    }
}
