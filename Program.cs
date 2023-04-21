using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    delegate  void myDel(string _text);
    internal class Program
    {
        static void Print(string _text){
            Console.WriteLine(_text);
        }
        static void WriteToFile(string _text) {
            string _name = "output.txt";
            //первый способ 
            var sr = new StreamWriter(_name,true);
            sr.WriteLine(_text);//записали нашу строчку
            sr.Close();//закрыли поток
            //второй способ
            using (var sr1 = new StreamWriter(_name))
            {
                sr1.WriteLine(_text);
            }  
        }
        static void Main(string[] args)
        {
            myDel output;
            output = Print;//создали делегат
            output += WriteToFile; //можем в делегат складывать методы
            output($"Hello! {DateTime.Now}");//этот метод не проверяет пуст ли файл
            output.Invoke($"Hello! {DateTime.Now.ToString("HH:mm:ss:ffff")}");//метод делегата проверяет не пуст ли файл
            output.Invoke(null);
            output(null);
            Console.ReadKey();
        }
    }
}
