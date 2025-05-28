namespace Kursach.Models;

public class Player
{
    public int X { get; set; }
    public int Y { get; set; }
    public int VerticalVelocity { get; set; }
    public bool IsJumping { get; set; }

    public Player(int x, int y)
    {
        X = x;
        Y = y;
        VerticalVelocity = 0;
        IsJumping = false;
    }
}
