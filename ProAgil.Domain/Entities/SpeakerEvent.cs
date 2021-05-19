
using ProAgil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAgil.Domain.Entities
{
    public class SpeakerEvent
    {

        //Classe Criada pois aqui existe uma Relação N para N entre Palestrante e Evento.
        //PalestranteId  ===  EventoId
        //      1                 1
        //      1                 2
        //      1                 3  
        //      2                 1 
             
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
