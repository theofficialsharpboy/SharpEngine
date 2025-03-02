using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine.Controls.EventArgs;

public delegate void ControlEventHandler<T>(T eventArgs);
public delegate void ControlEventHandler<T2, T>(T2 sender, T eventArgs);
public delegate void ControlEventHandler();
