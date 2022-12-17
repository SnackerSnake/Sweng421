using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10.Models
{
    public class ProjectLeader : AbstractEmployee
    {
        public string Name { get; set; }
        public bool IsEvacuated { get; set; }

        public ProjectLeader(string name)
        {
            this.Name = name;
            this.IsEvacuated = false;
        }

        public override void seeDanger()
        {
            //report to his supervisor
            this.getParent().seeDanger();
            //throw new NotImplementedException();
        }

        public override void provideInfo()
        {
            Console.WriteLine("Information from " + this.Name);
        }

        public override void notify()
        {
            //notify supervisors
            var children = this.getChildren();
            //Console.WriteLine(@"The person {0} (ProjectLeader) is notified", this.Name);
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
            Console.WriteLine("The person {0} (Project Leader) is evacuating", this.Name);
            this.IsEvacuated = true;
            //this.getParent().evacuate();
        }

        public override bool isEvacuated()
        {
            return this.IsEvacuated;
        }

        #region Methods not used
        public override void fixIt()
        {
            throw new NotImplementedException();
        }

        public override Decision suggestedDecision()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
