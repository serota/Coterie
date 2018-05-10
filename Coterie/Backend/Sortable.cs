using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    [Serializable]
    public abstract class Sortable {
        private static uint nextID = 0;

        private uint id;
        protected string name;

        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }

        public uint Id {
            get {
                return id;
            }
        }

        protected Sortable() {
            id = nextID++;
            name = "";
        }

        public static int byName(Sortable x, Sortable y) {
            return x.name.CompareTo(y.name);
        }

        public static int byID(Sortable x, Sortable y) {
            if (x.id > y.id) {
                return 1;
            }
            else if (x.id < y.id) {
                return -1;
            }
            else {
                return 0;
            }
        }

        public override string ToString() {
            return name;
        }

        /*public override bool Equals(Object s) {
            return id == ((Sortable)s).id;
        }*/
    }
}
