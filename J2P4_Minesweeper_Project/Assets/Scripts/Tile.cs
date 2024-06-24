using System;
using System.Diagnostics;

public class Tile : ClickHandler
{
    protected override void LeftClick()
    {
        if (hasMine)
        {
            Console.WriteLine("fesfesihfoes");
            // Freeze game And show gameover and your score ( Show a Mine first )
        }
        else
        {
            // Show that it has nothing ( Empty Tile )

        }
    }
    protected override void MiddleClick()
    {
        // Reveal a 3 by 3 space
    }
    protected override void RightClick()
    {
        // Place Flag
    }
}