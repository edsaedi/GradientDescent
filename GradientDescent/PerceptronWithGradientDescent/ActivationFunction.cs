﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PerceptronWithGradientDescent
{
    public class ActivationFunction
    {
        Func<double, double> function;
        Func<double, double> derivative;
        public ActivationFunction(Func<double, double> function, Func<double, double> derivative)
        {
            this.function = function;
            this.derivative = derivative;
        }

        public double Function(double input)
        {
            return function.Invoke(input);
        }

        public double Derivative(double input)
        {
            return derivative.Invoke(input);
        }
    }
}
