using Newtonsoft.Json;

namespace ruchi_assignment_week4.Entities
{
    public class BookEntity
    {
            [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
            public string UId { get; set; }

            [JsonProperty(PropertyName = "dType", NullValueHandling = NullValueHandling.Ignore)]
            public string DocumentType { get; set; }

            [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
            public int Version { get; set; }

            [JsonProperty(PropertyName = "updatedBy", NullValueHandling = NullValueHandling.Ignore)]
            public string UpdatedBy { get; set; }

            [JsonProperty(PropertyName = "updatedOn", NullValueHandling = NullValueHandling.Ignore)]
            public DateTime UpdatedOn { get; set; }

            [JsonProperty(PropertyName = "createdBy", NullValueHandling = NullValueHandling.Ignore)]
            public string CreatedBy { get; set; }

            [JsonProperty(PropertyName = "createdOn", NullValueHandling = NullValueHandling.Ignore)]
            public DateTime CreatedOn { get; set; }

            [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore)]
            public bool Active { get; set; }

            [JsonProperty(PropertyName = "archived", NullValueHandling = NullValueHandling.Ignore)]
            public bool Archived { get; set; }

            [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
            public string Title { get; set; }

            [JsonProperty(PropertyName = "Author", NullValueHandling = NullValueHandling.Ignore)]
            public string Author { get; set; }

            [JsonProperty(PropertyName = "publishedDate", NullValueHandling = NullValueHandling.Ignore)]
            public DateTime PublishedDate { get; set; }

            [JsonProperty(PropertyName = "isbn", NullValueHandling = NullValueHandling.Ignore)]
            public string ISBN { get; set; }

            [JsonProperty(PropertyName = "isissued", NullValueHandling = NullValueHandling.Ignore)]
            public Boolean IsIssued { get; set; }
    }
}
