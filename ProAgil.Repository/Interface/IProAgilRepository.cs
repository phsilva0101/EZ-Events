using ProAgil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProAgil.Repository.Interface
{
    public interface IProAgilRepository
    {
        //Geral
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //EVENTS
        Task<Event[]> GetAllEventAsync( bool includeSpeaker);
        Task<Event[]> GetAllEventAsyncByTheme(string theme, bool includeSpeaker);
        Task<Event> GetEventAsyncById(int eventId, bool includeSpeaker);

        //SPEAKER
        Task<Speaker[]> GetAllSpeakerAsyncByName(string name, bool includeEvent);
        Task<Speaker> GetSpeakerAsyncById(int speakerId, bool includeEvent);








    }
}
