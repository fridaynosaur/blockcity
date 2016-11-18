using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour
{
    public string item;
    public int rate;
    public int interval;

    private float lastUpdateTime;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	void Update ()
    {
	    if (Time.time - lastUpdateTime > interval)
        {
            lastUpdateTime = Time.time;
        }
	}

    private void Generate()
    {
        Debug.Log("Generator:: Generate: " + item + " rate: " + rate);
    }
    
}
