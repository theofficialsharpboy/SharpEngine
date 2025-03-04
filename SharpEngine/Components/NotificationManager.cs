
using SharpEngine.Graphics;
using SharpEngine.Helpers;

namespace SharpEngine.Components;
#nullable disable
public class NotificationManager : DrawableComponent
{
    List<Notification> notifications;
    SpriteBatch spriteBatch;

    /// <summary>
    /// Initialize a new instance of <see cref="NotificationManager"/>
    /// </summary>
    /// <param name="window"></param>
    protected NotificationManager(SharpWindow window) : base(window)
    {
        notifications = new ();
    }

    public override void Activate()
    {
        base.Activate();

        spriteBatch = new (Window.GraphicsDevice);
    }

    public override void Update(Time time)
    {
        base.Update(time);

        foreach(var notification in notifications)
        {
            notification.Update(time);

            if(notification.IsFinished)
            {
                notifications.Remove(notification);
            }
        }
    }

    public override void Draw(Time time)
    {
        base.Draw(time);

        foreach(var notification in notifications)
        {
            notification.Draw(time, spriteBatch);
        }
    }

    /// <summary>
    /// Adds a notification.
    /// </summary>
    /// <param name="notification"></param>
    public void Add(Notification notification) 
    {
        NullHelper.IsNullThrow(notification, nameof(notification));

        this.notifications.Add(notification);
    }
}
