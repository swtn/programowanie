//Klasa bankomat

namespace klasy
{
    internal class bankomat
    {
        private double saldo;
        private string login;
        private string haslo;
        private bool czy_zalogowany;

        public double Saldo
        {
            get { return saldo; }
        }

        public string Login
        {
            get { return login; }
        }
        public bankomat()
        {
            saldo = 0;
            login = "test";
            haslo = "test";
        }

        public bankomat(double saldo_poczatkowe, string haslo, string login)
        {
            saldo = saldo_poczatkowe;
            this.haslo = haslo;
            this.login = login; 
        }

        public void zaloguj(string haslo, string login)
        {
            if(this.haslo == haslo && this.login == login) 
            { 
                czy_zalogowany = true;
                Console.WriteLine("Zalogowano pomyslnie");
            }
            else
            {
                czy_zalogowany = false;
                Console.WriteLine("Blad logowania.");
            }
        }

        public void wplac(double kwota)
        {
            if(czy_zalogowany) 
            {
                saldo += kwota;
                Console.WriteLine($"Wplata {kwota} PLN zostala zrealizowana. Aktualne saldo wynosi {saldo} PLN");
            }
            else
            {
                Console.WriteLine("Najpierw sie zaloguj");
            }
        }
        public void wyplac(double kwota)
        {
            if(czy_zalogowany == true)
            {
                if (saldo >= kwota)
                {
                    saldo -= kwota;
                    Console.WriteLine($"Dokonano wyplaty {kwota} PLN. Aktualne saldo wynosi {saldo} PLN");
                }
                else
                {
                    Console.WriteLine("Nie wystarczajace srodki");
                }
            }
            else 
            {
                Console.WriteLine("Najpierw sie zaloguj");
            }
        }
        public void wyswietl_saldo()
        {
            if (czy_zalogowany)
            {
                Console.WriteLine($"Aktualne saldo wynosi {saldo} PLN.");
            }
            else
            {
                Console.WriteLine("Najpierw sie zaloguj");
            }
        }
    }
}

//klasa prostokat

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace klasy
{
    internal class prostokat
    {
        private double a;
        private double b;

        public double A {  get { return a; } }
        public double B { get { return b; } }

        //konstruktor domyslny
        public prostokat()
        {
            a = 1;
            b = 2;
        }

        //konstruktor parametryczny
        public prostokat(double a, double b)
        {
            this.a = a;
            this.b = b; 
        }

        //metoda liczaca pole prostokata

        public void pole()
        {
            double suma = 0;
            suma = this.a * this.b;
            Console.WriteLine($"Pole prostokata to: {suma}"); 
        }

        public void obwod()
        {
            double suma = 0;
            suma = this.a + this.b;
            Console.WriteLine($"Obwod prostokata to: {suma}");
        }
    }
}


//program main

namespace klasy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bankomat Bankomat = new bankomat();

            Bankomat.zaloguj("test", "test");

            Bankomat.wplac(100);

            Bankomat.wyplac(50);

            Bankomat.wyswietl_saldo();

            prostokat prostokat = new prostokat();

            prostokat.obwod();
            prostokat.pole();
        }
    }
}

