using Godot;
using System;

public partial class SingleShot : Weapon
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_projectile = GD.Load<PackedScene>(@"res://Scenes/Projectiles/bullet.tscn");
		FireRate = 5;
		base._Ready();
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void Fire()
    {
		// TODO Object pool for all projectiles
		var projectile = _projectile.Instantiate<Area2D>();
		projectile.Transform = _mount.GlobalTransform;
		
		_player.Owner.AddChild(projectile);
    }
}
