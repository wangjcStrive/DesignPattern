using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DesignPattern.StructuralPattern
{
    /// <summary>
    /// 系统可能有多个角度分类，每种角度都可能发生变化，把这多种角度分离出来让他们独立变化，减少他们之间的耦合。
    /// 用组合关系替代继承关系，把两个不同维度的东西桥接起来。
    /// https://www.runoob.com/design-pattern/bridge-pattern.html
    /// 1. 添加新的形状，或新的颜色需要修改的地方
    ///     
    /// </summary>
    public interface IColorDrawAPI
    {
        public void drawShape(int x, int y);
    }

    public class RedDraw : IColorDrawAPI
    {
        public void drawShape(int x, int y)
        {
            Console.WriteLine($"RedDraw draw {x} {y}");
        }
    }

    public class GreedDraw : IColorDrawAPI
    {
        public void drawShape(int x, int y)
        {
            Console.WriteLine($"Greed draw {x} {y}");
        }
    }


    /// <summary>
    /// 抽象化角色，包含一个实现化对象的引用,其里面有shape需要用到的东西。在这里是颜色
    /// </summary>
    public abstract class Shape
    {
        //shape里会有其他的一些与图形有关的成员变量


        protected IColorDrawAPI m_colorDraw;
        public Shape(IColorDrawAPI draw)
        {
            m_colorDraw = draw;
        }
        //调用colorDraw去实际的画图形
        public abstract void draw();
    }

    public class Circle : Shape
    {
        private int m_x, m_y, m_radius;
        public Circle(int x, int y, int radius, IColorDrawAPI colorDraw) : base(colorDraw)
        {
            m_x = x;
            m_y = y;
            m_radius = radius;
        }
        public override void draw()
        {
            Console.Write("Circle: ");
            m_colorDraw.drawShape(m_x, m_y);
        }
    }

    public class Rectangle : Shape
    {
        private int m_x, m_y, m_height, m_width;

        public Rectangle(int x, int y, int height, int width, IColorDrawAPI colorDraw):base(colorDraw)
        {
            m_x = x;
            m_y = y;
            m_height = height;
            m_width = width;
        }
        public override void draw()
        {
            Console.Write("Rectangle: ");
            base.m_colorDraw.drawShape(m_x, m_y);
        }
    }
}
