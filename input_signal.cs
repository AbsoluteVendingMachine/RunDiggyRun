using Godot;
using System;

public class input_signal : Node
{

// shorthands

    private ConfigFile cf = new ConfigFile();
    
// variables that are loaded initially for
// titlescreen scene
    string cfg_f_one = "settings.cfg";
    string cfg_f_two = "controls.cfg";
    int ckp;
    int ts_keynum = 0;
    bool ts_keypress = false;
    bool in_ts = true;
    bool ikts_1 = true;
    bool ikts_2 = false;
    bool ikts_3 = false;
    bool in_st = false;
    bool in_sts = false;
    bool do_inputs = false;
    bool in_do_inputs = false;
    int st_keynum = 0;
    int sts_keynum = 0;

// debugmode can be toggled on/off to show status
// of ts_keynum integer (see _process)

    [Export]
    bool debugmode;
    [Export]
    bool debugmode2;

    public void save_n()

    {

    //cf.SetValue("controls", "left", ckp);

    }

    public override void _Ready()

    {
        

        
    }

//input signals and signal to enter settings

    [Signal]
    public delegate void input1();
    [Signal]
    public delegate void input2();
    [Signal]
    public delegate void input3();
    [Signal]
    public delegate void enter_settings();
    [Signal]
    public delegate void setting1();
    [Signal]
    public delegate void setting2();
    [Signal]
    public delegate void setting3();
    [Signal]
    public delegate void setting4();
    [Signal]
    public delegate void setting5();
    [Signal]
    public delegate void set_inputs();
    [Signal]
    public delegate void enter_settings2();
    [Signal]
    public delegate void sip1();
    [Signal]
    public delegate void sip2();
    [Signal]
    public delegate void sip3();
    [Signal]
    public delegate void sip4();
    [Signal]
    public delegate void sip5();
    [Signal]
    public delegate void sip6();
    [Signal]
    public delegate void changesetting1();
    [Signal]
    public delegate void changesetting2();
    [Signal]
    public delegate void changesetting4();
    [Signal]
    public delegate void changesetting5();
    [Signal]
    public delegate void entertitlescreen();
    [Signal]
    public delegate void resetsettings();

// inputs are done in process to signal titlekeys
// to change to appropriate sprites

    public override void _Process(float delta)
    
{

if (in_ts == true) 

{

if (ts_keypress == false)

{
    if (ts_keynum < 2)

    {
        if (Input.IsActionPressed("down_title"))

        {

        ts_keynum = ts_keynum+1;
        ts_keypress = true;

        }
        
    }

    if (ts_keynum > 0)

    {

        if (Input.IsActionPressed("up_title"))

        {

        ts_keynum = ts_keynum-1;
        ts_keypress = true;

        }
        
    }

    if (ts_keynum == 1)
    
    {
        
        if(Input.IsActionPressed("title_cont"))
        GD.Print(Input.IsActionPressed("title_cont"));

        {
        
        ts_keypress = true;
        in_ts = false;
        in_sts = true;
        in_st = false;
        ts_keypress = false;

        { 
            if (ikts_1 == false) 

        {

        EmitSignal(nameof(enter_settings));
        EmitSignal(nameof(enter_settings2));
        ikts_1 = true;

        }

        }

    }

    if (ts_keynum == 2)
    
    {

        if(Input.IsActionPressed("title_cont"))

        {

        ts_keypress = true;
        in_ts = false;
        in_sts = false;
        in_st = true;
        ts_keypress = false;

        }

    }

}

if (ts_keypress == true)

{
    if (!Input.IsActionPressed("up_title"))

    {
        if (!Input.IsActionPressed("down_title"))

        {
            
            ts_keypress = false;

        }

    }

}

if (ts_keynum == 0)

{
    
    EmitSignal(nameof(input1));

}

else if (ts_keynum == 1)

{
   
    EmitSignal(nameof(input2));

}

else if (ts_keynum == 2)

{

    EmitSignal(nameof(input3));

}

}

if (debugmode == true)

{

    GD.Print("tskeynum:"+ts_keynum);
    GD.Print("stkeynum:"+st_keynum);
    GD.Print("stskeynum:"+sts_keynum);
    GD.Print("in titlescreen:"+in_ts);
    GD.Print("in settings:"+in_sts);
    GD.Print("in stats"+in_st);
    GD.Print("tskeypress:"+ts_keypress);

}

if (in_ts == false && in_sts == true) 

{

}

}

if (ikts_2 == true && (Input.IsActionPressed("title_cont") == false) && (Input.IsActionPressed("down_title")) && (Input.IsActionPressed("up_title")))

{

ikts_2 = false;

}

if (ikts_3 == true && (Input.IsActionPressed("title_cont") == false) && (Input.IsActionPressed("down_title")) && (Input.IsActionPressed("up_title")))

{

ikts_3 = false;

}

if (in_sts == true)

{

if (ikts_3 == false)

{

if (Input.IsActionPressed("down_title"))

{

if (st_keynum < 4)

{

st_keynum = st_keynum+1;
    
}

}

if (Input.IsActionPressed("up_title"))

{

if (st_keynum > 0)

{

st_keynum = st_keynum-1;

}

}

if (st_keynum == 0) 

{

if (Input.IsActionPressed("title_cont") && (ikts_3 == false))

{

EmitSignal(nameof(changesetting1));
ikts_3 = true;

}

EmitSignal(nameof(setting1));

}

if (st_keynum == 1) 

{

if (Input.IsActionPressed("title_cont") && (ikts_3 == false))

{

EmitSignal(nameof(changesetting2));
ikts_3 = true;

}

EmitSignal(nameof(setting2));

}

if (st_keynum == 2) 

{

EmitSignal(nameof(setting3));

}

if (st_keynum == 3) 

{

if (Input.IsActionPressed("title_cont") && (ikts_3 == false))

{

EmitSignal(nameof(changesetting4));
ikts_3 = true;

}

EmitSignal(nameof(setting4));

}

if (st_keynum == 4) 

{

if (Input.IsActionPressed("title_cont") && (ikts_3 == false))

{

EmitSignal(nameof(changesetting5));
ikts_3 = true;

}

EmitSignal(nameof(setting5));

}

if (Input.IsActionPressed("title_cont") && st_keynum == 2 && ikts_2 == false)

{

EmitSignal(nameof(set_inputs));
in_do_inputs = true;
do_inputs = true;
in_st = false;
in_ts = false;
in_sts = false;
ikts_2 = true;


}

else if (in_do_inputs == true && do_inputs == true && in_sts == false && in_ts == false)

{

save_n();

}

}

}

}

}



// yes, this is spaghetti code