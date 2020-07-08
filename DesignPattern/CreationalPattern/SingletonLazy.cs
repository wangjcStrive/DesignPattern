using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPattern
{
    /// <summary>
    /// 不是线程安全的，如果两个线程同时访问
    /// </summary>
    public class SingletonLazy
    {
        /// <summary>
        /// 不要在这里new出instance
        /// </summary>
        private static SingletonLazy m_instance;

        private SingletonLazy() { }

        public static SingletonLazy Instance()
        {
            return m_instance ?? (m_instance = new SingletonLazy());
        }
    }
}
