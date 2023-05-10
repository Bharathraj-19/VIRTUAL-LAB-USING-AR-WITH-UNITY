using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    private int pindex, nindex;
    private Transform point;
    public Transform leftBarrier, rightBarrier;
    public Transform returnNext(Transform present, Transform obj, int pathNumber, bool direction)
    {
        point = transform.GetChild(pathNumber);

        if (present.position == leftBarrier.GetChild(pathNumber).position)
        {
            obj.position = rightBarrier.GetChild(pathNumber).position;
            return point.GetChild(0);
        }
        else if (present.position == rightBarrier.GetChild(pathNumber).position)
        {
            obj.position = leftBarrier.GetChild(pathNumber).position;
            return point.GetChild(point.childCount - 1);
        }
        else
        {
            pindex = present.GetSiblingIndex();
            if (direction)
                nindex = pindex + 1;
            else
                nindex = pindex - 1;
            if (nindex < point.childCount && nindex >= 0)
                return point.GetChild(nindex);
            else if (nindex < 0)
                return rightBarrier.GetChild(pathNumber);

            else
                return leftBarrier.GetChild(pathNumber);
        }
    }
}
