using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public int Speed { get; set; } = 400;

    public Vector2 ScreenSize;
	public PackedScene PrimaryWeapon;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		EquipWeapon();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;

		if (Input.IsActionPressed("move_right"))
			velocity.X += 1;

		if (Input.IsActionPressed("move_left"))
			velocity.X -= 1;

		if (Input.IsActionPressed("move_up"))
			velocity.Y -= 1;

		if (Input.IsActionPressed("move_down"))
			velocity.Y += 1;

		var thrusterSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			var scale = thrusterSprite.Scale;
			scale.Y = 1.5f;
			thrusterSprite.Scale = scale;
        }
		else
		{
            var scale = thrusterSprite.Scale;
            scale.Y = 1f;
            thrusterSprite.Scale = scale;
        }

        Position += velocity * (float)delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0 + 24, ScreenSize.X - 24),
			y: Mathf.Clamp(Position.Y, 0 + 24, ScreenSize.Y - 24)
		);
    }

	private void EquipWeapon()
	{
		PrimaryWeapon = GD.Load<PackedScene>("res://Scenes/Weapons/single_shot.tscn");
		AddChild(PrimaryWeapon.Instantiate());
	}
}
