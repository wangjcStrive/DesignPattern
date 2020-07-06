using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPattern.Factory
{
    public abstract class AbstractBus
    {
        protected abstract void DoOperation();

        public void getInfo()
        {
            Console.WriteLine($"I am {this.GetType().Name}");
        }
    }

    public class BMWBus : AbstractBus
    {
        protected override void DoOperation()
        {
            throw new NotImplementedException();
        }
    }

    public class BYDBus : AbstractBus
    {
        protected override void DoOperation()
        {
            throw new NotImplementedException();
        }
    }
}
