#define SimpleFactoryPattern
#define ReflectFactoryPattern
#define FactoryMethodPattern
#define AbstractFactoryPattern

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

#if AbstractFactoryPattern
                Console.WriteLine("\nAbstractFactoryPattern!");
                BMWFactory bmw = new BMWFactory();
                bmw.createCar().getInfo();
                bmw.createBus().getInfo();

                BYDFactory byd = new BYDFactory();
                byd.createCar().getInfo();
                byd.createBus().getInfo();
#endif

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
