using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class depletion : MonoBehaviour
{
    float x, y, ex, ey;
    public GameObject go;
    public bool blocked;
    private bool check = false;
    Transform each;
    void Start()
    {
        go = GameObject.Find("carrier");
    }
    void Update()
    {

        if (blocked && !check)
        {
            for (int i = 0;i < go.transform.childCount; i++)
            {
                if(go.transform.GetChild(i).tag == "electron")
                    go.transform.GetChild(i).GetComponent<agent>().blocked = true;
            }
            check = true;
        }
        else if (!blocked && check)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                if (go.transform.GetChild(i).tag == "electron")
                    go.transform.GetChild(i).GetComponent<agent>().blocked = false;
            }
            check = false;
        }
        if (check)
        {
            x = transform.position.x + transform.localScale.x;
            y = transform.position.y + transform.localScale.y / 2;

            //finding the presence of the electron inside the deplection region
            for (int i = 0; i < go.transform.childCount; i++)
            {
                each = go.transform.GetChild(i);
                ex = each.position.x - transform.position.x;
                ey = each.position.y - transform.position.y;
                if (ex >= -x && ex <= x && ey >= -y && ey <= y)
                {
                    each.GetComponent<SpriteRenderer>().gameObject.SetActive(false);
                }
                else
                {
                    each.GetComponent<SpriteRenderer>().gameObject.SetActive(true);
                }
            }
        }   
    }
}
