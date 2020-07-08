using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPattern
{
    /// <summary>
    /// 产品类
    /// </summary>
    public class Computer
    {
        /// <summary>
        /// 类似于Band,可以添加CPU/mouse/keyboard等属性,在create builder时传进去
        /// </summary>
        public string Band { get; set; }

        private List<string> m_assemblyParts = new List<string>();

        public void assemblyPart(string partName)
        {
            this.m_assemblyParts.Add(partName);
        }

        
        public void showSteps()
        {
            Console.WriteLine($"start assemble {Band} PC");
            foreach (var item in m_assemblyParts)
            {
                Console.WriteLine($"assemble {item} ");
            }
            Console.WriteLine($"assemble {Band} done!");
        }
    }

    public abstract class Builder
    {
        /// <summary>
        /// 组装主机
        /// </summary>
        protected abstract void BuildMainFramePart();

        /// <summary>
        /// 组装显示器
        /// </summary>
        protected abstract void BuildScreenPart();

        /// <summary>
        /// 组装输入设备（键鼠）
        /// </summary>
        protected abstract void BuildInputPart();

        /// <summary>
        /// 获取组装PC。由具体的类决定组装顺序
        /// </summary>
        /// <returns>组装好的PC</returns>
        public abstract Computer BuildComputer();
    }
    public class HPBuilder : Builder
    {
        Computer m_computer = new Computer() { Band = "HP" };

        protected override void BuildInputPart()
        {
            m_computer.assemblyPart("mouse");
        }

        protected override void BuildMainFramePart()
        {
            m_computer.assemblyPart("主机");
        }

        protected override void BuildScreenPart()
        {
            m_computer.assemblyPart("screen");
        }
        public override Computer BuildComputer()
        {
            BuildMainFramePart();
            BuildScreenPart();
            BuildInputPart();
            return m_computer;
        }
    }

    /// <summary>
    /// DELLBuilder与HPBuilder内部实现的逻辑应该是不同的
    /// </summary>
    public class DELLBuilder : Builder
    {
        Computer m_computer = new Computer() { Band = "DELL" };

        protected override void BuildInputPart()
        {
            m_computer.assemblyPart("mouse");
        }

        protected override void BuildMainFramePart()
        {
            m_computer.assemblyPart("主机");
        }

        protected override void BuildScreenPart()
        {
            m_computer.assemblyPart("screen");
        }

        public override Computer BuildComputer()
        {
            BuildMainFramePart();
            BuildScreenPart();
            BuildInputPart();
            return m_computer;
        }
    }

    public class Director
    {
        public Computer Construct(Builder builder)
        {
            return builder.BuildComputer();
        }
    }
}
