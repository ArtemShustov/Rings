using UnityEngine;

namespace Game.UI.PanelSystem {
	public class PanelSwitcher: MonoBehaviour {
		[SerializeField] private Panel _game;
		[SerializeField] private Panel _lose;
		[SerializeField] private Panel _start;

		private Panel _current;

		private void Update() {
			if (Input.GetKeyDown(KeyCode.L)) {
				ShowGamePanel();
			}
		}

		public async void Switch(Panel panel) {
			if (_current) {
				await _current.HideAsync();
			}
			_current = panel;
			if (_current) {
				await _current.ShowAsync();
			}
		}
		public void HideAll() => Switch(null);
		public void ShowGamePanel() => Switch(_game);
		public void ShowLosePanel() => Switch(_lose);
		public void ShowStartPanel() => Switch(_start);
	}
}