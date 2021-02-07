using System;
using System.Linq;
using System.Collections.Generic;

namespace P3_LAB10
{
    class Program
    {
        static void Main(string[] args)
        {
            //test1();
            //test2();

            test3();
        }

        private static void test3()
        {
            Statek statek1 = new Statek();
            Statek statek2 = new Statek();
            KontrolaMostu kontrola = new KontrolaMostu();

            statek1.ProsbaOOtwarcie += kontrola.OnProsbaOOtwarcie;
            statek2.ProsbaOOtwarcie += kontrola.OnProsbaOOtwarcie;

            statek1.Wywyolaj();
            statek2.Wywyolaj();
        }

        public static void test2()
        {
            List mojList = new List
            {
                Tresc = "jakaś tam treśc listu"
            };
            Paczka mojaPaczka = new Paczka
            {
                Opis = "jakiś tam opis paczki",
                Waga = 15.5
            };

            Przesylka<List> przesylkaP1 = new Przesylka<List>();
            przesylkaP1.Adresat = "adres adrestata 1";
            przesylkaP1.Nadawca = "adres odbiorcy 1";

            przesylkaP1.PrzesykaPocztowa = mojList;
            przesylkaP1.Adresat = "adres adrestata 2";
            przesylkaP1.Nadawca = "adres odbiorcy 2";

            Przesylka<Paczka> przesylkaP2 = new Przesylka<Paczka>();
            przesylkaP2.PrzesykaPocztowa = mojaPaczka;
        }

        public static void test1()
        {
            BazaKonatow mojaBaza = new BazaKonatow();
            mojaBaza.bazaKontaktow.Add("microsoft", "mmm@microsoft.pl");
            mojaBaza.bazaKontaktow.Add("google", "mmm@google.com");
            mojaBaza.bazaKontaktow.Add("oracle", "mmm@oracle.pl");
            mojaBaza.bazaKontaktow.Add("steam", "mmm@steam.com");

            mojaBaza.SearchCompany();
        }

    }



    //Stwórz bazę kontaktów dla działu handlowego. Stwórz słownik mapujący string na string, który będzie przechowywał pary nazwa firmy > adres email.
    //Napisz funkcję, która wczyta od użytkownika nazwę firmy (lub część nazwy) i przeszuka słownik. Jeśli znajdzie kilka wyników, np. wpisze "o" i zostanie znalezione "Google" i "Microsoft",
    //wypisz wszystkie pasujące nazwy. Jeśli dopasowanie jest tylko jedno, wypisz nazwę i email. Jeśli nie zostanie znalezione dopasowanie, wypisz na konsolę informację, że takiej firmy nie ma w bazie.	
    public class BazaKonatow
    {
        public IDictionary<string, string> bazaKontaktow = new Dictionary<string, string>();

        public void SearchCompany()
        {


            string name = Console.ReadLine();
            if (bazaKontaktow.ContainsKey(name))
            {
                Console.WriteLine(bazaKontaktow[name]);
            }
            else
            {
                Console.WriteLine("Brak pasujących wyników");
            }
        }
    }

    //Stwórz klasę generyczną Przesylka.Klasa powinna mieć zabezpieczenie - powinna obsługiwać tylko typy, które są klasami.Klasa powinna zawierać pola tekstowe Nadawca i Adresat. 
    //  Stwórz klasę List z polem tekstowym Tresc.Stwórz klasę Paczka z polami Opis i Waga. Stwórz obiekty obu tych klas i opakuj je Przesyłką.Uzupełnij pola nadawcy i adresata.


    public class Przesylka<T> where T : class
    {
        public T PrzesykaPocztowa { get; set; }
        public string Nadawca { get; set; }
        public string Adresat { get; set; }

    }

    public class List
    {
        public string Tresc { get; set; }
    }
    public class Paczka
    {
        public string Opis { get; set; }
        public double Waga { get; set; }

    }



    //Stwórz klasę Statek, która publikuje event ProsbaOOtwarcie.Stwórz klasę KontrolaMostu, która nasłuchuje na ten event. 
    //Dodaj również metodę Czas. Metoda ta powinna wypisywać czy most jest otwarty i co 30 wywołań (pół godziny) 
    //powinna sprawdzać czy ktoś zgłosił prośbę o otwacie, a jeśli tak to otworzyć most na 10 min (10 wywołań).
    //Stwórz obiekt typu KontrolaMostu i dwa Statki. Podłącz eventy z handlerami. Wywołaj Czas 300 razy, w dowolnym momencie każdy statek powinień raz zgłosić Prośbę o otwarcie.

    public class Statek
    {
        public event EventHandler<EventArgs> ProsbaOOtwarcie;

        public void OnProsbaOOtwarcie()
        {
            if (ProsbaOOtwarcie != null)
                ProsbaOOtwarcie(this, EventArgs.Empty);
        }

        public void Wywyolaj()
        {
            OnProsbaOOtwarcie();
        }
    }

    public class KontrolaMostu
    {
        public void OnProsbaOOtwarcie(object o, EventArgs e)
        {
            Console.WriteLine("(KontrolaMostu odebrała event)");
            Czas();
        }

        public void Czas()
        {

             Console.WriteLine("Sprawdzenie czy otwarto most ");

        }
    }

}
