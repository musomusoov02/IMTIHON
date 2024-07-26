using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IMTIHON
{
    public class RestoranServis
    {

        public RestoranServis()
        {
            ReadDep();
            ReadTea();
            ReadStu();
        }


        public static string GetDepPath()
        {
            string p = Directory.GetCurrentDirectory();
            p += "\\Department.json";
            return p;
        }
        public static string GetTeaPath()
        {
            string p = Directory.GetCurrentDirectory();
            p += "\\Teacher.json";
            return p;
        }
        public static string GetStuPath()
        {
            string p = Directory.GetCurrentDirectory();
            p += "\\Student.json";
            return p;
        }

        public void ReadDep()
        {
            if (File.Exists(GetDepPath()))
            {
                string json = string.Empty;
                using (StreamReader re = new StreamReader(GetDepPath()))
                {
                    json = re.ReadToEnd();
                }
                buyurtmalars = JsonSerializer.Deserialize<List<Buyurtmalar>>(json);
            }
            else
            {
                buyurtmalars = new List<Buyurtmalar>();
            }

        }
        public void ReadTea()
        {
            if (File.Exists(GetTeaPath()))
            {
                string json = string.Empty;
                using (StreamReader re = new StreamReader(GetTeaPath()))
                {
                    json = re.ReadToEnd();
                }
                kategoriyalars = JsonSerializer.Deserialize<List<Kategoriyalar>>(json);
            }
            else
            {
                kategoriyalars = new List<Kategoriyalar>();
            }


        }
        public void ReadStu()
        {
            if (File.Exists(GetStuPath()))
            {
                string json = string.Empty;
                using (StreamReader re = new StreamReader(GetStuPath()))
                {
                    json = re.ReadToEnd();
                }
                restoranHaqidas = JsonSerializer.Deserialize<List<RestoranHaqida>>(json);
            }
            else
            {
                restoranHaqidas = new List<RestoranHaqida>();
            }

        }


        public void SaveRep()
        {
            string str = JsonSerializer.Serialize(buyurtmalars);
            using (StreamWriter sw = new StreamWriter(GetDepPath()))
            {
                sw.WriteLine(str);
            }
        }
        public void SaveTea()
        {
            string str = JsonSerializer.Serialize(kategoriyalars);
            using (StreamWriter sw = new StreamWriter(GetTeaPath()))
            {
                sw.WriteLine(str);
            }

        }
        public void SaveStu()
        {
            string str = JsonSerializer.Serialize(restoranHaqidas);
            using (StreamWriter sw = new StreamWriter(GetStuPath()))
            {
                sw.WriteLine(str);
            }
        }


        List<Buyurtmalar> buyurtmalars= new List<Buyurtmalar>();
         List<Kategoriyalar> kategoriyalars= new List<Kategoriyalar>();
         List<RestoranHaqida> restoranHaqidas= new List<RestoranHaqida>();

        public bool Kategoriyamamavjudemas = false;



        public void AddRestoranhaqida()
        {
            Console.WriteLine("New Name: ");
            string name = Console.ReadLine();
            int id = restoranHaqidas.Count > 0 ? restoranHaqidas.Max(i => i.id) + 1 : 1;
            if (!string.IsNullOrEmpty(name))
            {
                restoranHaqidas.Add(new RestoranHaqida { id = id, Name = name });
            }
            else
            {
                Console.WriteLine("kiritilmadi!!");
                return;
            }
            Console.WriteLine("successfuly");
            SaveStu();
            



        }
        public void ListRestoranhaqida()
        {
            if (restoranHaqidas.Count > 0)
            {
                foreach (var item in restoranHaqidas)
                {
                    Console.WriteLine($" {item.Name}");
                }
            }
            else Console.WriteLine("Empty");

        }

        public void ClearRestoranhaqida()
        {
            restoranHaqidas.Clear();
            SaveStu();

        }

        public void AddBuyurtmalar()
        {
            ListKategoriya();
            if (!Kategoriyamamavjudemas)
            {
                Console.WriteLine("taom Kategoriyalarini kiritish  kerak!!!!!!!!!");
                return;
            } 
            int idkat;
            while (!int.TryParse(Console.ReadLine(), out idkat))
            {
                Console.WriteLine("try again");
            }

            var idname= kategoriyalars.FirstOrDefault(i=>i.Id==idkat);


            int idNew = buyurtmalars.Count > 0 ? buyurtmalars.Max(i => i.id) + 1 : 1;
            
           
                buyurtmalars.Add(new Buyurtmalar { id= idNew,name=idname.Name  });
          
            Console.WriteLine("*** Qabul qilindi ***");
            SaveRep();



        }

        public void DeleteBuyurtmalar()
        {
            ListBuyurtmalar();
            Console.WriteLine("Id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("try again");
            }
            var up = buyurtmalars.FirstOrDefault(i => i.id == id);
            if (up != null)
            {
                buyurtmalars.Remove(up);
            }
            else
            {
                Console.WriteLine("not found");
                return;
            }
            Console.WriteLine("successfuly");
            SaveRep();



        }
        public void ListBuyurtmalar()
        {
            if (buyurtmalars.Count > 0)
            {

                foreach (var item in buyurtmalars)
                {
                    Console.WriteLine($" {item.id}: {item.name}");
                }
            }
            else  Console.WriteLine("not found");
            

        }

        public void ClearBuyurtmalar()
        {
            restoranHaqidas.Clear();
            SaveRep();

        }
        public string BuyQid()
        {
            
            Console.WriteLine(" Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Kiritilmadi!!");
                return "";
             
            }
            
            var up = kategoriyalars.FirstOrDefault(i => i. Name== name);
            if (up == null)
            {
                return "Not found";
            }
            else return "** shunday taom bor ** ";
            
            Console.WriteLine("successfully");
        }




        








        public void AddKategoriya()
        {
            Console.WriteLine("New Name: ");
            string name = Console.ReadLine();
            int id = kategoriyalars.Count > 0 ? kategoriyalars.Max(i => i.Id) + 1 : 1;
            if (!string.IsNullOrEmpty(name))
            {
                kategoriyalars.Add(new Kategoriyalar { Id = id,  Name= name });
            }
            else
            {
                Console.WriteLine("kiritilmadi!!");
                return;
            }
            Console.WriteLine("successfuly");
            SaveTea();


        }
        public void UpdateKategoriya()
        {
            ListKategoriya();
            Console.WriteLine("Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("try again");
            }
            var up = kategoriyalars.FirstOrDefault(i => i.Id == id);
            if (up == null)
            {
                Console.WriteLine("Not found ");
                return;
            }
            Console.WriteLine("New Name: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                up.Name = name;
            }
            else
            {
                Console.WriteLine("Kiritilmadi!!");
                return;
            }
            Console.WriteLine("successfully");
            SaveTea();

        }

        public void DeleteKategoriya()
        {
            ListKategoriya();
            Console.WriteLine("Id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("try again");
            }
            var up = kategoriyalars.FirstOrDefault(i => i.Id == id);
            if (up != null)
            {
                kategoriyalars.Remove(up);
            }
            else
            {
                Console.WriteLine("not found");
                return;
            }
            Console.WriteLine("successfuly");
            SaveTea();


        }

        public void ListKategoriya()
        {
            if (kategoriyalars.Count > 0)
            {
                Kategoriyamamavjudemas = true;

                foreach (var item in kategoriyalars)
                {
                    Console.WriteLine($"{item.Id}: {item.Name}");
                }
            }
            else Console.WriteLine("Empty");

        }

        public void ClearKategoriya()
        {
            kategoriyalars.Clear();
            SaveTea();

        }

        public void Listkopbuyruqlar()
        {
            if (buyurtmalars.Count > 0)
            {

                for (int i = buyurtmalars.Count-1; i >0; i--)
                {
                    Console.WriteLine($"{buyurtmalars[i].id}: {buyurtmalars[i].name}");
                }
            }
            else Console.WriteLine("not found");


        }

    }
}
