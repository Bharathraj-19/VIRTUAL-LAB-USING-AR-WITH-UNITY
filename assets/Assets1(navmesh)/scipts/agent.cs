using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agent : MonoBehaviour
{
    public waypoint wayobject;
    [Header("Properties")]
    [Range(0,25)]public int speed = 10;
    public bool isforwardBiased;
    private bool check;
    private Vector3 v;
    [HideInInspector]public Transform checkPoint;
    void Start()
    {
        wayobject = GameObject.Find("path").GetComponent<waypoint>();
        check = isforwardBiased;
        //checkPoint = wayobject.returnNext(null, isforwardBiased);
        //transform.position = checkPoint.position;
    }

    void Update()
    {
        if (isforwardBiased != check || Vector3.Distance(transform.position, checkPoint.position) == 0)
        {
            checkPoint = wayobject.returnNext(checkPoint,isforwardBiased);
            check = isforwardBiased;
        }
        v = Vector3.MoveTowards(transform.position, checkPoint.position,speed * Time.fixedDeltaTime);
        transform.position = new Vector3(Mathf.Round(v.x * 10) / 10f, Mathf.Round(v.y * 10) / 10f, Mathf.Round(v.z * 10) / 10f); ;
        //transform.position = v;
    }
}
//Vector3.Distance(transform.position,checkPoint.position) == 0s
