using Godot;
using System;

public class world1_2 : TileMap
{
    bool in_game;
    public override void _Ready()
    {
        in_game = false;
        Position = new Vector2(-1500,1500);
        Hide();
    }
    public void _on_world_singleton_level1(){
        in_game = false;
        Hide();
        Position = new Vector2(-1500,1500);
    }
    public void _on_world_singleton_level2(){
        in_game = true;
        if (in_game == true){
            Show();
        }
        Position = new Vector2(0,0);
    }
    public void _on_world_singleton_level3(){
        Hide();
        Position = new Vector2(-1500,1500);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
