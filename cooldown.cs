using Godot;
using System;

public class cooldown : Timer
{
    
    public override void _Ready()
    {
        
    }

    public void _on_pickaxe_pick_cooldown1()
    {
        Start();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
