using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8_Rubrica.Core.Entities;

namespace Week8_Rubrica.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        IList<Contatto> GetAllContatti();
        Esito AggiungiContatto(Contatto nuovoContatto);
        Esito EliminaContatto(int IDContatto);
        IList<Indirizzo> GetAllIndirizzi();
        Esito AggiungiIndirizzo(Indirizzo nuovoIndirizzo);
      
    }
}
