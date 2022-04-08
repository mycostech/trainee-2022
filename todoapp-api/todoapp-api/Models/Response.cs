namespace todoapp_api.Models
{
    public class Response
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public Object? Object {get; set;}
    }
}
