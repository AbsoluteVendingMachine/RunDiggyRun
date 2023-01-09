using Godot;
using System;

public class jetpack : AnimatedSprite
{
    bool on;
    public override void _Ready()
    {
        on = false;
        Hide();
        Play("off");    
    }

    public void _on_player_get_jetpack()
    {
        Show();
    }

    public void _on_restart_restart_game(){
        Hide();
    }

    public void _on_player_jetpack()
    {
        Play("on");
        on = true;
    }

    public void _on_player_jetpack_over()
    {
        on = false;
    }

    public override void _PhysicsProcess(float delta)
    {
        //add in_game stuff
        //change offset with signals from player code
        if (!Input.IsActionPressed("jump") || on == false){
            Play("off");
        }
    }
    public void _on_player_left(){
        Position = new Vector2(2,4);
    }
    public void _on_player_right(){
        Position = new Vector2(-1,4);
    }
}
