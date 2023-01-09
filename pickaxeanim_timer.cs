using Godot;
using System;

public class pickaxeanim_timer : Timer
{
   
    public override void _Ready()
    {
        
    }

    public void _on_player_action()
    {
        Start();
    }

}
