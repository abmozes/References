using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kombinatorika_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Kombinatorika 1.8";

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;


            Console.WriteLine("         Kombinatorika    v1.8");
            Console.WriteLine("          Mózes Árpád Benedek");
            Console.WriteLine("              2015.03.19" + Environment.NewLine);
            System.Threading.Thread.Sleep(1500);
            Console.Clear();

            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.ForegroundColor = ConsoleColor.White;

            string help0 = "Ismétléses kombináció:" + Environment.NewLine + "'n' különböző elem közül 'k' elemet kell kiválasztani. Egy elemet többször is kiválaszthatunk, a sorrend nem számít." + Environment.NewLine + "" + Environment.NewLine + "Ismétlés nélküli kombináció:" + Environment.NewLine + "'n' különböző elem közül 'k<=n' elemet kell kiválasztani. Egy elemet csak egyszer választhatunk ki, a sorrend nem számít, vagyis ha ugyan azokat az elemeket más sorrendben választjuk ki az ugyanannak a kiválasztásnak számít." + Environment.NewLine + "" + Environment.NewLine + "Ismétléses variáció:" + Environment.NewLine + "'n' különböző elem közül 'k' elemet kell kiválasztani. Egy elemet többször is kiválaszthatunk, a sorrend számít." + Environment.NewLine + "" + Environment.NewLine + "Ismétlés nélküli variáció:" + Environment.NewLine + "'n' különböző elem közül 'k<=n' elemet kell kiválasztani. Egy elemet csak egyszer választhatunk ki, a sorrend számít, vagyis ha ugyanazokat az elemeket más sorrendben választjuk ki, az más kiválasztásnak számít." + Environment.NewLine + "" + Environment.NewLine + "Ismétléses permutáció:" + Environment.NewLine + "'n' olyan elemet kell az összes lehetséges módon sorba rendezni, amelyek között ismétlődő elemek is vannak. Megadja az elrendezések számát, ha az ismétlődések száma k1, k2, ..., kr; (k1+k2+...+kr<=n)." + Environment.NewLine + "" + Environment.NewLine + "Ismétlés nélküli permutáció:" + Environment.NewLine + "'n' különböző elemet kell az összes lehetséges módon sorba rendezni." + Environment.NewLine + "" + Environment.NewLine + "Ciklikus permutáció:" + Environment.NewLine + "'n' különböző elemet kell az összes lehetséges módon egy kör mentén sorba rendezni." + Environment.NewLine + Environment.NewLine;
            string help1 = Environment.NewLine + "h - segítség  p - permutáció  k - kombináció  v - variáció  q - kilépés";
            bool folytatás = true;

            while (folytatás)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Kombinatorika v1.8 - Használja a természetes számok halmazán!");
                    Console.WriteLine(help1);
                    switch (Console.ReadKey().KeyChar)
                    {
                        //Segítség
                        case 'h':
                            Console.Clear();
                            Console.WriteLine(help0);
                            Console.WriteLine("A folytatáshoz nyomjon le egy billentyűt!");
                            Console.ReadKey();
                            break;

                        //Permutáció
                        case 'p':
                            Console.Clear();
                            Console.WriteLine("i - ismétléses  n - ismétlés nélküli  c - ciklikus" + Environment.NewLine);
                            switch (Console.ReadKey().KeyChar)
                            {
                                //Ismétléses    e rész
                                case 'i':
                                    Console.Clear();
                                    Console.WriteLine("Adja meg n-t!" + Environment.NewLine);
                                    long ne = int.Parse(Console.ReadLine());
                                    Console.WriteLine(Environment.NewLine + "Adja meg az ismétlődő csoportok számát!" + Environment.NewLine);
                                    long xe = int.Parse(Console.ReadLine());
                                    long[] ke = new long[xe];
                                    Console.WriteLine(Environment.NewLine + "Adja meg az ismétlődő csoportok elemszámait enterrel elválasztva!" + Environment.NewLine);
                                    for (int i = 0; i < xe; i++)
                                    {
                                        Console.Write("k(" + Convert.ToString(i + 1) + ")=");
                                        ke[i] = Convert.ToInt64(Console.ReadLine());
                                    }
                                    long koe = 0;
                                    for (int i = 0; i < xe; i++)
                                    {
                                        koe = koe + ke[i];
                                    }
                                    if (koe <= ne)
                                    {
                                        long ae = 1;
                                        for (int i = 0; i < ne; i++)
                                        {
                                            ae = (i + 1) * ae;
                                        }
                                        long[] kxe = new long[xe];
                                        for (int i = 0; i < xe; i++)
                                        {
                                            long ooe = 1;
                                            for (int ii = 0; ii < ke[i]; ii++)
                                            {
                                                ooe = (i + 1) * ooe;
                                            }
                                            kxe[i] = ooe;
                                        }
                                        long be = 1;
                                        for (int i = 0; i < xe; i++)
                                        {
                                            be = kxe[i] * be;
                                        }
                                        if (ae > 0 & be > 0)
                                        {
                                            Console.WriteLine(Environment.NewLine + "A permutációk száma: " + Convert.ToString(ae / be));
                                        }
                                        if (ae <= 0 | be <= 0)
                                        {
                                            Console.WriteLine(Environment.NewLine + "A megadott értékek túl nagyok a művelet elvégzéséhez!");
                                        }

                                    }
                                    if (koe > ne)
                                    {
                                        Console.WriteLine(Environment.NewLine + "a 'k'-k összege nem lehet nagyobb, mint 'n'!");
                                    }
                                    Console.WriteLine(Environment.NewLine + "A folytatáshoz nyomjon le egy billentyűt!");
                                    Console.ReadKey();
                                    break;

                                //ke elemei a "k"-k értékei
                                //kxe elemei a k!-ok értékei
                                //be = a kxe elemeinek szorzatával

                                //Ismétlés nélküli      f rész
                                case 'n':
                                    Console.Clear();
                                    Console.WriteLine("Adja meg n-t!" + Environment.NewLine);
                                    long nf = Convert.ToInt64(Console.ReadLine());
                                    long af = 1;
                                    for (int i = 0; i < nf; i++)
                                    {
                                        af = (i + 1) * af;
                                    }
                                    if (af <= 0)
                                    {
                                        Console.WriteLine(Environment.NewLine + "A megadott érték túl nagy a művelet elvégzéséhez.");
                                    }
                                    if (af > 0)
                                    {
                                        Console.WriteLine(Environment.NewLine + "A permutációk száma: " + Convert.ToString(af));
                                    }
                                    Console.WriteLine(Environment.NewLine + "A folytatáshoz nyomjon le egy billentyűt!");
                                    Console.ReadKey();
                                    break;

                                //Ciklikus      g rész
                                case 'c':
                                    Console.Clear();
                                    Console.WriteLine("Adja meg n-t!" + Environment.NewLine);
                                    long ng = Convert.ToInt64(Console.ReadLine());
                                    long ag = 1;
                                    if (ng < 0)
                                    {
                                        Console.WriteLine("");
                                    }
                                    for (int i = 0; i < ng - 1; i++)
                                    {
                                        ag = (i + 1) * ag;
                                    }
                                    if (ag <= 0)
                                    {
                                        Console.WriteLine(Environment.NewLine + "A megadott érték túl nagy a művelet elvégzéséhez.");
                                    }
                                    if (ag > 0)
                                    {
                                        Console.WriteLine(Environment.NewLine + "A permutációk száma: " + Convert.ToString(ag));
                                    }
                                    Console.WriteLine(Environment.NewLine + "A folytatáshoz nyomjon le egy billentyűt!");
                                    Console.ReadKey();
                                    break;

                                //Kilépés
                                case 'q':
                                    Console.Clear();
                                    folytatás = false;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        //Kombináció
                        case 'k':
                            Console.Clear();
                            Console.WriteLine("i - ismétléses  n - ismétlés nélküli");
                            switch (Console.ReadKey().KeyChar)
                            {
                                //Ismétléses    c rész
                                case 'i':
                                    Console.Clear();
                                    Console.WriteLine("Adja meg n-t!" + Environment.NewLine);
                                    long nc = Convert.ToInt64(Console.ReadLine());
                                    Console.WriteLine(Environment.NewLine + "Adja meg k-t!" + Environment.NewLine);
                                    long kc = Convert.ToInt64(Console.ReadLine());
                                    if (nc >= kc)
                                    {
                                        long ac = 1;
                                        long bc = 1;
                                        long cc = 1;
                                        if (nc > 0 & kc > 0)
                                        {
                                            for (int i = 0; i < nc + kc - 1; i++)
                                            {
                                                ac = (i + 1) * ac;
                                            }
                                            for (int i = 0; i < kc; i++)
                                            {
                                                bc = (i + 1) * bc;
                                            }
                                            for (int i = 0; i < nc - 1; i++)
                                            {
                                                cc = (i + 1) * cc;
                                            }

                                            if ((bc * cc > 0) & (ac > 0))
                                            {
                                                Console.WriteLine(Environment.NewLine + "A kombinációk száma: " + Convert.ToString(ac / (bc * cc)));
                                            }
                                            if ((bc * cc <= 0) | (ac <= 0))
                                            {
                                                Console.WriteLine(Environment.NewLine + "A megadott értékek sajnos túl nagyok a művelet elvégzéséhez!");
                                            }
                                        }
                                        if (nc > 0 & kc == 0)
                                        {
                                            Console.WriteLine(Environment.NewLine + "A kombinációk száma: 1");
                                        }
                                        if (nc == 0 & kc == 0)
                                        {
                                            Console.WriteLine(Environment.NewLine + "A kombinációk száma nem értelmezhető!");
                                        }
                                    }

                                    if (nc < kc)
                                    {
                                        Console.WriteLine(Environment.NewLine + "'k' értéke nem lehet nagyobb, mint 'n'!");
                                    }
                                    Console.WriteLine(Environment.NewLine + "A folytatáshoz nyomjon le egy billentyűt!");
                                    Console.ReadKey();
                                    break;

                                //Ismétlés nélküli      d rész
                                case 'n':
                                    Console.Clear();
                                    Console.WriteLine("Adja meg n-t!" + Environment.NewLine);
                                    long nd = Convert.ToInt64(Console.ReadLine());
                                    Console.WriteLine(Environment.NewLine + "Adja meg k-t!" + Environment.NewLine);
                                    long kd = Convert.ToInt64(Console.ReadLine());
                                    if (nd >= kd)
                                    {
                                        long ad = 1;
                                        long bd = 1;
                                        long cd = 1;
                                        if (nd > 0 & kd > 0)
                                        {
                                            for (int i = 0; i < nd; i++)
                                            {
                                                ad = (i + 1) * ad;
                                            }
                                            for (int i = 0; i < kd; i++)
                                            {
                                                bd = (i + 1) * bd;
                                            }
                                            for (int i = 0; i < nd - kd; i++)
                                            {
                                                cd = (i + 1) * cd;
                                            }

                                            if ((bd * cd > 0) & (ad > 0))
                                            {
                                                Console.WriteLine(Environment.NewLine + "A kombinációk száma: " + Convert.ToString(ad / (bd * cd)));
                                            }
                                            if ((bd * cd <= 0) | (ad <= 0))
                                            {
                                                Console.WriteLine(Environment.NewLine + "A megadott értékek sajnos túl nagyok a művelet elvégzéséhez!");
                                            }
                                        }
                                        if (nd > 0 & kd == 0)
                                        {
                                            Console.WriteLine(Environment.NewLine + "A kombinációk száma: 1");
                                        }
                                        if (nd == 0 & kd == 0)
                                        {
                                            Console.WriteLine(Environment.NewLine + "A kombinációk száma nem értelmezhető!");
                                        }
                                    }

                                    if (nd < kd)
                                    {
                                        Console.WriteLine(Environment.NewLine + "'k' értéke nem lehet nagyobb, mint 'n'!");
                                    }
                                    Console.WriteLine(Environment.NewLine + "A folytatáshoz nyomjon le egy billentyűt!");
                                    Console.ReadKey();
                                    break;

                                //Kilépés
                                case 'q':
                                    Console.Clear();
                                    folytatás = false;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        //Variáció
                        case 'v':
                            Console.Clear();
                            Console.WriteLine("i - ismétléses  n - ismétlés nélküli");
                            switch (Console.ReadKey().KeyChar)
                            {
                                //Ismétléses    a rész
                                case 'i':
                                    Console.Clear();
                                    long na = 1;
                                    long ka = 0;
                                    long va = 1;
                                    Console.WriteLine("Adja meg n-t!" + Environment.NewLine);
                                    na = Convert.ToInt64(Console.ReadLine());
                                    Console.WriteLine(Environment.NewLine + "Adja meg k-t!" + Environment.NewLine);
                                    ka = Convert.ToInt64(Console.ReadLine());
                                    if (na == 0)
                                    {
                                        Console.WriteLine(Environment.NewLine + "A variációk száma: 0");
                                    }
                                    if (na != 0 & ka == 0)
                                    {
                                        Console.WriteLine(Environment.NewLine + "A variációk száma: 1");
                                    }
                                    if (na > 0 & ka > 0)
                                    {
                                        long[] aa = new long[ka];
                                        for (int i = 0; i < ka; i++)
                                        {
                                            aa[i] = na;
                                        }
                                        for (int i = 0; i < ka; i++)
                                        {
                                            va = va * aa[i];
                                        }
                                        if (va > 0)
                                        {
                                            Console.WriteLine(Environment.NewLine + "A variációk száma: " + Convert.ToString(va));
                                        }
                                        if (va <= 0)
                                        {
                                            Console.WriteLine(Environment.NewLine + "A megadott értékek sajnos túl nagyok a művelet elvégzéséhez!");
                                        }
                                    }
                                    Console.WriteLine(Environment.NewLine + "A folytatáshoz nyomjon le egy billentyűt!");
                                    Console.ReadKey();
                                    break;

                                //Ismétlés nélküli      b rész
                                case 'n':
                                    Console.Clear();
                                    long nb;
                                    long kb;
                                    Console.WriteLine("Adja meg 'n'-t!" + Environment.NewLine);
                                    nb = Convert.ToInt64(Console.ReadLine());
                                    Console.WriteLine(Environment.NewLine + "Adja meg 'k'-t!" + Environment.NewLine);
                                    kb = Convert.ToInt64(Console.ReadLine());
                                    if (nb > kb)
                                    {
                                        long ab = 1;
                                        for (int i = 0; i < nb; i++)
                                        {
                                            ab = (i + 1) * ab;
                                        }
                                        long bb = nb - kb;
                                        long cb = 1;
                                        for (int i = 0; i < bb; i++)
                                        {
                                            cb = (i + 1) * cb;
                                        }
                                        if (ab <= 0 | cb <= 0)
                                        {
                                            Console.WriteLine(Environment.NewLine + "A megadott értékek sajnos túl nagyok a művelet elvégzéséhez!");
                                        }
                                        if (ab > 0 & cb > 0)
                                        {
                                            Console.WriteLine(Environment.NewLine + "A variációk száma: " + Convert.ToString(ab / cb));
                                        }

                                    }
                                    if (nb == kb)
                                    {
                                        Console.WriteLine(Environment.NewLine + "A variációk száma: 1");
                                    }
                                    if (nb < kb)
                                    {
                                        Console.WriteLine(Environment.NewLine + "'k' értéke nem lehet nagyobb, mint 'n'!");
                                    }
                                    Console.WriteLine(Environment.NewLine + "A folytatáshoz nyomjon le egy billentyűt!");
                                    Console.ReadKey();
                                    break;

                                //Kilépés
                                case 'q':
                                    Console.Clear();
                                    folytatás = false;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        //Kilépés
                        case 'q':
                            Console.Clear();
                            folytatás = false;
                            break;

                        default:
                            break;
                    }
                }
                //Hibakezelés
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Nem megfelelő formátum!");
                    System.Threading.Thread.Sleep(1000);
                    folytatás = true;
                }
            }
        }
    }
}
