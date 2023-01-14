using Godot;
using System;

public class restart : Label
{
    [Signal] public delegate void restart_game();
    bool restarting;
    bool ingame;
    bool cooldown;
    bool playerdead;
    public override void _Ready(){
        Text = "";
        ingame = false;
        restarting = false;
        cooldown = false;
        playerdead = false;
    }
    public void _on_final_boss_killAll(){
        QueueFree();
    }
    public override void _PhysicsProcess(float delta){
        if (ingame == true){
            if (GetNode<TouchScreenButton>("/root/game/mobile_controls/restart").IsPressed()){
                restarting = true;
                if (cooldown == false){
                    GD.Print("reaches here");
                    Text = "Restarting..";
                    cooldown = true;
                    GetNode<Timer>("/root/game/game_scene/player/player_cam/hud/restart_house/restart/restart_timer").Start();
                }
            }
            else if (!GetNode<TouchScreenButton>("/root/game/mobile_controls/restart").IsPressed()){
                restarting = false;
            }
        }
    }
    public void _on_player_death(){
        playerdead = true;
    }
    public void _on_restart_released(){
        if (playerdead){
            playerdead = false;
            EmitSignal("restart_game");
            cooldown = false;
        }
    }
    public void _on_death_screen_callRestart(){
        EmitSignal("restart_game");
        cooldown = false;
    }
    public void _on_restart_timer_timeout(){
        if (restarting == true){
            EmitSignal("restart_game");
            Text = "Restarted Game";
            cooldown = false;
        }
        else if (restarting == false){
            Text = "";
            GetNode<Timer>("/root/game/game_scene/player/player_cam/hud/restart_house/restart/restart_timer2").Start();
            cooldown = false;
        }
        
    }
    public void _on_restart_timer2_timeout(){
        Text = "";
    }
    public void _on_controls_sprite_game_start(){
        ingame = true;
    }
}
