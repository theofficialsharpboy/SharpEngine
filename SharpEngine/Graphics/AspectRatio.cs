
namespace SharpEngine.Graphics;

public class AspectRatio
{
    int width, height;

    /// <summary>
    /// Gets the width of the aspect ratio.
    /// </summary>
    public int Width => width;

    /// <summary>
    /// Gets the height of this aspect ratio.
    /// </summary>
    public int Height => height;

    /// <summary>
    /// Initialize a new instance of <see cref="AspectRatio"/>
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    protected AspectRatio(int width, int height) 
    {
        if(width < 0 || width > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(width));
        if(height < 0 || height > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(height));

        this.width = width;
        this.height = height;
    }

    /// <summary>
    /// Creates a aspect ratio based of the width and height.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static AspectRatio Create(int width, int height) 
    {
        int half = width/height;
        int? frameWidth, frameHeight;

        if(height > width) 
        {
            frameWidth = width;
            frameHeight = frameWidth / half;
        }
        else 
        {
            frameHeight = height;
            frameWidth = frameHeight / half;
        }

        int aspectWidth =  (width - frameWidth.Value) /2;
        int aspectHeight = (height - frameHeight.Value)/2;

        return new AspectRatio(aspectWidth, aspectHeight);
    }
}
