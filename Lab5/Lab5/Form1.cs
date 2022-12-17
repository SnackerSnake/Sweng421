using Lab5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        readonly static int RADIO_X = 17;
        readonly static int RADIO_Y = 16;
        readonly static int RADIO_INCREMENT = 30;
        readonly static string FILEPATH = @"D:\School\SWENG421\M5\Lab5\Lab5\modules.txt";
        readonly ComputationIF _computation = new Computation();
        List<string> modules;
        double result = 0;

        public Form1()
        {
            InitializeComponent();
            label5.Hide();
            ResetComponents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //show dialog and enter module name
            //this will add a row to the module.txt
            label5.Hide();
            var newModule = textBox2.Text;
            if (_computation.ValidateModule(newModule) && !modules.Contains(newModule)) //check if new module is valid to be created and already exists in modules.txt
            {
                modules.Add(newModule);
                File.AppendAllLines(FILEPATH, new List<string>() { newModule });
                panel1.Controls.OfType<RadioButton>().ToList().ForEach(p => panel1.Controls.Remove(p));
                ResetComponents();
            }
            else
            {
                label5.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Hide();
            var radioBtnToRemove = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if(radioBtnToRemove != null) //check if the radio button to remove exists on panel first
            {
                //remove selected module from text
                var moduleToRemove = radioBtnToRemove?.Text;
                modules.Remove(moduleToRemove);
                File.WriteAllLines(FILEPATH, modules);

                //remove radio button from panel
                //panel1.Controls.Remove(radioBtnToRemove);
                panel1.Controls.OfType<RadioButton>().ToList().ForEach(p => panel1.Controls.Remove(p));
                ResetComponents();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            label5.Hide();
            double result = 0.0;
            double currValue = 0.0;
            double inputValue = 0.0;
            double.TryParse(label3.Text, out currValue);
            double.TryParse(textBox1.Text, out inputValue);
            var selectedModule = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)?.Text;
            var module = _computation.CreateModule(selectedModule);
            module.CurrentValue = currValue;
            result = module.Compute(inputValue);
            label3.Text = result.ToString();
        }

        private void ResetComponents()
        {
            modules = File.ReadAllLines(FILEPATH).ToList();
            modules = modules.OrderBy(x => x).ToList();
            for (var i = 0; i < modules.Count; i++)
            {
                // create radio buttons
                panel1.Controls.Add(new RadioButton() { Name = "radioButton" + (i + 1), Text = modules[i], Location = new Point(RADIO_X, RADIO_Y + (RADIO_INCREMENT * i)), AutoSize = true });
            }
            //label3.Text = result.ToString();
        }

    }
}
