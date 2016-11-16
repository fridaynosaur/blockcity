using UnityEngine;
using System.Collections.Generic;
using System;

public class BlockCamera : MonoBehaviour
{
    public enum State
    {
        None        = 0,
        Moving      = 1,
        Rotating    = 2
    }

    public State CurrentState { get; private set; }

    public float RotateSpeed = 100f;
    public float ZoomSpeed = 100f;

    private const float minRotation = 2f;
    private const float maxRotation = 80f;
    private const float minDistance = 5f;

    private Dictionary<State, Action> stateActions;
    private Action StateUpdate;

    private Vector3 prevMousePlanePos;
    private Vector3 curMousePlanePos;


    void Awake()
    {
        CurrentState = State.None;
        StateUpdate = None;

        stateActions = new Dictionary<State, Action>()
        {
            { State.None,       None },
            { State.Moving,     Moving },
            { State.Rotating,   Rotating }
        };
    }
    
	void Update ()
    {
        StateUpdate();

        Zooming();
    }

    private void ChangeState(State state)
    {
        if (state == CurrentState)
        {
            return;
        }

        CurrentState = state;
        StateUpdate = stateActions[state];
    }

    private void None()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeState(State.Moving);

            prevMousePlanePos = GetMousePositionOnPlane();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ChangeState(State.Rotating);

            curMousePlanePos = GetCenterPointOnPlane();
        }
    }

    private void Moving()
    {
        curMousePlanePos = GetMousePositionOnPlane();

        var diff = prevMousePlanePos - curMousePlanePos;

        diff.y = 0f;
        diff *= 0.9f;
        
        transform.localPosition += diff;
        
        prevMousePlanePos = curMousePlanePos + diff;

        if (Input.GetMouseButtonUp(0))
        {
            ChangeState(State.None);
        }
    }

    private void Rotating()
    {
        // Rotate left-right
        transform.RotateAround(curMousePlanePos, Vector3.up, Time.deltaTime * Input.GetAxis("Mouse X") * RotateSpeed);
        
        // Rotate up-down
        var below = transform.localPosition;
        below.y = 0;

        var v1 = transform.localPosition - curMousePlanePos;
        var v2 = below - curMousePlanePos;

        var perp = Vector3.Cross(v1, v2);

        var rotation = Time.deltaTime * Input.GetAxis("Mouse Y") * RotateSpeed;
        
        // FIX THIS!
        if (transform.eulerAngles.x + rotation < minRotation)
        {
            rotation = transform.eulerAngles.x - minRotation;
            /*var r = transform.eulerAngles;
            r.x = minRotation;
            transform.eulerAngles = r;*/
        }
        else if (transform.eulerAngles.x - rotation > maxRotation)
        {
            rotation = transform.eulerAngles.x - maxRotation;
            /*var r = transform.eulerAngles;
            r.x = maxRotation;
            transform.eulerAngles = r;*/
        }

        transform.RotateAround(curMousePlanePos, perp, rotation);

        if (Input.GetMouseButtonUp(1))
        {
            ChangeState(State.None);
        }
    }

    private void Zooming()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            transform.Translate(Vector3.forward * scroll * Time.deltaTime * ZoomSpeed);

            var plane = new Plane(Vector3.up, Vector3.zero);

            var ray = new Ray(Camera.main.transform.localPosition, Camera.main.transform.forward);

            float distance;
            if (plane.Raycast(ray, out distance))
            {
                if (distance <= minDistance)
                {
                    transform.Translate(Vector3.back * (minDistance - distance));
                }
            }
        }
    }

    private Vector3 GetMousePositionOnPlane()
    {
        var plane = new Plane(Vector3.up, Vector3.zero);

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance;
        if (plane.Raycast(ray, out distance))
        {
            var hitPoint = ray.GetPoint(distance);

            Debug.DrawRay(hitPoint, Vector3.up * 1000);

            return hitPoint;
        }
        else
        {
            return Vector3.zero;
        }
    }

    private Vector3 GetCenterPointOnPlane()
    {
        var plane = new Plane(Vector3.up, Vector3.zero);

        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f));

        float distance;
        if (plane.Raycast(ray, out distance))
        {
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
