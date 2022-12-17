using SWENG421FinalProject.Models.DynamicLinkage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWENG421FinalProject.Models.Prototype
{
    public class Character : ICharacter
    {
        private string Name { get; set; }
        private int MaxHealth { get; set; }
        private int CurrHealth { get; set; }
        private List<AverageItem> Items { get; set; }
        private AverageItem CurrItem { get; set; }
        private Models.ReadWriteLock.ReadWriteLock LockManager { get; set; }

        public Character(string name, int maxHealth, ReadWriteLock.ReadWriteLock lockManager)
        {
            this.Name = name;
            this.MaxHealth = maxHealth;
            this.CurrHealth = this.MaxHealth;
            this.Items = new List<AverageItem>();
            this.LockManager = lockManager;
        }

        public virtual void SetName(string n)
        {
            this.Name = n;
        }

        public virtual string GetName()
        {
            return this.Name;
        }

        public virtual void SetHealth(int health)
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public virtual int GetHealth()
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

        public virtual int GetMaxHealth()
        {
            return this.MaxHealth;
        }

        public virtual void setMaxHealth(int health)
        {
            this.MaxHealth = health;
        }

        public virtual void AddItem(AverageItem i)
        {
            this.Items.Add(i);
        }

        public virtual void AddItems(List<AverageItem> items)
        {
            this.Items.AddRange(items);
        }

        public virtual void RemoveItem(AverageItem i)
        {
            this.Items.Remove(i);
        }

        public virtual List<AverageItem> GetItems()
        {
            return this.Items.OrderBy(x => x.GetName()).ToList();
        }

        public virtual AverageItem GetCurrentItem()
        {
            return this.CurrItem;
        }

        public virtual void SetCurrentItem(AverageItem i)
        {
            this.CurrItem = i;
        }

        public virtual bool IsDead()
        {
            if (this.CurrHealth <= 0)
            {
                this.CurrHealth = this.MaxHealth;
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void ClearCharacter()
        {
            this.Items = new List<AverageItem>();
            this.CurrHealth = this.MaxHealth;
        }

        public virtual object Clone()
        {
            return (Character)base.MemberwiseClone();
        }
    }
}
