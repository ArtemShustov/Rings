using TMPro;
using UnityEngine;

namespace Game.UI {
	public class ScoreLabel: MonoBehaviour {
		[SerializeField] private string _pattern = "Score: {0}";
		[SerializeField] private TMP_Text _label;
		[SerializeField] private ScoreCounter _counter;

		private void UpdateUI(int score) {
			_label.text = string.Format(_pattern, score);
		}
		public void Restore() {
			UpdateUI(0);
		}

		private void OnEnable() {
			_counter.ScoreUpdated += UpdateUI;
		}
		private void OnDisable() {
			_counter.ScoreUpdated -= UpdateUI;
		}
	}
}