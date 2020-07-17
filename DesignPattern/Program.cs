//#define SimpleFactoryPattern
//#define ReflectFactoryPattern
//#define FactoryMethodPattern
//#define AbstractFactoryPattern
//#define BuilderPattern
//#define AdapterPattern
//#define BridgePattern
#define DecoratorPattern

using System;
using DesignPattern.CreationalPattern;
using DesignPattern.CreationalPattern.Factory;
using DesignPattern.StructuralPattern;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Product product;
#if SimpleFactoryPattern
                Console.WriteLine("SimpleFactoryPattern!");
                product = SimpleFactory.getProduct(ProductEnum.a_product);
                product.methodDiff();
                product = SimpleFactory.getProduct(ProductEnum.b_product);
                product.methodDiff();
#endif

#if ReflectFactoryPattern
                Console.WriteLine("\nReflectFactoryPattern!");
                product = ReflectFactory.getProduct("DesignPattern.CreationalPattern.Factory.ConcreteProductA");
                product.methodDiff();
#endif

#if FactoryMethodPattern
                Console.WriteLine("\nFactoryMethodPattern!");
                iFactoryMethodBase fac = new ConcreateFactoryA();
                product = fac.createProduct();
                product.methodDiff();
#endif

#if AbstractFactoryPattern
                Console.WriteLine("\nAbstractFactoryPattern!");
                BMWFactory bmw = new BMWFactory();
                bmw.createCar().getInfo();
                bmw.createBus().getInfo();

                BYDFactory byd = new BYDFactory();
                byd.createCar().getInfo();
                byd.createBus().getInfo();
#endif
#if BuilderPattern
                Director director = new Director();
                HPBuilder hpBuilder = new HPBuilder();
                DELLBuilder dellBuilder = new DELLBuilder();

                //组装HP PC
                Computer hpPC = director.Construct(hpBuilder);
                hpPC.showSteps();
                //组装DELL PC
                Computer dellPC = director.Construct(dellBuilder);
                dellPC.showSteps();
#endif
#if AdapterPattern
                AudioPlayer player = new AudioPlayer();
                player.play(AudioTypeEnum.MP3, "aaa");
                player.play(AudioTypeEnum.MP4, "bbb");
                player.play(AudioTypeEnum.VLC, "ccc");

                Console.WriteLine();
                ClassPatternAudioPlayer classPatternPlayer = new ClassPatternAudioPlayer();
                classPatternPlayer.play(AudioTypeEnum.MP3, "ddd");
                classPatternPlayer.play(AudioTypeEnum.MP4, "eee");
#endif

#if BridgePattern
                Shape redCircle = new Circle(1, 1, 1, new RedDraw());
                redCircle.draw();
                Shape redRectangle = new Rectangle(2, 2, 2, 2, new RedDraw());
                redRectangle.draw();
                Shape greenCircle = new Circle(3, 3, 3, new GreedDraw());
                greenCircle.draw();
                Shape greenRectangle = new Rectangle(4, 4, 4, 4, new GreedDraw());
                greenRectangle.draw();
#endif
#if DecoratorPattern
                IShape circle = new CircleA();
                ShapeDecorator redCircle = new RedShapeDecorator(new CircleA());
                ShapeDecorator redRectangle = new RedShapeDecorator(new RectangleA());

                circle.draw();
                redCircle.draw();
                redRectangle.draw();
                //新的类仍然具有zoom的功能
                redRectangle.zoom();

#endif
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
