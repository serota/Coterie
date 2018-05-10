using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    class Faction : Sortable {
        private string description;

        private List<Role> roles;
        
        public string Description {
            get {
                return description;
            }
            set {
                description = value;
            }
        }

        public List<Role> Roles {
            get {
                return roles;
            }
        }

        public Faction() : base() {
            description = "";

            roles = new List<Role>();
        }

        public Faction(string name) : this() {
            this.name = name;
        }
    }

    enum Clan {
        None,
        Daeva,
        Gangrel,
        Mekhet,
        Nosferatu,
        Ventrue,

        Length
    }

    enum Coven {
        None,
        Carthians,
        Crones,
        Invictus,
        Lancea,
        Ordo,

        Length
    }
}
