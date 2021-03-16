using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using ClassLibrary1;

namespace ConsoleApplication
{
    class Program
    {
        static void Parallel()
        {
            DateTime StartTime = DateTime.Now;
            
            Console.WriteLine("Параллельность");

                string Book = File.ReadAllText("pushkin_a_s-text_0170.txt");
            
            MyClass _Exemp_ = new MyClass();

            Dictionary<string, int> _MyDict_;

            _MyDict_ = _Exemp_.Read(Book);
            StreamWriter SW = new StreamWriter(new FileStream("PARALLEL.txt", FileMode.Create, FileAccess.Write));
            foreach (var word in _MyDict_)
            {
                SW.Write($" {word.Key} {word.Value}" + ";\n");
            }
            SW.Close();
            TimeSpan ts = DateTime.Now.Subtract(StartTime);

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime, "RunTime");

            DateTime NeStartTime = DateTime.Now;

        }
        static void Unparallel()
        {
            DateTime StartTime = DateTime.Now;
            Console.WriteLine("Непараллельность");



        string Book = File.ReadAllText("pushkin_a_s-text_0170.txt");
            _MyClass_ Exam = new _MyClass_();

            var _type_ = Exam.GetType();
            
            var WordsIn = (Dictionary<string, int>)_type_.GetMethod("Read", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(Exam, new object[] { Book });
            StreamWriter SW = new StreamWriter(new FileStream("NOPARRALEL.txt", FileMode.Create, FileAccess.Write));
            foreach (var word in WordsIn)
            {
                SW.Write($" {word.Key} {word.Value}" + ";\n");
            }


            SW.Close();

            TimeSpan ts = DateTime.Now.Subtract(StartTime);
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime, "RunTime");

            DateTime NeStartTime = DateTime.Now;

        }
            static void Main(string[] args)
        {
            Parallel();
            Unparallel();
            Console.ReadLine();
        }
    }
}


