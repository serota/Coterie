using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    abstract class Character {
        protected string name, portraitPath, concept, biography;
        protected Trait[] attributes, skills;

        protected Character() {
            string traitName = "";

            name = "";
            portraitPath = "";
            concept = "";
            biography = "";

            attributes = new Trait[(int)Attr.Length];
            skills = new Trait[(int)Skil.Length];

            for (var i = 0; i < (int)Attr.Length; i++) {
                traitName = ((Attr)i).ToString();
                attributes[i] = new Trait(traitName);
            }

            for (var i = 0; i < (int)Skil.Length; i++) {
                traitName = ((Skil)i).ToString();
                skills[i] = new Trait(traitName);
            }
        }
    }
}
