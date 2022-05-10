using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour
{
    public Collider sliceCollider;
    private TrailRenderer sliceEffect;
    private Vector3 mousePos;
    void Start()
    {
        sliceEffect = gameObject.GetComponent<TrailRenderer>();
        sliceEffect.emitting = false;
        sliceCollider.enabled = false;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);
        transform.position = mousePos;
    }
    private void OnMouseDown()
    {
        sliceEffect.emitting = true;
        sliceCollider.enabled = true;
    }

    private void OnMouseUp()
    {
        sliceEffect.emitting = false;
        sliceCollider.enabled = false;
    }
}
