using Godot;
using System;

public class player_anim_tree : AnimationTree
{ 
    int state;
    bool ingame;
    public void _on_debug_timer_timeout()
    {
    //GD.Print(state);
    }
    public void _on_final_boss_killAll(){
        QueueFree();
    }
    public override void _Ready()
    {
        state = 1;
        ingame = false;
        Active = true;
    }

    public void _on_player_action()
    {
        state = 4;
    }

    public void _on_pickaxeanim_timer_timeout()
    {
        state = 2;
        //GD.Print("attack timeout");
    }

    public void _on_player_lunge()
    {
        state = 5;
    }

    public void _on_player_idle()
    {
        state = 1;
    }

    public void _on_player_jump()
    {
        state = 2;
    }

    public void _on_controls_sprite_game_start()
    {
        ingame = true;
    }

    public void _on_player_walk()
    {
        state = 3;
    }

    public void _on_player_hurt()
    {
        state = 6;
    }

    public override void _PhysicsProcess (float delta)
    {
        if (ingame == true)
        {
            if (!Input.IsActionJustPressed("action"))
        {
        if (state == 1)
        {
            Set("parameters/end_state/current",0);
            Set("parameters/movement/current",0);
        }
        if (state == 2)
        {
            Set("parameters/end_state/current",1);
        }
        if (state == 3 && GetNode<KinematicBody2D>("/root/game/game_scene/player").IsOnFloor() == true)
        { 
                Set("parameters/end_state/current",0);
                Set("parameters/movement/current",1);
        }
        }
        if (state == 4)
        {
            if ((!Input.IsActionPressed("up")) && !Input.IsActionPressed("down"))
            {
    
                Set("parameters/swing2/current",0);
                Set("parameters/end_state/current",4);
            }
            if (Input.IsActionPressed("down"))
            {
                Set("parameters/swing2/current",2);
                Set("parameters/end_state/current",4);
            }
            if (Input.IsActionPressed("up"))
            {
                Set("parameters/swing2/current",1);
                Set("parameters/end_state/current",4);
            }
        }
        if (state == 5)
        {
            Set("parameters/end_state/current",2);
        }
        if (state == 6)
        {
            Set("parameters/end_state/current",3);
        }
        }
    }
}