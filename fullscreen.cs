using Godot;
using System;

public class fullscreen : Label
{

    [Signal] public delegate void set_settings_2();
    private ConfigFile cf = new ConfigFile();
    [Export] private bool debugmode_on;
    private int fs_value;
    private bool in_settings;
    private bool selected;
    private bool cangoback;
    public override void _Ready()

    {

        Hide();
        in_settings = false;
        selected = false;
        cangoback = true;

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
    fs_value = (int) cf.GetValue("settings","f_screen");
    cf.Clear();
    if (selected == true)
    {
    if (fs_value == 1)
    {
        Text = "Fullscreen: On<";
    }
    else if (fs_value == 0)
    {
        Text = "Fullscreen: Off<";
    }
    }
    else if (selected == false)
    {
    if (fs_value == 1)
    {
        Text = "Fullscreen: On";
    }
    else if (fs_value == 0)
    {
        Text = "Fullscreen: Off";
    }
    }
    }

    public void _on_settings_node_enter_inputs()
    {
        if (in_settings == true)

    {

    if (debugmode_on == false)

    {

    cf.Load("user://settings.cfg");

    }

    else if (debugmode_on == true)

    {

    cf.Load("res://settings.cfg");

    }
    cf.SetValue("settings","f_screen",fs_value);
    if (debugmode_on == true)
    {
    cf.Save("res://settings.cfg");
    }
    else if (debugmode_on == false)
    {
    cf.Save("user://settings.cfg");
    }
    cf.Clear();
    in_settings = false;
    selected = false;
    cangoback = false;
    Hide();
    EmitSignal(nameof(set_settings_2));

    }
    }
    public void _on_resolution_set_settings_1()

    {

    if (in_settings == true)

    {

    if (debugmode_on == false)

    {

    cf.Load("user://settings.cfg");

    }

    else if (debugmode_on == true)

    {

    cf.Load("res://settings.cfg");

    }
    cf.SetValue("settings","f_screen",fs_value);
    if (debugmode_on == true)
    {
    cf.Save("res://settings.cfg");
    }
    else if (debugmode_on == false)
    {
    cf.Save("user://settings.cfg");
    }
    cf.Clear();
    in_settings = false;
    selected = false;
    Hide();
    EmitSignal(nameof(set_settings_2));

    }

    }
    
    public void _on_titlekeys_enter_intro()

    {

    QueueFree();

    }

    public void _on_settings_node_debugmode_on()

    {

    debugmode_on = true;
    cf.Load("res://settings.cfg");
    fs_value = (int) cf.GetValue("settings","f_screen");
    cf.Clear();
        
    }

    public void _on_titlekeys_enter_settings()
    
    {
        in_settings = true;

    if (debugmode_on == false)

    {

    cf.Load("user://settings.cfg");
    fs_value = (int) cf.GetValue("settings","f_screen");
    cf.Clear();

    }
    if (fs_value == 1)
    {
        Text = "Fullscreen: On";
    }
    else if (fs_value == 0)
    {
        Text = "Fullscreen: Off";
    }
    Show();
         
    }

    public void _on_settings_node_sprite1()

    {

    selected = false;
    if (fs_value == 1)
    {
        Text = "Fullscreen: On";
    }
    else if (fs_value == 0)
    {
        Text = "Fullscreen: Off";
    }

    }

    public void _on_settings_node_sprite2()
    
    {

    selected = true;
    if (fs_value == 1)
    {
        Text = "Fullscreen: On<";
    }
    else if (fs_value == 0)
    {
        Text = "Fullscreen: Off<";
    }

    }

    public void _on_settings_node_sprite3()

    {

    selected = false;
    if (fs_value == 1)
    {
        Text = "Fullscreen: On";
    }
    else if (fs_value == 0)
    {
        Text = "Fullscreen: Off";
    }

    }

    public void _on_input_singleton_titlecont()

    {

    if (selected == true)

    {

    if (fs_value == 0)

    {

    fs_value = 1;
    if (fs_value == 1)
    {
        Text = "Fullscreen: On<";
    }
    else if (fs_value == 0)
    {
        Text = "Fullscreen: Off<";
    }

    }

    else

    {

    fs_value = 0;
    if (fs_value == 1)
    {
        Text = "Fullscreen: On<";
    }
    else if (fs_value == 0)
    {
        Text = "Fullscreen: Off<";
    }

    }

    }
        
    }

}