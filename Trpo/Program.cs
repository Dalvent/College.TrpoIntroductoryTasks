using System;

namespace Trpo_task_1
{
    public class A
    {
    }

    public class B : A
    {
        public object Value1 { get; set; }
    }

    public class C : B
    {
        public object Value2 { get; set; }
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            var a1 = new A();

            var b1 = new B();
            var b2 = new B();
            var b3 = new B();

            var c1 = new C();

            b1.Value1 = a1;
            b2.Value1 = b3;
            b3.Value1 = a1;

            c1.Value1 = b1;
            c1.Value2 = b2;
        }
    }
}