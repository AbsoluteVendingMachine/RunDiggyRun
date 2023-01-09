using Godot;
using System;

public class world1 : TileMap
{
    bool in_game;
    public override void _Ready()
    {
        in_game = false;
        Position = new Vector2(-1500,0);
        Hide();
    }

    public void _on_world_singleton_level1(){
        in_game = true;
        if (in_game == true){
            Show();
        }
        Position = new Vector2(0,0);
    }

    public void _on_world_singleton_level2(){
        Hide();
        Position = new Vector2(-1500,0);
    }

    public void _on_world_singleton_level5(){
        Hide();
        Position = new Vector2(-1500,0);
    }

    public void _on_world_singleton2_gotolevel9(){
        Hide();
        Position = new Vector2(-1500,0);
    }
}
