namespace struktury
{

    public struct Ulamek
    {
        public int licznik { get; private set; }
        public int mianownik { get; private set; }

        public Ulamek(int Licznik, int Mianownik) {
            if (Mianownik == 0) 
            {
                throw new ArgumentException("Mianownik nie moze byc zerem");
            }
            licznik = Licznik;
            mianownik = Mianownik;
        }

        public static Ulamek operator +(Ulamek u1, Ulamek u2)
        {
            return new Ulamek(u1.licznik * u2.mianownik + u2.licznik * u1.mianownik, u1.mianownik * u2.mianownik);
        }

        public static Ulamek operator *(Ulamek u1, Ulamek u2)
        {
            return new Ulamek(u1.licznik * u2.licznik, u1.mianownik * u2.mianownik);
        }

        public static Ulamek operator -(Ulamek u1, Ulamek u2)
        {
            return new Ulamek(u1.licznik * u2.mianownik - u2.licznik * u1.mianownik, u1.mianownik * u2.mianownik);
        }

        public static Ulamek operator /(Ulamek u1, Ulamek u2)
        {
            if(u2.mianownik == 0)
            {
                throw new DivideByZeroException("Nie mozna dzielic przez zero");
            }
            return new Ulamek(u1.licznik * u2.mianownik, u2.licznik * u1.mianownik);
        }

        private static int NWW(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public void skrocenie()
        {
            int nww = NWW(licznik, mianownik);
            licznik /= nww;
            mianownik /= nww;
        }

        public double zmiennoprzecinkowe()
        {
            return (double)licznik / mianownik;
        }

        public static void zwieksz_licznik(ref Ulamek ulamek)
        {
            ulamek.licznik += 1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Ulamek u1 = new Ulamek(4, 8);
            Ulamek u2 = new Ulamek(1, 2);

            u1.skrocenie();
            Console.WriteLine($"Skrocony ulamek u1: {u1.licznik}/{u1.mianownik}");

            double a = u2.zmiennoprzecinkowe();
            Console.WriteLine($"Ulamek u2 przedstawiony jako liczba zmiennoprzecinkowa: {a}");

            Ulamek sum = u1 - u2;
            Console.WriteLine($"u1-u2={sum.licznik}/{sum.mianownik}");
            
        }
    } }
