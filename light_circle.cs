using Godot;
using System;

public class light_circle : Sprite
{
    bool canShow;

    public override void _Ready()
    {
        Hide();
        canShow = true;
    }

    public void _on_world_singleton_level1(){
        canShow = true;
    }

    public void _on_rabbit_boss_rabbitBossDeath(){
        canShow = false;
    }

    public void _on_restart_restart_game(){
        Hide();
    }

    public void _on_skull_pitchChange(){
        if (canShow){
            Show();
        }
    }

    public void _on_progress_point_newLevelPosition(){
        Hide();
    }

    public void _on_final_boss_killAll(){
        QueueFree();
    }

    public override void _Process(float delta){
        if (GetNode<Sprite>("/root/game/game_scene/player/player_anim").FlipH == false){
            FlipH = false;
            Position = new Vector2(795,137);
        }
        else if (GetNode<Sprite>("/root/game/game_scene/player/player_anim").FlipH == true){
            FlipH = true;
            Position = new Vector2(-775,137);
        }
    }
}
