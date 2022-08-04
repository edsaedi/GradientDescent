using System;
using System.Collections.Generic;
using System.Text;

namespace PerceptronWithGradientDescent
{
    public class Perceptron : PerceptronBase
    {
        double currentError;
        double mutationAmount;

        public Perceptron(double[] initialWeightValues, double initialBiasValue, double mutationAmount, Random random, Func<double, double, double> errorFunc, Func<double, double> function, ActivationFunction activationFunction)
        {
            /*initializes the perceptron*/
            weights = initialWeightValues;
            bias = initialBiasValue;
            this.mutationAmount = mutationAmount;
            this.random = random;
            this.errorFunc = errorFunc;
            this.activationFunction = activationFunction;
        }

        public Perceptron(int amountOfInputs, double mutationAmount, Random random, Func<double, double, double> errorFunc, ActivationFunction activationFunction)
        {
            /*Initializes the weights array given the amount of inputs*/
            this.mutationAmount = mutationAmount;
            this.random = random;
            this.errorFunc = errorFunc;
            this.activationFunction = activationFunction;

            weights = new double[amountOfInputs];

        }

        public Perceptron(int amountOfInputs, Func<double, double, double> errorFunc, Random random)
        {
            this.errorFunc = errorFunc;
            this.random = random;
            weights = new double[amountOfInputs];   
        }

        public override double TrainWithHillClimbing(double[][] inputs, double[] desiredOutputs)
        {
            // Randomly Mutate one weight
            ///Random mutation begins:

            double mutation = random.NextDouble(-mutationAmount, mutationAmount);
            int index = random.Next(-1, weights.Length);
            if (index == -1)
            {
                bias += mutation; //bias weight;
            }
            else
            {
                weights[index] += mutation;
            }

            ///Random mutation ends

            // Calculate the new error of the data(just use "GetError" function explained below)

            double newError = GetError(inputs, desiredOutputs);

            // If the new error is better than the current error, update the current error, else undo the mutation.

            if (newError <= currentError)
            {
                return newError;
            }

            else
            {
                if (index == -1)
                {
                    bias -= mutation;
                }
                else
                {
                    weights[index] -= mutation;
                }

                return currentError;
            }
        }
    }
}
