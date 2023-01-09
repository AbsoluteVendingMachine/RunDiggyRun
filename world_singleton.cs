using Godot;
using System;
public class world_singleton : Node{
    [Signal] public delegate void update_display();
    [Signal] public delegate void world1_1();
    [Signal] public delegate void world1_2();
    [Signal] public delegate void world1_3();
    [Signal] public delegate void world1_4();
    [Signal] public delegate void world2_1();
    [Signal] public delegate void world2_2();
    [Signal] public delegate void world2_3();
    [Signal] public delegate void world2_4();
    [Signal] public delegate void world3_1();
    [Signal] public delegate void world3_2();
    [Signal] public delegate void world3_3();
    [Signal] public delegate void world3_4();
    [Signal] public delegate void end();
    int world;
    int level;
    int map;
    int[] world1;
    int[] world2;
    int[] world3;
    bool levelOneOneDone;
    bool levelOneTwoDone;
    bool levelOneThreeDone;
    bool levelOneBossDone;
    bool levelTwoOneDone;
    bool levelTwoTwoDone;
    bool levelTwoThreeDone;
    bool levelTwoBossDone;
    bool levelThreeOneDone;
    bool levelThreeTwoDone;
    bool levelThreeThreeDone;
    bool levelThreeBossDone;
    bool worldOneDone;
    bool worldTwoDone;
    bool worldThreeDone;
    public override void _Ready(){
        world = 1;
        level = 1;
    }
    public void resetValues(){
        levelOneOneDone = false;
        levelOneTwoDone = false;
        levelOneThreeDone = false;
        levelOneBossDone = false;
        levelTwoOneDone = false;
        levelTwoTwoDone = false;
        levelTwoThreeDone = false;
        levelTwoBossDone = false;
        levelThreeOneDone = false;
        levelThreeTwoDone = false;
        levelThreeThreeDone = false;
        levelThreeBossDone = false;
        worldOneDone = false;
        worldTwoDone = false;
        worldThreeDone = false;
        world1[0] = 0;
        world1[1] = 0;
        world1[2] = 0;
        world2[0] = 0;
        world2[1] = 0;
        world2[2] = 0;
        world3[0] = 0;
        world3[1] = 0;
        world3[2] = 0;
    }
    public void matchArray(){
        GD.Randomize();
        var rng = new RandomNumberGenerator();
        if (world == 1){
            map = rng.RandiRange(1,3);
            if (map == 1 && world1[0] != 1){
                map = 1;
                world1[0] = 1;
            }
            else if (map == 1 && world1[0] == 1){
                GD.Randomize();
                map = rng.RandiRange(2,3);
                if (map == 2 && world1[1] != 2){
                    map = 2;
                    world1[1] = 2;
                }
                else if (map == 2 && world1[1] == 2){
                    map = 3;
                    world1[2] = 3;
                }
                if (map == 3 && world1[2] != 3){
                    map = 3;
                    world1[2] = 3;
                }
                else if (map == 3 && world1[2] == 3){
                    map = 2;
                    world1[1] = 2;
                } 
            }
            if (map == 2 && world1[1] != 2){
                map = 2;
                world1[1] = 2;
            }
            else if (map == 2 && world1[1] == 2){
                GD.Randomize();
                if (rng.RandiRange(1,2) == 1){
                    map = 1;
                    world1[0] = 1; 
                }
                else{
                    map = 3;
                    world1[2] = 3;
                }
            }
            if (map == 3 && world1[2] != 3){
                map = 3;
                world1[2] = 3;
            }
            else if (map == 3 && world1[2] == 3){
                GD.Randomize();
                if (rng.RandiRange(1,2) == 1){
                    map = 1;
                    world1[0] = 1;
                }
                else{
                    map = 2;
                    world1[1] = 2;
                }
            }
        }
    }
    public void checkArray(){
        if (world == 1 && !worldOneDone == true){
            if (map == world1[map-1]){
                if (map == 1){
                    levelOneOneDone = true;
                }
                else if (map == 2){
                    levelOneTwoDone = true;
                }
                else if (map == 3){
                    levelOneThreeDone = true;
                }
                if (levelOneOneDone == true && levelOneTwoDone == true && levelOneThreeDone == true){
                    worldOneDone = true;
                }
            }
        }

    }
    public void processArray(){
        EmitSignal("world"+world+"_"+map);
        if (level < 3){
            level = level+1;
        }
        else if (level == 3){
            level = 4;
        }
        else if (level == 4){
            level = 1;
        }
    }
    public void _on_controls_sprite_game_start(){
        world = 1;
        level = 1;
        resetValues();
        matchArray();
        checkArray();
        processArray();
    }

}
