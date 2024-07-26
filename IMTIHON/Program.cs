
using System.Runtime.InteropServices;

namespace IMTIHON
{
    public class Program
    {

        public static int ArrowIndex(List<string> buyruqlar,string name)
        {
            int selectIndex = 0;
            while(true)
            {
                Console.Clear();
                Console.WriteLine($"              >>      {name}     <<");
                for (int i = 0; i < buyruqlar.Count; i++)
                {
                    if(i==selectIndex) Console.WriteLine($">>>>  {buyruqlar[i]}");
                    else Console.WriteLine($"      {buyruqlar[i]}");
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key==ConsoleKey.DownArrow)selectIndex= (selectIndex+1)%buyruqlar.Count;
                else if(key.Key==ConsoleKey.UpArrow)selectIndex= (selectIndex-1+buyruqlar.Count)%buyruqlar.Count;
                else if(key.Key==ConsoleKey.Enter)return selectIndex;
            }
        }


        static void Main(string[] args)
        {
            RestoranServis restoranServis = new RestoranServis();

            List<string> menyu = new List<string>()
             {
                 "Restoran Admini",
                 "Mijoz",
                 "ko'p buyurmalar "
             };

            List<string> admin = new List<string>()
             {
                 "RestoranHaqida",
                 "Kategoriyalar Menyusi",
                 "Buyurtmalar",
                 "back"
             };

            List<string> RestoranHaqida = new List<string>()
             {
                 "add text",
                 "List Restoran Haqida",
                 "clear Restoran Haqida",
                 "back"
             };

            List<string> kategoriya = new List<string>()
             {
                 "Add Kategoriya",
                 "Update kategoriya",
                 "Delete kategoriya",
                 "List kategoriya",
                 "clear kategoriya",
                 "back"
             };
            List<string> buyurtma = new List<string>()
             {
                 "Buyurtmalar",
                 "Rad Javob berish",
                 "back"
             };




            List<string> mijoz = new List<string>()
            {
                "RestoranHaqida ",
                "buyurtma",
                "list buyurt",
                "Kategoriya qidish",
                "back"
            };


            menyu:
            int m = ArrowIndex(menyu, "");
            switch (m)
            {
                case 0:
                    admin:
                int a = ArrowIndex(admin, "admin");
                    switch(a)
                    {
                        case 0:
                            res:
                            int q = ArrowIndex(RestoranHaqida, "admin");
                            switch (q)
                            {
                                case 0:
                                    restoranServis.AddRestoranhaqida();
                                    Console.ReadKey();
                                    goto res;

                                case 1:
                                    restoranServis.ListRestoranhaqida();
                                    Console.ReadKey();
                                    goto res;


                                case 2:
                                    restoranServis.ClearRestoranhaqida();
                                    Console.ReadKey();
                                    goto res;


                                case 3:
                                    goto admin;
                            }
                            break;


                        case 1:
                            kat:
                            int kate= ArrowIndex(kategoriya, "admin");
                            switch(kate)
                            {
                                case 0:
                                    restoranServis.AddKategoriya();
                                    Console.ReadKey();
                                    goto kat;

                                case 1:
                                    restoranServis.UpdateKategoriya();
                                    Console.ReadKey();
                                    goto kat;


                                case 2:
                                    restoranServis.DeleteKategoriya();
                                    Console.ReadKey();
                                    goto kat;


                                case 3:
                                    restoranServis.ListKategoriya();
                                    Console.ReadKey();
                                    goto kat;
                                case 4:
                                    restoranServis.ClearKategoriya();
                                    Console.ReadKey();
                                    goto kat;
                                case 5:

                                    goto admin;



                            }
                            break;


                        case 2:
                            bu:
                            int b=ArrowIndex(buyurtma, "admin");
                            switch (b)
                            {
                                case 0:
                                    restoranServis.ListBuyurtmalar();
                                    Console.ReadKey();
                                    goto bu;


                                case 1:
                                    restoranServis.DeleteBuyurtmalar();
                                    Console.ReadKey();
                                    goto bu;

                                case 2:
                                    goto admin;

                            }
                            break;


                        case 3:
                            goto menyu;
                    }
                    break;


                case 1:/// Mizoj
                    mijoz:
                    int mm = ArrowIndex(mijoz, "mijoz");
                    switch(mm)
                    {
                        case 0:
                            restoranServis.ListRestoranhaqida();
                            Console.ReadKey();
                            goto mijoz;
                        case 1:
                            restoranServis.AddBuyurtmalar();
                            Console.ReadKey();

                                goto mijoz;
                            case 2:
                            restoranServis.ListBuyurtmalar();
                            Console.ReadKey();
                            goto mijoz;
                        case 3:
                            string str=restoranServis.BuyQid();
                            Console.WriteLine(str);
                            Console.ReadKey();
                            goto mijoz;
                        case 4:
                            goto menyu;
                    }
                    break;
                    case 2:
                    restoranServis.Listkopbuyruqlar();
                    Console.ReadKey();
                    goto menyu;
                    break;

            }



        }
    }
}