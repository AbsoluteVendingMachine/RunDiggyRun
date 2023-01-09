using Godot;
using System;

public class inputs : AnimatedSprite
{

    [Signal] public delegate void set_inputs();
    private bool in_settings;
    private bool selected;

    public void _on_settings_node_enter_inputs()
    {
        in_settings = false;
        selected = false;
        Hide();
    }
    public void _on_fullscreen_set_settings_2()

    {

    if (in_settings == true)

    {

    in_settings = false;
    selected = false;
    Hide();

    }

    }

    public void _on_titlekeys_enter_settings()

    {

    Show();
    in_settings = true;

    }

    public void _on_input_singleton_titlecont()

    {

    if (selected == true && in_settings == true)

    {

    in_settings = false;
    selected = false;
    Hide();
    EmitSignal(nameof(set_inputs));

    }

    }

    public void _on_settings_node_sprite2()

    {

    Play("inputs0_0");

    }

    public void _on_settings_node_sprite3()

    {

    Play("inputs0_1");

    }

    public void _on_settings_node_sprite4()

    {

    Play("inputs0_0");

    }

    public override void _Ready()

    {

        Play("inputs0_0");
        Hide();
        in_settings = false;
        selected = false;

    }
    
}
