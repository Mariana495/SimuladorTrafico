using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttrDZ : MonoBehaviour
{
    [Header("Box number:")]
    public int nBoxes = 0;

    private int possibleBox = 0;
    private RaycastHit hit;
    [SerializeField] private GameObject decor;

    private void Update()
    {
        if( nBoxes < 5)
        {
            if(Physics.Raycast(new Vector3(transform.position.x, 1.8f, transform.position.z), new Vector3(0, 1, 2), out hit, 6f) && hit.transform.tag == "Rob")
            {
                Debug.Log(hit.transform.position);
                possibleBox = hit.transform.gameObject.GetComponent<Move>().numBox;
                if(possibleBox > 0)
                {
                    if((nBoxes + possibleBox) > 5)
                    {
                        int tempRest = 5 - nBoxes;
                        possibleBox = possibleBox - tempRest;
                        nBoxes = 5;
                        Debug.Log(nBoxes);
                    }
                    else
                    {
                        nBoxes = nBoxes + possibleBox;
                        possibleBox = 0;
                        Debug.Log(nBoxes);
                    }
                    hit.transform.gameObject.GetComponent<Move>().numBox = possibleBox;
                }
            }
        }
        if (nBoxes > 0)
        {
            Instantiate(decor, new Vector3(transform.position.x, 1.90f, transform.position.z), Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, new Vector3(0,1,2) * 6f);
    }
}
