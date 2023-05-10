using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class drag : MonoBehaviour
{
    private PlayerInput pi;
    [SerializeField] private GameObject plane;
    private InputAction displace, press;
    RaycastHit hit;
    Ray ray;
    private GameObject go;
    private float z;
    private void Awake()
    {
        z = Camera.main.WorldToScreenPoint(plane.transform.position).z;
        pi = GetComponent<PlayerInput>();
        displace = pi.actions["displace"];
        press = pi.actions["press"];
    }

    private void OnEnable()
    {
        press.started += pressed;
        press.performed += dragging;
        press.canceled += stopdrag;
    }

    private void OnDisable()
    {
        press.started -= pressed;
        press.performed -= dragging;
        press.canceled -= stopdrag;
    }

    private void pressed(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(displace.ReadValue<Vector2>());
        Physics.Raycast(ray, out hit);
        if (hit.collider)
        {
            if (hit.collider.tag == "DragObject")
            {
                go = hit.collider.gameObject;
            }
        }
    }

    private void dragging(InputAction.CallbackContext context)
    {
        StartCoroutine(DisplaceObject(context));
    }
    private IEnumerator DisplaceObject(InputAction.CallbackContext context)
    {
        while (press.IsInProgress() && go != null)
        {
            Vector3 v = displace.ReadValue<Vector2>();
            v.z = z;
            go.transform.position = Camera.main.ScreenToWorldPoint(v);
            Debug.Log(press.IsInProgress());
            yield return null;
        }
    }

    private void stopdrag(InputAction.CallbackContext context)
    {
        go = null;
    }

    /*private void Update()
    {
        if (press.WasPerformedThisFrame())
        {
            ray = Camera.main.ScreenPointToRay(displace.ReadValue<Vector2>());
            Physics.Raycast(ray, out hit);
            if (hit.collider)
            {
                if (hit.collider.tag == "DragObject")
                {
                    go = hit.collider.gameObject;
                }
            }
        }
        else if (press.IsInProgress() && go != null)
        {
            Vector3 v = displace.ReadValue<Vector2>();
            v.z = z;
            go.transform.position = Camera.main.ScreenToWorldPoint(v);
        }
        else
            go = null;
    } */
    public void invoke(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);
    }
}
