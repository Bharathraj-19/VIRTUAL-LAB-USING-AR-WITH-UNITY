using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class touch_control : MonoBehaviour
{
    private PlayerInput pi;
    private InputAction ia1;
    [SerializeField] private GameObject moveObject;
    private float z;
    void Awake()
    {
        Debug.Log("script got attached");
        pi = GetComponent<PlayerInput>();
        ia1 = pi.actions["button"];
        z = moveObject.transform.position.z;
    }
    private void OnEnable()
    {
        ia1.performed += displacement;
    }

    private void OnDisable()
    {
        ia1.performed -= displacement;
    }
    private void displacement(InputAction.CallbackContext context)
    {
        Vector3 v = context.ReadValue<Vector2>();
        v.z = z;
        Debug.Log("got:" + v);
        moveObject.transform.position = Camera.main.ScreenToWorldPoint(v);
    }
}
