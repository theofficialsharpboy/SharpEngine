
using SharpEngine.Helpers;

namespace SharpEngine;

public class Color
{
    /// <summary>
    /// Gets the red color.
    /// </summary>
    public int R {get;}

    /// <summary>
    /// Gets the green color.
    /// </summary>
    public int G {get;}

    /// <summary>
    /// Gets the blue color.
    /// </summary>
    public int B {get;}

    /// <summary>
    /// Gets the alpha/opacity color.
    /// </summary>
    public int A {get;}

    /// <summary>
    /// Initialize a new instance of <see cref="Color"/>
    /// </summary>
    /// <param name="red"></param>
    /// <param name="green"></param>
    /// <param name="blue"></param>
    /// <param name="alpha"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Color(int red, int green, int blue, int alpha) 
    {
        if(red < int.MinValue || red > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(red));
        if(green < int.MinValue || green > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(green));
        if(blue < int.MinValue || blue > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(blue));
        if(alpha < int.MinValue ||alpha > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(alpha));
        if(red > 255) throw new ArgumentOutOfRangeException($"{nameof(red)} can not exceed 255");
        if(green > 255) throw new ArgumentOutOfRangeException($"{nameof(green)} can not exceed 255");
        if(blue > 255) throw new ArgumentOutOfRangeException($"{nameof(blue)} can not exceed 255");
        if(alpha > 255) throw new ArgumentOutOfRangeException($"{nameof(alpha)} can not exceed 255");

        this.R = red;
        this.G = green;
        this.B = blue;
        this.A = alpha;
    }

    /// <summary>
    /// Initialize a new instance of <see cref="Color"/>
    /// </summary>
    /// <param name="red"></param>
    /// <param name="green"></param>
    /// <param name="blue"></param>
    public Color(int red, int green, int blue) : this(red, green, blue, 255) 
    {
    }

    /// <summary>
    /// Initialize a new instance of <see cref="Color"/>
    /// </summary>
    /// <param name="hexColor">The hex color to transform from.</param>
    public Color(string hexColor) 
    {
        (int red, int blue, int green, int alpha) = ColorHelper.FromHex(hexColor);
      
        R = red;
        B = blue;
        G = green;
        A = alpha;
    }

    /// <summary>
    /// Initialize a new instance of <see cref="Color"/>
    /// </summary>
    /// <param name="h">Hue amount</param>
    /// <param name="l">Lightness amount</param>
    /// <param name="s">Saturation amount</param>
    public Color(float h, float l, float s)
    {
        (int red, int green, int blue, int alpha) = ColorHelper.FromHLS(h, l, s);

        R = red;
        G = green;
        B = blue;
        A = alpha;
    }

