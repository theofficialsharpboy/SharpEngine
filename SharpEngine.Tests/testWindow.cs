using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpEngine.Graphics;
using SharpEngine.Input.Devices;

namespace SharpEngine.Tests;

public class testWindow : SharpWindow
{
    public testWindow()
    {
        Title = "Test Title";
        DrawWhenFocused = false;
        IsFixedTimeSpan = false;
    }
    protected override void Activate()
    {
        base.Activate();
        SceneSystem.Input.Add(new Mouse("mouse"));
        SceneSystem.Input.Add(new Keyboard("keyboard", Input.InputIndex.One));
        SceneSystem.Add(new screenTest()); 
    }

    protected override void Initialize()
    {
        base.Initialize();
    }
    protected override void Draw(Time time)
    {
        GraphicsDevice.Clear(Color.White);

        base.Draw(time);
    }
    
}
