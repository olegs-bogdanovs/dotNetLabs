using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PersonToFile
{
    class Program
    {
        private static void createDirectoryIfNotExists(String dirname)
        {
            DirectoryInfo dir1 = new DirectoryInfo(dirname);
            if (!dir1.Exists)
            {
                Console.WriteLine("Folder " + dirname + " does not exist!\nCreating folder PERSON");
                dir1.Create();
            }
            else Console.WriteLine("The folder " + dirname + " exist!");
        }

        private static void createFileIfNotExists(String filename)
        {
            FileInfo file = new FileInfo(filename);
            if (!file.Exists)
            {
                file.Create();
            }
        }

        private static void outputFileInfo(String filename)
        {
            FileInfo file = new FileInfo(filename);
            if (file.Exists)
            {
                Console.WriteLine("The file persons.dat exist!");
                Console.WriteLine("***************************");
                Console.WriteLine("File name: {0}", file.Name);
                Console.WriteLine("File size: {0}", file.Length);
                Console.WriteLine("Creation: {0}", file.CreationTime);
                Console.WriteLine("Attributes: {0}", file.Attributes);
                Console.WriteLine("***************************\n");
            }
            else
            {
                Console.WriteLine("The file persons.dat does not exist!\n");
            }
        }

        private static void outputPerson(Person person)
        {
            Console.WriteLine("Name=" + person.name + " Age=" + person.age + " Pers.code=" + person.perCode);
        }

        static void Main(string[] args)
        {
            createDirectoryIfNotExists(@".\PERSON");
            createFileIfNotExists(@".\PERSON\persons.dat");
            outputFileInfo(@".\PERSON\persons.dat");


            Person pers1 = new Person();
            pers1.name = "John";
            pers1.age = 30;
            pers1.perCode = "123123-12312312";

            Person pers2 = new Person();
            pers2.name = "Peter";
            pers2.age = 32;
            pers2.perCode = "1231231230123123231";

            BinaryFormatter binFormat = new BinaryFormatter();
            FileStream fStream = new FileStream(@".\PERSON\persons.dat", FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            binFormat.Serialize(fStream, pers1);
            binFormat.Serialize(fStream, pers2);
            fStream.Close();


            fStream = new FileStream(@".\PERSON\persons.dat", FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            Person p1 = (Person)binFormat.Deserialize(fStream);
            Person p2 = (Person)binFormat.Deserialize(fStream);

            Console.WriteLine("Readed data: ");
            outputPerson(p1);
            outputPerson(p2);

            Console.ReadLine();
        }
    }
}
