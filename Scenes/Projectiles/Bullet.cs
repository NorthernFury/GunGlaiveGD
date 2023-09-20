using Godot;
using System;

public partial class Bullet : Area2D
{
	[Export]
	public int Speed { get; set; } = 600;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        Position += Vector2.Up * Speed * (float)delta;
    }

	private void OnVisibleOnScreenNotifier2DScreenExited()
	{
		QueueFree();
	}
}
