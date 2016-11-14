using UnityEngine;
using System.Collections;

public class UIInputManager : MonoBehaviour
{
    private Core core;

    void Awake()
    {
        core = GetComponent<Core>();
    }

    public void CreateBuildingOfRandomSize()
    {
        core.SendCommand(new AddBlockCommand(Vector3.zero, Vector3.one));
    }
}
