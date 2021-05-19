using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProAgil.Domain.Entities;

namespace ProAgil.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string Theme { get; set; }
        public int AmountOfPeople { get; set; }
        public DateTime Date { get; set; }
        public string ImagemURL {get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<Lot> Lots { get; set; } = new List<Lot>();
        public List<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();
        public List<SpeakerEvent> SpeakerEvents { get; set; } = new List<SpeakerEvent>();




        public Event(int id, string local, string theme, int amountOfPeople, DateTime date, string imagemURL, string phone, string email)
        {
            Id = id;
            Local = local;
            Theme = theme;
            AmountOfPeople = amountOfPeople;
            Date = date;
            ImagemURL = imagemURL;
            Phone = phone;
            Email = email;
        }

        public Event()
        {
        }

       

        public void AddLot(Lot lot)
        {

            Lots.Add(lot);
        }

        public void RemoveLot(Lot lot)
        {

            Lots.Remove(lot);
        }

        public void AddSocialMedias(SocialMedia socialMedia)
        {
            SocialMedias.Add(socialMedia);
        }

        public void RemoveSocialMedia(SocialMedia socialMedia)
        {
            SocialMedias.Remove(socialMedia);
        }

        public void AddSpeakerEvent(SpeakerEvent speakerEvent)
        {
            SpeakerEvents.Add(speakerEvent);
        }

        public void RemoveSpeakerEvent(SpeakerEvent speakerEvent)
        {
            SpeakerEvents.Remove(speakerEvent);
        }

    }
}
