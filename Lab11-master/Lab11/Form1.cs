using Lab11.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab11
{
    public partial class Form1 : Form
    {
        string label2Str = "0"; // formula str
        string label3Str = "0"; // curr input
        string[] basicOperationSigns = new string[] { "+", "-", "*", "/" };
        double result = 0;

        Context context = new Context();
        CalculateState calcState = new CalculateState();
        InitialState initState = new InitialState();
        InputState inputState = new InputState();
        ResultState resultState = new ResultState();

        public Form1()
        {
            InitializeComponent();
            label2.Text = "0";
            label3.Text = "0";
            context.setState(new InitialState());
        }

        private void BackButton_Click(object sender, EventArgs e)
        {

            var stateNum = context.getState().stateNum;
            //backspace btn
            if(context.getState().stateNum == (int)CalculatorStateEnum.Input)
            {
                if((label2.Text.Length > 1 && label2.Text.Substring(0, 1) == "√"))
                {

                }else if((label2.Text.Length > 2 && label2.Text.Substring(0, 2) == "1/"))
                {

                }
                else
                {
                    if (label3Str != "0")
                    {
                        if (label3Str.Length < 2)
                        {
                            label3.Text = "0";
                        }
                        else
                        {
                            label3.Text = label3Str.Remove(label3Str.Length - 1, 1);
                            label3Str = label3.Text;
                        }
                        label3Str = label3.Text;
                    }
                    if (label2Str == "0" && label3Str == "0")
                    {
                        //set the state to init
                        context.setState(initState);
                    }
                }
            }
            else if(context.getState().stateNum == (int)CalculatorStateEnum.Result)
            {
                label2Str = "";
                label2.Text = label2Str;
            }
            else
            {
                if (label3Str != "0")
                {
                    if (label3Str.Length < 2)
                    {
                        label3.Text = "0";
                    }
                    else
                    {
                        label3.Text = label3Str.Remove(label3Str.Length - 1, 1);
                        label3Str = label3.Text;
                    }
                    label3Str = label3.Text;
                }
                if (label2Str == "0" && label3Str == "0")
                {
                    //set the state to init
                    context.setState(initState);
                }
            }


        }

        private void CEButton_Click(object sender, EventArgs e)
        {
            if(context.getState().stateNum == (int)CalculatorStateEnum.Result)
            {
                label2Str = "0";
                label2.Text = label2Str;
            }
            label3Str = "0";
            label3.Text = label3Str;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            label2Str = "0";
            label3Str = "0";

            context.setState(initState);
            label2.Text = label2Str;
            label3.Text = label3Str;

        }

        private void PlusMinusSignButton_Click(object sender, EventArgs e)
        {
            //substring "-" or "+" to label3Str
            var original = label3.Text;
            if (original == "0")
            {
                return;
            }
            if (original.StartsWith('-'))
            {
                //if it starts with '-', then remove '-'
                label3Str = original.Remove(original.IndexOf("-"), 1);
                label3.Text = label3Str;
            }
            else
            {
                //add '-' to front
                label3Str = original.Insert(0, "-");
                label3.Text = label3Str;
            }
        }

        private void SquareRootButton_Click(object sender, EventArgs e)
        {
            //sqrt √
            if (context.getState().stateNum == (int)CalculatorStateEnum.Input || context.getState().stateNum == (int)CalculatorStateEnum.Result)
            {
                context.setState(calcState);
                var original = label3.Text;
                double parsedValue = 0;
                var canParse = double.TryParse(label3.Text, out parsedValue);
                if (!canParse)
                {
                    var lastChar = label2.Text[label2.Text.Length - 1];
                    label2.Text.Remove(lastChar);
                    double.TryParse(label2.Text, out parsedValue);
                }
                if (parsedValue > 0)
                {
                    var sqrtResult = Math.Sqrt(parsedValue);
                    label3Str = sqrtResult.ToString();
                }
                else
                {
                    label3Str = "Error! Press C to restart.";
                }
                label2Str = "√" + label3.Text;
                label3.Text = label3Str;
                label2.Text = label2Str;
            }
            context.setState(inputState);
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            //7
            if (context.getState().stateNum == (int)CalculatorStateEnum.Init || label3Str == "0")
            {
                label3Str = "7";
            }
            else
            {
                label3Str += "7";
            }
            context.setState(inputState);
            label3.Text = label3Str;
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            //8
            if (context.getState().stateNum == (int)CalculatorStateEnum.Init || label3Str == "0")
            {
                label3Str = "8";
            }
            else
            {
                label3Str += "8";
            }
            context.setState(inputState);
            label3.Text = label3Str;
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            //9
            if (context.getState().stateNum == (int)CalculatorStateEnum.Init || label3Str == "0")
            {
                label3Str = "9";
            }
            else
            {
                label3Str += "9";
            }
            context.setState(inputState);
            label3.Text = label3Str;
        }

        private void DivisionButton_Click(object sender, EventArgs e)
        {
            // /
            var lastChar = label2.Text[label2.Text.Length - 1];
            if (basicOperationSigns.Contains(lastChar.ToString()))
            {
                int charLocation = label2.Text.IndexOf(lastChar, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    var newStr = label2.Text.Substring(0, charLocation);
                    label2.Text = newStr + "/";
                    label2Str = label2.Text;
                }
            }
            else
            {
                label2.Text = label3Str + "/";
                label2Str = label2.Text;
            }
            context.setState(initState);
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            //4
            if (context.getState().stateNum == (int)CalculatorStateEnum.Init || label3Str == "0")
            {
                label3Str = "4";
            }
            else
            {
                label3Str += "4";
            }
            context.setState(inputState);
            label3.Text = label3Str;
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            //5
            if (context.getState().stateNum == (int)CalculatorStateEnum.Init || label3Str == "0")
            {
                label3Str = "5";
            }
            else
            {
                label3Str += "5";
            }
            context.setState(inputState);
            label3.Text = label3Str;
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            //6
            if (context.getState().stateNum == (int)CalculatorStateEnum.Init || label3Str == "0")
            {
                label3Str = "6";
            }
            else
            {
                label3Str += "6";
            }
            context.setState(inputState);
            label3.Text = label3Str;
        }

        private void MultiplicationButton_Click(object sender, EventArgs e)
        {
            //*
            // if label2.Text already includes one of basicOperationSigns, replace
            // if not, just add the operator
            var lastChar = label2.Text[label2.Text.Length - 1];
            if (basicOperationSigns.Contains(lastChar.ToString()))
            {
                int charLocation = label2.Text.IndexOf(lastChar, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    var newStr = label2.Text.Substring(0, charLocation);
                    label2.Text = newStr + "*";
                    label2Str = label2.Text;
                }
            }
            else
            {
                label2.Text = label3Str + "*";
                label2Str = label2.Text;
            }
            context.setState(initState);
        }

        private void ReciprocalButton_Click(object sender, EventArgs e)
        {
            // 1/x
            if (context.getState().stateNum == (int)CalculatorStateEnum.Input || context.getState().stateNum == (int)CalculatorStateEnum.Result)
            {
                context.setState(calcState);
                var original = label3.Text;
                double parsedValue = 0;
                var canParse = double.TryParse(label3.Text, out parsedValue);
                if (!canParse)
                {
                    var lastChar = label2.Text[label2.Text.Length - 1];
                    label2.Text.Remove(lastChar);
                    double.TryParse(label2.Text, out parsedValue);
                }
                if (parsedValue == 0)
                {
                    label3Str = "Error! Press C to restart.";
                    label2Str = "1/" + label3.Text;
                    label3.Text = label3Str;
                    label2.Text = label2Str;
                }
                else
                {
                    label3Str = (1 / parsedValue).ToString();
                    label2Str = "1/" + label3.Text;
                    label3.Text = label3Str;
                    label2.Text = label2Str;
                }
            }
            context.setState(inputState);
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            //1
            if (context.getState().stateNum == (int)CalculatorStateEnum.Init || label3Str == "0")
            {
                label3Str = "1";
            }
            else
            {
                label3Str += "1";
            }
            context.setState(inputState);
            label3.Text = label3Str;

        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            //2
            if (context.getState().stateNum == (int)CalculatorStateEnum.Init || label3Str == "0")
            {
                label3Str = "2";
            }
            else
            {
                label3Str += "2";
            }
            context.setState(inputState);
            label3.Text = label3Str;
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            //3
            if (context.getState().stateNum == (int)CalculatorStateEnum.Init || label3Str == "0")
            {
                label3Str = "3";
            }
            else
            {
                label3Str += "3";
            }
            context.setState(inputState);
            label3.Text = label3Str;
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            //-
            var lastChar = label2.Text[label2.Text.Length - 1];
            if (basicOperationSigns.Contains(lastChar.ToString()))
            {
                int charLocation = label2.Text.IndexOf(lastChar, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    var newStr = label2.Text.Substring(0, charLocation);
                    label2.Text = newStr + "-";
                    label2Str = label2.Text;
                }
            }
            else
            {
                label2.Text = label3Str + "-";
                label2Str = label2.Text;
            }
            context.setState(initState);
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            //0
            if (context.getState().stateNum == (int)CalculatorStateEnum.Init)
            {
                label3Str = "0";
            }
            else
            {
                label3Str += "0";
            }
            context.setState(inputState);
            label3.Text = label3Str;
        }

        private void DecimalButton_Click(object sender, EventArgs e)
        {
            //.
            var lastChar = label3.Text[label3.Text.Length - 1];
            if (lastChar == '.')
            {
                //do nothing
            }
            else
            {
                label3Str += ".";
                label3.Text = label3Str;
            }
            context.setState(inputState);
        }

        private void AdditionButton_Click(object sender, EventArgs e)
        {
            //+
            var lastChar = label2.Text[label2.Text.Length - 1];
            if (basicOperationSigns.Contains(lastChar.ToString()))
            {
                int charLocation = label2.Text.IndexOf(lastChar, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    var newStr = label2.Text.Substring(0, charLocation);
                    label2.Text = newStr + "+";
                    label2Str = label2.Text;
                }
            }
            else
            {
                label2.Text = label3Str + "+";
                label2Str = label2.Text;
            }
            context.setState(initState);
        }

        private void EqualSignButton_Click(object sender, EventArgs e)
        {
            //=
            if (context.getState().stateNum == (int)CalculatorStateEnum.Init || context.getState().stateNum == (int)CalculatorStateEnum.Input)
            {
                context.setState(calcState);
                var original = label3.Text;
                var rightHandValue = double.Parse(label3.Text);
                var oper = "";
                int operatorIndex = 0;
                
                foreach (var character in label2.Text)
                {
                    if (basicOperationSigns.Contains(character.ToString()) && operatorIndex != 0)
                    {
                        oper = character.ToString();
                        break;
                    }
                    operatorIndex++;
                }
                double leftHandValue = 0;

                var leftHandValueStr = label2.Text.Substring(0, operatorIndex);
                var canParse = double.TryParse(leftHandValueStr, out leftHandValue);
                if (canParse)
                {
                    if (oper == "+")
                    {
                        result = leftHandValue + rightHandValue;
                        label3Str = result.ToString();
                    }
                    else if (oper == "-")
                    {
                        result = leftHandValue - rightHandValue;
                        label3Str = result.ToString();
                    }
                    else if (oper == "*")
                    {
                        result = leftHandValue * rightHandValue;
                        label3Str = result.ToString();
                    }
                    else if (oper == "/")
                    {
                        if (rightHandValue > 0)
                        {
                            result = leftHandValue / rightHandValue;
                            label3Str = result.ToString();
                        }
                        else
                        {
                            label3Str = "Error! Press C to restart.";
                        }
                    }
                }
                else
                {
                    label3Str = "Error! Press C to restart.";
                }

                label2Str = "";
                if (leftHandValue != 0)
                {
                    if(oper != "")
                    {
                        label2Str += leftHandValue.ToString();
                    }
                }
                if(oper != "0")
                {
                    label2Str += oper;
                }
                label2Str += rightHandValue.ToString() + "=";
                label3.Text = label3Str;
                label2.Text = label2Str;
            }
            else if (context.getState().stateNum == (int)CalculatorStateEnum.Result)
            {
                context.setState(calcState);
                label2.Text = label2.Text.Remove(label2.Text.Length - 1);
                var oper = "";
                var rightHandValStr = "";
                int i = 0;
                bool operatorFound = false;
                foreach (var character in label2.Text)
                {
                    //find the operator
                    if (operatorFound)
                    {
                        rightHandValStr += character.ToString();
                    }
                    if (basicOperationSigns.Contains(character.ToString()) && i != 0)
                    {
                        oper = character.ToString();
                        operatorFound = true;
                    }
                    i++;
                }

                if (string.IsNullOrEmpty(oper))
                {
                    label2Str = label3.Text + "=";
                    label3.Text = label3Str;
                    label2.Text = label2Str;
                }
                else
                {
                    var leftHandValue = double.Parse(label3.Text);
                    var rightHandValue = double.Parse(rightHandValStr);
                    if (oper == "+")
                    {
                        result = leftHandValue + rightHandValue;
                        label3Str = result.ToString();
                    }
                    else if (oper == "-")
                    {
                        result = leftHandValue - rightHandValue;
                        label3Str = result.ToString();
                    }
                    else if (oper == "*")
                    {
                        result = leftHandValue * rightHandValue;
                        label3Str = result.ToString();
                    }
                    else if (oper == "/")
                    {
                        if (rightHandValue > 0)
                        {
                            result = leftHandValue / rightHandValue;
                            label3Str = result.ToString();
                        }
                        else
                        {
                            label3Str = "Error! Press C to restart.";
                        }
                    }
                    label2Str = leftHandValue.ToString() + oper + rightHandValue.ToString() + "=";
                    label3.Text = label3Str;
                    label2.Text = label2Str;
                }
            }
            context.setState(resultState);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
