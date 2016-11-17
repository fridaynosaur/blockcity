using UnityEngine;


public class GridCalculator
{
    public int Scale { get; private set; }
    private int offset;
    private float scaleHalf;

    public GridCalculator(int scale, int offset)
    {
        Scale = scale;
        scaleHalf = scale * 0.5f;

        this.offset = offset;
    }

	public Vector3 GetGridPositionFromWorld(Vector3 worldPosition)
    {
        return new Vector3(Mathf.CeilToInt((worldPosition.x - scaleHalf) / Scale) + offset, 0f, Mathf.CeilToInt((worldPosition.z - scaleHalf) / Scale) + offset);
    }

    public Vector3 GetWorldPositionFromGrid(int x, int y)
    {
        return new Vector3((x - offset) * Scale - scaleHalf, 0f, (y - offset) * Scale - scaleHalf);
    }

    public Vector3 GetWorldPositionFromGrid(Vector3 pos)
    {
        return GetWorldPositionFromGrid((int)pos.x, (int)pos.z);
    }
}
