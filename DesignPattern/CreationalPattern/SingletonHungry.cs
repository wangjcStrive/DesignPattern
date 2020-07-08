using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPattern
{
    /// <summary>
    /// 无论是否使用该类都会产生该类的实例。但是也是因为这样，不会有线程安全的问题
    /// steps:
    ///     1. 类成员变量就new出instance
    ///     2. private构造，阻止外部new
    ///     3. 提供一个访问的public函数
    /// </summary>
    public class SingletonHungry
    {
        /// <summary>
        /// private的成员变量
        /// </summary>
        private static SingletonHungry m_instance = new SingletonHungry();


        /// <summary>
        /// 进制外部实例化
        /// </summary>
        private SingletonHungry() { }

        public static SingletonHungry Instance()
        {
            return m_instance;
        }
    }
}
