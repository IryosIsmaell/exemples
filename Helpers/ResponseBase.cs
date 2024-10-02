namespace Ark.Domain.Helpers
{
    public class ResponseBase
    {
        public string? title { get; set; }
        public int status { get; set; }
        public Guid traceId { get; set; }
        public DateTime date { get; set; }
        public string? message { get; set; }
    }
}
