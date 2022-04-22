using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8_Rubrica.Core.BusinessLayer;
using Week8_Rubrica.Core.Entities;
using Week8_Rubrica.RepositoryMock;

namespace Rubrica.Presentation
{
    public class Menu
    {

        //inizializzo un oggetto di tipo IBusinessLayer per usare i metodi necessari
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());

        //Metodo di controllo apertura/chiusura programma
        public static void Start()
        {
            bool continua = true;

            while (continua)
            {
                //memorizzo la scelta dell'utente in una variabile
                int scelta = SchermoMenu();

                //metto lo switch in un metodo che restituisce il booleano che guida lo start
                continua = AnalizzaScelta(scelta);
            }
        }

        //visuallizza il menu e acquisisce la scelta dell'utente
        private static int SchermoMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("******************MENU*****************"); 
            Console.WriteLine("1. Visualizza tutti i contatti in rubrica");
            Console.WriteLine("2. Aggiungi un nuovo contatto");
            Console.WriteLine("3. Aggiungi un indirizzo ad un contatto");
            Console.WriteLine("4.Elimina contatto");
            Console.WriteLine("0. Esci\n");

            int scelta;

            Console.WriteLine("Inserisci la tua scelta: ");
            while (!int.TryParse(Console.ReadLine(), out scelta))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
            }

            return scelta;

        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch(scelta)
            {
                case 1:
                    VisualizzaTuttiContatti();
                    break;
                case 2:
                    //aggiungi contatto
                    AggiungiContatto();
                    break;
                case 3:
                    AggiungiIndirizzo();
                    break;
                case 4:
                    EliminaContatto();
                    break;
                case 0:
                    return false;
                default:
                    Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
                    break;   
            }

            return true;

        }

        private static void EliminaContatto()
        {
            VisualizzaTuttiContatti();

            int id = 0;
            do
            {
                Console.WriteLine("Inserisic l'id del contatto che vuoi eliminare: ");

            } while (!int.TryParse(Console.ReadLine(), out id));
          
            IList<Contatto> contatti = bl.GetAllContatti();

            Esito esito = new Esito();
            if (contatti.Count == 0)
            {
                esito.IsOk = false;
                esito.Messaggio = "\nNon ci sono contatti in rubrica";
            }

            else
            {
                
                foreach (Contatto contatto in contatti)
                {
                    if (contatto.IDContatto == id && GetIndirizzo(contatto) == null)
                    {
                        esito = bl.EliminaContatto(contatto.IDContatto);
                       

                    }
                    else
                    {
                        esito.IsOk = false;
                        esito.Messaggio = "ID errato o contatto non eliminabile";
                        
                    }
                }
            }
            Console.WriteLine(esito.Messaggio);
        }

        //Aggiunge un indirizzo alla rubrica
        private static Indirizzo AggiungiIndirizzo()
        {
            IList<Indirizzo> indirizzi = bl.GetAllIndirizzi();

            Console.WriteLine("\nInserisci la tipologia:");
            string tipologia = Console.ReadLine();
            Console.WriteLine("Inserisci la via: ");
            string via = Console.ReadLine();    
            Console.WriteLine("Inserisic la città: ");
            string citta = Console.ReadLine();
            Console.WriteLine("Inserisci il cap: ");
            string cap = Console.ReadLine();
            Console.WriteLine("Inserisic la provincia");
            string provincia = Console.ReadLine();
            Console.WriteLine("Inserisci la nazione: ");
            string nazione = Console.ReadLine();
            Console.WriteLine("Inserisici l'id del contatto: ");
            int idContatto;
            do
            {
                Console.WriteLine("Inserisic  l'id intero corretto");

            }while(!int.TryParse(Console.ReadLine(), out idContatto));

            Indirizzo? nuovoIndirizzo = new Indirizzo(tipologia,via,citta,cap,provincia,nazione,idContatto);


            Esito esito = new Esito();
            foreach (Indirizzo i in indirizzi)
            {
                if (i == nuovoIndirizzo)
                {
                    esito.IsOk = false;
                    esito.Messaggio = "Indirizzo già presente in rubrica";
                    nuovoIndirizzo =  null;
                    return nuovoIndirizzo;
                } 
            }
            esito = bl.AggiungiIndirizzo(nuovoIndirizzo);
            Console.WriteLine(esito.Messaggio);
            return nuovoIndirizzo;
        }



        //Aggiunge un contatto con o senza indirizzo
        private static void AggiungiContatto()
        {
            VisualizzaTuttiContatti();

            Console.WriteLine("\nDigita il nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digita il cognome: ");
            string cognome = Console.ReadLine();

            Contatto nuovoContatto = new Contatto(nome,cognome);

            Console.WriteLine("Vuoi aggiungere l'indirizzo? Digita s/n");
            string risposta = Console.ReadLine().ToLower();

            while (!(risposta == "s" || risposta == "n"))
            {
                Console.WriteLine("Digita s per aggiungere un indirizzo al contatto, altrimenti digita n");
                risposta = Console.ReadLine().ToLower();
            };

            Esito esito = new Esito();

            if (risposta == "n")
            { 
               esito = bl.AggiungiContatto(nuovoContatto); 
            }
            else
            {
                Console.WriteLine($"L'id del contatto è: {nuovoContatto.IDContatto}");

                Console.WriteLine("Ricorda che non puoi aggiungere un indirizzo già esistente");
                IList<Indirizzo> indirizzi = bl.GetAllIndirizzi();

                foreach(Indirizzo i in indirizzi)
                {
                    Console.WriteLine(i);
                }

                Indirizzo nuovoIndirizzo = AggiungiIndirizzo();
                nuovoContatto.Indirizzo = nuovoContatto.SetIndirizzo(nuovoIndirizzo);
                esito = bl.AggiungiContatto(nuovoContatto);
            }

            Console.WriteLine(esito.Messaggio);
                         
    
        }



        //Visualizza contatti resenti in rubrica
        private static void VisualizzaTuttiContatti()
        {
            IList<Contatto> contatti = bl.GetAllContatti();
            if (contatti.Count == 0)
                Console.WriteLine("Non ci sono contatti in rubrica");
            else
            {
                Console.WriteLine("\nEcco l'elenco dei conatti presenti nella rubrica: ");

                foreach (Contatto contatto in contatti)
                {
                    Console.WriteLine(contatto);
                    Console.WriteLine($"Indirizzo: {GetIndirizzo(contatto)}\n");
                }
            }
        }

        public static Indirizzo GetIndirizzo(Contatto c)
        {
            foreach (Indirizzo i in bl.GetAllIndirizzi())
            {
                if (c.IDContatto == i.IDContatto)
                {
                    return i;
                }
            }
            return new Indirizzo();
        }
    }
}
