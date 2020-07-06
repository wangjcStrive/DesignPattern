using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// 当需要添加新的product时，需要修改的地方
///     1. 新的product
///     2. 工厂类的if/else -> 违反了开放封闭原则
/// </summary>
namespace DesignPattern.CreationalPattern.Factory
{
    public static class SimpleFactory
    {
        public static Product getProduct(ProductEnum pro)
        {
            Product product = null;
            if (pro == ProductEnum.a_product)
            {
                product = new ConcreteProductA();
            }
            else if(pro == ProductEnum.b_product)
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
