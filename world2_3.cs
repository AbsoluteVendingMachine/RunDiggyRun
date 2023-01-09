using Godot;
using System;

public class world2_3 : TileMap
{
    public void _on_world_singleton_level1(){
        Position = new Vector2(0,3000);
        Hide();
    }
    public override void _Ready()
    {
        Position = new Vector2(0,3000);
        Hide();
    }
    public void _on_world_singleton_level7(){
        Position = new Vector2(0,0);
        Show();
    }
    public void _on_world_singleton_level8(){
        Position = new Vector2(0,3000);
        Hide();
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
