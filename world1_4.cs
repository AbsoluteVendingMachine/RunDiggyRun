using Godot;
using System;

public class world1_4 : TileMap
{
    public void resetPosition(){
        Position = new Vector2(-1500,3000);
        Hide();
    }
    public override void _Ready()
    {
        resetPosition();
    }

    public void _on_world_singleton_level1(){
        resetPosition();
    }

    public void _on_world_singleton_level4(){
        Position = new Vector2(0,0);
        Show();
    }
    
    public void _on_world_singleton_level5(){
        resetPosition();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
