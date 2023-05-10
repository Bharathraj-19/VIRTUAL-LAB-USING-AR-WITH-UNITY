using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agent : MonoBehaviour
{
    public e_place_layer wayobject;
    [Header("Properties")]
    [Range(0, 25)] public int speed = 10;
    [Range(0f, 1f)] public float wait = 0.1f;
    public bool isforwardBiased;
    public bool blocked;
    private bool check;
    private Vector3 v;
    [HideInInspector] public Transform checkPoint;
    [HideInInspector] public int pathNumber;
    private Vector3 leftBarrier, rightBarrier;
    void Start()
    {
        wayobject = GameObject.Find("diode").transform.GetChild(0).GetComponent<e_place_layer>();
        check = isforwardBiased;
        StartCoroutine(delay());
    }
    IEnumerator delay()
    {
        while (true)
        {
          /*  if (blocked)
            {
                yield return null;
                continue;
            } */
            if (isforwardBiased != check || Vector3.Distance(transform.position, checkPoint.position) == 0)
            {
                yield return new WaitForSeconds(wait);
                checkPoint = wayobject.returnNext(checkPoint, transform, pathNumber, isforwardBiased);
                check = isforwardBiased;
            }
            transform.position = Vector3.MoveTowards(transform.position, checkPoint.position, speed * Time.fixedDeltaTime);
            yield return null;
        }
    }
}
