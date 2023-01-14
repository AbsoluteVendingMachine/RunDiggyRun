using Godot;
using System;

public class death_screen : CanvasLayer
{
    [Signal] public delegate void callRestart();
    bool deathScreenShow;
    int causeOfDeath;
    string string1 = "\"It wasn't gonna happen.\"";
    string string2 = "\"Not exactly a save.\"";
    string string3 = "\"Should've saw it coming.\"";
    public override void _Ready(){
        //add connections in player code and such to allow for causeOfDeath to be interpreted
        //correctly
        deathScreenShow = false;
        Hide();
    }
    public void _on_restart_restart_game(){
        Hide();
    }
    public void deathCause(){
        var Message = GetNode<Label>("/root/game/game_scene/player/player_cam/hud/death_screen/message");
        if (causeOfDeath == 1){
            Message.Text = string1; 
        }
        else if (causeOfDeath == 2){
            Message.Text = string2; 
        }
        else if (causeOfDeath == 3){
            Message.Text = string3; 
        }
        var Image = GetNode<AnimatedSprite>("/root/game/game_scene/player/player_cam/hud/death_screen/images");
        Image.Play("anim"+causeOfDeath);
        GD.Print("anim"+causeOfDeath);
    }
    public void _on_player_causeOfDeath1(){
        causeOfDeath = 1;
    }
    public void _on_hurt_timer_causeOfDeath2(){
        causeOfDeath = 2;
    }
    public void _on_hurt_timer_causeOfDeath3(){
        causeOfDeath = 3;
    }
    public void _on_player_death(){
        deathScreenShow = true;
        deathCause();
        Show();
    }
    public void _on_final_boss_killAll(){
        QueueFree();
    }
    public override void _PhysicsProcess(float delta){
        if (deathScreenShow == true && Input.IsActionPressed("restart")){
            EmitSignal("callRestart");
            deathScreenShow = false;
            Hide();
        }
    }
}
