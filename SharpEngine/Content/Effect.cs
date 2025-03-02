
using SFML.Graphics;
using SharpEngine.Exceptions;

namespace SharpEngine.Content;

public class Effect
{
    /// <summary>
    /// Gets the shader path.
    /// </summary>
    public string VertexPath {get;}

    /// <summary>
    /// Gets the frag path.
    /// </summary>
    public string FragPath {get;}

    /// <summary>
    /// Gets the geometry path.
    /// </summary>
    public string GeometryPath {get;}

    /// <summary>
    /// Initialize a new instance of <see cref="Effect"/>
    /// </summary>
    /// <param name="shader"></param>
    /// <param name="frag"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ContentException"></exception>
    public Effect(string shader, string geometry, string frag)
    {
        if(string.IsNullOrWhiteSpace(shader)) throw new ArgumentNullException(nameof(shader));
        if(string.IsNullOrWhiteSpace(frag)) throw new ArgumentNullException(nameof(frag));
        if(string.IsNullOrWhiteSpace(geometry)) throw new ArgumentNullException(nameof(geometry));

        if(!shader.EndsWith(".glsl")) throw new ContentException("The current vertex shader file is not a vaild .glsl file.");
        if(!frag.EndsWith(".glsl")) throw new ContentException("The current fragment shader file is not a vaild .glsl file.");
        if(!geometry.EndsWith(".glsl")) throw new ContentException("The current geometry shader file is not a valid .glsl file.");
        
        if(!File.Exists(shader)) throw new FileNotFoundException(shader);
        if(!File.Exists(geometry)) throw new FileNotFoundException(geometry);
        if(!File.Exists(frag)) throw new FileNotFoundException(frag);

        this.FragPath = frag;
        this.VertexPath = shader;
        this.GeometryPath = geometry;
    }
}
