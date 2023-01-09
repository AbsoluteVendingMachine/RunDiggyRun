using Godot;
using System;

public class controls_sprite : Sprite
{
    [Signal] public delegate void game_start();
    private int intro_count;
    public override void _Ready()
    {
        intro_count = 0;
    }

    public void _on_cont_singleton_any_button()
    {
        if (intro_count == 1)
        {
            Hide();
            EmitSignal(nameof(game_start));
        }
        else
        {
            Show();
            intro_count = 1;
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
