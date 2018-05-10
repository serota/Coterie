using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    class Mortal : Character {
        public Mortal() : base () {
            humanity = new Trait("Integrity") { dots = 7 };
        }
    }
}
