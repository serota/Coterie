using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    [Serializable]
    public abstract class Character : Sortable {
        protected string player,
            portraitPath,
            concept,
            biography,
            splat;
        protected Trait[] attributes,
            skills;

        protected string mask,
            dirge;
        protected Trait potency,
            humanity;

        public string Player {
            get {
                return player;
            }
            set {
                player = value;
            }
        }
        public string PortraitPath {
            get {
                return portraitPath;
            }
            set {
                portraitPath = value;
            }
        }
        public string Concept {
            get {
                return concept;
            }
            set {
                concept = value;
            }
        }
        public string Biography {
            get {
                return biography;
            }
            set {
                biography = value;
            }
        }
        public string Splat {
            get {
                return splat;
            }
        }
        public Trait[] Attributes {
            get {
                return attributes;
            }
        }
        public Trait[] Skills {
            get {
                return skills;
            }
        }
        public string Mask {
            get {
                return mask;
            }
            set {
                mask = value;
            }
        }
        public string Dirge {
            get {
                return dirge;
            }
            set {
                dirge = value;
            }
        }
        public Trait Potency {
            get {
                return potency;
            }
            set {
                potency = value;
            }
        }
        public Trait Humanity {
            get {
                return humanity;
            }
            set {
                humanity = value;
            }
        }

        protected Character() : base() {
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
                attributes[i] = new Trait(traitName) { Dots = 1 };
            }

            for (var i = 0; i < (int)Skil.Length; i++) {
                traitName = ((Skil)i).ToString();
                skills[i] = new Trait(traitName);
            }

            mask = "";
            dirge = "";
        }
    }
}
