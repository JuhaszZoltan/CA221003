using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA221003
{
    internal class Fish
    {
        private float _weight;
        private bool _weightIsSet = false;
        private bool _predator;
        private int _swimTop;
        private int _swimDepth;
        private string _species;

        public float Weight
        { 
            get => _weight;
            set
            {
                if (value < .5f)
                    throw new Exception("a hal súlya túl alacsony");
                if (value > 40f)
                    throw new Exception("a hal súlya túl nagy");
                if (_weightIsSet)
                {
                    if (value < _weight * .9f)
                        throw new Exception("a hal súlya ennyivel nem csökkenhet egyszerrre");
                    if (value > _weight * 1.1f)
                        throw new Exception("a hal súlya ennyivel nem növekedhet egyszerre");
                }
                _weight = value;
            }
        }
        public bool Predator 
        {
            get => _predator;
            set => _predator = value;
        }
        public int SwimTop
        { 
            get => _swimTop;
            set => _swimTop = value;
        }
        public int SwimDepth 
        { 
            get => _swimDepth;
            set => _swimDepth = value;
        }
        public string Species 
        { 
            get => _species;
            set => _species = value;
        }

        public Fish(float weight, bool predator, int swimTop, int swimDepth, string species)
        {
            Weight = weight;
            _weightIsSet = true;
            Predator = predator;
            SwimTop = swimTop;
            SwimDepth = swimDepth;
            Species = species;
        }
    }
}
