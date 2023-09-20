using Godot;
using System;

public partial class Enemy01 : Area2D
{
	public int Speed = 100;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        Position += Vector2.Down * Speed * (float)delta;
    }
}
