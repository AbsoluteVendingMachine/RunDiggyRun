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

    public void _on_start_game_pressed(){
        EmitSignal("titlecont");
        iskeypressed = true;
        var sfx = GetNode<AudioStreamPlayer>("/root/game/titlescreen/sfx");
        sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/toggle.wav");
        sfx.Play();
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

    }

    else if (iskeypressed == true)

    {

    if (!Input.IsActionPressed("title_cont"))

    {

    iskeypressed = false;

    }

    }

    }

}
