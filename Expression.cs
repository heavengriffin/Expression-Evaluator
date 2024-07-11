using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningVirtualMethods
{
    public abstract class Expression
    {
        public abstract double Evaluate(Hashtable vars);
    }

    public class Constant : Expression
    {
        public double value { get;set;}

        public Constant(double value)
        {
            this.value = value;
        }

        public override double Evaluate(Hashtable vars)
        {
            return value;
        }
    }

    public class VariableReference : Expression
    {
        public string name;

        public VariableReference(string name)
        {
            this.name = name;
        }

        public override double Evaluate(Hashtable vars)
        {
            object? value = vars[name];
            if (value == null)
            {
                throw new Exception("Unkown variable: " + name);
            }
            return Convert.ToDouble(value);
        }
    }

    public class Operation : Expression
    {
        public Expression left;
        public char op;
        public Expression right;

        public Operation(Expression left, char op, Expression right)
        {
            this.left = left;
            this.op = op;
            this.right = right;
        }

        public override double Evaluate(Hashtable vars)
        {
            double x = left.Evaluate(vars);
            double y = right.Evaluate(vars);
            switch (op)
            {
                case '+': return x + y;
                case '-': return x - y;
                case '*': return x * y;
                case '/': return x / y;
            }
            throw new Exception("Unknown operator");
        }
    }
}
