using Godot;
using System;

public class ig_timer_counter : Timer
{
    
    public void _on_controls_sprite_game_start()
    {
        Start();
    }
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
