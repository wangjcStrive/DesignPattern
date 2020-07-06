#define SimpleFactoryPattern
#define ReflectFactoryPattern
#define FactoryMethodPattern

using System;
using DesignPattern.CreationalPattern;
using DesignPattern.CreationalPattern.Factory;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Product product;
#if SimpleFactoryPattern
                Console.WriteLine("SimpleFactoryPattern!");
                product = SimpleFactory.getProduct(ProductEnum.a_product);
                product.methodDiff();
                product = SimpleFactory.getProduct(ProductEnum.b_product);
                product.methodDiff();
#endif

#if ReflectFactoryPattern
                Console.WriteLine("\nReflectFactoryPattern!");
                product = ReflectFactory.getProduct("DesignPattern.CreationalPattern.Factory.ConcreteProductA");
                product.methodDiff();
#endif

#if FactoryMethodPattern
                Console.WriteLine("\nFactoryMethodPattern!");
                iFactoryMethodBase fac = new ConcreateFactoryA();
                product = fac.createProduct();
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
