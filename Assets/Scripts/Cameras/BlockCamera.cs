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

    private float minRotation = 2f; //(float)Math.PI * 2f / 180f;
    private float maxRotation = 80f; //(float)Math.PI * 80f / 180f;

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
        transform.RotateAround(curMousePlanePos, Vector3.up, Time.deltaTime * Input.GetAxis("Mouse X") * RotateSpeed);
        

        var below = transform.localPosition;
        below.y = 0;

        var v1 = transform.localPosition - curMousePlanePos;
        var v2 = below - curMousePlanePos;

        var perp = Vector3.Cross(v1, v2);

        var rotation = Time.deltaTime * Input.GetAxis("Mouse Y") * RotateSpeed;

        Debug.Log(transform.localRotation.eulerAngles.x + "::" + rotation);

        /*if (transform.eulerAngles.x < minRotation && rotation > 0)
        {
            rotation = 0;
        }
        else if (transform.eulerAngles.x > maxRotation && rotation < 0)
        {
            rotation = 0;
        }*/
        
        transform.RotateAround(curMousePlanePos, perp, rotation);
        
        if (transform.eulerAngles.x < minRotation)
        {
            var r = transform.eulerAngles;
            r.x = minRotation;
            transform.eulerAngles = r;
        }
        else if (transform.localRotation.eulerAngles.x > maxRotation && rotation < 0)
        {
            var r = transform.eulerAngles;
            r.x = maxRotation;
            transform.eulerAngles = r;
        }


        if (Input.GetMouseButtonUp(1))
        {
            ChangeState(State.None);
        }
    }

    private void Zooming()
    {
        transform.Translate(Vector3.forward * (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * ZoomSpeed));
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
