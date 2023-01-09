using Godot;
using System;

public class debug_signal : Timer
{
    
[Export] public bool debugmode;

    public override void _Ready()
    {
        
    if (debugmode == false)

    {

    QueueFree();

    } 

    }

public void _on_titlekeys_enter_intro()

{

QueueFree();

}

//  public override void _Process(float delta)
//  {
//      
//  }
}
