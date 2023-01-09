using Godot;
using System;

public class extra_hud : CanvasLayer{
    [Signal] public delegate void audio1();
    [Signal] public delegate void audio2();
    [Signal] public delegate void audio3();
    private File file_ = new File();
    private ConfigFile config_ = new ConfigFile();
    int localAudio;
    int localCamera;
    bool inGame;
    public void _on_controls_sprite_game_start(){
        inGame = true;
    }
    public void _on_final_boss_killAll(){
        QueueFree();
    }
    public override void _Ready(){
        inGame = false;
        GetNode<AnimatedSprite>("/root/game/game_scene/player/player_cam/extra_hud/audio").Hide();
        GetNode<AnimatedSprite>("/root/game/game_scene/player/player_cam/extra_hud/camera").Hide();
        if (!file_.FileExists("res://extra.cfg")){
            config_.Clear();
            config_.SetValue("extra","audio",1);
            config_.SetValue("extra","camera",1);
            config_.Save("res://extra.cfg");
            config_.Clear();
        }
        else if (file_.FileExists("res://extra.cfg")){
            config_.Load("res://extra.cfg");
            localAudio = (int)config_.GetValue("extra","audio");
            localCamera = (int)config_.GetValue("extra","camera");
            EmitSignal("audio"+localAudio);
            if (localCamera == 1){
                GetNode<Camera2D>("/root/game/game_scene/player/player_cam").SmoothingEnabled = true;
            }
            else{
                GetNode<Camera2D>("/root/game/game_scene/player/player_cam").SmoothingEnabled = false;
            }
            config_.Clear();
        }
    }
public override void _PhysicsProcess(float delta){
    if (Input.IsActionJustPressed("audio") && inGame == true){
        if (localAudio < 3){
            localAudio += 1;
        }
        else if (localAudio == 3){
            localAudio = 1;
        }
        if (localAudio == 1){
            GetNode<AnimatedSprite>("/root/game/game_scene/player/player_cam/extra_hud/audio").Show();
            GetNode<AnimatedSprite>("/root/game/game_scene/player/player_cam/extra_hud/audio").Play("on");
        }
        else if (localAudio == 2){
            GetNode<AnimatedSprite>("/root/game/game_scene/player/player_cam/extra_hud/audio").Show();
            GetNode<AnimatedSprite>("/root/game/game_scene/player/player_cam/extra_hud/audio").Play("music");
        }
        else{
            GetNode<AnimatedSprite>("/root/game/game_scene/player/player_cam/extra_hud/audio").Show();
            GetNode<AnimatedSprite>("/root/game/game_scene/player/player_cam/extra_hud/audio").Play("off");
        }
        EmitSignal("audio"+localAudio);
        config_.Load("res://extra.cfg");
        config_.SetValue("extra","audio",localAudio);
        config_.Save("res://extra.cfg");
        config_.Clear();
    }
    if (Input.IsActionJustPressed("camera") && inGame == true){
        if (localCamera == 1){
            localCamera = 0;
            GetNode<Camera2D>("/root/game/game_scene/player/player_cam").SmoothingEnabled = false;
            GetNode<AnimatedSprite>("/root/game/game_scene/player/player_cam/extra_hud/camera").Show();
            GetNode<AnimatedSprite>("/root/game/game_scene/player/player_cam/extra_hud/camera").Play("snap");
        }
        else{
            localCamera = 1;
            GetNode<Camera2D>("/root/game/game_scene/player/player_cam").SmoothingEnabled = true;
            GetNode<AnimatedSprite>("/root/game/game_scene/player/player_cam/extra_hud/camera").Show();
            GetNode<AnimatedSprite>("/root/game/game_scene/player/player_cam/extra_hud/camera").Play("smooth");
        }
        config_.Load("res://extra.cfg");
        config_.SetValue("extra","camera",localCamera);
        config_.Save("res://extra.cfg");
        config_.Clear();
    }
    }
}
