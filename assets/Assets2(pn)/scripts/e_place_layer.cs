using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_place_layer : MonoBehaviour
{
    private int pindex, nindex;
    private Transform point;

    private GameObject electron, hole, carrier;
    private Transform path;
    int[] electron_count = new int[] {4,5,2,2,2,2,2};
    [SerializeField] private bool isforwardBiased;
    private GameObject clone;
    public Transform leftBarrier, rightBarrier;
    private void Awake()
    {
        electron = Resources.Load<GameObject>("electron");
        hole = Resources.Load<GameObject>("hole");
        carrier = new GameObject("carrier");
    }

    private void Start()
    {
        int nindex;
        if (isforwardBiased)
            nindex = 1;
        else
            nindex = -1;
        for (int i = 0;i < transform.childCount; i++)
        {
            path = transform.GetChild(i);
            int j = 0;
            for (;j < electron_count[i]; j++)
            {

                clone = Instantiate(electron, path.GetChild(j).position, Quaternion.identity);
                clone.transform.SetParent(carrier.transform);
                clone.GetComponent<agent>().isforwardBiased = isforwardBiased;
                clone.GetComponent<agent>().pathNumber = i;

                if (nindex + j < 0)
                    clone.GetComponent<agent>().checkPoint = rightBarrier.GetChild(i);
                else
                    clone.GetComponent<agent>().checkPoint = path.GetChild(nindex + j);

            }
            for (; j < path.childCount; j++)
            {
                clone = Instantiate(hole, path.GetChild(j).position, Quaternion.identity);
                clone.transform.SetParent(carrier.transform);
            }
        }
    }
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
