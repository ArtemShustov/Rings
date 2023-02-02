using System;
using UnityEngine;

public class ScoreCounter: MonoBehaviour {
	[SerializeField] private Chain _chain;

	public int Points { get; private set; }

	public event Action<int> ScoreUpdated;

	private void AddScorePoint() {
		Points++;
		ScoreUpdated?.Invoke(Points);
	}

	private void OnEnable() {
		_chain.RingAdded += AddScorePoint;
	}
	private void OnDisable() {
		_chain.RingAdded -= AddScorePoint;
	}
}