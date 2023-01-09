using Godot;
using System;

public class world2_2 : TileMap
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Hide();
        Position = new Vector2(0,1500);
    }
    public void _on_world_singleton_level6(){
        Position = new Vector2(0,0);
        Show();
    }
    public void _on_world_singleton_level1(){
        Position = new Vector2(0,1500);
        Hide();
    }
    public void _on_world_singleton_level7(){
        Position = new Vector2(0,1500);
        Hide();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
