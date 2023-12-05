using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace Assignment_26
{
    public class Program
    {
        //Binary Serialization
        static void Main(string[] args)
        {
            Employee obj = new Employee()
            {
                Id = 1,
                FirstName = "john",
                LastName = "Wick",
                Salary=99000

            };
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"E:\mphasis\problem statement\days\day 21\assignment26-master", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, obj); 
            stream.Close();
           
            stream = new FileStream(@"E:\mphasis\problem statement\days\day 21\assignment26-master", FileMode.Open, FileAccess.Read);
            Employee objnew = (Employee)formatter.Deserialize(stream);
            Console.WriteLine("Deserialized Data Binary Formatter:");
            Console.WriteLine(objnew.Id);
            Console.WriteLine(objnew.FirstName);
            Console.WriteLine(objnew.LastName);
            Console.WriteLine(objnew.Salary);
           

            //Xml Serialization

           
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter writer = new StreamWriter(@"E:\mphasis\problem statement\days\day 21\assignment26-master"))
            {
                serializer.Serialize(writer, obj);
            }
            using (TextReader reader = new StreamReader(@"E:\mphasis\problem statement\days\day 21\assignment26-master"))
            {
                Employee deserialization = (Employee)serializer.Deserialize(reader);
                Console.WriteLine("Deserialized Data Xml Formatter:");
                Console.WriteLine($"ID: {deserialization.Id},FirstName: {deserialization.FirstName},LastName: {deserialization.LastName},Salary: {deserialization.Salary}");

            }
            Console.ReadKey();
        }
    }
}
