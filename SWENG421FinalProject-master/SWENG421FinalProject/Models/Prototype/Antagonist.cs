using SWENG421FinalProject.Models.DynamicLinkage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWENG421FinalProject.Models.Prototype
{
    public class Antagonist : Character
    {
        private string Name { get; set; }
        private int MaxHealth { get; set; }
        private int CurrHealth { get; set; }
        private List<AverageItem> Items { get; set; }
        private AverageItem CurrItem { get; set; }
        private Models.ReadWriteLock.ReadWriteLock LockManager { get; set; }

        public Antagonist(string name, int maxHealth, ReadWriteLock.ReadWriteLock lockManager) : base(name, maxHealth, lockManager)
        {
            this.Name = name;
            this.MaxHealth = maxHealth;
            this.CurrHealth = this.MaxHealth;
            this.Items = new List<AverageItem>();
            this.LockManager = lockManager;
        }

        public override void SetName(string n)
        {
            this.Name = n;
        }

        public override string GetName()
        {
            return this.Name;
        }

        public override void SetHealth(int health)
        {
            try
            {
                LockManager.WriteLock();
                if (health > 0)
                {
                    this.CurrHealth -= health;
                }
                LockManager.Complete();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override int GetHealth()
        {
            try
            {
                LockManager.ReadLock();
                int currHealth = this.CurrHealth;
                LockManager.Complete();
                return currHealth;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return this.CurrHealth;
        }

        public override int GetMaxHealth()
        {
            return this.MaxHealth;
        }

        public override void setMaxHealth(int health)
        {
            this.MaxHealth = health;
        }

        public override void AddItem(AverageItem i)
        {
            this.Items.Add(i);
        }

        public override void AddItems(List<AverageItem> items)
        {
            this.Items.AddRange(items);
        }

        public override void RemoveItem(AverageItem i)
        {
            this.Items.Remove(i);
        }

        public override List<AverageItem> GetItems()
        {
            return this.Items.OrderBy(x => x.GetName()).ToList();
        }

        public override AverageItem GetCurrentItem()
        {
            return this.CurrItem;
        }

        public override void SetCurrentItem(AverageItem i)
        {
            this.CurrItem = i;
        }

        public override bool IsDead()
        {
            return this.CurrHealth <= 0;
        }

        public override void ClearCharacter()
        {
            this.Items = new List<AverageItem>();
            this.CurrHealth = this.MaxHealth;
        }

        public override object Clone()
        {
            Antagonist tmp = (Antagonist)base.MemberwiseClone();
            tmp.Name = base.GetName();
            tmp.MaxHealth = base.GetMaxHealth();
            tmp.CurrHealth = tmp.MaxHealth;
            tmp.CurrItem = base.GetCurrentItem();
            tmp.Items = base.GetItems();
            tmp.LockManager = this.LockManager;
            return tmp;
        }
    }
}
