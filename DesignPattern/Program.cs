#define SimpleFactory

using System;
using DesignPattern.CreationalPattern;


namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
#if SimpleFactory
                Product product;
                product = SimpleFactory.getProduct("A");
                product.methodDiff();
                product = SimpleFactory.getProduct("C");
                product.methodDiff();
#endif

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
