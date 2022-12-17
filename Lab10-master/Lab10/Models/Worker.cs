using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.Models
{
    public class Worker : AbstractEmployee
    {
        public string Name { get; set; }
        public bool IsEvacuated { get; set; }

        public Worker(string name)
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

        public override void fixIt()
        {
            Console.WriteLine(@"The person {0} is fixing it", this.Name);
        }

        public override void notify()
        {
            //Console.WriteLine(@"The person {0} (Worker) is notified", this.Name);
            //this.evacuate();
        }

        public override void evacuate()
        {
            //evacuate
            Console.WriteLine(@"The person {0} (Worker) is evacuating", this.Name);
            this.IsEvacuated = true;
            //this.getParent().evacuate();
        }

        public override bool isEvacuated()
        {
            return this.IsEvacuated;
        }


        #region Methods not used
        public override void provideInfo()
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
