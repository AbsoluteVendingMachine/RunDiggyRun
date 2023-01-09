using Godot;
using System;

public class inputdo_delay : Timer
{
    public override void _Ready()
    {
        
    }
    public void _on_input_set_handler_input_delaycheck()
    {
        Start();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
