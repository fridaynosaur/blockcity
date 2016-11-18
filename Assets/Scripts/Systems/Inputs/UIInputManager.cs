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
	        Vector3 gridPos = mouseInput.ReadTerrainPosition();

	        gridPos = visuals.GridVisual.GridCalc.GetGridPositionFromWorld(gridPos);

	        core.SendCommand(new AddBlockCommand(gridPos, Vector3.one, type));
	    }
	}
}