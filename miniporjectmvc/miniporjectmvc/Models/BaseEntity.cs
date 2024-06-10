using miniporjectmvc.Data;

namespace miniporjectmvc.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool SoftDeleted { get; set; }=false;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
