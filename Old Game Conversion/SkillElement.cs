using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion
{
    class SkillElement
    {
        public SkillEnum skill { get; set; }
        public int expAmount { get; set; }

        public SkillElement(SkillEnum aSkill, int exp)
        {
            skill = aSkill;
            expAmount = exp;
        }

    }
}
