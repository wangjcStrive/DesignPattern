using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPattern.Factory
{
    /// <summary>
    /// 解耦，在工厂类里没有出现产品类的信息。
    /// 可以与配置文件配合使用
    /// </summary>
    public static class ReflectFactory
    {
        public static Product getProduct(string typeName)
        {
            Type type = Type.GetType(typeName, true, true);
            var instance = type?.Assembly.CreateInstance(typeName) as Product;

            return instance;
        }
    }
}
