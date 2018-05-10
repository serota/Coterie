using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    abstract class Character {
        protected static int nextID = 1;

        protected int ID;
        protected string name,
            player,
            portraitPath,
            concept,
            biography;
        protected Trait[] attributes,
            skills;

        protected string mask,
            dirge;
        protected Trait potency,
            humanity;

        protected Character() {
            ID = nextID++;

            string traitName = "";

            name = "";
            player = "";
            portraitPath = "";
            concept = "";
            biography = "";

            attributes = new Trait[(int)Attr.Length];
            skills = new Trait[(int)Skil.Length];

            for (var i = 0; i < (int)Attr.Length; i++) {
                traitName = ((Attr)i).ToString();
                attributes[i] = new Trait(traitName) { dots = 1 };
            }

            for (var i = 0; i < (int)Skil.Length; i++) {
                traitName = ((Skil)i).ToString();
                skills[i] = new Trait(traitName);
            }
        }

        public override string ToString() {
            return name;
        }
    }
}
