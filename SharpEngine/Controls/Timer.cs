using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpEngine.Controls.EventArgs;
using SharpEngine.Input;

namespace SharpEngine.Controls;

#nullable disable

public class Timer : Control
{
    int timer_time = 0;

    /// <summary>
    /// Gets or sets the interval.
    /// </summary>
    public float Interval 
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets whether this timer is enabled.
    /// </summary>
    public bool Enabled 
    {
        get;
        set;
    }

    /// <summary>
    /// Raised when this <see cref="Timer"/> enters the <see cref="Timer.Interval"/>
    /// </summary>
    public event ControlEventHandler Tick;

    /// <summary>
    /// Initialize a new instance of <see cref="Timer"/>
    /// </summary>
    public Timer() {}

    protected override void OnUpdate(Time time)
    {
        base.OnUpdate(time);

        timer_time += (int)time.Enlapsed.TotalSeconds;

        if(timer_time >= Interval)
        {
            if(Enabled) 
            {
                OnTick();
                timer_time =0; // reset it.
            }
        }
    }

    protected override void OnHandleInput(InputSystem inputSystem)
    {
    }

    /// <summary>
    /// Raised when this <see cref="Timer"/> enters the <see cref="Timer.Interval"/>
    /// </summary>
    protected virtual void OnTick() => Tick?.Invoke();
}
