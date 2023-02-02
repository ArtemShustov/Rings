using System.Threading.Tasks;
using UnityEngine;

namespace Game.UI.PanelSystem.Variants {
	public class GamePanel: Panel {
		[SerializeField] private ScoreLabel _score;

		public async override Task HideAsync() {
			gameObject.SetActive(false);
			await Task.Delay(3000);
		}
		public override Task ShowAsync() {
			gameObject.SetActive(true);
			_score.Restore();
			return null;
		}
	}
}