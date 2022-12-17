using System;
using System.Collections.Generic;
using System.Text;

namespace SWENG421FinalProject.Models.DynamicLinkage
{
    public class Soda : AverageItem
    {
        private string Name { get; set; }
        private int Healing => 5;
        public int ItemType => (int)ItemTypeEnum.Healing;

        public override string GetName()
        {
            return this.Name;
        }

        public override void SetName(string n)
        {
            this.Name = n;
        }

        public override int Heal()
        {
            return this.Healing;
        }

        public override int GetItemType()
        {
            return this.ItemType;
        }

    }
}
