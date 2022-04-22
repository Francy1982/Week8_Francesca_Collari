using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8_Rubrica.Core.Entities;
using Week8_Rubrica.Core.InterfaceRepository;

namespace Week8_Rubrica.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        //dichiaro due campi di tipo interfaccia archivio: uno per di contatti e uno  di indirizzi
       
        private readonly IRepositoryContatti? contattiRepo;
        private readonly IRepositoryIndirizzi? indirizziRepo;


        //costruttore overloaded della classe Main del business layer
        //gli passo le repository del programma
        public MainBusinessLayer(IRepositoryContatti contatti, IRepositoryIndirizzi indirizzi)
        {
            contattiRepo = contatti;
            indirizziRepo = indirizzi;
        }


        public Esito AggiungiContatto(Contatto nuovoContatto)
        {
            foreach(Contatto c in contattiRepo.GetAll())
            {
                if(nuovoContatto.Nome == c.Nome && nuovoContatto.Cognome == c.Cognome)
                {
                    return new Esito() { IsOk = false, Messaggio = "Conatto già presente in archivio" };
                }
               
            }

            contattiRepo.Add(nuovoContatto);
            return new Esito() { IsOk = true, Messaggio = "Contatto Aggiunto" };

        }



        //Aggiungi contatto alla rubrica
        public Esito AggiungiIndirizzo(Indirizzo nuovoIndirizzo)
        {
            foreach (Indirizzo c in indirizziRepo.GetAll())
            {
                if (nuovoIndirizzo == c)
                     return new Esito() { IsOk = false, Messaggio = "Conatto già presente in archivio" };
            }

            indirizziRepo.Add(nuovoIndirizzo);
            return new Esito() { IsOk = true, Messaggio = "Indirizzo Aggiunto" };
        }




        //Elimina contatto
        public Esito EliminaContatto(int IDContatto)
        {
            Contatto? contattoDaEliminare = contattiRepo.GetById(IDContatto);

            if (contattoDaEliminare == null)
                return new Esito() { IsOk = false, Messaggio = "Contatto non trovato" };

            foreach (Indirizzo c in indirizziRepo.GetAll())
            {
                if (contattoDaEliminare.IDContatto == c.IDContatto)
                    return new Esito() { IsOk = false, Messaggio = "Impossibile eliminare il contatto" };

            }

            contattiRepo.GetAll().Remove(contattoDaEliminare);
            return new Esito() { IsOk = true, Messaggio = "Conatto eliminato" };

        }


        public IList<Contatto> GetAllContatti()
        {
            IList<Contatto> contatti = contattiRepo.GetAll();
            return contatti;
           
        }

        public IList<Indirizzo> GetAllIndirizzi()
        {
            IList<Indirizzo> indirizzi = indirizziRepo.GetAll();
            return indirizzi;
        }
    }
}
