
using Sandbox;
using Sandbox.UI;
using System;

public class FloatingTextLabel : Panel
{

    public Vector3 WorldPosition { get; set; }

    Label label;
    int textSize = 15;
    float lifespan = 1f;
    float fadeInTime = 0f;
    float fadeOutTime = 0f;
    TimeSince timeSinceCreated = 0;

    Vector2 animationOffset;
    Vector2 animationDirection;
    float animationSpeed;
    float animationCurveAmplitude;
    float animationCurveFrequency;

    float startScale = 1.0f;
    float middleScale = 1.0f;
    float endScale = 1.0f;

    public override void Tick()
    {
        base.Tick();

        if(timeSinceCreated > lifespan)
        {
            Delete();
            return;
        }

        animationOffset += animationDirection * animationSpeed * Time.Delta;

        if (MathF.Abs(animationCurveAmplitude) > float.Epsilon)
        {
            float curveValue = animationCurveAmplitude * MathF.Sin(timeSinceCreated * animationCurveFrequency);
            Vector2 curveDirection = new Vector2(-animationDirection.y, animationDirection.x);
            animationOffset += curveDirection * curveValue;
        }

        var halfLife = lifespan / 2.0f;
        var scale = 1.0f;
        if (timeSinceCreated < halfLife)
        {
            var t = timeSinceCreated / halfLife;
            scale = startScale.LerpTo(middleScale, t);
        }
        else
        {
            var t = (timeSinceCreated - halfLife) / halfLife;
            scale = middleScale.LerpTo(endScale, t);
        }

        Style.FontSize = textSize * scale;

        var screenpos = WorldPosition.ToScreen();
        screenpos.x *= Screen.Width * ScaleFromScreen;
        screenpos.y *= Screen.Height * ScaleFromScreen;
        screenpos += (Vector3)animationOffset;

        Style.Left = screenpos.x;
        Style.Top = screenpos.y;

        if ( timeSinceCreated < fadeInTime )
        {
            var a = timeSinceCreated / fadeInTime;
            Style.Opacity = a;
        }

        if( timeSinceCreated > lifespan - fadeOutTime )
        {
            var a = ( lifespan - timeSinceCreated ) / fadeInTime;
            Style.Opacity = a;
        }
    }

    public FloatingTextLabel WithText(string text, int size = 15)
    {
        label ??= AddChild<Label>();
        label.Text = text;
        textSize = size;
        return this;
    }

    public FloatingTextLabel WithLifespan(float lifespan)
    {
        this.lifespan = lifespan;

        return this;
    }

    public FloatingTextLabel WithFadeOut( float duration )
    {
        fadeOutTime = duration;
        return this;
    }

    public FloatingTextLabel WithFadeIn( float duration )
    {
        fadeInTime = duration;
        return this;
    }

    public FloatingTextLabel WithMotion(Vector2 direction, float speed = 100.0f, float curveAmplitude = 0.15f, float curveFrequency = 4.0f)
    {
        animationDirection = direction.WithY( -direction.y );
        animationSpeed = speed;
        animationCurveAmplitude = curveAmplitude;
        animationCurveFrequency = curveFrequency;
        return this;
    }

    public FloatingTextLabel WithScale(float startScale = 1.0f, float middleScale = 1.0f, float endScale = 1.0f)
    {
        this.startScale = startScale;
        this.middleScale = middleScale;
        this.endScale = endScale;
        return this;
    }

}
