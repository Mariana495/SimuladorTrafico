using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxD : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        other.GetComponent<Move>().numBox++;
    }
}
