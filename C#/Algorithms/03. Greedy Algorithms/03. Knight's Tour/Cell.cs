namespace _03._Knight_s_Tour
{
    public class Cell
    {
        public byte Row { get; set; }

        public byte Col { get; set; }

        public bool IsVisited { get; set; }

        public int TurnVisited { get; set; }
    }
}
