namespace CourDuSoirBackEnd
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public string GroupLevel { get; set; } = string.Empty;
        public int GroupSessionNumber { get; set; }
        public string NextSessionDate { get; set; } = string.Empty ;
        public string Hour { get; set; } = string.Empty  ;

        public int numberOfLearners { get; set; } = 0 ;


    }
}
