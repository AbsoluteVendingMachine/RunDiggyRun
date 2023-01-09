using Godot;
using System;

public class world_name : Label
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public void _on_world_singleton_level1(){
        Text = "Cricket";
        Show();
        GetNode<Timer>("/root/game/game_scene/player/player_cam/hud/world_name/timer").Start();
    }
    public void _on_world_singleton_level5(){
        Text = "Growth";
        Show();
        GetNode<Timer>("/root/game/game_scene/player/player_cam/hud/world_name/timer").Start();
    }
    public void _on_rabbit_boss_rabbitBossDeath(){
        Text = "Castle";
        Show();
        GetNode<Timer>("/root/game/game_scene/player/player_cam/hud/world_name/timer").Start();
    }
    public void _on_heart_jar_fullHeal(){
        Text = "You feel replenished.";
        Show();
        GetNode<Timer>("/root/game/game_scene/player/player_cam/hud/world_name/timer").Start();
    }
    public void _on_greed_jar_greedJar(){
        Text = "Greed overwhelms all of us.";
        Show();
        GetNode<Timer>("/root/game/game_scene/player/player_cam/hud/world_name/timer").Start();
    }
    public void _on_skull_pitchChange(){
        Text = "A cold hunger erupts";
        Show();
        GetNode<Timer>("/root/game/game_scene/player/player_cam/hud/world_name/timer").Start();
    }
    public void _on_world_singleton_level9(){
        Text = "Cold";
        Show();
        GetNode<Timer>("/root/game/game_scene/player/player_cam/hud/world_name/timer").Start();
    }
    public void _on_final_boss_killAll(){
        QueueFree();
    }
    public override void _Ready()
    {
        Hide();
    }
    public void _on_timer_timeout(){
        Hide();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
