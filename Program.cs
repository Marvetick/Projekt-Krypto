using System;

namespace KodowanieProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            int random = 0;
            int n = 14, k = 8;
            int[] gx = { 1, 0, 0, 0, 1, 0, 1 };
            int[,] G = new int[8, 14] { {1,0,0,0,0,0,0,0,1,0,0,0,1,0},
                                        {0,1,0,0,0,0,0,0,0,1,0,0,0,1},
                                        {0,0,1,0,0,0,0,0,1,0,1,0,1,0},
                                        {0,0,0,1,0,0,0,0,0,1,0,1,0,1},
                                        {0,0,0,0,1,0,0,0,1,0,1,0,0,0},
                                        {0,0,0,0,0,1,0,0,0,1,0,1,0,0},
                                        {0,0,0,0,0,0,1,0,0,0,1,0,1,0},
                                        {0,0,0,0,0,0,0,1,0,0,0,1,0,1}};

            int[,] Ht = new int[14, 6] {{1,0,0,0,1,0},
                                        {0,1,0,0,0,1},
                                        {1,0,1,0,1,0},
                                        {0,1,0,1,0,1},
                                        {1,0,1,0,0,0},
                                        {0,1,0,1,0,0},
                                        {0,0,1,0,1,0},
                                        {0,0,0,1,0,1},
                                        {1,0,0,0,0,0},
                                        {0,1,0,0,0,0},
                                        {0,0,1,0,0,0},
                                        {0,0,0,1,0,0},
                                        {0,0,0,0,1,0},
                                        {0,0,0,0,0,1}};
            int[] h = new int[8];  //Informacja o d�ugo�ci 6, kt�r� wprowadzamy
            int[] c = new int[14];  //S�owo kodowe

            //--------Wprowadzamy slowo(informacje?)--------//
            Console.WriteLine("\nWitaj w proramie kodujacym i dekodujacym z korekcja bledow");
            Console.WriteLine("\nDane: (14,8) wielomian generujacy: 1000101 (x^6+x^2+x^0)");
            Console.WriteLine("\nWprowadz slowo informacyjne (8 cyfr: zero lub jeden) :");
            // h = int.Parse(Console.ReadLine().ToString().Split(' '));
            int ix = 0;
            foreach (char s in Console.ReadLine())
            {
                h[ix] = int.Parse(s.ToString());
                ix++;
            }

            Console.WriteLine("\nKODER:");
            Console.WriteLine("\nMnoże macierz generujaca i podana informacje");
            

            //--------Liczymy s�owo kodowe c=h*G--------//
            int pomocnicza = 0;
            int a = 0;
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 14; j++) //j=liczba kolumn macierzy
                {
                    pomocnicza = 0;
                    for (int kx = 0; kx < 8; kx++)    //k=liczba wierszy macierzy
                    {
                        pomocnicza = h[kx] * G[kx,j];
                        if (pomocnicza == 1 && a == 1)
                        {
                            a = 0;
                        }
                        else
                            a = a + pomocnicza;
                    }
                    c[j] = a;
                    a = 0;
                }
            }


            //--------Wypisujemy s�owo kodowe--------//
            Console.WriteLine("\nSlowo kodowe: ");
            for (int i = 0; i < 14; i++)
            {
                Console.Write(c[i]);
            }

            //----------generujemy randomowo błąd---------//
            Random rnd = new Random();
            random = (rnd.Next(0, 1));
            if (c[random] == 1)
            {
                c[random] = 0;
            }
            else
            {
                c[random] = 1;
            }
            Console.WriteLine("\nGeneruje randomowo blad\nOdebrane slowo kodowe:");
            for (int i = 0; i < 14; i++)
            {
                Console.Write(c[i]);
            }
            //--------Liczymy syndrom--------//
            Console.WriteLine("\nSyndrom licze poprzez pomnozenie macierzy HT ze slowem odebranym");
            //Console.WriteLine("Macierz HT:\n1,1,0,0,1,1,0,1,1\n1,0,1,0,1,0,1,1,0\n0,1,0,1,0,1,0,1,1\n1,1,1,0,0,1,1,1,0\n0,1,1,1,0,0,1,1,1\n1,1,1,1,0,1,0,0,0\n0,1,1,1,1,0,1,0,0\n0,0,1,1,1,1,0,1,0\n0,0,0,1,1,1,1,0,1\n1,1,0,0,0,0,1,0,1\n1,0,1,0,1,1,0,0,1");
           // Console.WriteLine("1,0,0,1,1,0,1,1,1\n1,0,0,0,0,0,0,0,0\n0,1,0,0,0,0,0,0,0\n0,0,1,0,0,0,0,0,0\n0,0,0,1,0,0,0,0,0\n0,0,0,0,1,0,0,0,0\n0,0,0,0,0,1,0,0,0\n0,0,0,0,0,0,1,0,0\n0,0,0,0,0,0,0,1,0\n0,0,0,0,0,0,0,0,1");



            int[] syndrom = new int[6];

            int pomocnicza1 = 0;
            int a1 = 0;
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 6; j++) //j=liczba kolumn macierzy
                {
                    pomocnicza1 = 0;
                    for (int kx = 0; kx < 14; kx++)    //k=liczba wierszy macierzy
                    {
                        pomocnicza1 = c[kx] * Ht[kx,j];
                        if (pomocnicza1 == 1 && a1 == 1)
                        {
                            a1 = 0;
                        }
                        else
                            a1 = a1 + pomocnicza1;
                    }
                    syndrom[j] = a1;
                    a1 = 0;
                }
            }
            //--------Wypisujemy syndrom--------//
            Console.WriteLine("Syndrom: ");
            for (int i = 0; i < 6; i++) //I to dlugosc syndromu
            {
                Console.Write(syndrom[i]);
            }

            //--------Liczymy wage syndromu--------//
            Console.WriteLine("Licze wage syndromu");
            int waga = 0;

            for (int i = 0; i < 6; i++)     //Warunek zako�czenia to d�ugo�� syndromu, w tym przypadku 9
            {
                if (syndrom[i] == 1)
                {
                    waga++;
                }
                else
                {
                    continue;
                }
                Console.WriteLine("Waga syndromu to:" + waga);
            }


            //--------Liczymy t--------//

            int dmin = 3;   //to trzeba wyliczy�, albo wymysli� algorytm, kto� ch�tny? ;)
            int t = 0;
            t = (dmin - 1) / 2;
            Console.WriteLine("Dlugosc minimalna: " + dmin);
            Console.WriteLine("t: " + t);
            Console.WriteLine("Porownuje wage syndromu ze zdolnoscia korekcyjna 't' i jesli waga jest wieksza, przesuwam slowo kodowe, licze syndrom jeszcze raz, sprawdzam warunek itd. Gdy waga syndromu jest mniejsza lub rowna 't' to koryguje slowo poprzez dodanie do czesci nadmiarowej syndromu i  przesuniecie slowa z powrotem o tyle pozycji,ile razy sprawdzalam warunek (waga syndromu<=t). Slowem oddanym przez dekoder jest pierwsze 8 cyfr tego slowa");


            //--------Sprawdzamy warunek czy waga syndromu <= t--------//
            int[] d = new int[14];
            int licznik_przesuniec = 0;
            poczatek:
            if (licznik_przesuniec == 13 && waga > t)       //13 to d�ugo�� s�owa kodowego -1
            {
                Console.WriteLine("Nie mozna poprawic");
            }
            else
            {
                if (waga <= t)
                {
                    //--------zapisuje zawartosc c do d--------//
                    for (int i = 0; i < 14; i++)    //14 to rozmiar wektora c(s�owa kodowego)
                    {
                        d[i] = c[i];
                    }


                    //--------Do d dodaje na ostatnich bitach syndrom (na tylu bitach jaka by�a d�ugo�� syndromu--------//

                    for (int i = 8; i < 14; i++)
                    {
                        if (d[i] + syndrom[i - 8] == 2)
                        {
                            d[i] = 0;
                        }
                        else
                        {
                            d[i] = d[i] + syndrom[i - 8];
                        }
                    }


                    //--------Przesuwam o tyle ile by�o przesuni��--------//
                    for (int j = 0; j < licznik_przesuniec; j++)
                    {
                        d[13] = d[0];
                        for (int i = 0; i < 13; i++)    
                        {
                            d[i] = d[i + 1];
                        }

                    }

                    //--------Wypisujemy poprawione slowo, tylko 8 pierwszych bit�w---------//
                    Console.WriteLine("Poprawione slowo : ");
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write(h[j]);
                    }
                }
                else
                {
                    //--------Przesuwam o jeden bit w lewo--------//
                    licznik_przesuniec++;

                    for (int i = 0; i < 13; i++)
                    {
                        d[i] = c[i + 1];
                    }
                    d[13] = c[0];   //Zamieniam ostatnie bity
                    //--------Liczymy syndrom--------//

                    int[] syndrom1 = new int[6];

                    int pomocnicza2 = 0;
                    int a2 = 0;
                    for (int i = 0; i < 1; i++)
                    {
                        for (int j = 0; j < 6; j++) //j=liczba kolumn macierzy
                        {
                            pomocnicza2 = 0;
                            for (int kx = 0; kx < 14; kx++)    //k=liczba wierszy macierzy
                            {
                                pomocnicza2 = d[kx] * Ht[kx, j];
                                if (pomocnicza2 == 1 && a2 == 1)
                                {
                                    a2 = 0;
                                }
                                else
                                    a2 = a2 + pomocnicza2;
                            }
                            syndrom1[j] = a2;
                            a2 = 0;
                        }
                    }
                    //--------Liczymy wage syndromu--------//
                    waga = 0;

                    for (int i = 0; i < 6; i++)
                    {
                        if (syndrom1[i] == 1)
                        {
                            waga++;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    goto poczatek;
                }
            }
            Console.WriteLine("Koniec");
            Console.ReadKey();
        }
    }
}
