using Godot;
using System;

public class exit_instruction2 : Label
{
   
    private bool in_titlescreen;
    private bool in_stats;
    public override void _Ready()
    {
        Hide();
        in_titlescreen = true;
        in_stats = false;
    }
    
    public void _on_titlekeys_enter_stats()
    {
        Show();
        in_titlescreen = false;
        in_stats = true;
    }

    public void _on_input_singleton_titleback()
    {
        if (in_titlescreen == false && in_stats == true)
        {
            Hide();
            in_titlescreen = true;
            in_stats = false;
        }
    }
    
}
