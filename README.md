# 2D Game Engine - Powered by SFML.NET

This is a lightweight, high-performance 2D game engine built using **SFML.NET**, inspired by **MonoGame**. The engine provides a simple yet flexible framework for creating 2D games, leveraging the power of SFML for rendering, input handling, audio, and more. Whether you're a hobbyist or a seasoned game developer, this engine offers the tools you need to create your next 2D project with ease.

## Features:
- **SFML.NET Integration**: Harness the power of the SFML library with .NET bindings for seamless rendering, window management, input handling, and more.
- **MonoGame-Inspired Architecture**: Built with a similar structure to MonoGame, making it easy for developers familiar with MonoGame to get started quickly.
- **Cross-Platform**: Supports Windows, macOS, and Linux, ensuring your games can run on multiple platforms.
- **Easy-to-Use API**: Focuses on simplicity, providing a clean and intuitive API for developers of all levels.
- **Extensible**: Easily extendable to add new features or modify existing ones to suit your specific needs.
- **SpriteSheet**: Easily animate spritesheets.
- **Animator**: Easily animate animations or 2D spritesheets.

## MonoGame Features
- **GraphicsDevice/GraphicsDeviceManager**
- **ContentManager**
- **SpriteBatch**: The sprite batch has extensions, DrawLine, DrawTextureShadow, DrawTextShadow, CreateRectangle, CreateRoundedRectangle, and DrawGradient. Methods
- **SpriteFont**
- **Song/SoundEffect**
- **Shader**: SFML.NET Shaders has a custom class called Effects from monogame. This class Takes 3 parameters, (shaderPath, geometryPath, fragmentPath).
- **SceneSystem/Scene/SceneObjects**
- **InputSystem**: The input system utilizes the SFML.NET input system. But recreated to make it simular to **MonoGame**

## Custom UI Controls.
- **Button**
- **TextBox**
- **Label**
- **Timer**
- **Custom**: By inheriting the **Control** you can make your own. All handles are overridable.

## Requirements:
- .NET 9.0 or higher
- SFML.NET (requires SFML native libraries) or SFML.NET nuget package.
