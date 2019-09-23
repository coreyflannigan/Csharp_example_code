using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    /// <summary>
    /// I, Sean Flannigan, 000270501 certify that this material is my original work. No other person's work has been used without due acknowledgement.
    /// 
    /// 19-09-2019
    /// 
    /// Employee class of the Lab1 program, accepts params passed from the main class that are read in from a text file.
    /// Stores the name, employee number, rate, hours, and gross pay of each Employee, and provides methods to return or set these variables.
    /// </summary>
    class Employee {
        private string name;
        private int number;
        private decimal rate;
        private double hours;
        private decimal gross;

        /// <summary>
        /// Employee class constructor, accepts four params from the main class and stores them in local variables.
        /// </summary>
        /// <param name="name">The name of the Employee</param>
        /// <param name="number">The employee number for the Employee</param>
        /// <param name="rate">The hourly pay rate for the Employeee</param>
        /// <param name="hours">The number of hours worked by the Employee</param>
        public Employee(string name, int number, decimal rate, double hours) {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
            gross = CalculateGross();
        }

        /// <summary>
        /// Calculate method to determine Employee gross pay. Called in initial construction
        /// and again any time hours or rate is set.
        /// </summary>
        /// <returns>A decimal value representing the Employee gross pay, to be stored in the variable gross</returns>
        private decimal CalculateGross() {
            if (hours <= 40) {
                return rate * (decimal)hours;
            }
            else {
                double overtime = hours - 40;
                return (rate * 40) + ((rate + (rate / 2)) * (decimal)overtime);
            }
        }

        /// <summary>
        /// Get method for the gross variable.
        /// Calculates the Employee's gross pay, rate * hours for 40 hours and under,
        /// and time and a half pay for each hour of overtime. Returns the gross variable
        /// after calculation.
        /// </summary>
        /// <returns>The decimal variable gross, which represents the gross pay.</returns>
        public decimal GetGross() {
            return gross;
        }

        /// <summary>
        /// Get method for hours variable.
        /// </summary>
        /// <returns>The double variable hours, which represents hours worked.</returns>
        public double GetHours() {
            return hours;
        }

        /// <summary>
        /// Get method for name variable.
        /// </summary>
        /// <returns>The string variable name, which is the Employee's name.</returns>
        public string GetName() {
            return name;
        }

        /// <summary>
        /// Get method for number variable.
        /// </summary>
        /// <returns>The int variable number, which is the employee number of the Employee.</returns>
        public int GetNumber() {
            return number;
        }

        /// <summary>
        /// Get method for the rate variable.
        /// </summary>
        /// <returns>The decimal variable rate, which is the hourly wage of the Employee.</returns>
        public decimal GetRate() {
            return rate;
        }

        /// <summary>
        /// Overriden To String method. Formats a string made up of the variables contained in the
        /// Employee class in order to apply proper spacing and $ signs.
        /// </summary>
        /// <returns>A string variable made up of the 5 variables contained in the Employee class.</returns>
        public override string ToString() {
            return String.Format($"{name, -34}{number}{rate, 15:c2}{hours, 13:n2}{GetGross(), 15:c2}");
        }

        /// <summary>
        /// Set method for the hours variable.
        /// </summary>
        /// <param name="hours">New number of hours worked by the Employee to be stored in the hours variable.</param>
        public void SetHours(double hours) {
            this.hours = hours;
            gross = CalculateGross();

        }

        /// <summary>
        /// Set method for the name variable.
        /// </summary>
        /// <param name="name">New name of the Employee to be stored in the name variable.</param>
        public void SetName(string name) {
            this.name = name;
        }

        /// <summary>
        /// Set method for the number variable.
        /// </summary>
        /// <param name="number">New employee number for the Employee to be stored in the number variable.</param>
        public void SetNumber(int number) {
            this.number = number;
        }

        /// <summary>
        /// Set method for the rate variable.
        /// </summary>
        /// <param name="rate">New hourly pay rate for the Employee to be stored in the rate variable.</param>
        public void SetRate(decimal rate) {
            this.rate = rate;
            gross = CalculateGross();
        }
    }
}
