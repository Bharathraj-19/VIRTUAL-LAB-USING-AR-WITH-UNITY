using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groupflow : MonoBehaviour
{
    private float perimeter;
    [SerializeField] private int spacing = 2;
    [SerializeField] private Transform path;
    [SerializeField] private bool isforwardBiased;
    private GameObject electron;
    void Start()
    {
        int i,j;
//        for (i = 0; i < path.childCount - 1; i++)
//            perimeter += Vector3.Distance(path.GetChild(i).position, path.GetChild(i + 1).position);
//        perimeter += Vector3.Distance(path.GetChild(i).position, path.GetChild(0).position);
//       Debug.Log(perimeter);
//        //finding the number of electrons suiable for the point
//       perimeter /= spacing;
        Vector3 v;
        int nindex;
        int mag = 0;
        for (i = 0,j = 0;j < path.childCount;j++)
        {
            if (isforwardBiased)
                nindex = i + 1;
            else
                nindex = i - 1;
            if (nindex >= path.childCount || nindex < 0)
                nindex = path.childCount - Mathf.Abs(nindex);
            //finding the normalized vector between two checkpoints
            v = (path.GetChild(nindex).position - path.GetChild(i).position);
            while(v.magnitude > mag) {
                electron = (GameObject)Instantiate(Resources.Load("electron",typeof(GameObject)),(path.GetChild(i).position + v.normalized * mag),Quaternion.identity);
                electron.GetComponent<agent>().isforwardBiased = isforwardBiased;
                electron.GetComponent<agent>().checkPoint = path.GetChild(nindex);
                mag += spacing;
            }
            mag = (int)(mag - v.magnitude);
            i = nindex;
        }
    }
}
