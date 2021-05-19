using ProAgil.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ProAgil.Domain.Entities
{
    public class Lot
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }

        public int Amount { get; set; }
        public int EventId { get; set; }
        public Event Event { get; }

        public Lot(int id, string name, DateTime? initialDate, DateTime? finalDate, int amount, int eventId, double price)
        {
            Id = id;
            Name = name;
            InitialDate = initialDate;
            FinalDate = finalDate;
            Amount = amount;
            EventId = eventId;
            Price = price;
        }
    }
}