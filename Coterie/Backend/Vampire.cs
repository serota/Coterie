using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    class Vampire : Character {

        public Vampire() : base() {
            
        }

        public override string ToString() {
            return attributes[1].name;
        }
    }
}
