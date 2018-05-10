using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie.Backend {
    [Serializable]
    public class City {
        //this is the user session
        private List<Character> characters;
        private List<Faction> factions;

        public List<Character> Characters {
            get {
                return characters;
            }
        }
        public List<Faction> Factions {
            get {
                return factions;
            }
        }

        public City() {
            characters = new List<Character>();
            factions = new List<Faction>();
        }
    }
}
