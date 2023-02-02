using UnityEngine;

[CreateAssetMenu]
public class RingBuilder: ScriptableObject {
	[SerializeField] private AnimationCurve _rotation;
	[SerializeField] private AnimationCurve _fillAmount;
	[Space]
	[SerializeField] private Ring _prefab;

	public Ring Instantiate(Transform root, float rotation, float fill) {
		var ring = GameObject.Instantiate(_prefab, root);
		ring.Init(rotation, fill);
		return ring;
	}
	public Ring InstantiateRandom(Transform root) {
		var rotation = GetRandomFromCurve(_rotation, -1, 1);
		var fill = GetRandomFromCurve(_fillAmount, 0, 1);
		return Instantiate(root, rotation, fill);

		float GetRandomFromCurve(AnimationCurve curve, float minTime, float maxTime) {
			var time = Random.Range(minTime, maxTime);
			return curve.Evaluate(time);
		}
	}
}
