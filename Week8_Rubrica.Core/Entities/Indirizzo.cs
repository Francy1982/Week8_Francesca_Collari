using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8_Rubrica.Core.Entities
{
    public class Indirizzo
    {
        private static int IDPartenza = 0;
        public int IDIndirizzo { get; }
        public string Tipologia { get; set; }
        public string Via { get; set; }
        public string Citta { get; set; }
        public string Cap { get; set; }
        public string Provincia { get; set; }
        public string Nazione { get; set; }
        


    //FK
        public int IDContatto { get; set; }

        public Indirizzo()
        {

        }
        public Indirizzo(string tipologia, string via, string citta, string cap, string provincia, string nazione, int idContatto)
        {
            IDIndirizzo = ++IDPartenza;
            Tipologia = tipologia;
            Via = via;
            Citta = citta;
            Cap = cap;
            Provincia = provincia;
            Nazione = nazione;
            IDContatto = idContatto;

        }


        public override string ToString()
        {
            return $"{Tipologia}\nVia: {Via}\tCittà: {Citta}\tCap: {Cap}\tProvincia: {Provincia}\tNazione: {Nazione}\n";
        }




    }
}
