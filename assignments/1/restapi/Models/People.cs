using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using Newtonsoft.Json;
using restapi.Helpers;

namespace restapi.Models
{
    public class People
    {
        public People() { }

        public People(int id)
        {
            UniqueIdentifier = Guid.NewGuid();
            Opened = DateTime.UtcNow;
        }

        [BsonIgnore]
        [JsonProperty("_self")]
        public string Self { get => $"/people/{UniqueIdentifier}"; }

        [JsonIgnore]
        [BsonId]
        public int Id { get; set; }

        public DateTime Opened { get; set; }

        [JsonProperty("id")]
        public Guid UniqueIdentifier { get; set; }

        public override string ToString()
        {
            return PublicJsonSerializer.SerializeObjectIndented(this);
        }
    }
}