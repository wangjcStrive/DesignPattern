using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// 当需要添加新的product时，需要修改的地方
///     1. 新的product
///     2. 工厂类的if/else -> 违反了开放封闭原则
/// </summary>
namespace DesignPattern.CreationalPattern
{
    abstract class Product
    {
        public void methodName()
        {
            Console.WriteLine("this is product common method");
        }
        public abstract void methodDiff();
    }

    class ConcreteProductA : Product
    {
        public override void methodDiff()
        {
            Console.WriteLine("this is ConcreteProductAAAA product");
        }
    }

    class ConcreteProductB : Product
    {
        public override void methodDiff()
        {
            Console.WriteLine("this is ConcreteProductBBBB product");
        }
    }

    class SimpleFactory
    {
        public static Product getProduct(string str)
        {
            Product product = null;
            if (str.Equals("A"))
            {
                product = new ConcreteProductA();
            }
            else if(str.Equals("B"))
            {
                product = new ConcreteProductB();
            }
            else
            {
                throw new Exception("error product type");
            }
            return product;
        }
    }
}
