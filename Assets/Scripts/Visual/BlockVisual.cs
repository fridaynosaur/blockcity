using UnityEngine;
using System.Collections;
using System;

public class BlockVisual : MonoBehaviour
{
    public Block block { get; set; }

	// Use this for initialization
	void Start () {
        if (block == null)
            throw new MissingComponentException();

        this.transform.localPosition = transformPosition(block.Position);
	}

    private Vector3 transformPosition(Vector3 position)
    {
        position.Scale(new Vector3(25f, 25f, 25f));

        return position;
    }

    // Update is called once per frame
    void Update () {
	
	}





}
