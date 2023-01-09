using Godot;
using System;

public class cont_singleton : Node
{
    [Signal] public delegate void any_button();
    private bool in_intro;
    private bool intro_done;

    public override void _Ready()
    {
        in_intro = false;
        intro_done = false;
    }

    public void _on_titlescreen_do_intro()
    {
        in_intro = true;
    }

    public override void _Process(float delta)
    {
        if (in_intro == true && Input.IsActionJustPressed("any"))
        {
            EmitSignal(nameof(any_button));
        }
        else if (in_intro == true && intro_done == true)
        {
            in_intro = false;
            intro_done = false;
            QueueFree();
        }
    }

    public void _on_controls_sprite_game_start()
    {
        intro_done = true;
    }
}
