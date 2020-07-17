using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// 把一个shape装饰不同的颜色，同时又不改变形状
/// </summary>
namespace DesignPattern.StructuralPattern
{
    public interface IShape
    {
        void draw();
        void zoom();
    }

    public class RectangleA : IShape
    {
        public void draw()
        {
            Console.WriteLine($"shape: RectangleA");
        }

        public void zoom()
        {
            Console.WriteLine($"zoom: RectangleA");
        }
    }
    public class CircleA : IShape
    {
        public void draw()
        {
            Console.WriteLine($"shape: CircleA");
        }

        public void zoom()
        {
            Console.WriteLine($"zoom: CircleA");
        }
    }

    //实现shape接口的抽象装饰类
    public abstract class ShapeDecorator : IShape
    {
        protected IShape m_decoratorShapre;
        public ShapeDecorator(IShape shape)
        {
            m_decoratorShapre = shape;
        }
        public virtual void draw()
        {
            m_decoratorShapre.draw();
        }

        public void zoom()
        {
            m_decoratorShapre.zoom();
        }
    }

    /// <summary>
    ///【扩展了】ShapeDecorator类的实体装饰类
    /// 原来shape类有的功能，RedShapeDecorator类都有，并且新添加了setRedBorder()
    /// </summary>
    public class RedShapeDecorator : ShapeDecorator
    {
        /// <summary>
        /// 要把被装饰的shape传进去
        /// </summary>
        /// <param name="shape"></param>
        public RedShapeDecorator(IShape shape):base(shape)
        {

        }

        public override void draw()
        {
            m_decoratorShapre.draw();
            setRedBorder();
        }

        //新扩展的方法
        private void setRedBorder()
        {
            Console.WriteLine($" border color: red");
        }
    }
}
