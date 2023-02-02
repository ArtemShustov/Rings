using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RingAnimations: MonoBehaviour {
	[SerializeField] private float _popDuration = 0.5f;
	[SerializeField] private float _popScale = 0.3f;
	[Space]
	[SerializeField] private Image _area;

	public void Pop() {
		transform.DOPunchScale(Vector3.one * _popScale, _popDuration, 0);
	}
	public void Break() {
		_area.DOColor(Color.red, 1);
		_area.DOFillAmount(1, 1 * (1 - _area.fillAmount));
	}
	public void Place() {
		_area.DOColor(Color.green, 1);
		_area.DOFillAmount(1, (1 - _area.fillAmount));
	}
}