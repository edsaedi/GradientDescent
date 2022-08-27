using System;
using System.Collections.Generic;
using System.Text;

namespace PerceptronWithGradientDescent
{
    public abstract class PerceptronBase
    {
        public double[] weights;
        public double bias;
        protected Random random;
        protected Func<double, double, double> errorFunc;
        protected ActivationFunction activationFunction;
        public double currentError;

        public PerceptronBase(double[] weights, Random random, Func<double, double, double> errorFunc)
        {
            this.weights = weights;
            this.random = random;
            this.errorFunc = errorFunc;
        }

        public PerceptronBase(double[] weights, Random random, Func<double, double, double> errorFunc, ActivationFunction activationFunction)
            : this(weights, random, errorFunc)
        {
            this.activationFunction = activationFunction;
        }

        public PerceptronBase(double[] weights, double bias, Random random, Func<double, double, double> errorFunc, ActivationFunction activationFunction)
            : this(weights, random, errorFunc, activationFunction)
        {
            this.bias = bias;
        }

        public void Randomize(Random random, double min, double max)
        {
            /*Randomly generates values for every weight including the bias*/

            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = random.NextDouble(min, max);
            }

            bias = random.NextDouble(min, max);
        }

        public double Compute(double[] inputs)
        {
            double result = bias;
            /*computes the output with given input*/

            for (int i = 0; i <= inputs.Length - 1; i++)
            {
                result += (weights[i] * inputs[i]);
            }

            return result;

            //return activationFunction.Function(result);
        }

        public double[] Compute(double[][] inputs)
        {
            double[] result = new double[inputs.Length];
            /*computes the output for each row of inputs*/

            for (int i = 0; i <= result.Length - 1; i++)
            {
                result[i] = Compute(inputs[i]);
            }

            return result;
        }

        public double GetError(double[][] inputs, double[] desiredOutputs)
        {
            double error = 0;
            var outputs = Compute(inputs);

            for (int i = 0; i < outputs.Length; i++)
            {
                error += errorFunc.Invoke(desiredOutputs[i], outputs[i]);
            }

            error /= outputs.Length;
            return error;
            /*computes the output using the inputs returns the average error between each output row and each desired output row using errorFunc*/
        }

        public abstract double Train(double[][] inputs, double[] desiredOutputs);

        //public abstract double Train(double[][] input, double output);
        //This is wierd that it is not the train function with double[], double

    }
}
