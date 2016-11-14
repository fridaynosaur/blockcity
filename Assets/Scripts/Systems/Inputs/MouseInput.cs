using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour
{



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Vector3 mousePos = ReadTerrainPosition();
        ReadTerrainPosition();
    }

    public Vector3 ReadTerrainPosition()
    {
        // this creates a horizontal plane passing through this object's center
        var plane = new Plane(Vector3.up, transform.position);

        // create a ray from the mousePosition
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // plane.Raycast returns the distance from the ray start to the hit point
        float distance;
        
        if (plane.Raycast(ray, out distance))
        {
            // some point of the plane was hit - get its coordinates
            var hitPoint = ray.GetPoint(distance);

            Debug.DrawRay(hitPoint, Vector3.up * 1000);

            return hitPoint;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
