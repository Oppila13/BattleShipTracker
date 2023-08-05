namespace BattleShipTracker.API.Interface
{
    public interface IBattleShipGame
    {
        string AddShip(int row, int column, int length, string orientation);

        string Attack(int row, int column);

    }
}
