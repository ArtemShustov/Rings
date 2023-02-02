using UnityEngine;
using UnityEngine.UI;

public class Ring: MonoBehaviour {
	[Range(-1, 1)]
	[SerializeField] private float _rotation = 0.5f;
	[Range(0, 1)]
	[SerializeField] private float _areaFill = 0.2f;
	[Space]
	[SerializeField] private Image _area;
	[SerializeField] private RingAnimations _animations;

	public RingAnimations Animations => _animations;

	public void Init(float rotation, float areaFill) {
		_rotation = rotation;
		_areaFill = areaFill;
		_area.fillAmount = _areaFill;
		transform.localEulerAngles = Vector3.forward * Random.Range(0, 360);
		_animations.Pop();
	}

	private void Update() {
		var angles = transform.localEulerAngles;
		angles.z += 360 * _rotation * Time.deltaTime;
		transform.localEulerAngles = angles;
	}

	public bool IsSelectorInArea() {
		float ringAngle = transform.localEulerAngles.z;
		float areaEndAngle = 360 * _areaFill;
		return ringAngle >= 0 && ringAngle <= areaEndAngle;
	}
	public void Break() {
		_animations.Break();
		_rotation = 0;
	}
	public void Place() {
		_animations.Place();
		_rotation = 0;
	}
	
	private void OnValidate() {
		if (_area) {
			_area.fillAmount = _areaFill;
		}
	}
}