using UnityEngine;
using System.Collections;

public class ElectricPlantVisual : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        var model = Resources.Load("Prefabs/Buildings/ElectricPlantPrefab");
        var go = Instantiate(model) as GameObject;
        go.transform.parent = transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
