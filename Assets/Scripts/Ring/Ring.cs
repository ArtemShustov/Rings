using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Ring: MonoBehaviour {
	[Range(-1, 1)]
	[SerializeField] private float _rotation = 0.5f;
	[Range(0, 1)]
	[SerializeField] private float _areaFill = 0.2f;
	[Space]
	[SerializeField] private RectTransform _rectTransform;
	[SerializeField] private Image _area;

	public void Init(float rotation, float areaFill) {
		_rotation = rotation;
		_areaFill = areaFill;
		_area.fillAmount = _areaFill;
		_rectTransform.localEulerAngles = Vector3.forward * Random.Range(0, 360);
	}

	private void Update() {
		var angles = _rectTransform.localEulerAngles;
		angles.z += 360 * _rotation * Time.deltaTime;
		_rectTransform.localEulerAngles = angles;
	}

	public bool IsPointerInArea() {
		float ringAngle = _rectTransform.localEulerAngles.z;
		float areaEndAngle = 360 * _areaFill;
		return ringAngle >= 0 && ringAngle <= areaEndAngle;
	}
	public void Break() {
		_area.DOColor(Color.red, 1);
		_area.DOFillAmount(1, 1 * (1 - _area.fillAmount));
		_rotation = 0;
	}
	public void Place() {
		_area.DOColor(Color.green, 1);
		_area.DOFillAmount(1,  (1 - _area.fillAmount));
		_rotation = 0;
	}
	
	private void OnValidate() {
		if (_area) {
			_area.fillAmount = _areaFill;
		}
	}
}