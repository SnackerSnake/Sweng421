using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.Models
{
    public abstract class AbstractEmployee : IEmployee
    {
        private AbstractEmployee parent;
        private List<AbstractEmployee> children;

        public void setParent(AbstractEmployee ie)
        {
            this.parent = ie;
        }

        public AbstractEmployee getParent()
        {
            return parent;
        }

        public void setChildren(List<AbstractEmployee> ieList)
        {
            this.children = ieList;
        }

        public List<AbstractEmployee> getChildren()
        {
            return this.children;
        }

        public abstract void fixIt();

        public abstract void provideInfo();

        public abstract Decision suggestedDecision();

        public abstract void seeDanger();

        public abstract void notify();

        public abstract void evacuate();

        public abstract bool isEvacuated();
    }
}
