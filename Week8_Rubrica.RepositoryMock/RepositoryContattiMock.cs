using Week8_Rubrica.Core.Entities;
using Week8_Rubrica.Core.InterfaceRepository;

namespace Week8_Rubrica.RepositoryMock
{


    public class RepositoryContattiMock : IRepositoryContatti
    {
       

        //creo una lista di prova con due contatti
        private static List<Contatto> contatti = new List<Contatto>()
        {
            new Contatto{Nome = "Sandra", Cognome = "Solemi"},
            new Contatto{Nome = "Francesca", Cognome = "Collari"}
        };

        

        //Aggiunge un contatto alla repository se non esiste già
        public Contatto? Add(Contatto item)
        {
            foreach(Contatto contatto in contatti)
            {
                if (contatto.IDContatto == item.IDContatto)
                {
                    return null;
                }
            }

            contatti.Add(item);
            return item;
           
        }

    
        //cancella un conattto dalla repository 
        public bool Delete(Contatto item)
        {

            foreach (Contatto contatto in contatti)
            {
                if (item == contatto)
                {
                   
                    contatti.Remove(contatto);
                    return true;
                }
            }
            return false;
          
        }

        public IList<Contatto> GetAll()
        {
            return contatti;
           
        }

        public Contatto? GetById(int id)
        {
            Contatto contattoTrovato = null;

            foreach(Contatto item in contatti)
            {
                if (item.IDContatto != id)
                    continue;
                else
                    contattoTrovato = item;    
            }
            return contattoTrovato;
           
        }
    }
}