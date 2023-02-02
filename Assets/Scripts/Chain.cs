using System;
using UnityEngine;
using DG.Tweening;

public class Chain: MonoBehaviour {
	[SerializeField] private float _ringHeight = 250;
	[SerializeField] private float _slideDownTime = 0.5f;
	[SerializeField] private Transform _root;
	[SerializeField] private RingBuilder _builder;

	private Ring _current;
	private int _length;

	public event Action Breaked;
	public event Action RingPlaced;
	public event Action RingAdded;

	private void Start() {
		AddRing(silent: true);
	}

	public void Next() {
		if (_current.IsSelectorInArea()) {
			_current.Place();
			_length++;
			RingPlaced?.Invoke();
			AddRing();
		} else {
			_current.Break();
			Breaked?.Invoke();
		}
	}
	private void AddRing(bool silent = false) {
		transform.DOComplete();
		_current = _builder.InstantiateRandom(_root);
		if (silent) {
			return;
		}
		SlideAnimate();
		RingAdded?.Invoke();

		#region LocalMethods
		void SlideAnimate() {
			transform.DOLocalMoveY(transform.localPosition.y, _slideDownTime)
				.From(transform.localPosition.y + _ringHeight);
		}
		# endregion LocalMethods
	}
	public void Restore() {
		for (int index = 0; index < _root.childCount; index++) {
			Destroy(_root.GetChild(index));
		}
	}
	public int GetLength() => _length;
}
