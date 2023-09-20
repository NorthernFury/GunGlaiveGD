using Godot;
using System;

public partial class EnemyController : Node2D
{
	[Export]
	public int EnemiesPerWave { get; set; } = 10;
	[Export]
	public int WaveInterval { get; set; } = 1;
	[Export]
	public PackedScene Enemy { get; set; }

	private int _enemiesRemaining;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnStartTimerTimeout()
	{
        _enemiesRemaining = EnemiesPerWave;

        var timer = GetNode<Timer>("SpawnTimer");
		timer.WaitTime = WaveInterval;
		timer.Start();
	}

	private void OnSpawnTimerTimeout()
	{
        var rng = new RandomNumberGenerator();
		var enemy = Enemy.Instantiate<Area2D>();

		enemy.GlobalPosition = new Vector2(rng.RandiRange(24, Mathf.RoundToInt(GetViewportRect().Size.X - 24)), -48);
		AddChild(enemy);

		_enemiesRemaining--;

		if (_enemiesRemaining < 1)
		{
            var timer = GetNode<Timer>("SpawnTimer");
            timer.Stop();
        }
    }
}
