using Godot;
using System;

public class music : AudioStreamPlayer
{
    int audio;
    
    public override void _Ready()
    {
        audio = 1;
        play_audio();
    }

    public void play_audio()
    {
        Stop();
        if (audio == 1)
        {
            Stream = GD.Load<AudioStream>("res://assets/audio/ost/titlescreen2.ogg");
        }
        else if (audio == 2)
        {
            Stream = GD.Load<AudioStream>("res://assets/audio/ost/cricket.ogg");
        }
        else if (audio == 3)
        {
            Stream = GD.Load<AudioStream>("res://assets/audio/ost/boss2.ogg");
        }
        else if (audio == 4){
            Stream = GD.Load<AudioStream>("res://assets/audio/ost/growth.ogg");
        }
        else if (audio == 5){
            Stream = GD.Load<AudioStream>("res://assets/audio/ost/castle.ogg");
        }
        else if (audio == 6){
            Stream = GD.Load<AudioStream>("res://assets/audio/ost/boss3.ogg");
        }
        else if (audio == 7){
            Stream = GD.Load<AudioStream>("res://assets/audio/ost/credits.ogg");
        }
        Play();

    }

    public void _on_progress_point_newLevelPosition(){
        PitchScale = 1;
    }

    public void _on_extra_hud_audio1(){
        VolumeDb = -2;
    }

    public void _on_extra_hud_audio2(){
        VolumeDb = -100;
    }

    public void _on_extra_hud_audio3(){
        VolumeDb = -100;
    }

    public void _on_skull_pitchReset(){
        PitchScale = 1;
    }

    public void _on_skull_pitchChange(){
        PitchScale = (float)0.8;
    }

    public void _on_world_singleton_level2(){
        audio = 2;
        play_audio();
    }

    public void _on_world_singleton_level3(){
        audio = 2;
        play_audio();
    }

    public void _on_controls_sprite_game_start()
    {
        audio = 2;
        play_audio();
    }

    public void _on_bat_boss_boss1Dead()
    {
        Stop();
    }

    public void _on_world_singleton_level4()
    {
        audio = 3;
        play_audio();
    }

    public void _on_world_singleton_level5(){
        audio = 4;
        play_audio();
    }

    public void _on_world_singleton_level6(){
        audio = 4;
        play_audio();
    }

    public void _on_world_singleton_level7(){
        audio = 4;
        play_audio();
    }

    public void _on_world_singleton_level8(){
        audio = 3;
        play_audio();
    }

    public void _on_rabbit_boss_rabbitBossDeath(){
        audio = 5;
        play_audio();
    }

    public void _on_world_singleton2_level10(){
        audio = 5;
        play_audio();
    }

    public void _on_world_singleton2_finalboss(){
        audio = 6;
        play_audio();
    }

    public void _on_cutscene_startCredits()
    {
        audio = 7;
        play_audio();
    }

    public override void _PhysicsProcess(float delta)
    {
        if (OS.IsWindowFocused() == true)
        {
            VolumeDb = -2;
        }
        else if (OS.IsWindowFocused() == false)
        {
            VolumeDb = -20;
        }
    }
    public void _on_restart_restart_game(){
        audio = 2;
        play_audio();
    }

    public void _on_player_death(){
        audio = 2;
        Stop();
    }

    public void _on_kill_timer_timeout(){
        Stop();
    }

    public void _on_final_boss_killAll(){
        Stop();
    }

    //blowing pack blowing strands in yodieland
    //U2hhbGwgd2U/IENoZWVycyBteSBmcmllbmRz
    // :)
}
