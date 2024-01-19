// See https://aka.ms/new-console-template for more information
namespace AlgoritmoAmiciziaConsole
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            bool isRispostaAmmissibile=false;
            string result = string.Empty;
            Console.WriteLine("Ciao");
            Console.WriteLine("questo programma implementa l'algoritmo dell'amicizia di Sheldon Cooper");
            Console.WriteLine("segui le istruzioni sullo schermo");
            Console.WriteLine("vuoi cominciare? [S/N]");
            while (isRispostaAmmissibile==false)
            {
                result = Console.ReadKey().Key.ToString();
                if(result.Equals("s", StringComparison.InvariantCultureIgnoreCase) || result.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                {
                    isRispostaAmmissibile=true;
                    break;
                } else
                {
                    Console.WriteLine("Risposta non ammessa");
                    Console.WriteLine("vuoi cominciare? [S/N]");
                }               
            }
            
            if(result.Equals("s",StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine();
                AlgoritmoAmicizia algoritmo=new AlgoritmoAmicizia();
                await Task.Run(()=>algoritmo.CaricaAlgoritmo());
            }
            Console.WriteLine();
            Console.WriteLine("Ciao");
        }

        
    }
}


