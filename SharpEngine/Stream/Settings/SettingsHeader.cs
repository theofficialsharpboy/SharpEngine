using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Stream.Settings;

public class SettingsHeader
{
    /// <summary>
    /// Gets the header.
    /// Gets the header.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the sections.
    /// </summary>
    public List<SettingsSection> Sections { get; }

    /// <summary>
    /// Initilaize a new instance of <see cref="SettingsHeader"/>
    /// </summary>
    /// <param name="name"></param>
    public SettingsHeader(string name)
    {
        Name = name;
        Sections = new List<SettingsSection>();
    }

    /// <summary>
    /// Gets a section by name.
    /// </summary>
    /// <param name="sectionName"></param>
    /// <returns></returns>
    public SettingsSection? this[string sectionName]
    {
        get
        {
            SettingsSection section = null;
            foreach(var s in Sections)
            {
                if (s.Name == sectionName)
                    section = s;
            }
            return section;
        }
    }
}
