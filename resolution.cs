using Godot;
using System;

public class resolution : Label

{
    [Signal]
    public delegate void set_settings_1();
    [Signal] public delegate void insettingsdelay();
    private int resolution_value;
    [Export] private bool debugmode_on;
    private ConfigFile cf = new ConfigFile();
    private bool in_settings;
    private bool selected;
    private bool cangoback;
    public override void _Ready()

    {

    Hide();
    in_settings = false;
    selected = true;
    cangoback = true;

    }

    public void unselected_anim()
    {
        if (resolution_value == 1)
        {
            Text = "Resolution: 1x";
        }
        else if (resolution_value == 2)
        {
            Text = "Resolution: 0.5x";
        }
        else if (resolution_value == 3)
        {
            Text = "Resolution: 0.25x";
        }
        else if (resolution_value == 4)
        {
            Text = "Resolution: 1.5x";
        }
        else if (resolution_value == 5)
        {
            Text = "Resolution: 2x";
        }
    }

    public void selected_anim()
    {
        if (resolution_value == 1)
        {
            Text = "Resolution: 1x<";
        }
        else if (resolution_value == 2)
        {
            Text = "Resolution: 0.5x<";
        }
        else if (resolution_value == 3)
        {
            Text = "Resolution: 0.25x<";
        }
        else if (resolution_value == 4)
        {
            Text = "Resolution: 1.5x<";
        }
        else if (resolution_value == 5)
        {
            Text = "Resolution: 2x<";
        }
    }

    public void _on_resetsettings_func_timeout()

    {

    if (debugmode_on == true)
    {
    cf.Load("res://settings.cfg"); 
    }
    else
    {
    cf.Load("user://settings.cfg");
    }
    resolution_value = (int) cf.GetValue("settings","res_value");
    cf.Clear();
    if (selected == true)
    {
    selected_anim();
    }
    else
    {
    unselected_anim();
    }

    }

    public void _on_insettings_delay_timeout()

    {

    in_settings = true;

    }

    public void _on_debug_signal_timeout()

    {

    GD.Print("in_settings? = "+in_settings);

    }
    
    public void _on_settings_node_debugmode_on()

    {

    debugmode_on = true;
    cf.Load("res://settings.cfg");
    resolution_value = (int) cf.GetValue("settings","res_value");
    cf.Clear();

    }
    
    public void _on_settings_node_enter_inputs()
    {
        if (debugmode_on == false)

    {

    cf.Load("user://settings.cfg");

    }

    else if (debugmode_on == true)

    {

    cf.Load("res://settings.cfg");

    }
    GD.Print(resolution_value);
    cf.SetValue("settings","res_value",resolution_value);
    if (debugmode_on == true)
    {
    cf.Save("res://settings.cfg");
    }
    else if (debugmode_on == false)
    {
    cf.Save("user://settings.cfg");
    }
    cf.Clear();
    Hide();
    EmitSignal(nameof(set_settings_1));
    in_settings = false;
    selected = true;
    cangoback = false;

    }

    public void _on_titlekeys_enter_settings()

    {
    
    EmitSignal(nameof(insettingsdelay));
    //in_settings = true;
    cangoback = true;

    if (debugmode_on == false)

    {

    cf.Load("user://settings.cfg");
    resolution_value = (int) cf.GetValue("settings","res_value");
    cf.Clear();

    }
    selected_anim();
    Show();  

    }

    public void _on_settings_node_sprite1()

    {

    selected = true;
    selected_anim();

    }

    public void _on_settings_node_sprite2()

    {

    selected = false;
    unselected_anim();

    }

    public void _on_input_singleton_titlecont()

    {

    if (selected == true)

    {

    if (in_settings == true)

    {

    if (resolution_value < 5)

    {
    
    GD.Print("a change occured");
    resolution_value = resolution_value+1;
    selected_anim();

    }

    else

    {

    GD.Print("a change occured");
    resolution_value = 1;
    selected_anim();

    }

    }

    }

    }

    public void _on_settings_node_returntitle()

    {

    if (in_settings == true && cangoback == true)

    {

    if (debugmode_on == false)

    {

    cf.Load("user://settings.cfg");

    }

    else if (debugmode_on == true)

    {

    cf.Load("res://settings.cfg");

    }
    GD.Print(resolution_value);
    cf.SetValue("settings","res_value",resolution_value);
    if (debugmode_on == true)
    {
    cf.Save("res://settings.cfg");
    }
    else if (debugmode_on == false)
    {
    cf.Save("user://settings.cfg");
    }
    cf.Clear();
    Hide();
    EmitSignal(nameof(set_settings_1));
    in_settings = false;
    selected = true;

    }

    }

    }