using UnityEngine;
using System.Collections;

namespace BlockCity {
	
	public class Block : MonoBehaviour
	{
	    private int id;
	    public Vector3 Position { get; private set; }
	    public Vector3 Size { get; private set; }

	    void Awake()
	    {
			// nah
	        //Debug.Log("Awake ");
	    }

		// Use this for initialization
		void Start ()
	    {
			Debug.Log("Created " + this + " id=" + this.id);
	    }
		
		// Update is called once per frame
		void Update ()
	    {
		}

		public void Init(int id, Vector3 position, Vector3 size)
	    {
	        this.id = id;
	        this.Position = position;
	        this.Size = size;
	    }
	}

}
