
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;

namespace BloemwinekelProj
{
    public class Program
    {
        /*
         * In de main zal ik een voorbeeld maken van hoe dit programma zou kunnen runnen.
         * Natuurlijk hangt de run van de programma af van wat de opgave zelf is.
         * De code zal in comments gezet worden zodat je kan zien wat je allemaal zou kunnen doen.
         * Lees ook alle comments in dit bestand zodat je zoveel mogelijk herinnert tijdens de examen.
         */

        static void Main(string[] args)
        {
            /*
             * Zo maak je een object aan, in geval dat je het vergeten bent:
             * (KlasseNaam) (variabeleNaam) = new (KlasseNaam)(parameters van constructor);
             * Bloem b1 = new Bloem('a', 5.99);
             */

            //List van 4 bloem objecten met 
            List<Bloem> assortimentVanBloemen = new List<Bloem>()
            {
                // In een lijst, altijd constructor callen om een object te maken. "new Bloem()", niet: Bloem b1 = new Bloem();
                new Bloem('a', 5.99),           
                new Bloem('a', 4.99),
                new Bloem('b', 12.99),
                new Bloem('c', 23.55),
            };

            /*
             * Hier is wat code dat mss handig zou zijn:
             * 
             * Console.WriteLine("Naam van bloem: ");                      //Vraag gebruiker voor naam
             * assortimentVanBloemen[0].SetNaam(Console.ReadLine());      // Ken naam toe aan de eerste bloem in de lijst.
             * 
             * string naamBloem1InLijst = assortimentVanBloemen[0].GetNaam();       //Bewaar naam van 1e bloem in een aparte variabele
             * Console.WriteLine(naamBloem1InLijst);                               // Druk naam van 1e bloem af op scherm.
             * 
             * 
             * for(int i = 0; i < assortimentVanBloemen.Count; i++)               // Deze for loop vraagt voor elk bloem in de lijst een naam. Dit naam zal toegekend worden aan de bloem dat in de iteratie besproken word.
               {                                                                 // Vb: i = 0, 0ste element is 1e bloem, 1e bloem naam wordt gezet

                    Console.WriteLine("Naam van bloem: ");                      //Vraag gebruiker voor naam
                    assortimentVanBloemen[i].SetNaam(Console.ReadLine());      // Ken naam toe aan de (i)e bloem in de lijst.
               }
            
             * for(int i = 0; i < assortimentVanBloemen.Count; i++)
               {
                 Console.WriteLine(assortimentVanBloemen[i].GetNaam());      // Deze for loop drukt alle toegekende namen uit
               }
            *
            *
            */

        }
    }

    public class Bloem
    {
        /* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        * Fields: variabelen op klasse niveau. Elk instantie(object) van klasse Bloem bevat de volgende variabelen.
        * Elk klasse-instantie, of beter gezegd, elk object heeft zijn eigen waarde voor de volgende velden, als die ingesteld zijn.
        * Vb: bloem b1 naam = "roos", bloem b2 naam = "paardenbloem", maar beide bloemen delen de naam variabele.
        * Wanneer je over b1 gaat spreken, dan gaan de onderstaande velden enkel de waarden uitlezen dat aan b1 werden toegekend
        * maar dat betekend niet dat b2 _naam dezelfde waarde heeft als b1 _naam, gewoon omdat het ze de attribute/field "_naam" delen
        */

        private string _naam;
        private char _categorie;
        private double _prijs;
        private bool _eetbaar;
        private int _voorraad;

        /* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        * Constructor van Bloem klasse om een bloem object te maken.
        * niet elke veld hoeft geinitialiseerd te worden via de constructor. Vb: Je kan een bloem maken dat naamloos is als je gewoon geen naam vraagt bij constructie van object.
        * Ik heb gewoon twee velden geinitaliseerd voor elk bloem object hieronder, ter voorbeeld:
        * Hieronder zie je ook een voorbeeld van validatie voor prijs.
        */

