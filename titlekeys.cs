using Godot;
using System;

public class titlekeys : Label
{

[Signal] public delegate void enter_settings();
[Signal] public delegate void enter_stats();
[Signal] public delegate void enter_intro();
private int title_keynum;
private bool in_titlescreen;
private bool cangoback;

    public override void _Ready()

    {

        Show();
        title_keynum = 0;
        Text = "New Game< Settings Stats ";
        in_titlescreen = true;
        cangoback = false;

    }
    
    public void _on_settings_node_enter_inputs()
    {
        in_titlescreen = false;
        cangoback = false;
    }
    public void _on_input_singleton_titleback()
    {
        if (in_titlescreen == false && cangoback == true)
        {
            title_keynum = 0;
            in_titlescreen = true;
            Text = "New Game< Settings Stats ";
            Show();
            cangoback = false;
            GD.Print("reaches this code");
        }
    }

    public void _on_input_singleton_titledown()

    {

    if (in_titlescreen == true && cangoback == false)

    {

    if (title_keynum < 2)

    {

    title_keynum = title_keynum + 1;
    
    if (title_keynum == 0)

    {

    Text = "New Game< Settings Stats ";

    }

    else if (title_keynum == 1)

    {

    Text = "New Game  Settings< Stats ";

    }

    else if (title_keynum == 2)

    {

    Text = "New Game  Settings Stats< ";

    }

    }

    }

    }

    public void _on_input_singleton_titleup()

    {

    if (in_titlescreen == true && cangoback == false)

    {
    
    if (title_keynum > 0)

    {

    title_keynum = title_keynum-1;
    
    if (title_keynum == 0)

    {

    Text = "New Game< Settings Stats ";

    }

    else if (title_keynum == 1)

    {

    Text = "New Game  Settings< Stats ";

    }

    else if (title_keynum == 2)

    {

    Text = "New Game  Settings Stats< ";

    }

    }

    }

    }

    public void _on_input_singleton_titlecont()

    {

    if (in_titlescreen == true && cangoback == false)

    {

    if (title_keynum == 0)

    {
    
    in_titlescreen = false;
    EmitSignal((nameof(enter_intro)));
    QueueFree();
    cangoback = false;

    }

    if (title_keynum == 1)

    {

    in_titlescreen = false;
    EmitSignal((nameof(enter_settings)));
    Hide();
    cangoback = true;

    }

    if (title_keynum == 2)

    {

    in_titlescreen = false;
    EmitSignal((nameof(enter_stats)));
    Hide();
    cangoback = true;

    }

    }

    }

    public void _on_debug_signal_timeout()

    {

    if (in_titlescreen == true) 
    
    {

    GD.Print("title_keynum = "+title_keynum);

    }

    }

    }
