using Godot;
using System;

public class onscreen_timer : CanvasLayer
{
    public override void _Ready()
    {
        Hide();
    }

    public void _on_controls_sprite_game_start()
    {
        Show();
    }
}
