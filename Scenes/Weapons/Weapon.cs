using Godot;
using System;

public partial class Weapon : Node
{
	[Export]
	public int FireRate { get; set; } = 5;

	public double UpdateDelta;
	public double CurrentTime = 0f;

	public PackedScene _projectile { get; set; }
	public Area2D _player { get; set; }
	public Marker2D _mount { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetParent<Area2D>();
		_mount = _player.GetNode<Marker2D>("WeaponMount");

		UpdateDelta = 1f / FireRate;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CurrentTime += delta;
		if (CurrentTime < UpdateDelta)
			return;

        if (Input.IsActionPressed("primary_fire"))
		{
			CurrentTime = 0;
			Fire();
		}
	}

	public virtual void Fire()
	{

	}
}
