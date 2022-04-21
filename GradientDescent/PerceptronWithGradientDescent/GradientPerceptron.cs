using System;
using System.Collections.Generic;
using System.Text;

namespace PerceptronWithGradientDescent
{
    public class GradientPerceptron : Perceptron
    {
        public double LearningRate { get; set; }
        public double[] weights;
        public double bias;

        ErrorFunction errorFunction;
        ActivationFunction activationFunction;

        public GradientPerceptron(int amountOfInputs, double learningRate, ActivationFunction activationFunction, ErrorFunction errorFunction)
             : base(amountOfInputs, errorFunction.Function)//Base initializes weights, bias, and errorFunc
        {
            LearningRate = learningRate;
            this.activationFunction = activationFunction;
            this.errorFunction = errorFunction;
        }

        //Randomize is in base class

        public double Compute(double[] inputs)
        {
            /*computes the output with given input*/
            return 0;        
        }

        public double[] Compute(double[][] inputs)
        {
            /*computes the output for each row of inputs*/
            return null;
        }

        //Get error is in base class

        public double Train(double[] inputs, double desiredOutput)
        {
            /*trains the perceptron using gradient descent for one iteration and returns the error */
            return 0;
        }

        public double Train(double[][] inputs, double[] desiredOutput)
        {
            /*batch trains the perceptron using gradient descent for one iteration and returns the error */
            return 0;
        }
    }
}
