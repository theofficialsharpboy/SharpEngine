using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Threading.Tasks;
using SFML.Graphics;
using SharpEngine.Content;
using SharpEngine.Controls;
using SharpEngine.Extensions;
using SharpEngine.Graphics;
using SharpEngine.Input;
using SharpEngine.Input.Devices;
using SharpEngine.Input.States.Mouse;

namespace SharpEngine.Tests;

public class screenTest : Scene.Scene
{
    Texture2D texture;
    int positionX = 10;
    int positionY = 10;
    SpriteFont font;

    Controls.Label label;

    public screenTest() : base("screenTest")
    {

    }

    public override void Draw(Time time, SpriteBatch spriteBatch)
    {
        base.Draw(time, spriteBatch);
    }

    public override void Activate()
    {
        var content = SceneSystem.Window.ContentManager;
        texture = content.LoadTexture2D(Environment.CurrentDirectory + "\\test.png", new Rectangle(0, 0, 100, 100));
        font = content.LoadFont(Environment.CurrentDirectory + "\\segoeui.ttf", 50);

        label = new Controls.Label()
        {
            Text = "this is a text",
            Font = font,
            Foreground = Color.White
        };

        AddControl(label);

    }

    public override void Update(Time time, bool otherScreenHasFocus, bool coveredByScreen)
    {
        base.Update(time, otherScreenHasFocus, coveredByScreen);

        label.Text = "FPS: " + SceneSystem.Window.FrameBufferInfo.FramesPerSecond.ToString("00") + $", {SceneSystem.Window.FrameBufferInfo.FrameLatency.ToString("0.00")}";
        label.Position = new(
                SceneSystem.Window.GraphicsDeviceManager.CurrentContext.Resulotion.Width /2- label.Size.Width/2,
                SceneSystem.Window.GraphicsDeviceManager.CurrentContext.Resulotion.Height/2 - label.Size.Height/2
                
        );
        
    }
    public override void HandleInput(InputSystem inputSystem)
    {
        base.HandleInput(inputSystem);

        var mouse = inputSystem.GetDevice<Mouse>("mouse");

        if(mouse.IsNewButtonDown(MouseButton.Left))
        {
            SceneSystem.Window.GraphicsDeviceManager.ApplyChanges(
                new GraphicsContext(
                    120, false, false,
                    new (1200, 720)
                )
            );
        }
    }
}
