using System;
using System.IO;

namespace Solid_Master.Decorator
{
    internal abstract class VisualComponent
    {
        public abstract void Draw();
    }

    internal class TextView : VisualComponent
    {
        public override void Draw()
        {
            Console.WriteLine("Calling TextView.draw()");
        }
    }

    internal class Decorator : VisualComponent
    {
        private readonly VisualComponent _component;

        public Decorator(VisualComponent component)
        {
            _component = component;
        }

        public override void Draw()
        {
            _component?.Draw();
        }
    }

    internal class ScrollDecorator : Decorator
    {
        public ScrollDecorator(VisualComponent component) : base(component)
        {
        }

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("Calling ScrollDecorator.draw()");
        }
    }

    internal class BorderDecorator : Decorator
    {
        public BorderDecorator(VisualComponent component) : base(component)
        {
        }

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("Calling BorderDecorator.draw()");
        }
    }

    public class DecoratorMain
    {
        public static void Main(string[] args)
        {
            //VisualComponent comp = new BorderDecorator(new ScrollDecorator(new TextView()));
            //comp.Draw();


            Console.ReadLine();
        }
    }
}