﻿using UnityEngine;
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
	            GetComponentInParent<UIInputManager>().CreateBuildingAtMousePosition(BuildingType.House);
	        }

	        if (Input.GetKeyDown(KeyCode.R))
	        {
				GetComponentInParent<UIInputManager>().CreateRoadAtPosition(RoadType.Default);
	        }

	        if (Input.GetKeyDown(KeyCode.E))
	        {
	            GetComponentInParent<UIInputManager>().CreateBuildingAtMousePosition(BuildingType.ElectricPlant);
	        }
	    }


	}
}