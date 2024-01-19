using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoAmiciziaConsole
{
    public class AlgoritmoAmicizia
    {
        private HashSet<string> _yesNoEscOptions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "s", "n","x" };
        private HashSet<string> _yesNoOptions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "s", "n" };
        private HashSet<string> _yesOptions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "s" };

        public void CaricaAlgoritmo()
        {
            string risposta = string.Empty;
            int contatore = 0;
            bool trovatoQualcosaDaFareInsieme = false;
            Stampa(new string[] { "Cominciamo", "Componi il numero di telefono della persona","E' in casa? [S/N/X]" });
            risposta=Leggi(_yesNoEscOptions, "Risposta non ammessa", "E' in casa? [S/N/X]").ToLower();
            switch(risposta)
            {
                case "s":
                    risposta=StepInvitoAMangiareInsieme();
                    if(risposta.Equals("s",StringComparison.InvariantCultureIgnoreCase))
                    {
                        risposta=StepMangiateQualcosaInsieme();
                        risposta=StepSieteDiventatiAmici();
                    }
                    else if(risposta.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                    {
                        risposta=StepInvitoABereQualcosaDiCaldo();
                        if (risposta.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                        {
                            risposta=StepScegliCosaBere();
                            risposta=StepSieteDiventatiAmici();
                        }
                        else if (risposta.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                        {
                            Stampa(new string[] { "Allora svaghiamoci un pò" });
                            while (contatore<6) {
                                risposta=StepCosaAltroTiVaDiFare();
                                risposta=StepLoVuoiFareAncheTe();

                                if(risposta.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    contatore=contatore+1;

                                } else if(risposta.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    trovatoQualcosaDaFareInsieme=true;
                                    break;
                                }
                            }
                            if(trovatoQualcosaDaFareInsieme)
                            {
                                risposta=StepFacciamoLaCosaInsieme();
                                risposta=StepSieteDiventatiAmici();
                            }
                            else
                            {
                                risposta=StepScegliLaMenoPeggio();
                                Stampa(new string[] { "Fattela piacere" });
                                risposta=StepFacciamoLaCosaInsieme();
                                risposta=StepSieteDiventatiAmici();
                            }
                           
                        }
                    }
                    break;
                case "n":
                    Stampa(new string[] { "Lascia un messaggio", "Aspetta di essere richiamato" });
                    break;
                case "x":
                    Stampa(new string[] { "Ciao" });
                    break;
            }

        }

        public string StepScegliLaMenoPeggio()
        {
            Stampa(new string[] { "Scegli tra tutte le opzioni quella che ti sembra la meno disumana", });
            return string.Empty;
        }

        public string StepFacciamoLaCosaInsieme()
        {
            Stampa(new string[] { "Facciamola insieme", });
            return string.Empty;
        }

        public string StepLoVuoiFareAncheTe()
        {
            Stampa(new string[] { "E' una cosa che vuoi fare anche te? [S/N]" });
            var risposta=Leggi(_yesNoOptions, "Risposta non ammessa", "E' una cosa che vuoi fare anche te? [S/N]").ToLower();
            return risposta;
        }

        public string StepCosaAltroTiVaDiFare()
        {
            Stampa(new string[] { "Cosa altro ti va di fare" });
            return string.Empty;
        }

        public string StepScegliCosaBere()
        {
            Stampa(new string[] { "Scegli: the, caffè o cioccolata", });
            return string.Empty;
        }

        public string StepInvitoABereQualcosaDiCaldo()
        {
            Stampa(new string[] { "Ti va di bere qualcosa di caldo? [S/N]" });
            var risposta=Leggi(_yesNoOptions, "Risposta non ammessa", "Ti va di bere qualcosa di caldo? [S/N]").ToLower();
            return risposta;
        }

        public string StepMangiateQualcosaInsieme()
        {
             Stampa(new string[] { "Ti va di mangiare qualcosa insieme? [S/N]" });
            var risposta=Leggi(_yesNoOptions, "Risposta non ammessa", "Ti va di mangiare qualcosa insieme? [S/N]").ToLower();
            return risposta;
        }      

        public string StepSieteDiventatiAmici()
        {
            Stampa(new string[] { "Siete diventati amici, ora hai una persona in più a cui chiedere in caso di bisogno", });
            return string.Empty;
        }

        public string StepInvitoAMangiareInsieme()
        {
            string risposta;
            Stampa(new string[] { "Ti va di mangiare qualcosa insieme?", "Aspetta la risposta. [S/N]" });
            risposta=Leggi(_yesNoOptions, "Risposta non ammessa", "Aspetta la risposta. [S/N]").ToLower();
            return risposta;
        }

        public void Stampa(string[] strOutput)
        {
            Console.WriteLine();
            foreach (string str in strOutput)
            {
                Console.WriteLine(str);
            }
        }

        public string Leggi(HashSet<string> valoriAmmessi,string etichettaErrore,string etichettaDomanda)
        {
            bool isAmmissibile=false;
            string risposta = string.Empty;
            while (isAmmissibile==false)
            {
                risposta=Console.ReadKey().KeyChar.ToString();
                isAmmissibile=RispostaAmmissibile(risposta, valoriAmmessi);
                if (isAmmissibile)
                {
                    break;
                } else
                {
                    Console.WriteLine(etichettaErrore);
                    Console.WriteLine(etichettaDomanda);
                }
            }
            return risposta;
        }

        public bool RispostaAmmissibile(string risposta, HashSet<string> valoriAmmissibili)
        {
            if (valoriAmmissibili.Any(t => risposta.Equals(t, StringComparison.InvariantCultureIgnoreCase)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
