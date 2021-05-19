using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Entities;
using ProAgil.Repository.Data;
using ProAgil.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAgil.Repository
{
  public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilAPIContext _context;
        public ProAgilRepository(ProAgilAPIContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //Methods General
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }


        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //Methods EVENTS
        public async  Task<Event[]> GetAllEventAsync(bool includeSpeaker = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(c => c.Lots)
                .Include(c => c.SocialMedias);

            if (includeSpeaker)
            {
                query = query
                    .Include(se => se.SpeakerEvents)
                    .ThenInclude(s => s.Speaker);
            }
            query = query.OrderByDescending(c => c.Date);
            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventAsyncByTheme(string theme, bool includeSpeaker)
        {
            IQueryable<Event> query = _context.Events
               .Include(c => c.Lots)
               .Include(c => c.SocialMedias);

            if (includeSpeaker)
            {
                query = query
                    .Include(se => se.SpeakerEvents)
                    .ThenInclude(s => s.Speaker);
            }
            query = query.OrderByDescending(c => c.Date)
                .Where(c => c.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventAsyncById(int eventId, bool includeSpeaker)
        {
            IQueryable<Event> query = _context.Events
              .Include(c => c.Lots)
              .Include(c => c.SocialMedias);

            if (includeSpeaker)
            {
                query = query
                    .Include(se => se.SpeakerEvents)
                    .ThenInclude(s => s.Speaker);
            }
            query = query.OrderByDescending(c => c.Date)
                .Where(c => c.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }

        //Methods SPEAKER

        public async Task<Speaker[]> GetAllSpeakerAsyncByName(string name, bool includeEvent)
        {
            IQueryable<Speaker> query = _context.Speakers
              .Include(c => c.SocialMedias);

            if (includeEvent)
            {
                query = query
                    .Include(se => se.SpeakerEvents)
                    .ThenInclude(e => e.Event);
            }
            query = query.Where(s => s.Name.ToLower().Contains(name.ToLower()));


            return await query.ToArrayAsync();
        }

      

        public async Task<Speaker> GetSpeakerAsyncById(int speakerId, bool includeEvent = false)
        {
            IQueryable<Speaker> query = _context.Speakers
             .Include(c => c.SocialMedias);

            if (includeEvent)
            {
                query = query
                    .Include(se => se.SpeakerEvents)
                    .ThenInclude(e => e.Event);
            }
            query = query.OrderBy(s => s.Name)
                .Where(s => s.Id == speakerId);

            return await query.FirstOrDefaultAsync();
        }

    }
}
