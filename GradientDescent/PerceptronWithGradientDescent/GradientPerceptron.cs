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
        
        //Not needed because there is a shared 
        //public double Compute(double[] inputs)
        //{
        //    /*computes the output with given input*/

        //    double activationInput = base.Compute(inputs);
        //    return activationFunction.Function(activationInput);
        //}

        //Compute[] is in the base class

        //Get error is in base class

        void PartialWeight()
        {
            //derivative of activation function is easy
            activationFunction.Derivative(/*input*/);
        }

        void PartialBias()
        {
            //derivative of activation function is easy
            activationFunction.Derivative(/*input*/);
        }

        public double Train(double[] inputs, double desiredOutput)
        {
            /*trains the perceptron using gradient descent for one iteration and returns the error */
            //computed has the activation function in it.
            double computed = base.Compute(inputs);
            double output = activationFunction.Function(computed);
            double error = errorFunction.Function(output, desiredOutput);

            //double learningRate 



            
            //LearningRate * (-1) * (partial derivative)


            return error;
        }

        public double Train(double[][] inputs, double[] desiredOutput)
        {
            /*batch trains the perceptron using gradient descent for one iteration and returns the error */
            return 0;
        }
    }
}
