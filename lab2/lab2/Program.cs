using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace JsonAddAndUpdate
{
    class Program
    {
        private string jsonFile = @"E:\РГРТУ\Dev\lab2\lab2\user.json";
        private void AddBuyer()
        {
            Console.WriteLine("Введите ID покупателя: ");
            var buyerId = Console.ReadLine();
            Console.WriteLine("\nВведите имя покупателя : ");
            var buyerName = Console.ReadLine();

            var newBuyerMember = "{ 'buyerid': " + buyerId + ", 'buyername': '" + buyerName + "'}";
            try
            {
                var json = File.ReadAllText(jsonFile);
                var jsonObj = JObject.Parse(json);
                var buyerArrary = jsonObj.GetValue("buyer") as JArray;
                var newBuyer = JObject.Parse(newBuyerMember);
                buyerArrary.Add(newBuyer);

                jsonObj["buyer"] = buyerArrary;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFile, newJsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка добавления : " + ex.Message.ToString());
            }
        }

        private void UpdateBuyer()
        {
            string json = File.ReadAllText(jsonFile);

            try
            {
                var jObject = JObject.Parse(json);
                JArray buyerArrary = (JArray)jObject["buyer"];
                Console.Write("Введите ID покупателя для изменения его данных : ");
                var buyerId = Convert.ToInt32(Console.ReadLine());

                if (buyerId > 0)
                {
                    Console.Write("Введите новое имя покупателя: ");
                    var buyerName = Convert.ToString(Console.ReadLine());

                    foreach (var buyer in buyerArrary.Where(obj => obj["buyerid"].Value<int>() == buyerId))
                    {
                        buyer["buyername"] = !string.IsNullOrEmpty(buyerName) ? buyerName : "";
                    }

                    jObject["buyer"] = buyerArrary;
                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonFile, output);
                }
                else
                {
                    Console.Write("Invalid Company ID, Try Again!");
                    UpdateBuyer();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Ошибка обновления : " + ex.Message.ToString());
            }
        }

        private void DeleteBuyer()
        {
            var json = File.ReadAllText(jsonFile);
            try
            {
                var jObject = JObject.Parse(json);
                JArray buyerArrary = (JArray)jObject["buyer"];
                Console.Write("Введите ID покупателя которого хотите удалить : ");
                var buyerId = Convert.ToInt32(Console.ReadLine());

                if (buyerId > 0)
                {
                    var buyerName = string.Empty;
                    var buyerToDeleted = buyerArrary.FirstOrDefault(obj => obj["buyerid"].Value<int>() == buyerId);

                    buyerArrary.Remove(buyerToDeleted);

                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonFile, output);
                }
                else
                {
                    Console.Write("Неверный ID покупателя попробуйте другой!");
                    UpdateBuyer();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetBuyerDetails()
        {
            var json = File.ReadAllText(jsonFile);
            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    Console.WriteLine("ID :" + jObject["id"].ToString());
                    Console.WriteLine("Name :" + jObject["name"].ToString());
                    JArray buyerArrary = (JArray)jObject["buyer"];
                    if (buyerArrary != null)
                    {
                        foreach (var item in buyerArrary)
                        {
                            Console.WriteLine("buyer Id :" + item["buyerid"]);
                            Console.WriteLine("buyer Name :" + item["buyername"].ToString());
                        }

                    }
                    //Console.WriteLine("Phone Number :" + jObject["phoneNumber"].ToString());
                    //Console.WriteLine("Role :" + jObject["role"].ToString());

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        static void Main(string[] args)
        {
            Program objProgram = new JsonAddAndUpdate.Program();

            Console.WriteLine("Введите цифру что бы воспользоваться опциями : 1 - Добавить, 2 - Обновить, 3 - Удалить, 4 - Просмотреть \n");
            objProgram.GetBuyerDetails();
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    objProgram.AddBuyer();
                    break;
                case "2":
                    objProgram.UpdateBuyer();
                    break;
                case "3":
                    objProgram.DeleteBuyer();
                    break;
                case "4":
                    objProgram.GetBuyerDetails();
                    break;
                default:
                    Main(null);
                    break;
            }
            Console.ReadLine();

        }
    }
}