using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    class Trait {
        private string name;
        private int dots;
        //private List<string> notes;

        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }
        public int Dots {
            get {
                return dots;
            }
            set {
                dots = value;
            }
        }

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
