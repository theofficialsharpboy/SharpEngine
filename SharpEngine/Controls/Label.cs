using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpEngine.Graphics;
using SharpEngine.Input;

namespace SharpEngine.Controls;

public class Label : Control
{
    protected override void OnDraw(Time time, SpriteBatch spritebatch)
    {
        base.OnDraw(time, spritebatch);

        spritebatch.Begin();
        spritebatch.DrawString(Font, Text, Position, Foreground);
        spritebatch.End();
    }

    protected override void OnHandleInput(InputSystem inputSystem)
    {
    }
}
