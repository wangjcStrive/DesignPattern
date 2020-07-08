using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPattern
{
    public class SingletonLock
    {
        private static SingletonLock m_instance;
        private static readonly object m_locker = new object();

        private SingletonLock() { }

        public static SingletonLock Instance()
        {
            if (m_instance == null)
            {
                lock(m_locker)
                {
                    //这个是必须的吗？
                    if (m_instance == null)
                        m_instance = new SingletonLock();
                }
            }
            return m_instance;
        }
    }
}
