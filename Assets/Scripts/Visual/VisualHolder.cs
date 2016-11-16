using UnityEngine;
using System.Collections;

public class VisualHolder : MonoBehaviour
{
    public Transform blocksParent;

    public void AddBlock(GameObject block)
    {
        block.transform.parent = blocksParent;
    }

}
