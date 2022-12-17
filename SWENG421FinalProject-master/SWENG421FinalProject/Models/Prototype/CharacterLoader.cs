using System;
using System.Collections.Generic;
using System.Text;

namespace SWENG421FinalProject.Models.Prototype
{
    public class CharacterLoader : CharacterManager
    {
        public override Character LoadCharacter(Character c)
        {
            var newCharacter = c.Clone();
            return (Character)newCharacter;
        }
    }
}
