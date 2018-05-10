using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    struct Trait {
        public string name;
        public int dots;
        //public List<string> notes;

        public Trait(string name) {
            this.name = name;
            dots = 0;
            //notes = new List<string>();
        }
    }

    enum Attr {
        Intelligence,
        Wits,
        Resolve,

        Strength,
        Dexterity,
        Stamina,

        Presence,
        Manipulation,
        Composure,

        Length
    }

    enum Skil {
        Academics,
        Computer,
        Crafts,
        Investigation,
        Medicine,
        Occult,
        Politics,
        Science,

        Athletics,
        Brawl,
        Drive,
        Firearms,
        Larceny,
        Stealth,
        Survival,
        Weaponry,

        AnimalKen,
        Empathy,
        Expression,
        Intimidation,
        Persuasion,
        Socialize,
        Streetwise,
        Subterfuge,

        Length
    }
}
