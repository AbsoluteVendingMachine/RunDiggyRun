using Godot;
using System;

public class vsync : Label
{

    [Signal] public delegate void updatesettings();
    private ConfigFile cf = new ConfigFile();
    [Export] private bool debugmode_on;
    private int vsync_value;
    private bool in_settings;
    private bool selected;

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
    cf.SetValue("settings","vsync",vsync_value);
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
    vsync_value = (int) cf.GetValue("settings","vsync");
    cf.Clear();
    if (selected == true)
    {
    if (vsync_value == 0)
    {
        Text = "VSync: On<";
    }
    else
    {
        Text = "VSync: Off<";
    }
    }
    else
    {
    if (vsync_value == 0)
    {
        Text = "VSync: On";
    }
    else
    {
        Text = "Vsync: Off";
    }
    }
    }
    public void _on_fps_set_settings_3()

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
    cf.SetValue("settings","vsync",vsync_value);
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

    }

    }

    public override void _Ready()

    {

        Hide();
        in_settings = false;
        selected = false;

    }

    public void _on_settings_node_debugmode_on()

    {

    debugmode_on = true;
    cf.Load("res://settings.cfg");
    vsync_value = (int) cf.GetValue("settings","vsync");
    cf.Clear();

    }

    public void _on_titlekeys_enter_settings()

    {
        in_settings = true;

    if (debugmode_on == false)

    {

    cf.Load("user://settings.cfg");
    vsync_value = (int) cf.GetValue("settings","vsync");
    cf.Clear();

    }
    if (vsync_value == 0)
    {
        Text = "VSync: On";
    }
    else
    {
        Text = "VSync: Off";
    }
    Show();

    }

    public void _on_settings_node_sprite3()

    {

    selected = false;
    if (vsync_value == 0)
    {
        Text = "VSync: On";
    }
    else
    {
        Text = "VSync: Off";
    }

    }

    public void _on_settings_node_sprite4()

    {

    selected = true;
    if (vsync_value == 0)
    {
        Text = "VSync: On<";
    }
    else
    {
        Text = "VSync: Off<";
    }

    }

    public void _on_input_singleton_titlecont()

    {

    if (selected == true)

    {

    if (vsync_value == 0)

    {

    vsync_value = 1;
    if (vsync_value == 0)
    {
        Text = "VSync: On<";
    }
    else
    {
        Text = "VSync: Off<";
    }

    }
    
    else

    {

    vsync_value = 0;
    if (vsync_value == 0)
    {
        Text = "VSync: On<";
    }
    else
    {
        Text = "VSync: Off<";
    }

    }
        
    }

    }

    public void _on_titlekeys_enter_intro()

    {

    QueueFree();

    }
    
}