        public Bloem(char categorie, double prijs)
        {
            _categorie = categorie;
            if (double.IsNegative(prijs))               //datatype.IsNegative(int/double/float) => checkt of ingevoerde nummer negatief is. datatype moet cijfers zijn, denk: int.IsNegative, double.IsNegative.
            {                                          //Tip: als je ooit iets wil doen met een datatype, typ eens "[datatype]." => toont alle functies voor de datatype klasse, vb: string.IsNullOrWhitespace(), int.IsNegative(), int.Parse(), ...
                throw new ArgumentException("Prijs mag niet negatief zijn!");     // => "throw new ArgumentException" crasht de programma en geeft een melding dat de gegeven prijs niet mag bij constructie.
            }
            _prijs = prijs;                                                      // Else -> prijs van dit object = meegegeven prijs;
        }

        /* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        * Querries: methods dat info opvragen. 
        * Deze getters halen info terug van de bovenvermelde variabelen.
        * Voor validatie, zie helemaal onderaan.
        */

        public string GetNaam()             // return-type: string, want we vragen een naam, en de naam field is een string.
        {
            return _naam;                   // return geeft een waarde terug, in dit geval, we retourneren _naam
        }
        public char GetCategorie()
        {
            return _categorie;
        }
        public double GetPrijs()
        {
            return _prijs;
        }
        public bool IsEetbaar()
        {
            return _eetbaar;
        }
        public int GetVoorraad()
        {
            return _voorraad;
        }

        /* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        *
        * Commands: methods dat info gaan aanpassen.
        * Deze setters, of "command" methods, bewerken info van de bovenvermelde variabelen. Haal Set-methode weg indien een veld niet bewerkt mag worden van buitenaf.
        * Voor validatie, zie helemaal onderaan.
        */

        public void SetNaam(string naam)
        {
            //Validatie kan ook hier toegepast worden. Zelfde manier als constructor, aan de hand van een if statement, maar dan moet je die hieronder implementeren (uitschrijven).
            _naam = naam;
        }
        public void SetCategorie(char categorie)
        {
            _categorie = categorie;
        }
        public void SetPrijs(double prijs)
        {
            _prijs = prijs;
        }
        public void SetEetbaarheid(bool eetbaar)
        {
            _eetbaar = eetbaar;
        }
        public void SetVoorraad(int voorraad)
        {
            _voorraad = voorraad;
        }


        /*
         * Hoe valideren:
         * In de setters kan je if en else gebruiken om bepaalde invoer te weigeren. indien je een waarde wil weigeren, bv: if(Prijs < 0), zet tussen {} van if statement het volgende:
         * "throw new ArgumentException("hier komt een zelfgekozen zin dat uitlegd waarom die data niet kan toegekend woorden") => bv: "De prijs mag niet negatief zijn!".
         * 
         * 
         * Klasse "Bloem" is het idee van een bloem. Een bloem heeft bepaalde "attributen", bv naam, categorie, kleur, of wat dan ook. 
         * Een bloem kan dan ook "functionaliteiten" hebben. Dit zijn gewoon methodes. Een methode doet iets; het heeft een functie. Vandaar "functionaliteit".
         * 
         * 
         * Maak extra methodes indien de opgave hiervoor vraagt. Vb "Maak een methode dat de prijs met btw berekent" 
            public (static) void PrijsMetBtw(double prijs)               => Static is optioneel en hangt af van context van programma. Zie beschrijving hieronder.
            {
                return prijs * 0,21;
            }

         * Static enkel indien je het wil oproepen zonder object referentie.
         * Als het niet static is zal het er dan zo moeten uitgevoerd worden in de main methode: (er bestaat een bloem genaamd b1) b1.PrijsMetBtw();
         * Als het wel static is: PrijsMetBtw(b1.GetPrijs());
         * 
         * Onthoud:
         * Klasse "Bloem" is een zogenaamde "idee" van hoe een Bloem-object eruit zou moeten zien.
         * Een Bloem-object is een instantie van de klasse "bloem", of beter gezegd: Een object van het type Bloem, heeft alles wat de klasse Bloem bevat.
         * vb: Een naam, een categorie, een prijs, ..., De waardes kunnen aangepast worden via de Set en Get methodes.
         */



        // Succes!
    }
}


