using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SWENG421FinalProject.Models.DynamicLinkage
{
    public class ConcreteLoadableItem : AbstractLoadableItem
    {
        public override AverageItem Load(string itemName)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Models\\DynamicLinkage\\" + itemName + ".json";
            if (System.IO.File.Exists(path))
            {
                using (StreamReader r = new StreamReader(path))
                {
                    AverageItem item = new AverageItem();
                    string json = r.ReadToEnd();
                    Type t = Type.GetType("SWENG421FinalProject.Models.DynamicLinkage." + itemName);
                    if(t != null)
                    {
                        var inst = Activator.CreateInstance(t);
                        if(inst != null)
                        {
                            var loadedItem = JsonConvert.DeserializeObject<AverageItem>(json);
                            item.SetName(loadedItem.Name);
                            item.SetDamage(loadedItem.Damage);
                            item.SetHealing(0);
                        }
                    }
                    return item;
                }
            }
            return null;
        }
    }
}
