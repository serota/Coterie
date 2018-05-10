using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    class Vampire : Character {
        private Clan clan;
        private Coven covenant;

        public Clan Clan {
            get {
                return clan;
            }
            set {
                clan = value;
            }
        }
        public Coven Covenant {
            get {
                return covenant;
            }
            set {
                covenant = value;
            }
        }

        public Vampire() : base() {
            splat = "vampire";

            potency = new Trait("Blood Potency") { Dots = 1 };
            humanity = new Trait("Humanity") { Dots = 7 };

            clan = Clan.None;
            covenant = Coven.None;
        }
    }
}
