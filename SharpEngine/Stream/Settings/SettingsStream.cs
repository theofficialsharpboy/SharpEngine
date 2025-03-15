using SharpEngine.Helpers;

namespace SharpEngine.Stream.Settings;

public class SettingsStream
{
    List<SettingsHeader> headers;
    string fileName;

    /// <summary>
    /// Gets the file name.
    /// </summary>
    public string FileName => fileName;

    /// <summary>
    /// Gets a specified <see cref="SettingsHeader"/> by its name.
    /// </summary>
    /// <param name="headerName"></param>
    /// <returns></returns>
    public SettingsHeader? this[string headerName]
    {
        get
        {
            SettingsHeader? header = null;
            foreach (var h in headers)
            {
                if (h.Name == headerName)
                {
                    header = h;
                }
            }
            return header;
        }
    }

#nullable disable

    /// <summary>
    /// Initialize a new instance of <see cref="SettingsStream"/>
    /// </summary>
    /// <param name="fileName"></param>
    public SettingsStream(string fileName)
    {
        NullHelper.IsNullThrow(fileName, nameof(fileName));

        this.fileName = fileName;
        this.headers = new List<SettingsHeader>();

        if(!File.Exists(fileName))
        {
            return;
        }
        else
        {
            var lines = File.ReadAllLines(fileName);

            foreach(var line in lines)
            {
                SettingsHeader header = null;
                
                if(line.StartsWith("[") && line.EndsWith("]"))
                {
                    header = new SettingsHeader(line.Replace("[", "").Replace("]", ""));
                }

                if(line.Contains("="))
                {
                    var split = line.Split("=");
                    var name = split[0];
                    var value = split[1];

                    if (header != null)
                    {
                        header.Sections.Add(new SettingsSection(name, value));
                    }
                }

                headers.Add(header);
            }
        }
    }

    /// <summary>
    /// Adds a section.
    /// </summary>
    /// <param name="header"></param>
    public void Add(SettingsHeader header)
    {
        NullHelper.IsNullThrow(header, nameof(header));

        headers.Add(header);
    }

    /// <summary>
    /// Removes a settings header.
    /// </summary>
    /// <param name="headerName"></param>
    public void Remove(string headerName) => headers.Remove(this[headerName]);

    /// <summary>
    /// Saves this settings stream to the specificed filename in <see cref="SettingsStream.FileName"/>
    /// </summary>
    public void Save()
    {
        StreamWriter writer = new StreamWriter(fileName);
        foreach(var header in headers)
        {
            writer.WriteLine($"[{header.Name}]");
            foreach (var section in header.Sections)
            {
                writer.WriteLine(section.ToString());
            }
        }
        writer.Close();
    }
}
