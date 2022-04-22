using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8_Rubrica.Core.Entities;
using Week8_Rubrica.Core.InterfaceRepository;

namespace Week8_Rubrica.RepositoryMock
{
    public class RepositoryIndirizziMock : IRepositoryIndirizzi
    {
        private static List<Indirizzo> indirizzi = new List<Indirizzo>()
        {
            new Indirizzo{Tipologia = "Domicilio", Via = "Italia", Citta = "Roma", Cap = "09034", Nazione = "Italia", Provincia = "Roma", IDContatto = 1},
            new Indirizzo{Tipologia = "Domicilio", Via = "Mazzini", Citta = "Padova", Cap = "09089", Nazione = "Italia", Provincia = "PD", IDContatto = 2}
        };

        //aggiunge un indirizzo alla repository
        public Indirizzo Add(Indirizzo item)
        {
            indirizzi.Add(item);
            return item;
           
        }

        //cancella un indirizzo dalla repository
        public bool Delete(Indirizzo item)
        {
            foreach(var indirizzo in indirizzi)
            {
                if(indirizzo.IDIndirizzo != item.IDIndirizzo)
                {
                    return false;
                }
            }
            indirizzi.Remove(item);
            return true;
            
        }


        //Restituisce la lista degli indirizzi nellla repository
        public IList<Indirizzo> GetAll()
        {
            return indirizzi;
           
        }

        //restituisce l'indirizzo se presente, se no restituisce null
        public Indirizzo? GetById(int id)
        {
            foreach(Indirizzo item in indirizzi)
            {
                if (item.IDIndirizzo != id)
                    continue;
                return item;
            }
            return null;
         
        }
    }
}
