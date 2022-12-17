using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9.Models
{
    public interface CoffeeIF
    {
        double getPrice();
        void run();
        void addCondiment(CondimentIF cdif);
    }
}
