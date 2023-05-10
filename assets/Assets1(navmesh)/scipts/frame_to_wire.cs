using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frame_to_wire : MonoBehaviour
{
    public waypoint wayobject;
    private Transform present = null,next = null;
    [SerializeField] private bool startpivot;
    private Vector3 pivotPosition;
    private GameObject wire;
    void Start()
    {
        Debug.Log(wayobject.points);
        present = wayobject.returnNext(present, true); 
        for (int i = 0; i < wayobject.points - 1; i++)
        {
            next = wayobject.returnNext(present,true);
            if (startpivot)
                pivotPosition = present.position;
            else
                pivotPosition = next.position; 
                Vector3 mid = (next.position + present.position) / 2;
            Vector3 diff = next.position - present.position;
            wire = Instantiate(Resources.Load("leg", typeof(GameObject)), mid, Quaternion.identity) as GameObject;
            Instantiate(Resources.Load("joint", typeof(GameObject)), pivotPosition, Quaternion.identity);
            wire.transform.localScale = new Vector3(1, diff.magnitude / 2, 1);
            //now finding the rotation of the wire part
            wire.transform.up = diff;
            present = next;
        }

    }
}
