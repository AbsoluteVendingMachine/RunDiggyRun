using Godot;
using System;

public class exsettings_delay : Timer
{
    public void _on_settings_node_settingsexitdelay()
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
