using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    [Range(0,2f)][SerializeField] private float radius;
    private int pindex,nindex;
    [HideInInspector] public int points;
    public void OnDrawGizmos()
    {
        foreach(Transform t in transform)
        {
            Gizmos.DrawWireSphere(t.position, radius);
        }
        points = transform.childCount;
        for (int i = 0;i < points - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }
            Gizmos.DrawLine(transform.GetChild(points - 1).position, transform.GetChild(0).position);

    }
    public Transform returnNext(Transform present,bool direction)
    {
        if(present == null)
            return transform.GetChild(0);
        pindex = present.GetSiblingIndex();
        if (direction)
            nindex = pindex + 1;
        else
            nindex = pindex - 1;
        if (nindex < transform.childCount && nindex >= 0)
            return transform.GetChild(nindex);
        else
            return transform.GetChild(transform.childCount - Mathf.Abs(nindex));
    }
}
