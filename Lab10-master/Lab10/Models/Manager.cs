using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.Models
{
    public class Manager : AbstractEmployee
    {
        public string Name { get; set; }
        public bool IsEvacuated { get; set; }

        public Manager(string name)
        {
            this.Name = name;
            this.IsEvacuated = false;
        }

        public override void seeDanger()
        {
            //handle the danger by gathering information from all supervisors under his management
            var children = this.getChildren();
            foreach(var child in children)
            {
                child.provideInfo();
            }

            //and execute contactBoss() to inform CEO
            this.getParent().seeDanger();
        }

        public override Decision suggestedDecision()
        {
            return new Decision()
            {
                DecisionStr = "The city's environmental department is notified."
            };
        }

        public override void notify()
        {
            //notify project leaders
            var children = this.getChildren();
            //Console.WriteLine(@"The person {0} (Manager) is notified", this.Name);
            foreach (var child in children)
            {
                child.notify();
            }
        }
        public override void evacuate()
        {
            //evacuate
            var children = this.getChildren();
            foreach (var child in children)
            {
                if (!child.isEvacuated())
                {
                    child.evacuate();
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine("The person {0} (Manager) is evacuating", this.Name);
            this.IsEvacuated = true;
            //this.getParent().evacuate();
        }

        public override bool isEvacuated()
        {
            return this.IsEvacuated;
        }

        public override void fixIt()
        {
            throw new NotImplementedException();
        }

        public override void provideInfo()
        {
            throw new NotImplementedException();
        }
    }
}
