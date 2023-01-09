using Godot;
using System;

public class world2_4 : TileMap
{
    public override void _Ready()
    {
        Hide();
        Position = new Vector2(0,4500);
    }
    public void _on_world_singleton_level1(){
        Hide();
        Position = new Vector2(0,4500);
    }
    public void _on_world_singleton_level8(){
        Show();
        Position = new Vector2(0,0);
    }
    public void _on_rabbit_boss_rabbitBossDeath(){
        Hide();
        Position = new Vector2(0,4500);
    }
}
