using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPattern.Factory
{
    /// <summary>
    /// 用于产品族，增加产品线很容易，但是无法添加新的产品
    ///     1. 添加产品需要修改
    ///         a. 新的AbstractProduct.cs
    ///         b. IAbstractFactory...所以不能添加新产品
    ///     2. 添加产品线 -> 添加雪佛兰factory
    ///         a. public class XFLFactory : IAbstractFactory
    ///         
    /// </summary>
    public interface IAbstractFactory
    {
        AbstractCar createCar();
        AbstractBus createBus();
    }

    /// <summary>
    /// 宝马工厂
    /// </summary>
    public class BMWFactory : IAbstractFactory
    {
        public AbstractBus createBus()
        {
            return new BMWBus();
        }

        public AbstractCar createCar()
        {
            return new BMWCar();
        }
    }

    public class BYDFactory : IAbstractFactory
    {
        public AbstractBus createBus()
        {
            return new BYDBus();
        }

        public AbstractCar createCar()
        {
            return new BYDCar();
        }
    }
}
