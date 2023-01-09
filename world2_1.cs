using Godot;
using System;

public class world2_1 : TileMap
{
    public override void _Ready()
    {
        Position = new Vector2(0,-1500);
        Hide();
    }

    public void _on_world_singleton_level6(){
        Position = new Vector2(0,-1500);
        Hide();
    }

    public void _on_world_singleton_level5(){
        Position = new Vector2(0,0);
        Show();
    }

    public void _on_world_singleton_level1(){
        Position = new Vector2(0,-1500);
        Hide();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
