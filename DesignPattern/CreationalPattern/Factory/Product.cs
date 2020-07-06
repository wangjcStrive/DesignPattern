using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPattern.Factory
{
    public enum ProductEnum
    {
        a_product,
        b_product
    }

    public abstract class Product
    {
        public void methodName()
        {
            Console.WriteLine("this is product common method");
        }
        public abstract void methodDiff();
    }

    public class ConcreteProductA : Product
    {
        public override void methodDiff()
        {
            Console.WriteLine("this is ConcreteProductAAAA product");
        }
    }

    public class ConcreteProductB : Product
    {
        public override void methodDiff()
        {
            Console.WriteLine("this is ConcreteProductBBBB product");
        }
    }
}
