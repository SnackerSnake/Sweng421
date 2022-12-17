using System;
using System.Collections.Generic;
using System.Text;

namespace SWENG421FinalProject.Models.DynamicLinkage
{
    public class Axe : AverageItem
    {
        private string Name { get; set; }
        private int Damage { get; set; }
        public int ItemType => (int)ItemTypeEnum.Weapon;

        public override string GetName()
        {
            return this.Name;
        }

        public override void SetName(string n)
        {
            this.Name = n;
        }

        public override void SetDamage(int d)
        {
            this.Damage = d;
        }

        public override int Attack()
        {
            return this.Damage;
        }

        public override int GetItemType()
        {
            return this.ItemType;
        }

    }
}
