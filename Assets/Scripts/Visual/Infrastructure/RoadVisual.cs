using UnityEngine;
using System.Collections;
using BlockCity;

namespace BlockCity.Visual {
	public class RoadVisual : MonoBehaviour {
		public const string PREFAB_PATH = "Prefabs/";
		public const string PREFAB_SUFFIX = "Prefab";

		public Road Road { get; set; }
		public string PrefabName { get; set; }
		public Mesh Mesh { get; set; }

		void Start()
		{
			if (Road == null)
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

			if (Mesh != null) {
				MeshFilter meshFilter = go.GetComponentInChildren<MeshFilter> ();
				meshFilter.mesh = Mesh;
			}

		}
	}
}