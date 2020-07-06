using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPattern.Factory
{
    public abstract class AbstractCar
    {
        protected abstract void DoOperation();

        public void getInfo()
        {
            Console.WriteLine($"I am {this.GetType().Name}");
        }
    }

    public class BMWCar : AbstractCar
    {
        protected override void DoOperation()
        {
            throw new NotImplementedException();
        }
    }

    public class BYDCar : AbstractCar
    {
        protected override void DoOperation()
        {
            throw new NotImplementedException();
        }
    }
}