    /// <summary>
    /// Initialize a new instance of <see cref="Color"/>
    /// </summary>
    /// <param name="h">Hue amount</param>
    /// <param name="l">Lightness amount</param>
    /// <param name="s">Saturation amount</param>
    /// <param name="a">The alpha amount (MAX is 255)</param>
    public Color(float h, float l, float s, int a)
    {
         (int red, int green, int blue, int alpha) = ColorHelper.FromHLSA(h, l, s, a);

        R = red;
        G = green;
        B = blue;
        A = alpha;
    }
    #region otherators
    public static Color operator *(Color color, float alpha)
    {
        return new Color(color.R, color.G, color.B, (int)(alpha * 255f));
    }
    #endregion
    #region static colors
    public static Color Black = new ("#000000");
    public static Color White = new ("#FFFFFF");
    public static Color Red = new ("#FF0000");
    public static Color Green = new ("#00FF00");
    public static Color Blue = new ("#0000FF");
    public static Color Yellow = new ("#FFFF00");
    public static Color Cyan = new ("#00FFFF");
    public static Color Magenta = new ("#FF00FF");
    public static Color Gray = new ("#808080");
    public static Color DarkRed = new ("#8B0000");
    public static Color DarkGreen = new ("#006400");
    public static Color DarkBlue = new ("#00008B");
    public static Color LightYellow = new ("#FFFFE0");
    public static Color LightGreen = new ("#90EE90");
    public static Color LightBlue = new ("#ADD8E6");
    public static Color LightGray = new ("#D3D3D3");
    public static Color Orange = new ("#FFA500");
    public static Color Brown = new ("#A52A2A");
    public static Color Pink = new ("#FFC0CB");
    public static Color Purple = new ("#800080");
    public static Color Violet = new ("#EE82EE");
    public static Color Indigo = new ("#4B0082");
    public static Color Turquoise = new ("#40E0D0");
    public static Color Beige = new ("#F5F5DC");
    public static Color Lime = new ("#00FF00");
    public static Color Salmon = new ("#FA8072");
    public static Color Teal = new ("#008080");
    public static Color Olive = new ("#808000");
    public static Color NavyBlue = new ("#000080");
    public static Color Chocolate = new ("#D2691E");
    public static Color Coral = new ("#FF7F50");
    public static Color Gold = new ("#FFD700");
    public static Color Silver = new ("#C0C0C0");
    public static Color Plum = new ("#DDA0DD");
    public static Color Khaki = new ("#F0E68C");
    public static Color Lavender = new ("#E6E6FA");
    public static Color MistyRose = new ("#FFE4E1");
    public static Color PapayaWhip = new ("#FFEFD5");
    public static Color PeachPuff = new ("#FFDAB9");
    public static Color SeaGreen = new ("#2E8B57");
    public static Color MintCream = new ("#F5FFFA");
    public static Color SlateBlue = new ("#6A5ACD");
    public static Color SlateGray = new ("#708090");
    public static Color LawnGreen = new ("#7CFC00");
    public static Color DarkKhaki = new ("#BDB76B");
    public static Color LightCyan = new ("#E0FFFF");
    public static Color Aqua = new ("#00FFFF");
    public static Color DarkOrange = new ("#FF8C00");
    public static Color Fuchsia = new ("#FF00FF");
    public static Color HotPink = new ("#FF69B4");
    public static Color MidnightBlue = new ("#191970");
    public static Color DeepPink = new ("#FF1493");
    public static Color DarkMagenta = new ("#8B008B");
    public static Color LightSeaGreen = new ("#20B2AA");
    public static Color DarkSlateGray = new ("#2F4F4F");
    public static Color DarkTurquoise = new ("#00CED1");
    public static Color LightCoral = new ("#F08080");
    public static Color RoyalBlue = new ("#4169E1");
    public static Color Chartreuse = new ("#7FFF00");
    public static Color SpringGreen = new ("#00FF7F");
    public static Color MediumPurple = new ("#9370DB");
    public static Color Tomato = new ("#FF6347");
    public static Color MediumBlue = new ("#0000CD");
    public static Color DarkOrchid = new ("#9932CC");
    public static Color LightSteelBlue = new ("#B0C4DE");
    public static Color DarkViolet = new ("#9400D3");
    public static Color AquaMarine = new ("#7FFFD4");
    public static Color CadetBlue = new ("#5F9EA0");
    public static Color OliveDrab = new ("#6B8E23");
    public static Color PaleVioletRed = new ("#DB7093");
    public static Color FireBrick = new ("#B22222");
    public static Color GhostWhite = new ("#F8F8FF");
    public static Color FloralWhite = new ("#FFFAF0");
    public static Color Ivory = new ("#FFFFF0");
    public static Color AliceBlue = new ("#F0F8FF");
    public static Color LavenderBlush = new ("#FFF0F5");
    public static Color Honeydew = new ("#F0FFF0");
    public static Color OldLace = new ("#FDF5E6");
    public static Color Cornsilk = new ("#FFF8DC");
    public static Color BlanchedAlmond = new ("#FFEBCD");
    public static Color Bisque = new ("#FFE4C4");
    public static Color Linen = new ("#FAF0E6");
    public static Color DarkGoldenrod = new ("#B8860B");
    public static Color Orchid = new ("#DA70D6");
    public static Color RosyBrown = new ("#BC8F8F");
    public static Color SaddleBrown = new ("#8B4513");
    public static Color Seashell = new ("#FFF5EE");
    public static Color Sienna = new ("#A0522D");
    public static Color Snow = new ("#FFFAFA");
    public static Color Tan = new ("#D2B48C");
    public static Color Thistle = new ("#D8BFD8");
    public static Color Wheat = new ("#F5DEB3");
    public static Color WhiteSmoke = new ("#F5F5F5");
    public static Color YellowGreen = new ("#9ACD32");
    public static Color MediumOrchid = new ("#BA55D3");
    public static Color MediumSlateBlue = new ("#7B68EE");
    public static Color Peru = new ("#CD853F");
    public static Color PowderBlue = new ("#B0E0E6");
    public static Color SandyBrown = new ("#F4A460");
    public static Color ZinnwalditeBrown = new ("#2C3539");
    public static Color Amaranth = new ("#E52B50");
    public static Color Amber = new ("#FFBF00");
    public static Color Amethyst = new ("#9966CC");
    public static Color Apricot = new ("#FBCEB1");
    public static Color BabyBlue = new ("#89CFF0");
    public static Color BlueViolet = new ("#8A2BE2");
    public static Color BonFire = new ("#FE6F5E");
    public static Color Charcoal = new ("#36454F");
    public static Color Cherry = new ("#D2042D");
    public static Color Chestnut = new ("#9E2A2F");
    public static Color Copper = new ("#B87333");
    public static Color Emerald = new ("#50C878");
    public static Color Fandango = new ("#B53389");
    public static Color Firebrick = new ("#B22222");
    public static Color Grape = new ("#6F2DA8");
    public static Color GreenYellow = new ("#ADFF2F");
    public static Color Gunmetal = new ("#2A353F");
    public static Color Jade = new ("#00A86B");
    public static Color LemonChiffon = new ("#FFFACD");
    public static Color Lilac = new ("#C8A2C8");
    public static Color Mauve = new ("#E0B0FF");
    public static Color Periwinkle = new ("#CCCCFF");
    public static Color PineGreen = new ("#01796F");
    public static Color PoppyRed = new ("#F44336");
    public static Color Rose = new ("#FF007F");
    public static Color RoyalPurple = new ("#6A0DAD");
    public static Color Ruby = new ("#E0115F");
    public static Color Sapphire = new ("#0F52BA");
    public static Color SeaShell = new ("#FFF5EE");
    public static Color SunflowerYellow = new ("#FFDA03");
    public static Color Tangerine = new ("#FF9F00");
    public static Color Topaz = new ("#FFC87C");
    public static Color Umber = new ("#635147");
    public static Color Watermelon = new ("#FC6C85");
    public static Color Wisteria = new ("#C9A0DC");
    public static Color Zinc = new ("#8A7F7D");
    public static Color Acai = new ("#6A0DAD");
    public static Color AcidGreen = new ("#B0BF1A");
    public static Color Aero = new ("#7CB9E8");
    public static Color Alabaster = new ("#F2F0E6");
    public static Color AmaranthPink = new ("#F19CBB");
    public static Color AmberYellow = new ("#FFBF00");
    public static Color AmericanRose = new ("#FF033E");
    public static Color AppleGreen = new ("#8DB600");
    public static Color ApricotPeach = new ("#FAD6A5");
    public static Color ArcticLime = new ("#D0FF14");
    public static Color AshGray = new ("#B2BEB5");
    public static Color Auburn = new ("#A52A2A");
    public static Color Azure = new ("#007FFF");
    public static Color BabyPowder = new ("#FEFEFA");
    public static Color BananaMania = new ("#FAE7B5");
    public static Color BattleshipGrey = new ("#848482");
    public static Color BeigeTaupe = new ("#BDB7B2");
    public static Color BigStone = new ("#4A3C30");
    public static Color BitterLime = new ("#BFFF00");
    public static Color BlackBean = new ("#3D0C02");
    public static Color BlueGray = new ("#6699CC");
    public static Color BlueJeans = new ("#5DADE2");
    public static Color BlueLagoon = new ("#6EAFD2");
    public static Color Blush = new ("#DE5D6D");
    public static Color BoogerBuster = new ("#B4C400");
    public static Color Bone = new ("#E3DAC9");
    public static Color Brass = new ("#B5A642");
    public static Color BrightLavender = new ("#BF94E4");
    public static Color BrilliantRose = new ("#FF55A3");
    public static Color Bronze = new ("#CD7F32");
    public static Color BubbleGumPink = new ("#FF69B4");
    public static Color CadmiumGreen = new ("#006B3C");
    public static Color Calypso = new ("#3A6A47");
    public static Color CaribbeanGreen = new ("#00CC99");
    public static Color CarrotOrange = new ("#ED9121");
    public static Color Celadon = new ("#ACE1AF");
    public static Color Celeste = new ("#B2FFFF");
    public static Color Champagne = new ("#F7E7CE");
    public static Color CharcoalGray = new ("#36454F");
    public static Color CherryBlossomPink = new ("#FFB7C5");
    public static Color ChestnutRose = new ("#9E2A2F");
    public static Color ChinaPink = new ("#DE6FA1");
    public static Color Cinnabar = new ("#E44D2E");
    public static Color Cinnamon = new ("#D2691E");
    public static Color ClassicRose = new ("#FBCCE7");
    public static Color Cloud = new ("#C1D3D4");
    public static Color CocoaBrown = new ("#D2691E");
    public static Color CoralRed = new ("#FF4040");
    public static Color CornflowerBlue = new ("#6495ED");
    public static Color CosmicLatte = new ("#FFF8E7");
    public static Color Crimson = new ("#DC143C");
    public static Color CyanAzure = new ("#4E82B8");
    public static Color DarkAmber = new ("#FF7F00");
    public static Color DarkGrape = new ("#6A2E8C");
    public static Color DarkMossGreen = new ("#4A5D23");
    public static Color DarkOliveGreen = new ("#556B2F");
    public static Color DarkPink = new ("#E75480");
    public static Color DarkSeaGreen = new ("#8FBC8F");
    public static Color DarkSlateBlue = new ("#483D8B");
    public static Color DeepAquamarine = new ("#007F7F");
    public static Color DeepCarmine = new ("#9E2A2F");
    public static Color DeepPurple = new ("#5D3FD3");
    public static Color Denim = new ("#1560BD");
    public static Color DesertSand = new ("#EDC9AF");
    public static Color Diamond = new ("#B9F2FF");
    public static Color ElectricBlue = new ("#7DF9FF");
    public static Color EmeraldGreen = new ("#50C878");
    public static Color FadedLavender = new ("#B59BC4");
    public static Color FandangoPink = new ("#F643A6");
    public static Color FernGreen = new ("#4F9A8D");
    public static Color FuchsiaPink = new ("#FF77FF");
    public static Color GoldenYellow = new ("#FFDF00");
    public static Color Grullo = new ("#A99A86");
    public static Color HoneydewGreen = new ("#F0FFF0");
    public static Color HotMagenta = new ("#FF1DCE");
    public static Color JellyBean = new ("#DA2C6D");
    public static Color Lemon = new ("#FFF700");
    public static Color LemonCurry = new ("#CCA300");
    public static Color LightAquamarine = new ("#7FFFD4");
    public static Color LightIndigo = new ("#8A2BE2");
    public static Color LightPeriwinkle = new ("#B3A7D6");
    public static Color LightPink = new ("#FFB6C1");
    public static Color LilacMist = new ("#B39EB5");
    public static Color MellowYellow = new ("#F8E47F");
    public static Color MistyMoss = new ("#B3C890");
    public static Color Mushroom = new ("#B7AFA3");
    public static Color NeapolitanPink = new ("#F1C6B8");
    public static Color NightShadz = new ("#30322F");
    public static Color OrchidPink = new ("#F2A7D7");
    public static Color PaleGoldenrod = new ("#EEE8AA");
    public static Color PaleSilver = new ("#C9C0BB");
    public static Color PaleTurquoise = new ("#AFEEEE");
    public static Color Peach = new ("#FFDAB9");
    public static Color Pear = new ("#D1E55C");
    public static Color PeriwinkleBlue = new ("#CCCCFF");
    public static Color Pineapple = new ("#563F27");
    public static Color PlumPurple = new ("#8E4585");
    public static Color PowderRose = new ("#E0B0FF");
    public static Color Razzmatazz = new ("#E3256B");
    public static Color RedViolet = new ("#C71585");
    public static Color RobinEggBlue = new ("#1F8A70");
    public static Color RubyRed = new ("#E0115F");
    public static Color Sage = new ("#9DC183");
    public static Color SalmonPink = new ("#FF91A4");
    public static Color SapphireBlue = new ("#0F52BA");
    public static Color SnowWhite = new ("#FFFAFA");
    public static Color SpicyPink = new ("#FF5C8D");
    public static Color SpringBud = new ("#A7FC00");
    public static Color SteelGray = new ("#464646");
    public static Color SweetBrown = new ("#8B6F47");
    public static Color TiffanyBlue = new ("#0ABAB5");
    public static Color Timberwolf = new ("#DBD3C8");
    public static Color TropicalRainForest = new ("#00755E");
    public static Color Tumbleweed = new ("#DEAA88");
    public static Color VioletRed = new ("#D02090");
    public static Color WisteriaPurple = new ("#9C6B92");
    public static Color Zaffre = new ("#0018A8");
    public static Color Transparent = new Color(0, 0, 0, 0);
    #endregion
}
