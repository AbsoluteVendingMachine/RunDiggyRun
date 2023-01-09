using Godot;
using System;

public class reload : AnimatedSprite
{
    public override void _Ready()
    {
        Hide();
    }
    public void _on_final_boss_killAll(){
        QueueFree();
    }
    public void _on_cooldown_timer_timeout(){
        Play("anim");
        Show();
        GetNode<Timer>("/root/game/game_scene/player/reload/time").Start();
    }
    public void _on_time_timeout(){
        Hide();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
