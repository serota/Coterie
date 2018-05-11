using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    [Serializable]
    public class Trait {
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

        public Trait() {
            name = "";
            dots = 0;
            //notes = new List<string>();
        }

        public Trait(string name) : this() {
            this.name = name;
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
        Composure
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
        Subterfuge
    }
}
