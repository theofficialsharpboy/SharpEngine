

namespace SharpEngine.Input.States.Mouse;

public class MouseState
{
    bool[] pressedButtons;

    public MouseState() 
    {
        pressedButtons = new bool[5];
    }

    public void UpdateStates()
    {
        for(int i = 0; i < 5;i++)
        {
            pressedButtons[i] = SFML.Window.Mouse.IsButtonPressed((SFML.Window.Mouse.Button)i);
        }
    }

    /// <summary>
    /// Gets whether a button is pressed.
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    public bool IsMouseButtonDown(MouseButton button) => pressedButtons[(int)button];

    /// <summary>
    /// Gets the position of the mouse.
    /// </summary>
    /// <returns></returns>
    public Vector2 GetPosition() 
    {
        return new (SFML.Window.Mouse.GetPosition(SharpWindow.Instance.renderWindow).X, SFML.Window.Mouse.GetPosition(SharpWindow.Instance.renderWindow).Y);
    }
}
