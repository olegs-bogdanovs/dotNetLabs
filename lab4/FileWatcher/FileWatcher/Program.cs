using System;
using System.IO;

namespace FileWatcher
{
    class Program
    {
        // Следующие два обработчика событий просто сообщают о модификациях файлов:
        static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Показать, что сделано, если файл изменен, создан или удален.
            Console.WriteLine("File : {0} {1}!,", e.FullPath, e.ChangeType);
        }

        static void OnDeleted(object source, FileSystemEventArgs e)
        {
            // Показать, что сделано, если файл изменен, создан или удален.
            Console.WriteLine("The file {0} is deleted", e.Name);
        }

        static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Показать, что файл был переименован.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }

        static void Main(string[] args)
        {


            Console.WriteLine("***** The Amazing File Watcher App *****\n");
            // Установить путь к каталогу, за которым нужно наблюдать.
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @"..\..\..\..\..\PersonToFile\PersonToFile\bin\Debug\PERSON";
                //watcher.Path = @".\PERSON";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return;
            }
            // Указать цели наблюдения.
            watcher.NotifyFilter = NotifyFilters.LastAccess
            | NotifyFilters.LastWrite
            | NotifyFilters.FileName
            | NotifyFilters.DirectoryName;
            // Следить только за текстовыми файлами.
            watcher.Filter = "persons.dat";
            // Добавить обработчики событий.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            // Начать наблюдение зa файлом.
            watcher.EnableRaisingEvents = true;
            // Ожидать команды пользователя на завершение программы.
            Console.WriteLine(@"Press q to quit app.");
            while (Console.Read() != 'q') ;
        }
    }
}
