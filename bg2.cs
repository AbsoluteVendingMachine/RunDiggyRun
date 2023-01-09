using Godot;
using System;

public class bg2 : TileMap
{
    public override void _Ready(){
        Hide();
    }
    public void _on_title_screenbackground_background2(){
        Show();
    }
}
