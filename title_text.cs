using Godot;
using System;

public class title_text : Label
{

    private bool in_title;
    private bool cangoback;

    public override void _Ready()

    {

    Show();
    in_title = true;
    cangoback = false;

    }

    public void _on_titlekeys_enter_intro()

    {

    in_title = false;
    cangoback = false;
    QueueFree();

    }

    public void _on_titlekeys_enter_settings()

    {

    in_title = false;
    cangoback = true;
    Show();

    }

    public void _on_titlekeys_enter_stats()
    {
        in_title = false;
        cangoback = true;
        Show();
    }

    public void _on_input_singleton_titleback()
    {
        if (in_title == false && cangoback == true)
        {
            in_title = true;
            cangoback = false;
            Show();
        }
    }
    
    public void _on_settings_node_enter_inputs()

    {
        Hide();
        in_title = false;
        cangoback = false;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
