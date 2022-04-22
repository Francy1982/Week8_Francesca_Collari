using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8_Rubrica.Core.Entities
{
    public class Contatto
    {
        private static int IDPartenza = 0;

        public int IDContatto { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public Indirizzo? Indirizzo { get; set; }
      

        public Contatto()
        {
            IDContatto = ++IDPartenza;

        }

        public Contatto(string nome, string cognome)
        {
            IDContatto = ++IDPartenza;
            Nome = nome;
            Cognome = cognome;
        }

        public Contatto(string nome, string cognome, Indirizzo i )
        {
            IDContatto = ++IDPartenza;
            Nome = nome;
            Cognome = cognome;

            Indirizzo = SetIndirizzo(i);

        }

        public Indirizzo? SetIndirizzo(Indirizzo i)
        {
            
            if(i.IDContatto == IDContatto)
                return Indirizzo;
            else
                return null;
        }

     

        public override string ToString()
        {
            return $"\n{Nome}\t{Cognome}\tId: {IDContatto}\n";
        }

    }

    }

