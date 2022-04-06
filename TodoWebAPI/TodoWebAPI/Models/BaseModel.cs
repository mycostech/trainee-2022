namespace TodoWebAPI.Models
{
    public class BaseModel
    {
        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset Updated { get; set; } = DateTimeOffset.Now;
        
    }
}
