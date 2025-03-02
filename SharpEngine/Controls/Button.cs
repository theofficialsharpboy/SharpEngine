
using SharpEngine.Extensions;
using SharpEngine.Graphics;

namespace SharpEngine.Controls;

public class Button : Control
{
    bool selected = false;

    /// <summary>
    /// Gets or sets the selection color.
    /// </summary>
    public Color SelectionColor 
    {
        get;
        set;
    } = Color.Gray * 0.5f;


    protected override void OnDraw(Time time, SpriteBatch spritebatch)
    {
        base.OnDraw(time, spritebatch);

        var rectTexture = spritebatch.CreateRectangle(Size.Width +10, Size.Height +10, selected? SelectionColor : Background);
        var position = new Vector2(
            (Position.X + rectTexture.Size.X /2 - Size.Width/2) -5,
            (Position.Y + rectTexture.Size.Y /2 - Size.Height/2)
        );
        
        spritebatch.Begin();
        spritebatch.Draw(rectTexture, Position, Color.White);
        spritebatch.DrawString(Font, Text, position, Foreground);
        spritebatch.End();
    }

    protected override void OnMouseHover()
    {
        base.OnMouseHover();

        selected = true;
    }

    protected override void OnMouseLeave()
    {
        base.OnMouseLeave();
        selected = false;
    }
}
