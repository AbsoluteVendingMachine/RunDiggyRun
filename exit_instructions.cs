using Godot;
using System;

public class exit_instructions : Label

{

    public override void _Ready()

    {

    Hide();

    }

    public void _on_titlekeys_enter_intro()

    {

    QueueFree();

    }

    public void _on_titlekeys_enter_settings()

    {

    Show();

    }

    public void _on_input_singleton_titleback()
    {
        Hide();
    }

    

}
