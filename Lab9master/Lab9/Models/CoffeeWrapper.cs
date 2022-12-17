using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9.Models
{
    public class CoffeeWrapper : CoffeeIF
    {
        CoffeeIF cif;
        CondimentIF cdif;

        public CoffeeWrapper(CoffeeIF cif, CondimentIF cdif)
        {
            this.cif = cif;
            this.cdif = cdif;
            this.addCondiment(cdif);
        }

        public void addCondiment(CondimentIF cdif)
        {
            cif.addCondiment(cdif);
        }

        public void run()
        {
            //run cmm
            cif.run();
        }

        public double getPrice()
        {
            return cif.getPrice();
        }


    }
}
