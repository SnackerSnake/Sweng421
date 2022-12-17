using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.Models
{
    public interface IEmployee
    {
        void seeDanger();

        void notify();

        void evacuate();

        bool isEvacuated();

    }
}
