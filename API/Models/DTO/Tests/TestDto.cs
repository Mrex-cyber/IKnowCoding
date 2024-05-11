using IKnowCoding.DAL.Models.Entities;
using Newtonsoft.Json;

namespace IKnowCoding.API.Models.DTO.Tests
{
    public class TestDto
    {
        public TestDto() { }
        public TestDto(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
        public static implicit operator TestDto(TestEntity test)
        {
            return new TestDto
            {
                Id = test.Id,
                Title = test.Title,
                Description = test.Description,
            };
        }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
