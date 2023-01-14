using Godot;
using System;

public class toggle_singleton : Node
{
    [Signal] public delegate void item1();
    [Signal] public delegate void item2();
    bool inGame;
    int item;
    public override void _Ready(){
        item = 1;
        inGame = false;
    }
    public void _on_controls_sprite_game_start(){
        item = 1;
        inGame = true;
    }
    public void _on_restart_restart_game(){
        item = 1;
        inGame = true;
    }
    public void _on_shotgun_shotgunExists(){
        if (item == 1){
            EmitSignal("item1");
        }
        else{
            EmitSignal("item2");
        }
    }
    public override void _Process(float delta){
        if (inGame == true && Input.IsActionJustPressed("toggle")){
           var sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/toggle_singleton/sfx");
           sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/toggle.wav");
           sfx.Play();
           if (item == 1){
               item = 2;
               EmitSignal("item2");
           }
           else{
               item = 1;
               EmitSignal("item1");
           } 
        }

    }
    public void _on_toggle_released(){
        if (inGame){
            var sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/toggle_singleton/sfx");
            sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/toggle.wav");
            sfx.Play();
            if (item == 1){
               item = 2;
               EmitSignal("item2");
            }
            else{
               item = 1;
               EmitSignal("item1");
            } 
        }
    }
    public void _on_final_boss_killAll(){
        QueueFree();
    }
    public void _on_extra_hud_audio1(){
        GetNode<AudioStreamPlayer>("/root/game/game_scene/toggle_singleton/sfx").VolumeDb = 0;
    }
    public void _on_extra_hud_audio3(){
        GetNode<AudioStreamPlayer>("/root/game/game_scene/toggle_singleton/sfx").VolumeDb = -100;
    }
    public void _on_player_get_super(){
        if (item == 1){
            EmitSignal("item1");
        }
        if (item == 2){
            EmitSignal("item2");
        }
    }
}
