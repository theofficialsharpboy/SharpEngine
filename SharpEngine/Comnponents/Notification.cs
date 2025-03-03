using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using SFML.Graphics;
using SharpEngine.Content;
using SharpEngine.Extensions;
using SharpEngine.Graphics;
using SharpEngine.Helpers;

namespace SharpEngine.Comnponents;

public class Notification
{
    private SpriteFont _spriteFont;
    private NotificationDirection _direction;
    private float positionX = 0;
    private float positionY = 0;
    private float speed = 1f;
    private bool _isDoneMoving = false;
    private Rectangle _bounds;
    private string text;
    private Size _fontSize;
    private float slideBackTimer = 0;
    private float slideBackTime = 2000;

    /// <summary>
    /// Gets a bool value indecating whether this <see cref="Notification"/> is finished and should be disposed, and removed.
    /// </summary>
    public bool IsFinished 
    {
        get;
        private set;
    }
#nullable disable
    /// <summary>
    /// Initialize a new instance of <see cref="Notification"/>
    /// </summary>
    public Notification(string text, SpriteFont font, float speed, NotificationDirection direction, float diration) 
    {
        NullHelper.IsNullThrow(text, nameof(text));
        NullHelper.IsNullThrow(font, nameof(font));
        NullHelper.IsNullThrow(speed, nameof(speed));
        NullHelper.IsNullThrow(direction, nameof(direction));
        NullHelper.IsNullThrow(diration, nameof(diration));

        this._direction = direction;
        this.speed = speed;
        this._spriteFont = font;
        this._fontSize = font.Measure(text);
        this.slideBackTime = diration;
    }

    /// <summary>
    /// Initialize a new instance of <see cref="Notification"/>
    /// </summary>
    /// <param name="font"></param>
    /// <param name="speed"></param>
    public Notification(string text, SpriteFont font, float speed, float diration) : this(text, font, speed, NotificationDirection.Left, diration) {}
    
#nullable disable

    /// <summary>
    /// Update this notification.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public void Update(Time time)
    {
        _bounds = new ((int)positionX, (int)positionY, _fontSize.Width, _fontSize.Height);

        if(!_isDoneMoving)
        {
            float push = _direction switch 
            {
                NotificationDirection.Left => positionX+=speed,
                NotificationDirection.Right => positionX-=speed,
                NotificationDirection.Top => positionY+=speed,
                NotificationDirection.Down => positionY-=speed,
                _ => throw new ArgumentNullException(nameof(_direction))
            };
        }

        var screenHeight = SharpWindow.Instance.GraphicsDeviceManager?.CurrentContext.Resulotion.Height;
        var screenWidth = SharpWindow.Instance.GraphicsDeviceManager?.CurrentContext.Resulotion.Width;

        switch(_direction)
        {
            case NotificationDirection.Left:
                 if(positionX >= 0) _isDoneMoving = true;
            break;
            case NotificationDirection.Right:
                 if(positionX <= screenWidth - _bounds.Width) _isDoneMoving = true;
            break;
            case NotificationDirection.Top:
                 if(positionY >= 0) _isDoneMoving = true;
            break;
            case NotificationDirection.Down:
                 if(positionY <= screenHeight - _bounds.Height) _isDoneMoving = true;
            break; 
        }

        if(_isDoneMoving)
        {
            slideBackTimer += (float)time.Enlapsed.TotalMilliseconds;
            
            if(slideBackTime >= slideBackTimer)
            {
                switch(_direction)
                {
                    case NotificationDirection.Left:
                         positionX-=speed;

                         if(positionX < _bounds.Width)
                         {
                            IsFinished = true;
                         }
                    break;
                    case NotificationDirection.Right:
                         positionX+=speed;

                         if(positionX >= screenWidth + _bounds.Width)
                         {
                            IsFinished = true;
                         }
                    break;
                    case NotificationDirection.Down:
                         positionY+=speed;

                         if(positionY >=screenHeight + _bounds.Height)
                         {
                            IsFinished = true;
                         }
                    break;
                    case NotificationDirection.Top:
                         positionY-=speed;

                         if(positionY <= _bounds.Height)
                         {
                            IsFinished = true;
                         }
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Draws this notification.
    /// </summary>
    /// <param name="time"></param>
    /// <param name="spriteBatch"></param>
    public void Draw(Time time, SpriteBatch spriteBatch)
    {
        NullHelper.IsNullThrow(time, nameof(time));
        NullHelper.IsNullThrow(spriteBatch, nameof(spriteBatch));

        var rectangleTexture = spriteBatch.CreateRectangle(_bounds.Width, _bounds.Height, Color.White);
        var textPosition = new Vector2(
            _bounds.X + _bounds.Width /2 - _fontSize.Width /2,
            _bounds.Y + _bounds.Height /2 - _fontSize.Height
        );
        var rectanglePosition = new Vector2(_bounds.X, _bounds.Y);

        spriteBatch.Begin();
        spriteBatch.DrawShadowTexture(rectangleTexture, rectanglePosition, 0.5f, Color.White);
        spriteBatch.DrawShadowString(_spriteFont, text, textPosition, 0.5f, Color.Black);
        spriteBatch.End();
    }
    #region private methods

    private void UpdatePosition() 
    {
        var screenHeight = SharpWindow.Instance.GraphicsDeviceManager?.CurrentContext.Resulotion.Height;
        var screenWidth = SharpWindow.Instance.GraphicsDeviceManager?.CurrentContext.Resulotion.Width;

        switch(_direction)
        {
            case NotificationDirection.Left:
                 positionY = - _bounds.Height;
                 positionX = - _bounds.Width;
            break;
            case NotificationDirection.Right:
                 positionX = screenWidth.Value + _bounds.Width;
                 positionY = - _bounds.Height;
            break;
            case NotificationDirection.Top:
                 positionX = - _bounds.Width;
                 positionY = - _bounds.Height;
            break;
            case NotificationDirection.Down:
                 positionY = screenHeight.Value + _bounds.Height;
                 positionX = - _bounds.Width;
            break; 
        }
    }

    #endregion
    
}
