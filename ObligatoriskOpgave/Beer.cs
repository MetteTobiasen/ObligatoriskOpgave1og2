namespace ObligatoriskOpgave
{
    public class Beer
    {
        public int id { get; set; } 
        public string? name { get; set; }
        public int alcoholProcent { get; set; }

        public override string ToString()
        {
            return $"{id} {name} {alcoholProcent}"; 
        }

        public void ValidateName()
        {
            if (name == null) 
            {
                throw new ArgumentNullException("name is null");
            };
            if (name.Length < 3)
            {
                throw new ArgumentException("name should be at least 3 caracters");
            }
        }

        public void ValidateAlcoholProcent()
        {
            if (alcoholProcent < 0 || alcoholProcent > 67)
            {
                throw new ArgumentOutOfRangeException("alcoholprocent skal være mellem 0 - 67");
            }
        }

        public void Validate()
        {
            ValidateName();
            ValidateAlcoholProcent();
        }
    }
}