using UnityEngine;
using System.Collections;
using BlockCity.Core;

public class GridVisual : MonoBehaviour
{
    public GridCalculator GridCalc { get; private set; }
    public Grid2d Grid { get; private set; }

    public Visuals visuals;

    public const int SCALE = 25;


    void Awake()
    {
        if (visuals == null)
        {
            throw new MissingComponentException();
        }
    }

    void Start()
    {
        int gridHalfSize = visuals.core.Grid.Size / 2;

        GridCalc = new GridCalculator(SCALE, gridHalfSize);
    }
}
