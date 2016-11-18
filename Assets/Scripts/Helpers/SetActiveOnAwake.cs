using UnityEngine;
using System.Collections;

public class SetActiveOnAwake : MonoBehaviour {

    public bool isActive;

    void Awake()
    {
        gameObject.SetActive(isActive);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
