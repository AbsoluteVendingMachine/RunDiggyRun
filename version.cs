using Godot;

using System;

public class version : Label

{
    
    bool cangoback;
    public override void _Ready()

    {

    Show();

    }

    public void _on_settings_node_enter_inputs()
    {
        Hide();
    }

    public void _on_titlekeys_enter_intro()

    {

    QueueFree();

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
