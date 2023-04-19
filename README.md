# S&box Floating Text

For damage numbers and whatnot

Video example: https://files.facepunch.com/crayz/1b1811b1/sbox_0080.mp4

![enter image description here](https://files.facepunch.com/crayz/1b1811b1/sbox-dev_wdjO0AvCVn.png)

## Install

Add `facepunch.floating_text` to your project packages:

![enter image description here](https://files.facepunch.com/crayz/1b1811b1/sbox-dev_RFkyPlDMgw.png)


## Usage

1. `FloatingText` is a panel that you can add to your hud.
2. Create an instance and call the `Create` method on it, pass it a world position.
3. Tweak it with the various methods.

```c#
public MyGame()
{
	if ( Game.IsClient )
	{
		Game.RootPanel = new Hud();
		Game.RootPanel.AddChild<FloatingText>();
	}
}
```

```c#
FloatingText.CreateNew()
        .WithPosition( cl.Pawn.Position + cl.Pawn.Rotation.Forward * 100f + Vector3.Random * 30f )
	.WithText( Game.Random.Next( 32, 1000 ).ToString() )
	.WithLifespan( 1f + Game.Random.NextSingle() )
	.WithFadeOut( .25f )
	.WithFadeIn( .25f )
	.WithMotion( Vector2.Up, Game.Random.Next(50, 100), Game.Random.NextSingle() * .5f, Game.Random.Next(0, 10) )
	.WithClass( "enemy-damage" )
	.WithScale( 0, 1.5f, 0.5f );
```

## Styling

You can style floating text color, shadow, or whatever, just by updating your stylesheet.  Use the `FloatingText` and `FloatingTextLabel` selectors:

```scss
FloatingTextLabel {
    color: gray;
    font-weight: heavy;
    text-stroke: 4px black;
    
    &.enemy-damage {
        color: red;
    }
}
```
