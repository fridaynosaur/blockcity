using UnityEngine;
using System.Collections;

namespace BlockCity {
		
	public class UIInputManager : MonoBehaviour
	{
	    public Core core;
	    public Visuals visuals;
	    private MouseInput mouseInput;
	    
	    void Awake()
	    {
	        if (core == null)
	            throw new MissingComponentException();

	        if (visuals == null)
	            throw new MissingComponentException();

	        mouseInput = GetComponentInChildren<MouseInput>();
	    }
	    
	    public void CreateBuildingAtMousePosition(string type)
	    {
			Vector3 gridPos = visuals.GetGridPositionFromMousePosition (mouseInput);

	        core.SendCommand(new AddBlockCommand(gridPos, Vector3.one, type));
	    }

		public void CreateRoadAtPosition(string type) {
			Vector3 gridPos = visuals.GetGridPositionFromMousePosition (mouseInput);

			core.SendCommand (new AddRoadCommand (gridPos, Vector3.one, type));
		}


	}
}