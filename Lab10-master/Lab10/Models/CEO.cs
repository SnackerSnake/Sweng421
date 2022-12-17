using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.Models
{
    public class CEO : AbstractEmployee
    {
        public string Name { get; set; }
        public bool IsEvacuated { get; set; }

        public CEO(string name)
        {
            this.Name = name;
            this.IsEvacuated = false;
        }

        public override void seeDanger()
        {
            //throw a meeting to discuss with the managers,

            //and collect suggested decisions from individual managers who perform their implemented Decision suggestedDecision()

            var children = this.getChildren();
            var decisions = new List<Decision>();
            foreach(var child in children)
            {
                decisions.Add(child.suggestedDecision());
            }

            var grantedDecision = this.grant(decisions.ToArray());

            grantedDecision.doIt();
        }

        public Decision grant(Decision[] da)
        {
            Random ran = new Random();
            return da[ran.Next(0, 2)];
        }

        public override void notify()
        {
            //notify managers
            var children = this.getChildren();
            //Console.WriteLine(@"The person {0} (CEO) is notified", this.Name);
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
            Console.WriteLine("The person {0} (CEO) is evacuating", this.Name);
            this.IsEvacuated = true;
        }

        #region Methods not used
        public override void fixIt()
        {
            throw new NotImplementedException();
        }

        public override void provideInfo()
        {
            throw new NotImplementedException();
        }

        public override Decision suggestedDecision()
        {
            throw new NotImplementedException();
        }
        public override bool isEvacuated()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
