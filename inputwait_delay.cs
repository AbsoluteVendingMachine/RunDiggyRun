using Godot;
using System;

public class inputwait_delay : Timer
{
    public override void _Ready()
    {
        
    }

    public void _on_input_set_handle_nextinput_timer()
    {
        Start();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
