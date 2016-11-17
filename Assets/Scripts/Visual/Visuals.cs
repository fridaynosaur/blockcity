using UnityEngine;
using System.Collections;
using BlockCity.Core;

public class Visuals : MonoBehaviour
{
    public Transform blocksParent;
    public GridVisual GridVisual { get; private set; }
    public Core core;

    void Awake()
    {
        GridVisual = GetComponentInChildren<GridVisual>();

        if (GridVisual == null)
        {
            throw new MissingComponentException();
        }

        if (core == null)
        {
            throw new MissingComponentException();
        }
    }

    public void AddBlock(Block block)
    {
        block.transform.parent = blocksParent;
        block.transform.localPosition = GridVisual.GridCalc.GetWorldPositionFromGrid(block.Position);
    }

}
