using System;
using System.Collections.Generic;
using System.Text;

namespace SWENG421FinalProject.Models.DynamicLinkage
{
    public abstract class AbstractLoadableItem
    {
        public abstract AverageItem Load(string fileName);
    }
}
