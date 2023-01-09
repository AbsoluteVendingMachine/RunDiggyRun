using Godot;
using System;

public class debug_timer : Timer
{
    [Export] bool debugmode;
    public override void _Ready()
    {
        if (debugmode == false)
        {
            QueueFree();
        }
    }
}
