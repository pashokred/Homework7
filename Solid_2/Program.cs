using System;
using System.Collections.Generic;
using System.IO;

namespace Solid_2
{
    //Який принцип S.O.L.I.D. порушено? Виправте!

/*Зверніть увагу на клас EmailSender. Крім того, що за допомогою методу Send, він відправляє повідомлення, 
він ще і вирішує як буде вестися лог. В даному прикладі лог ведеться через консоль.
Якщо трапиться так, що нам доведеться міняти спосіб логування, то ми будемо змушені внести правки в клас EmailSender.
Хоча, здавалося б, ці правки не стосуються відправки повідомлень. Очевидно, EmailSender виконує кілька обов'язків і, 
щоб клас ні прив'язаний тільки до одного способу вести лог, потрібно винести вибір балки з цього класу.*/

// Порушено принцип OCP (Open Closed Principle)

    interface IEmailLogger
    {
        IEnumerable<string> LogEmail(Email email);
    }

    class ConsoleLogger : IEmailLogger
    {
        public IEnumerable<string> LogEmail(Email email)
        {
            Console.WriteLine("Email from '" + email.From + "' to '" + email.To + "' was send");
            return new List<string>();
        }
    }

    class FileLogger : IEmailLogger
    {
        public IEnumerable<string> LogEmail(Email email)
        {
            string message = "Email from '" + email.From + "' to '" + email.To + "' was send";
            File.AppendText(message);
            return new List<string>();
        }
    }

    class DatabaseLogger : IEmailLogger
    {
        public IEnumerable<string> LogEmail(Email email)
        {
            return new List<string>();
        }
    }


    class Email
    {
        public String Theme { get; set; }
        public String From { get; set; }
        public String To { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
            Email e2 = new Email() { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };
            Email e3 = new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
            Email e4 = new Email() { From = "Vasya", To = "Me", Theme = "washing machines!" };
            Email e5 = new Email() { From = "Me", To = "Vasya", Theme = "Yes" };
            Email e6 = new Email() { From = "Vasya", To = "Petya", Theme = "+2" };

            ConsoleLogger consoleLogger = new ConsoleLogger();
            consoleLogger.LogEmail(e1);
            consoleLogger.LogEmail(e4);
        
            FileLogger fileLogger = new FileLogger();
            fileLogger.LogEmail(e2);
            fileLogger.LogEmail(e5);
        
            DatabaseLogger databaseLogger = new DatabaseLogger();
            databaseLogger.LogEmail(e3);
            databaseLogger.LogEmail(e6);
        
            Console.ReadKey();
        }
    }
}