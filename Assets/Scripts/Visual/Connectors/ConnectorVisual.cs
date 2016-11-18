using UnityEngine;
using System.Collections;
using BlockCity;

namespace BlockCity.Visual {
	public class ConnectorVisual : MonoBehaviour {
		public const string PREFAB_PATH = "Prefabs/";
		public const string PREFAB_SUFFIX = "Prefab";

		public Block Block { get; set; }
		public string PrefabName { get; set; }

		void Start()
		{
			if (Block == null)
				throw new MissingComponentException();

			if (PrefabName == null)
			{
				throw new MissingComponentException();
			}

			LoadPrefab(PrefabName);
		}

		protected void LoadPrefab(string name)
		{
			var model = Resources.Load(PREFAB_PATH + name + PREFAB_SUFFIX);

			var go = Instantiate(model) as GameObject;

			go.transform.parent = transform;
			go.transform.localPosition = Vector3.zero;
			go.transform.localScale = Vector3.one;
		}
	}
}