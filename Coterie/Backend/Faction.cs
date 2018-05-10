using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    class Faction : Sortable {
        public Faction() : base() {
        }

        public Faction(string name) {
            this.name = name;
        }
    }
}
