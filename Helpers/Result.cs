namespace Ark.Domain.Helpers
{
    public class Result
    {
        public object data { get; set; }
        public object errors { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public Guid traceId { get; set; }
        public DateTime date { get; set; }
        public string message { get; set; }
    }
}
