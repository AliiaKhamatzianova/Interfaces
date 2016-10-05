using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public static class Extensions
    {
        public static void Done(this IQuack quacker)
        {
            Console.WriteLine("Done quack");
        }

        public static void Quack(this IQuack quacker)
        {
            Console.WriteLine("Quack");
        }

        public static void Ready(this IQuack quacker)
        {
            Console.WriteLine("Ready to Quack");
        }
    }

    public interface IQuack
    {
        void Quack();
        void Ready();
    }

    public interface IFly
    {
        void Fly();
        void Ready();
    }

    public class Duck : IQuack, IFly
    {
        public void Fly()
        {
            Console.WriteLine("Duck fly!");
        }

        public void Quack()
        {
            Console.WriteLine("Duck quack!");
        }

        public void Ready()
        {
            Console.WriteLine("Ready to quack and fly");
        }

        void IQuack.Ready()
        {
            Console.WriteLine("Ready to quack");
        }

        void IFly.Ready()
        {
            Console.WriteLine("Ready to fly");
        }

    }

    public interface IPrintable<T>
    {
        void Print(T obj);
    }

    public class IntPrint:IPrintable<int>
    {
        public void Print(int obj)
        {
            Console.WriteLine(obj);
        }
    }

    public class Printer<T>:IPrintable<T> // where T:struct // type constraint
    {
        public void Print(T obj)
        {
            Console.WriteLine(obj);
        }
    }

    public interface IConvertable<in T,out TResult>
    {
        TResult Convert(T obj);
    }


    /*
    public class ToStringConverter<T,TResult> :IConvertable<T,TResult>
    {
        public TResult Convert(T obj)
        {
            return obj.ToString();
        }


        public TResult Convert(IQuack duck)
        {
            return duck.ToString();
        }

        string IConvertable<T, TResult>.Convert(T obj)
        {
            return obj.ToString();
        }
    }
    */

    class Program
    {
        static void Main(string[] args)
        {
            #region
            /*
            
            Duck duck1 = new Duck();
            duck1.Ready();
            duck1.Quack();
            duck1.Fly();
            duck1.Done();

            IQuack quack1 = new Duck();
            quack1.Ready();
            quack1.Quack();
            quack1.Done();
            */
            #endregion

            //var array = new[] { 1,2,3,4,5,6,7,8};
            //int[] even = array.Where(x => x % 2 == 0).ToArray(); //LINQ

            IPrintable<int> printer = new Printer<int>();
            printer.Print(2);
            /*
            var converter = new ToStringConverter<int>();
            converter.Convert(5);

            IEnumerable<IQuack> quacks = new List<Duck>(); //ковариация IQuack ->Duck

            IConvertable<Duck,object> converter2 = new ToStringConverter<Duck>();
            IQuack duck = new Duck();
            string str = converter2.Convert(duck);*/
        }
    }
}
