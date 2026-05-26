using System;
using Microsoft.Xna.Framework;

namespace MonoGameLibrary.Graphics;

public class AnimatedSprite : Sprite
{
    private int _currentFrame;
    private TimeSpan _elapsed;
    private Animation _animation;

    public float timeScale {get; set;} = 1.0f;

    public Animation Animation
    {
        get => _animation;
        set
        {
            _animation = value;
            Region = _animation.Frames[0];
        }
    }

    public AnimatedSprite() {}

    public AnimatedSprite(Animation animation)
    {
        Animation = animation;
    }

    public void Update(GameTime gameTime)
    {
        _elapsed += gameTime.ElapsedGameTime;
        if (_elapsed >= _animation.Delay / timeScale)
        {
            _elapsed -= _animation.Delay / timeScale;
            _currentFrame++;

            if (_currentFrame >= _animation.Frames.Count)
            {
                _currentFrame = 0;
            }

            Region = _animation.Frames[_currentFrame];
        }
    }
}