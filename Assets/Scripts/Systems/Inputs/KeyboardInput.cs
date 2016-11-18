using UnityEngine;
using System.Collections;

namespace BlockCity {
		
	public class KeyboardInput : MonoBehaviour
	{
	    

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update ()
	    {
		
	        if (Input.GetKeyDown(KeyCode.B))
	        {
	            GetComponentInParent<UIInputManager>().CreateBuildingAtMousePosition(BuildingTypes.House);
	        }

	        if (Input.GetKeyDown(KeyCode.R))
	        {
				GetComponentInParent<UIInputManager>().CreateBuildingAtMousePosition(BuildingTypes.Interconnect);
	        }

	        if (Input.GetKeyDown(KeyCode.E))
	        {
	            GetComponentInParent<UIInputManager>().CreateBuildingAtMousePosition(BuildingTypes.ElectricPlant);
	        }
	    }


	}
}