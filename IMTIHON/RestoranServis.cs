using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IMTIHON
{
    public class RestoranServis
    {

        public RestoranServis()
        {
            ReadDep();
            ReadTea();
            ReadStu();
            ReadProduct();
        }
        
                  



        //-----------------------------------------------------get

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

        public static string GetProductPath()
        {
            string p = Directory.GetCurrentDirectory();
            p += "\\Product.json";
            return p;
        }

        //------------------------------------------------------read

        public void ReadDep()
        {
            if (File.Exists(GetDepPath()))
            {
                string json = string.Empty;
                using (StreamReader re = new StreamReader(GetDepPath()))
                {
                    json = re.ReadToEnd();
                }
                buyurtmalars = JsonSerializer.Deserialize<Dictionary<string,List<string >>>(json);
            }
            else
            {
                buyurtmalars = new Dictionary<string ,List<string>>();
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

        public void ReadProduct()
        {
            if (File.Exists(GetProductPath()))
            {
                string json = string.Empty;
                using (StreamReader re = new StreamReader(GetProductPath()))
                {
                    json = re.ReadToEnd();
                }
                products = JsonSerializer.Deserialize<List<Product>>(json);
            }
            else
            {
                products = new List<Product>();
            }
        }

        //----------------------------------------------------------------------save
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

        public void SaveProduct()
        {
            string str = JsonSerializer.Serialize(products);
            using (StreamWriter sw = new StreamWriter(GetProductPath()))
            {
                sw.WriteLine(str);
            }
        }


        Dictionary<string, List<string>> buyurtmalars = new Dictionary<string, List<string>>();
        List<Kategoriyalar> kategoriyalars= new List<Kategoriyalar>();
        List<RestoranHaqida> restoranHaqidas= new List<RestoranHaqida>();
        List<Product> products= new List<Product>();
        List<Attach> attaches= new List<Attach>();
        Dictionary<string,List<string>> DicAttach= new Dictionary<string,List<string>>();












        public void Attach()
        {
            Console.Clear();
            Console.WriteLine("Kategoriylar ***");
            Console.WriteLine();
            ListKategoriya();
            Console.WriteLine();

            Console.Write("id kategoriya: ");
            int idk;
            while (!int.TryParse(Console.ReadLine(), out idk))
            {
                Console.WriteLine("try again");
            }
            var idKate = kategoriyalars.FirstOrDefault(i => i.Id == idk);
            if(idKate==null)
            {
                Console.WriteLine("not found");
                return;
            }

            Console.Clear();
            Console.WriteLine("Productlarlar ***");
            Console.WriteLine();
            ListProduct();
            Console.WriteLine();
            Console.Write("id product: ");
            int idp;
            while(!int.TryParse(Console.ReadLine(), out idp))
            {
                Console.WriteLine("try again ");
            }
            var idpro=products.FirstOrDefault(i=> i.Id == idp);
            if(idpro==null)
            {
                Console.WriteLine("not found");
                return;
            }

            var birxil = attaches.FirstOrDefault(i=>i.NameKategoriya==idKate.Name);

            if (DicAttach.ContainsKey(idKate.Name))
            {
                DicAttach[idKate.Name].Add(idpro.Name);
            }
            else
            {
                DicAttach[idKate.Name] = new List<string> { idpro.Name };
            }
          




            Console.WriteLine("successfuly");
        }

        int buyurmaIndexkategoriya ; 
        string buyurtmaIndex ;
        public void AttachList()
        {
            if(DicAttach.Count > 0)
            {


                Console.Clear();
                Console.WriteLine("Kategoriyalar ***");
                Console.WriteLine();
                int count = 0;
                foreach (var entry in DicAttach)
                {
                    Console.WriteLine($"{count}: {entry.Key}");
                    count++;
                }
                int idk;

                while(!int.TryParse(Console.ReadLine(), out idk))
                {
                    Console.WriteLine("try again");
                }

                

                var selectKategoriya= DicAttach.Keys.ElementAt(idk);

                buyurmaIndexkategoriya = idk;
                buyurtmaIndex = selectKategoriya;

                if(selectKategoriya==null)
                {
                    Console.WriteLine("not found ");
                    return;
                }
                Console.Clear();
                if (DicAttach.TryGetValue(selectKategoriya, out var products))
                {
                    count = 0;
                    Console.WriteLine("Productlar:");
                    Console.WriteLine();
                    foreach (var item in products)
                    {
                        Console.WriteLine($"{count}:  {item}");
                        count++;
                    }
                }
                else
                {
                    Console.WriteLine("No products found.");
                }
            }
            else Console.WriteLine("Empty");
        }























        //---------------------------------------------------------------------restoran haqida

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

        //----------------------------------------------------------------------Buyurtmalar

        public void AddBuyurtmalar()
        {
            if (DicAttach.Count < 0)
            {
                Console.WriteLine("Kategoriylar va Prodectlar yoq!");
                return;
            }
            AttachList();
            Console.WriteLine();
            int idpro;
            while(!int.TryParse(Console.ReadLine(), out idpro))
            {
                Console.WriteLine("try again");
            }

            var namekate = DicAttach.Keys.ElementAt(buyurmaIndexkategoriya);
            if (DicAttach.TryGetValue(namekate, out var products) && idpro >= 0 && idpro < products.Count)
            {
                var namepro = products[idpro];

                if (buyurtmalars.ContainsKey(namekate))
                {
                    buyurtmalars[namekate].Add(namepro);
                }
                else
                {
                    buyurtmalars[namekate] = new List<string> { namepro };
                }

                Console.WriteLine("*** Qabul qilindi ***");
                SaveRep(); 
            }
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

            if (buyurtmalars.ContainsKey(buyurtmaIndex))
            {
                buyurtmalars.Remove(buyurtmaIndex);
                buyurtmalars[buyurtmaIndex].RemoveAt(id);
                Console.WriteLine("successfuly");
            }
            else
            {
                Console.WriteLine("Not found");
            }
            

            SaveRep();
            

            // Ma'lumotlarni saqlash
            SaveRep();
        }
    
    
        public void ListBuyurtmalar()
        {
            if(buyurtmalars.Count > 0)
            {
                int countkate = 0;
                foreach (var item in buyurtmalars)
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine($"Category:{countkate}:  {item.Key} =>");
                    int counPro = 0;
                    foreach (var product in item.Value)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"\t\tProduct:{counPro}:  {product}");
                        counPro++;
                    }
                    counPro = 0;
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine();
                    countkate++;
                }
            }
            else
            {
                Console.WriteLine("not found");
            }
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

        //--------------------------------------------------------------Kategoriyalar 

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

        //------------------------------------------------------------Product

        public void AddProduct()
        {
            Console.WriteLine("New Name: ");
            string name = Console.ReadLine();
            int id = products.Count > 0 ? products.Max(i => i.Id) + 1 : 1;
            if (!string.IsNullOrEmpty(name))
            {
                products.Add(new Product { Id = id, Name = name });
            }
            else
            {
                Console.WriteLine("kiritilmadi!!");
                return;
            }
            Console.WriteLine("successfuly");
            SaveProduct();
        }

        public void UpdateProduct()
        {
            ListProduct();
            Console.WriteLine("Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("try again");
            }
            var up = products.FirstOrDefault(i => i.Id == id);
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
            SaveProduct();
        }

        public void DeleteProduct()
        {
            ListProduct();
            Console.WriteLine("Id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("try again");
            }
            var up = products.FirstOrDefault(i => i.Id == id);
            if (up != null)
            {
                products.Remove(up);
            }
            else
            {
                Console.WriteLine("not found");
                return;
            }
            Console.WriteLine("successfuly");
            SaveProduct();
        }

        public void ListProduct()
        {
            if (products.Count > 0)
            {
                foreach (var item in products)
                {
                    Console.WriteLine($"{item.Id}: {item.Name}");
                }
            }
            else Console.WriteLine("Empty");
        }

        public void ClearProduct()
        {
            products.Clear();
            SaveProduct();
        }

        // ----------------------------------------------------------------Report

        public void Listkopbuyruqlar()
        {
            if (buyurtmalars.Count > 0)
            {
                /*for (int i = buyurtmalars.Count-1; i >0; i--)
                {
                    Console.WriteLine($"{buyurtmalars[i].id}: {buyurtmalars[i].name}");
                }*/
            }
            else Console.WriteLine("not found");
        }
    }
}
