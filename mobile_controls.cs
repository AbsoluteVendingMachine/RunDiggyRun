using Godot;
using System;

public class mobile_controls : CanvasLayer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Hide();
    }
    public void _on_controls_sprite_game_start(){
        Show();
    }
    public void _on_final_boss_killAll(){
        Hide();
        Offset = new Vector2(1000,0);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
