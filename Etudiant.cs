namespace CourDuSoirBackEnd
{
    public class Etudiant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string EntryDate { get; set; } = string.Empty;
        public int NumberOfSessions { get; set; }
        public int PhoneNumber { get; set; }
        public bool Payment { get; set; } = true;
        public string Group { get; set; } = string.Empty ;

        



    }
}
