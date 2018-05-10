using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    class Vampire : Character {
        private Clan clan;
        private Coven covenant;

        public Vampire() : base() {
            potency = new Trait("Blood Potency") { dots = 1 };
            humanity = new Trait("Humanity") { dots = 7 };

            clan = Clan.None;
            covenant = Coven.None;
        }
    }
}
