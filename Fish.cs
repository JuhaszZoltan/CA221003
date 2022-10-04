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
            private set => _predator = value;
        }
        public int SwimTop
        { 
            get => _swimTop;
            set
            {
                if (value > 400)
                    throw new Exception("a hal legmagasabb mélysége nem lehet 400nál nagyobb");
                if (value < 0)
                    throw new Exception("a halak nem tudnak repülni - legalábbis ezek");
                _swimTop = value;
            }
        }
        public int SwimDepth 
        { 
            get => _swimDepth;
            set
            {
                if (value < 10)
                    throw new Exception("a halnak ennél nagyobb élettérre van szüksége");
                if (value > 400)
                    throw new Exception("a hal mozgási sávja nem lehet szélesebb 400m-nél");
                _swimDepth = value;
            }
        }
        public int SwimBottom => SwimTop + SwimDepth;

        public string Species 
        { 
            get => _species;
            set
            {
                if (value is null)
                    throw new Exception("a hal fajtája nem lehet null");
                if (value.Length < 3)
                    throw new Exception("a halfajta megnevezése legalább 3 karakter kell, hogy legyen");
                if (value.Length > 30)
                    throw new Exception("a halfajta megnevezése maximum 30 karakter kell, hogy legyen");
                _species = value;
            }
            
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
