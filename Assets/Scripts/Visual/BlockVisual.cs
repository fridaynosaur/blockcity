using UnityEngine;
using System.Collections;
using System;
using BlockCity.Core;

namespace BlockCity.Visual 
{	
	public class BlockVisual : MonoBehaviour {
		public Block Block { get; set; }

		// Use this for initialization
		void Start () {
	        if (Block == null)
	            throw new MissingComponentException();

	        this.transform.localPosition = transformPosition(Block.Position);
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
}