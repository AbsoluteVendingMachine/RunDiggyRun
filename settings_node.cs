using Godot;
using System;

public class settings_node : Node
{

    private int settingskey_num;
    private bool in_settings;
    [Signal] public delegate void returntitle();
    [Signal] public delegate void sprite1();
    [Signal] public delegate void sprite2();
    [Signal] public delegate void sprite3();
    [Signal] public delegate void sprite4();
    [Signal] public delegate void debugmode_on();
    [Export] private bool debugmode;

    public void _on_input_singleton_titleback()

    {

    if (in_settings == true)

    {

    in_settings = false;
    settingskey_num = 1;
    EmitSignal(nameof(returntitle));

    }

    }

    public void _on_input_singleton_titledown()

    {

    if (in_settings == true)

    {

    if (settingskey_num < 4)

    {

    settingskey_num = settingskey_num+1;

    if (settingskey_num == 1)

    {

    EmitSignal(nameof(sprite1));

    }

    else if (settingskey_num == 2)

    {

    EmitSignal(nameof(sprite2));

    }

    else if (settingskey_num == 3)

    {

    EmitSignal(nameof(sprite3));

    }

    else if (settingskey_num == 4)

    {

    EmitSignal(nameof(sprite4));

    }

    }

    }

    }

    public void _on_input_singleton_titleup()

    {

    if (in_settings == true)

    {

    if (settingskey_num > 1)

    {

    settingskey_num = settingskey_num-1;
    
    if (settingskey_num == 1)

    {

    EmitSignal(nameof(sprite1));

    }

    else if (settingskey_num == 2)

    {

    EmitSignal(nameof(sprite2));

    }

    else if (settingskey_num == 3)

    {

    EmitSignal(nameof(sprite3));

    }

    else if (settingskey_num == 4)

    {

    EmitSignal(nameof(sprite4));

    }

    }

    }

    }

    public void _on_titlekeys_enter_intro()
    
    {

    QueueFree();

    }

    public void _on_titlekeys_enter_settings()

    {

    in_settings = true;
    settingskey_num = 1;

    }

    public override void _Ready()

    {

    settingskey_num = 1;
    in_settings = false;
    if (debugmode == true)
    {

        EmitSignal(nameof(debugmode_on));

    }

    }

    public void _on_debug_signal_timeout()

    {

    GD.Print("settingskey_num = "+settingskey_num);

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
