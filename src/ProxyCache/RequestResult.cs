namespace CachingProxy
{
    public class RequestResult
    {
        public RequestResult(byte[] content, string contentType)
        {
            Content = content;
            ContentType = contentType;
        }

        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
}