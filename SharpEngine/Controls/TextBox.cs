using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpEngine.Graphics;
using SharpEngine.Input.States.Keyboard;
using SharpEngine.Extensions;

namespace SharpEngine.Controls;

public class TextBox : Control
{
    protected override void OnKeyDown(Keys key)
    {
        base.OnKeyDown(key);

        if(IsFocused)
        {
            if(key != Keys.Backspace)
            {
                Text += key.ToString();
            }            
        }
    }

    protected override void OnDraw(Time time, SpriteBatch spritebatch)
    {
        base.OnDraw(time, spritebatch);

        var rectTexture = spritebatch.CreateRectangle(Size.Width +10, Size.Height +10, Background);
        var position = new Vector2(
            (Position.X + rectTexture.Size.X /2 - Size.Width/2) -5,
            (Position.Y + rectTexture.Size.Y /2 - Size.Height/2)
        );
        var caretPositionEnd = new Vector2(
            (Position.X),
            (Position.Y + Size.Height)
        );

        // push the text back if its bigger than the rectTexture.
        if(Size.Width > rectTexture.Size.X)  position.X -=1;

        spritebatch.Begin();
        spritebatch.Draw(rectTexture, Position, Color.White);
        spritebatch.DrawString(Font, Text, position, Foreground);
        spritebatch.DrawLine(Position, caretPositionEnd, Color.Black * 0.7f);
        spritebatch.End();
    }

    protected override void OnClick()
    {
        base.OnClick();
    }
}
