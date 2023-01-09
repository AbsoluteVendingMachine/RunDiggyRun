using Godot;
using System;

public class hud : CanvasLayer
{
    public override void _Ready()
    {
        Hide();
    }

    public void _on_controls_sprite_game_start()
    {
        Show();
    }

    public void _on_restart_restart_game(){
        //
    }
}
