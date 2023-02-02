using UnityEngine;

namespace Game.Stats {
	public class ScoreSaver: MonoBehaviour {
		[SerializeField] private string _lastScoreKey = "lastScore";
		[SerializeField] private string _bestScoreKey = "bestScore";
		[SerializeField] private ScoreCounter _counter;

		public void Save() {
			var currentScore = _counter.Points;
			PlayerPrefs.SetInt(_lastScoreKey, currentScore);
			var bestScore = PlayerPrefs.GetInt(_bestScoreKey, 0);
			if (bestScore < currentScore) {
				PlayerPrefs.SetInt(_bestScoreKey, currentScore);
			}
		}
	}
}