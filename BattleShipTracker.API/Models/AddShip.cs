namespace BattleShipTracker.API.Models
{
    public class AddShip
    {
        public int row { get; set; }
        public int column { get; set; }

        public int length { get; set; }

        public string orientation { get; set; }
    }
}
