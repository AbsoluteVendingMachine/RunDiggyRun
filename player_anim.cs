using Godot;
using System;

public class player_anim : AnimatedSprite
{
    bool in_air;
    bool in_game;
    bool is_pressed;
    bool reset_anim;
    string state;

    public override void _Ready()
    {
        in_game = false;
        in_air = false;
        is_pressed = false;
        reset_anim = false;
        state = "normal";
        FlipH = false;
        Play("idle_normal");
    }

    public void _on_player_in_air_status()
    {
        //GD.Print("in_air = "+in_air);
    }

    public void _on_player_game_start()
    {
        in_game = true;
    }
    
    public override void _PhysicsProcess(float delta)
    {
        if (in_game == true)
        {
        if ((Input.IsActionPressed("right")) && !Input.IsActionPressed("left"))
        {
            FlipH = false;
        }
        else if ((Input.IsActionPressed("left")) && !Input.IsActionPressed("right"))
        {
            FlipH = true;
        }
        if (is_pressed == false && in_air == false && (!Input.IsActionPressed("left") && !Input.IsActionPressed("right")))
        {
            if (Input.IsActionPressed("up"))
            {
                Play("idle_up");
            }
            else if (Input.IsActionPressed("down"))
            {
                Play("idle_down");
            }
            else if (!Input.IsActionPressed("down") || !Input.IsActionPressed("up"))
            {
                Play("idle_normal");
            }
        }
        if ((Input.IsActionPressed("left")) || (Input.IsActionPressed("right")))
        {
            if (is_pressed == false)
            {
                if (Input.IsActionPressed("up"))
                {
                    Play("walk_up");
                    is_pressed = true;
                }
                else if (Input.IsActionPressed("down"))
                {
                    Play("walk_down");
                    is_pressed = true;
                }
                else if (!Input.IsActionPressed("down") || !Input.IsActionPressed("up"))
                {
                    Play("walk_normal");
                    is_pressed = true;
                }
            }
            
        }
        if (!Input.IsActionPressed("left") && !Input.IsActionPressed("right"))
        {
            is_pressed = false;
        }
        }
        }
    }
