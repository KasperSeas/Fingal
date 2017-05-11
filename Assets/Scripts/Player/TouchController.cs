using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AxisType { Horizontal, Vertical };
public enum ButtonType { Button, Touch };
public enum InputType { HandTrigger, IndexTrigger, ThumbRest, A, B, X, Y, ThumbStick };

[RequireComponent (typeof(SphereCollider))]
public class TouchController : MonoBehaviour {

    public OVRInput.Controller Controller;
    public float IndexTriggerAxis;
    public bool grabbing;

    private Material Mat;
    private Color Invisible;
    private Color Visible;
    private SphereCollider GrabCollider;

    private void Awake() {
        grabbing = false;

        GrabCollider = GetComponent<SphereCollider>();
        GrabCollider.radius = 1f;

        Mat = GetComponent<Renderer>().material;
        Visible = Mat.GetColor("_TintColor");
        Invisible = new Color(0,0,0,0);

    }

    void Update () {
        UpdatePosition();
	}

    private void UpdatePosition() {
        transform.localPosition = OVRInput.GetLocalControllerPosition(Controller);
        transform.localRotation = OVRInput.GetLocalControllerRotation(Controller);
    }
    

    public float Axis1D(InputType input) {
        return Input.GetAxis("Axis1D." + input.ToString() + Controller.ToString());
    }

    public float Axis2D(InputType input, AxisType type) {
        return Input.GetAxis("Axis2D." + input.ToString() + Controller.ToString() + "." + type.ToString());
    }

    public bool Button(InputType input, ButtonType type) {
        return Input.GetButton(type.ToString()+"."+input.ToString()+"."+Controller.ToString());
    }

    public void Grab() {
        ExpandCollider(1.5f);
        grabbing = true;
        Mat.SetColor("_TintColor", Invisible);
    }

    public void Drop() {
        ExpandCollider(1f);
        grabbing = false;
        Mat.SetColor("_TintColor", Visible);
    }

    private void ExpandCollider(float radius) {
        GrabCollider.radius = radius;
    }

}
