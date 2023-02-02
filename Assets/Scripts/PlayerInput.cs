using UnityEngine;

public class PlayerInput: MonoBehaviour {
	[SerializeField] private Chain _chain;

	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			_chain.Next();
		}
	}
}
