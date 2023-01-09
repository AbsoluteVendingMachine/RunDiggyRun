using Godot;
using System;

public class jetpack_hud : Sprite
{
    
    public override void _Ready()
    {
        Hide();
    }

    public void _on_player_get_jetpack(){
        Show();
    }

    public void _on_restart_restart_game(){
        Hide();
    }
}
