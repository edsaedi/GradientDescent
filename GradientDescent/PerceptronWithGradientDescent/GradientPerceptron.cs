using System;
using System.Collections.Generic;
using System.Text;

namespace PerceptronWithGradientDescent
{
    public class GradientPerceptron : Perceptron
    {
        public double LearningRate { get; set; }

        ErrorFunction errorFunction;

        public GradientPerceptron(int amountOfInputs, double learningRate, ActivationFunction activationFunction, ErrorFunction errorFunction, Random random)
             : base(amountOfInputs, errorFunction.Function, random)//Base initializes weights, bias, and errorFunc
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

        public double Train(double[] inputs, double desiredOutput)
        {
            /*trains the perceptron using gradient descent for one iteration and returns the error */
            //computed has the activation function in it.
            double computed = Compute(inputs);
            double output = activationFunction.Function(computed);
            double error = errorFunction.Function(output, desiredOutput);

            //Computes weightChangeScalar = e(o,d) * a'(z) * -LearningRate;
            //learning rate is inputed
            double weightChangeScalar = errorFunction.Derivative(output, desiredOutput) * activationFunction.Derivative(computed) * -LearningRate;

            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] += weightChangeScalar * inputs[i];
            }
            //LearningRate * (-1) * (partial derivative)
            bias += weightChangeScalar;

            return error;
        }

        public double Train(double[][] inputs, double[] desiredOutput)
        {
            /*batch trains the perceptron using gradient descent for one iteration and returns the error */
            double[] computed = base.Compute(inputs);

            double[] output = new double[inputs.Length];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = activationFunction.Function(computed[i]);
            }

            double error = GetError(inputs, desiredOutput);

            for (int i = 0; i < desiredOutput.Length; i++)
            {
                double weightChangeScalar = errorFunction.Derivative(output[i], desiredOutput[i]) * activationFunction.Derivative(computed[i]) * -LearningRate;

                for (int j = 0; j < weights.Length; j++)
                {
                    weights[j] += weightChangeScalar * inputs[i][j];
                }
                bias += weightChangeScalar;
            }
            
            return error;
        }

        public double TrainForIterations(double[][] inputs, double[] desiredOutputs, int trainingIterations)
        {
            double error = 0;
            for (int i = 0; i < trainingIterations; i++)
            {
                error = Train(inputs, desiredOutputs);
            }
            return error;
        }
    }
}
