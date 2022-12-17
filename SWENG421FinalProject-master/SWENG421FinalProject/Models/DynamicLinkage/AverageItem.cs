using System;
using System.Collections.Generic;
using System.Text;

namespace SWENG421FinalProject.Models.DynamicLinkage
{
    public enum ItemTypeEnum
    {
        Weapon = 1,
        Healing = 2
    }

    public class AverageItem : ItemIF
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Healing { get; set; }
        private int ItemType { get; set; }

        public virtual int Attack()
        {
            return this.Damage;
        }
        public virtual int Heal()
        {
            return this.Healing;
        }

        public virtual string GetName()
        {
            return this.Name;
        }

        public virtual void SetName(string n)
        {
            this.Name = n;
        }

        public virtual void SetDamage(int d)
        {
            this.Damage = d;
        }

        public virtual void SetHealing(int h)
        {
            this.Healing = h;
        }

        public virtual int GetItemType()
        {
            return this.ItemType;
        }
    }
}
