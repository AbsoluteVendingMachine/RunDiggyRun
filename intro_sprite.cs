using Godot;
using System;

public class intro_sprite : Sprite
{
    public override void _Ready()
    {
        Hide();
    }

    public void _on_cont_singleton_any_button()
    {
        Hide();
        QueueFree();
    }

    public void _on_titlescreen_do_intro()
    {
        Show();
    }
}
