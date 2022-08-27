using System;
using System.Collections.Generic;
using System.Text;

namespace PerceptronWithGradientDescent
{
    abstract class ExampleBase
    {

        protected abstract int a { get; }

        public virtual void DoStuff() { }

        public void hi()
        {
            DoStuff();
        }
    }

    //class Example : ExampleBase
    //{
    //    public override void DoStuff()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
