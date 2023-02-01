using System;
using UnityEngine;

[Serializable]
public class RingBuilder {
	[SerializeField] private AnimationCurve _rotation;
	[SerializeField] private AnimationCurve _fillAmount;
	[Space]
	[SerializeField] private Ring _prefab;

	public Ring InstantiateRandom(Transform root) {
		var rotation = GetRandomFromCurve(_rotation, -1, 1);
		var fill = GetRandomFromCurve(_fillAmount, -1, 1);
		var ring = GameObject.Instantiate(_prefab, root);
		ring.Init(rotation, fill);
		return ring;

		float GetRandomFromCurve(AnimationCurve curve, float minTime, float maxTime) {
			var time = UnityEngine.Random.Range(minTime, maxTime);
			return curve.Evaluate(time);
		}
	}
}
