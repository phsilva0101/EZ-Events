using ProAgil.Domain.Entities;
using System.Collections.Generic;

namespace ProAgil.Domain.Entities
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public int? EventId { get; set; }
        public Event Event { get; }

        public int? SpeakerId { get; set; }
        public Speaker Speaker { get; }

    }
}