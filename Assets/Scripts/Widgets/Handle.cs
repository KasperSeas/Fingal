using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour {

    
    public float Value;
    public ScreenModule module; // TODO: Inheritance from Module Object
    public ScreenModule.Widget widget;

    private TouchController CurrentController;
    private Material Mat;
    private float XLock;
    private float ZLock;
    private float Length;
    private float Max;
    private float Min;

    // Colors
    private Color DefaultColor;
    private Color EnterColor;
    private Color ActionColor;

    private void Awake() {
        Value = 0f;
        if (transform.parent.parent.GetComponent<ScreenModule>() != null) {
            module = transform.parent.parent.GetComponent<ScreenModule>();
        }

        // Colors Init
        DefaultColor = new Color(0, 0, 1);
        EnterColor = new Color(0, 0.8f, 1);
        ActionColor = new Color(1, 1, 1);

        Mat = GetComponent<Renderer>().material;
        Mat.color = DefaultColor;

        XLock = transform.localPosition.x;
        ZLock = transform.localPosition.z;
        
        Length = transform.parent.FindChild("Slide").localScale.y;
        Max = Length / 2;
        Min = -Max;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TouchController>() == null) return;
        CurrentController = other.gameObject.GetComponent<TouchController>();
        Mat.color = EnterColor;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<TouchController>() == null) return;
        if (!CurrentController.grabbing && CurrentController.Axis1D(InputType.IndexTrigger) > 0.8f) {
            Mat.color = ActionColor;
            CurrentController.Grab();
        }

        if (CurrentController.Axis1D(InputType.IndexTrigger) > 0f) {
            transform.position = CurrentController.transform.position;
            transform.localPosition = new Vector3(XLock, Mathf.Clamp(transform.localPosition.y, Min, Max), ZLock);
            UpdateValue();
        } else {
            Mat.color = EnterColor;
            CurrentController.Drop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<TouchController>() == null) return;
        Mat.color = DefaultColor;
        CurrentController.Drop();
        CurrentController = null;

    }

    private void UpdateValue() {
        Value = transform.localPosition.y / Max;
        module.SetValue(widget, Value);
    }


}
