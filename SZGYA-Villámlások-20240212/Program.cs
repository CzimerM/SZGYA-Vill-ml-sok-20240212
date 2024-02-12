using System.Text;
using SZGYA_Villámlások_20240212.src;

namespace SZGYA_Villámlások_20240212
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<VillamNap> villamnapok = new List<VillamNap>();

            StreamReader sr = new StreamReader("../../../src/villam.txt", Encoding.UTF8);

            for(int i = 1; !sr.EndOfStream; i++)
            {
                villamnapok.Add(new VillamNap(i, sr.ReadLine()));
            }

            sr.Close();

            //2
            Console.WriteLine("\n2.feladat");
            foreach (var v in villamnapok)
            {
                Console.WriteLine(v);
            }
            //3
            var maxnap = villamnapok.MaxBy(v => v.Orak.Max());
            var maxora = maxnap.Orak.IndexOf(maxnap.Orak.Max()) + 1;
            Console.WriteLine($"\n3.feladat \n\t{maxnap.Nap}. nap {maxora} óra");

            //4
            Console.WriteLine("\n4.feladat");
            StreamWriter sw = new StreamWriter("../../../src/villamkezdet.txt", false, Encoding.UTF8);
            foreach (var nap in villamnapok)
            {
                var villamlas = nap.Orak.FirstOrDefault(n => n != 0);
                sw.WriteLine($"{nap.Nap} {(villamlas == 0 ? "null" : nap.Orak.IndexOf(villamlas) + 1)}");
            }
            sw.Close();

            //5
            Console.WriteLine($"\n5.feladat: {villamnapok.Sum(v => v.Orak.Count(n => n > 0))}");

            //6
            Console.WriteLine($"\n6.feladat: {villamnapok.First(v => v.Orak.Sum() < 200).Nap}");

            //7
            var nemvoltnap = villamnapok.FirstOrDefault(v => v.Orak.Sum() == 0);
            Console.WriteLine($"\n7.feladat: {(nemvoltnap == null ? "[HIBA] nem volt ilyen nap" : nemvoltnap.Nap)}");

            //--------------------
            //------SZORGALMI-----
            //--------------------

            //8
            Console.WriteLine($"\n8.feladat: {villamnapok.Sum(v => v.Orak.Chunk(2).First().Count(n => n > 0))}");

            //9
            Console.WriteLine($"\n9.feladat: {villamnapok.Chunk(20).First().Sum(v => v.Orak.Sum())}");

            //10 - nincs kész
            var min = villamnapok.MinBy(v => v.Orak.Min());
            Console.WriteLine($"\n10.feladat: {min}");
        }
    }
}