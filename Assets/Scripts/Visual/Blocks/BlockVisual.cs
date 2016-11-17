using UnityEngine;
using System.Collections;
using System;
using BlockCity.Core;

namespace BlockCity.Visual 
{	
	public class BlockVisual : MonoBehaviour
    {
		public Block Block { get; set; }

        void Start()
        {
            if (Block == null)
                throw new MissingComponentException();
        }

        /*void Start ()
        {
	        transform.localPosition = TransformPosition(Block.Position);
		}

	    private Vector3 TransformPosition(Vector3 position)
	    {
	        position.Scale(new Vector3(25f, 25f, 25f));

	        return position;
	    }

	    // Update is called once per frame
	    void Update () {
		
		}*/

	}
}