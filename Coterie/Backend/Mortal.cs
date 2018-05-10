using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    [Serializable]
    class Mortal : Character {
        public Mortal() : base () {
            splat = "mortal";

            humanity = new Trait("Integrity") { Dots = 7 };
        }
    }
}
