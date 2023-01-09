using Godot;
using System;

public class world3_3 : TileMap
{
    public override void _Ready()
    {
        Hide();
        Position = new Vector2(1500,1500);
    }
    public void _on_world_singleton_level1(){
        Hide();
        Position = new Vector2(1500,1500);
    }
    public void _on_world_singleton2_finalboss(){
        Show();
        Position = new Vector2(0,0);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
