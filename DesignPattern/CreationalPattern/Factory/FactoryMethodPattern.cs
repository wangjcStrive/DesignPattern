using DesignPattern.CreationalPattern.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPattern
{
    /// <summary>
    /// 优点
    ///     增加新的产品无需修改现有系统，开放封闭原则
    /// 缺点
    ///     增加新产品的同时需要增加新的工厂，导致系统类的个数成对增加，在一定程度上增加了系统的复杂性
    /// 当需要添加新的product时，需要修改的地方
    ///     0. 新product类
    ///     1. 客户端代码需要修改 -> 通过反射 + 配置文件可以不需要修改代码
    ///     2. 添加新的concreateFactorx类，而不需要修改iFactoryMethodBase
    /// </summary>
    public interface iFactoryMethodBase
    {
        public Product createProduct();
    }

    public class ConcreateFactoryA : iFactoryMethodBase
    {
        public Product createProduct()
        {
            return new ConcreteProductA();
        }
    }

    public class ConcreateFactoryB : iFactoryMethodBase
    {
        public Product createProduct()
        {
            return new ConcreteProductB();
        }
    }
}
