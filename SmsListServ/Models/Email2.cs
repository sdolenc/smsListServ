// quicktype
namespace Models.Email2
{
    using System;
    using Newtonsoft.Json;

    public partial class Root
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }
    }

    public partial class Attachment
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ContentBytes")]
        public string ContentBytes { get; set; }

        [JsonProperty("ContentType")]
        public string ContentType { get; set; }

        [JsonProperty("ContentId")]
        public string ContentId { get; set; }

        [JsonProperty("Size")]
        public long Size { get; set; }
    }

    public partial class Body
    {
        public void Flip()
        {
            var origFrom = From;
            From = To;
            To = origFrom;
        }

        [JsonProperty("MultipleEmailsFound")]
        public bool MultipleEmailsFound { get; set; }

        [JsonProperty("From")]
        public string From { get; set; }

        [JsonProperty("SenderName")]
        public string SenderName { get; set; }

        [JsonProperty("To")]
        public string To { get; set; }

        [JsonProperty("Cc")]
        public string Cc { get; set; }

        [JsonProperty("Bcc")]
        public string Bcc { get; set; }

        [JsonProperty("Subject")]
        public string Subject { get; set; }

        [JsonProperty("Body")]
        public string EmailBody { get; set; }

        [JsonProperty("Snippet")]
        public string Snippet { get; set; }

        [JsonProperty("LabelIds")]
        public string[] LabelIds { get; set; }

        [JsonProperty("HistoryId")]
        public long HistoryId { get; set; }

        [JsonProperty("DateTimeReceived")]
        public DateTimeOffset DateTimeReceived { get; set; }

        [JsonProperty("EstimatedSize")]
        public long EstimatedSize { get; set; }

        [JsonProperty("IsRead")]
        public bool IsRead { get; set; }

        [JsonProperty("IsHtml")]
        public bool IsHtml { get; set; }

        [JsonProperty("HasAttachments")]
        public bool HasAttachments { get; set; }

        [JsonProperty("Attachments")]
        public Attachment[] Attachments { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("ThreadId")]
        public string ThreadId { get; set; }
    }
}