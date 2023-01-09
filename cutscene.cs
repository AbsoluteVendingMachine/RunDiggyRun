using Godot;
using System;

public class cutscene : VideoPlayer
{
    [Signal] public delegate void startCredits();
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Hide();
    }

    public void _on_final_boss_killAll(){
        Show();
        Play();
    }
    
    public void _on_cutscene_finished(){
        Hide();
        EmitSignal("startCredits");
        GetNode<Sprite>("/root/game/credits/background").Show();
        QueueFree();
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
