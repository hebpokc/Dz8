using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dz8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упраженение 9.1");
            Console.WriteLine("Программа создает объекты класса банк, в котором созданы конструкторы");
            BankAccount ba1 = new BankAccount(50000);
            BankAccount ba2 = new BankAccount(BankAccount.BankAccountType.savings);
            BankAccount ba3 = new BankAccount(1000000, BankAccount.BankAccountType.current);
            ba1.Print();
            ba2.Print();
            ba3.Print();

            Console.WriteLine("\nУпраженение 9.2");
            Console.WriteLine("Программа создает объекты класса банк, в котором при изменении баланса, создается объект BankTransaction");
            BankAccount ba4 = new BankAccount(5000, BankAccount.BankAccountType.current);
            ba4.AddBalance(1250);
            Thread.Sleep(2000);
            ba4.RemoveBalance(700);
            Thread.Sleep(1000);
            ba4.Transfer(ba1, 3000);
            Queue<BankTransaction> bankTransactions1 = ba4.Transactions;
            foreach (var trans in bankTransactions1)
            {
                Console.WriteLine();
                Console.WriteLine(trans);
            }

            Console.WriteLine("\nУпраженение 9.3");
            Console.WriteLine("Программа создает объекты класса банк, в котором при изменении баланса, транзации записываются в файл");
            BankAccount ba5 = new BankAccount(2000, BankAccount.BankAccountType.savings);
            ba5.AddBalance(2300);
            Thread.Sleep(2000);
            ba5.RemoveBalance(4000);
            Thread.Sleep(1000);
            ba5.Transfer(ba4, 500);
            ba5.Dispose();

            Console.WriteLine("\nДом. задание 9.1");
            Console.WriteLine("Программа создает объекты класса песня, с новыми конструкторами");
            List<Song> songs = new List<Song>();
            Song song1 = new Song("Billie Jean", "Michael Jackson");
            Song song2 = new Song("Stairway to Heaven", "Led Zeppelin", song1);
            Song song3 = new Song();

            songs.Add(song1);
            songs.Add(song2);
            songs.Add(song3);

            foreach (var song in songs)
            {
                Console.WriteLine(song.Title());
            }

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
