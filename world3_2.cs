using Godot;
using System;

public class world3_2 : TileMap
{
    public override void _Ready()
    {
        Hide();
        Position = new Vector2(1500,0);
    }
    public void _on_world_singleton_level1(){
        Hide();
        Position = new Vector2(1500,0);
    }
    public void _on_world_singleton2_level10(){
        Show();
        Position = new Vector2(0,0);
    }
    public void _on_world_singleton2_finalboss(){
        Hide();
        Position = new Vector2(1500,0);
    }
}
