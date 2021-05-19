using ProAgil.Domain.Entities;
using System.Collections.Generic;

namespace ProAgil.Domain.Entities
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string  ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();
        public List<SpeakerEvent> SpeakerEvents { get; set; } = new List<SpeakerEvent>();



        public void AddSocialMedias(SocialMedia socialMedia)
        {
            SocialMedias.Add(socialMedia);
        }

        public void RemoveSocialMedia(SocialMedia socialMedia)
        {
            SocialMedias.Remove(socialMedia);
        }

    }
}