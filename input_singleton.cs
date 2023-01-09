using Godot;
using System;

public class input_singleton : Node
{

    public void _on_titlekeys_enter_intro()

    {

    QueueFree();

    }
    
    [Signal] public delegate void titlecont();
    [Signal] public delegate void titleup();
    [Signal] public delegate void titledown();
    [Signal] public delegate void titleback();
    [Signal] public delegate void settingsreset();

    private bool iskeypressed;
    private bool cangoback;

    public override void _Ready()

    {

    iskeypressed = false;
    cangoback = true;

    }

    public void _on_settings_node_enter_inputs()
    {
        iskeypressed = false;
        cangoback = false;
    }

     public override void _Process(float delta)

    {
      
    if (iskeypressed == false && cangoback == true)

    {

    if (Input.IsActionPressed("title_cont"))

    {

    var sfx = GetNode<AudioStreamPlayer>("/root/game/titlescreen/sfx");
    sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/toggle.wav");
    sfx.Play();
    EmitSignal(nameof(titlecont));
    iskeypressed = true;

    }

    if (Input.IsActionPressed("up_title"))

    {

    var sfx = GetNode<AudioStreamPlayer>("/root/game/titlescreen/sfx");
    sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/toggle.wav");
    sfx.Play();
    EmitSignal(nameof(titleup));
    iskeypressed = true;

    }

    if (Input.IsActionPressed("down_title"))

    {

    var sfx = GetNode<AudioStreamPlayer>("/root/game/titlescreen/sfx");
    sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/toggle.wav");
    sfx.Play();
    EmitSignal(nameof(titledown));
    iskeypressed = true;

    }

    if (Input.IsActionPressed("title_back"))

    {

    var sfx = GetNode<AudioStreamPlayer>("/root/game/titlescreen/sfx");
    sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/toggle.wav");
    sfx.Play();
    EmitSignal(nameof(titleback));
    iskeypressed = true;

    }

    if ((Input.IsActionPressed("resetsettingskb1")) || (Input.IsActionPressed("resetsettingscontroller")))

    {

    var sfx = GetNode<AudioStreamPlayer>("/root/game/titlescreen/sfx");
    sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/toggle.wav");
    sfx.Play();
    EmitSignal(nameof(settingsreset));
    iskeypressed = true;

    }

    }

    else if (iskeypressed == true)

    {

    if ((!Input.IsActionPressed("title_cont")) && (!Input.IsActionPressed("up_title")) && (!Input.IsActionPressed("down_title")) && (!Input.IsActionPressed("title_back")) && (!Input.IsActionPressed("resetsettingskb1")) && (!Input.IsActionPressed("resetsettingscontroller")))

    {

    iskeypressed = false;

    }

    }

    }

}
