using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bloggen
{
    internal class Program
    {
        static void Datum()//lägger till en metod datum för bloggen
        {
            DateTime dagensDatum = DateTime.Now;//lägger till ett datumobjekt för att spara datum för blogginlägget
            Console.WriteLine("Datum för ditt inlägg:");//berättar för användaren vilket datum inlägget görs
            Console.WriteLine(dagensDatum.ToLongDateString());//skriver ut datum för inlägget
        }
        static void Main(string[] args)
        {
            bool myBool = true;//lägger till en bool som gör att loopen fortsätter tills den är false
            List<string[]> minBloggLista = new List<string[]>(); //skapar en vektor sträng lista för menyn
            while (myBool)//gör en loop till min bool
            {
                Console.Clear();//rensar efter varje menyval för att det inte ska bli så mycket oreda
                Console.WriteLine("[1] - Skapa nytt blogginglägg.");//meny för bloggen
                Console.WriteLine("[2] - Skriv ut alla blogginlägg.");
                Console.WriteLine("[3] - Sök i bloggen.");
                Console.WriteLine("[4] - Rensa bloggen.");
                Console.WriteLine("[5] - Avsluta programmet.");

                Int32.TryParse(Console.ReadLine(), out int input); //förhindrar körtidsfel
                switch (input)//switch för att skapa menyn
                {
                    case 1://om användaren gör menyval 1
                        string[] bloggInlägg = new string[2];//skapar en vektor med två värden
                        /*använder mig av vektorer för att kunna spara titlar och blogginlägg
                         på ett smidigt sätt*/
                        Console.WriteLine("Skriv en bloggtitel:");//instruerar användaren att skriva en titel
                        bloggInlägg[0] = Console.ReadLine();//läser in användarens inmatning
                        Console.WriteLine("Skriv ett blogginlägg:");//instruerar användaren att skriva ett blogginlägg
                        bloggInlägg[1] = Console.ReadLine();//läser in användares inmatning
                        Datum();//använder metoden datum för att visa datum för inlägget som görs
                        minBloggLista.Add(bloggInlägg);//sparar titel och inlägg med add 
                        Console.WriteLine("Dina titlar och inlägg har sparats.");//efter användaren gjort en titel och ett inlägg så meddelas hen att det sparats
                        break;//break för att menyvalet är klart och menyn kommer fram igen
                    case 2://om användaren gör menyval 2
                        for (int i = 0; i < minBloggLista.Count; i++)//använder en forloop för att visa inlägg och titlar
                        /*använder mig av listan som jag deklarerade i början av koden
                         för att enkelt kunna komma åt blogginlägg och titlar som görs i 
                        menyval 1*/
                        {
                            Console.WriteLine("-------------------------------------");//för att tydligare visa vart vi börjar visa inläggen
                            Console.WriteLine("Bloggtitlar och inlägg:" + (i + 1));//en räknare för att räkna upp det som är sparat
                            Console.WriteLine("Bloggtitel: " + minBloggLista[i][0]);//visar användarens titlar
                            Console.WriteLine("Blogginlägg: " + minBloggLista[i][1]);//visar användarens blogginlägg
                            Datum();//använder metoden datum för att visa datum för inlägget som görs
                        }
                        break;//break för att menyvalet är klart och menyn kommer fram igen
                    case 3://om användaren gör menyval 3
                        Console.WriteLine("Sök efter ett blogginlägg genom att skriva titeln du söker:");//ber användaren söka efter titel
                        string sökord = Console.ReadLine();//läser in det användaren skriver
                        bool knapp = false;//deklarerar en bool för att sökningen ska kunna vara sann eller falsk

                        for (int i = 0; i < minBloggLista.Count; i++)//gör en forloop för att kunna söka i bloggen
                        {
                            if (sökord.ToUpper() == minBloggLista[i][0].ToUpper())//om sökordet stämmer med bloggtitlar
                            /*la till toupper för att stora eller små bokstäver inte ska 
                             spela någon roll när användaren matar in sökordet*/
                            {
                                knapp = true;//när bool är sann skrivs nedstående ut
                                Console.WriteLine("Blogginlägget finns i bloggen på index: " + i + ".");
                                Datum();//använder metoden datum för att visa datum för inlägget som görs
                            }
                        }

                        if (knapp == false)//om sökningen misslyckas så skrivs följande ut:
                        {
                            Console.WriteLine("Blogginlägget hittades inte.");
                        }
                        break;//break för att menyvalet är klart och menyn kommer fram igen
                    case 4://om användaren gör menyval 4
                        Console.WriteLine("Nu rensar vi dina bloggar och titlar:");
                        minBloggLista.Clear();//rensar bloggtitlar och inlägg med clear
                        break;//break för att menyvalet är klart och menyn kommer fram igen
                    case 5://om användaren gör menyval 5
                        Console.WriteLine("Tack för den här gången!");//ett meddelande skrivs ut när användaren avslutar programmet
                        myBool = false;//gör mybool false så att programmet avslutas
                        break;
                    default://om användaren gör ett fel så kommer felmeddelande upp
                        Console.WriteLine("Du har gjort ett felaktigt val, var god välj menyval 1-5!");
                        break;//break för att menyvalet är klart och menyn kommer fram igen
                }
                Console.ReadLine();//efter att varje menyval är klart behöver användaren trycka enter så rensas innehållet med clear som deklarerades i menyn
            }

        }
    }
}
