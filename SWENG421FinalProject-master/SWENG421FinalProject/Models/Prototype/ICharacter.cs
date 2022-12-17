using SWENG421FinalProject.Models.DynamicLinkage;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWENG421FinalProject.Models.Prototype
{
    public interface ICharacter
    {
        void SetHealth(int health);
        int GetHealth();
        void AddItem(AverageItem i);
        List<AverageItem> GetItems();
        bool IsDead();
        object Clone();
    }
}
