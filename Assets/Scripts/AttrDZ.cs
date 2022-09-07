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

    private void OnTriggerEnter(Collider other)
    {
        possibleBox = other.GetComponent<Move>().numBox;
        if(possibleBox > 0)
        {
            if( nBoxes < 5)
            {
                if((nBoxes + possibleBox) > 5)
                {
                    int tempRest = 5 - nBoxes;
                    possibleBox = possibleBox - tempRest;
                    nBoxes = 5;
                }
                else
                {
                    nBoxes = nBoxes + possibleBox;
                    possibleBox = 0;
                }
            }other.GetComponent<Move>().numBox = possibleBox;
        }
    }
}
