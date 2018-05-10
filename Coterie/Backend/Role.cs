using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    class Role {
        private string name;

        private List<Character> members;

        public string Name {
            get {
                return name;
            }
        }

        public List<Character> Members {
            get {
                return members;
            }
        }

        public Role(string name) {
            this.name = name;

            members = new List<Character>();
        }

        public override string ToString() {
            return name;
        }
    }
}
