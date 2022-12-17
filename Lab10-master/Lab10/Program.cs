using Lab10.Models;
using System;
using System.Collections.Generic;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            //chain of responsibility 
            var jack = new Supervisor("Jack");
            var john = new Worker("John");
            var mary = new Worker("Mary");
            var jane = new Worker("Jane");
            var tom = new Worker("Tom");
            var nick = new Worker("Nick");

            var jeff = new Supervisor("Jeff");
            var rob = new Worker("Rob");
            var ed = new Worker("Ed");
            var rick = new Worker("Rick");
            var michael = new Worker("Michael");

            var chuck = new ProjectLeader("Chuck");
            var joe = new Worker("Joe");
            var frank = new Worker("Frank");
            var sam = new Worker("Sam");
            var greg = new Worker("Greg");

            var denise = new ProjectLeader("Denise");
            var amy = new Worker("Amy");
            var wil = new Worker("Wil");
            var nancy = new Worker("Nancy");
            var adam = new Worker("Adam");

            var steve = new CEO("Steve");
            var bob = new Manager("Bob");
            var rachel = new Manager("Rachel");

            john.setParent(jack);
            mary.setParent(jack);
            jane.setParent(jack);
            tom.setParent(jack);
            nick.setParent(jack);
            jack.setChildren(new List<AbstractEmployee>() { john, mary, jane, tom, nick });
            jack.setParent(bob);

            rob.setParent(jeff);
            ed.setParent(jeff);
            rick.setParent(jeff);
            michael.setParent(jeff);
            jeff.setChildren(new List<AbstractEmployee>() { rob, ed, rick, michael });
            jeff.setParent(bob);

            joe.setParent(chuck);
            frank.setParent(chuck);
            sam.setParent(chuck);
            greg.setParent(chuck);
            chuck.setChildren(new List<AbstractEmployee>() { joe, frank, sam, greg });
            chuck.setParent(rachel);

            amy.setParent(denise);
            wil.setParent(denise);
            nancy.setParent(denise);
            adam.setParent(denise);
            denise.setChildren(new List<AbstractEmployee>() { amy, wil, nancy, adam });
            denise.setParent(rachel);

            bob.setParent(steve);
            bob.setChildren(new List<AbstractEmployee>() { jack, jeff });
            rachel.setParent(steve);
            rachel.setChildren(new List<AbstractEmployee>() { chuck, denise });
            steve.setChildren(new List<AbstractEmployee>() { bob, rachel });

            john.seeDanger();
            steve.notify();
            steve.evacuate();

        }
    }
}
