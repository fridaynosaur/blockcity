using UnityEngine;
using System.Collections;

public class UIInputManager : MonoBehaviour
{
    public Core core;
    private MouseInput mouseInput;
    
    void Awake()
    {
        if (core == null)
            throw new MissingComponentException();

        mouseInput = GetComponentInChildren<MouseInput>();
    }

    public void CreateBuildingOfRandomSize()
    {
        core.SendCommand(new AddBlockCommand(Vector3.zero, Vector3.one));
    }

    public void CreateBuildingAtMousePosition()
    {
        Vector3 gridPos = mouseInput.ReadTerrainPosition() / 25f;

        core.SendCommand(new AddBlockCommand(gridPos, Vector3.one));
    }
}
