using System.Threading.Tasks;
using UnityEngine;

namespace Game.UI.PanelSystem {
	public abstract class Panel: MonoBehaviour {
		public abstract Task HideAsync();
		public abstract Task ShowAsync();
	}
}