# Run Diggy, Run!

Run Diggy, Run! is a free and open source game inspired by games like Cave Story and Spelunky.
It is made using Godot Game Engine 3.5 with scripting in C# & GDScript.

itch.io: https://absolutevendingmachine.itch.io/run-diggy-run

## Credits

Playtesters & Feedback:
Hyper Go On!, Kai, Kean, SleepingRaven, WaterNova

## Hardware Requirements

| Minimum Requirements | Recommended |
| -------------------- | ----------- |
| GPU: Integrated Graphics | GPU: Integrated Graphics |
| CPU: Any processor with integrated graphics| CPU: Any processor with integrated graphics|
| RAM: 512MB | RAM: 1GB |
| Storage: 128MB | Storage: 256MB |

## How To Install

Go to releases and select the latest archive according to your operating system, then extract and run executable.

## How To Build / Mod (etc.)

### Setup

- Download the mono version of [Godot Game Engine](https://godotengine.org/download) 3.5 (or a version below 4.0 and that's not for Android)
- Download and install dependencies listed on download page if you haven't already
- Download [.NET Core 3.1 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/3.1) and install it if you haven't already
- Download the Run Diggy, Run! source code
- Import the Run Diggy, Run! .zip or project.godot file into Godot Game Engine.
- Finally, go to Editor Settings > Mono > Builds > Build Tool > and set your Build Tool to dotnet CLI

### After Setup

If you have no experience with the Godot Game Engine or programming, without editing code, you can change assets such as: images, audio, collision shapes, and more. It is recommended to learn the basics of programming.

One thing you should know regardless of experience is that for this project I use Visual Studio Code for development. This is because I can use C# and GDScript in the same code editor (by downloading and configuring the [godot-tools](https://github.com/godotengine/godot-vscode-plugin) plugin in Visual Studio Code and Godot Game Engine).

## Notes

Windows: A SmartScreen warning will pop up because I have not codesigned the game (it costs money which I don't have right now and there may be some more additional requirements). This is a pretty normal thing and to get around it just select "More info" and then "Run anyway".

There may be some major bugs because this is my first game I've made that's not a web game in Scratch and I will try to fix them if documented. This game is also not optimized because rather than trying to create an optimal product, I tried to focus on the creative aspect (art, music, etc.) more than optimal code.
