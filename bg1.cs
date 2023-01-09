using Godot;
using System;
public class bg1 : TileMap
{
    public override void _Ready()
    {
        Hide();
    }
    public void _on_title_screenbackground_background1(){
        Show();
    } 
}
