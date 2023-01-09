using Godot;
using System;

public class fps : Label
{
    [Signal] public delegate void set_settings_3();
    private ConfigFile cf = new ConfigFile();
    private bool in_settings;
    private bool selected;
    private int fps_value;
    [Export] private bool debugmode_on;
    
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
    fps_value = (int) cf.GetValue("settings","frames_ps");
    cf.Clear();
    if (selected == true)
    {
    if (fps_value == 0)
    {
        Text = "FPS: 30<";
    }
    else if (fps_value == 1)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 2)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 3)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 4)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 5)
    {
        Text = "FPS: 60<";
    }
    }
    else
    {
       if (fps_value == 0)
    {
        Text = "FPS: 30";
    }
    else if (fps_value == 1)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 2)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 3)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 4)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 5)
    {
        Text = "FPS: 60";
    }
    }
    }

    public void _on_settings_node_enter_inputs()
    {
        if (in_settings == true)
        {
            //deprecated
        }
    {

    if (debugmode_on == false)

    {

    cf.Load("user://settings.cfg");

    }

    else if (debugmode_on == true)

    {

    cf.Load("res://settings.cfg");

    }
    cf.SetValue("settings","frames_ps",fps_value);
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
    EmitSignal(nameof(set_settings_3));
    }
    }

    public void _on_fullscreen_set_settings_2()

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
    cf.SetValue("settings","frames_ps",fps_value);
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
    EmitSignal(nameof(set_settings_3));

    }

    }

    public void _on_settings_node_debugmode_on()

    {

    debugmode_on = true;
    cf.Load("res://settings.cfg");
    fps_value = (int) cf.GetValue("settings","frames_ps");
    cf.Clear();

    }

    public void _on_titlekeys_enter_settings()

    {
        in_settings = true;

    if (debugmode_on == false)
    
    {

    cf.Load("user://settings.cfg");
    fps_value = (int) cf.GetValue("settings","frames_ps");
    cf.Clear();

    }
       if (fps_value == 0)
    {
        Text = "FPS: 30";
    }
    else if (fps_value == 1)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 2)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 3)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 4)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 5)
    {
        Text = "FPS: 60";
    }
    Show();

    }

    public void _on_settings_node_sprite2()

    {
    
    selected = false;
       if (fps_value == 0)
    {
        Text = "FPS: 30";
    }
    else if (fps_value == 1)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 2)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 3)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 4)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 5)
    {
        Text = "FPS: 60";
    }

    }

    public void _on_settings_node_sprite3()

    {

    selected = true;
       if (fps_value == 0)
    {
        Text = "FPS: 30<";
    }
    else if (fps_value == 1)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 2)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 3)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 4)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 5)
    {
        Text = "FPS: 60<";
    }

    }

    public void _on_settings_node_sprite4()

    {

    selected = false;
       if (fps_value == 0)
    {
        Text = "FPS: 30";
    }
    else if (fps_value == 1)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 2)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 3)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 4)
    {
        Text = "FPS: 60";
    }
    else if (fps_value == 5)
    {
        Text = "FPS: 60";
    }

    }

    public void _on_input_singleton_titlecont()

    {

    if (selected == true)

    {
    
    if (fps_value < 5)

    {
    
    fps_value = fps_value+1;
       if (fps_value == 0)
    {
        Text = "FPS: 30<";
    }
    else if (fps_value == 1)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 2)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 3)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 4)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 5)
    {
        Text = "FPS: 60<";
    }

    }

    else
    
    {

    fps_value = 0;
       if (fps_value == 0)
    {
        Text = "FPS: 30<";
    }
    else if (fps_value == 1)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 2)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 3)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 4)
    {
        Text = "FPS: 60<";
    }
    else if (fps_value == 5)
    {
        Text = "FPS: 60<";
    }

    }

    }

    }

    public override void _Ready()

    {

    Hide();
    in_settings = false;
    selected = false;


    }

    
}
