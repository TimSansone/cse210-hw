public class BingoBall
    {
        public string _letter { get; }
        public int _number { get; }
        public bool _isCalled { get; set; }

        public BingoBall(string letter, int number)
        {
            _letter = letter;
            _number = number;
            _isCalled = false;
        }
    }