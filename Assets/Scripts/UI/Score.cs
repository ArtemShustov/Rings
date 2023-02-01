using TMPro;
using UnityEngine;

namespace Game.UI {
	public class Score: MonoBehaviour {
		[SerializeField] private string _pattern = "Score: {0}";
		[SerializeField] private TMP_Text _label;
		[SerializeField] private Chain _chain;

		private int _points = 0;

		private void AddScorePoint() {
			_points++;
			UpdateUI();
		}
		private void UpdateUI() {
			_label.text = string.Format(_pattern, _points);
		}

		private void OnEnable() {
			_chain.RingAdded += AddScorePoint;
		}
		private void OnDisable() {
			_chain.RingAdded -= AddScorePoint;
		}
	}
}