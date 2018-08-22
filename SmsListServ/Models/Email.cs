// json2csharp
namespace Models.Email
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RootObject
    {
        public string uri { get; set; }
        public string method { get; set; }
        public Body body { get; set; }
    }

    public class Attachment
    {
        public string Name { get; set; }
        public string ContentBytes { get; set; }
        public string ContentType { get; set; }
        public string ContentId { get; set; }
        public int Size { get; set; }
    }

    public class Body
    {
        public bool MultipleEmailsFound { get; set; }
        public string From { get; set; }
        public string SenderName { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }

        [JsonProperty("Body")]
        public string EmailBody { get; set; }
        public string Snippet { get; set; }
        public List<string> LabelIds { get; set; }
        public int HistoryId { get; set; }
        public DateTime DateTimeReceived { get; set; }
        public int EstimatedSize { get; set; }
        public bool IsRead { get; set; }
        public bool IsHtml { get; set; }
        public bool HasAttachments { get; set; }
        public List<Attachment> Attachments { get; set; }
        public string Id { get; set; }
        public string ThreadId { get; set; }
    }
}