using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 originPos;
    int randDir;
    public float moveDuration;
    private RaycastHit hit;
    private bool[] listTF;
    public int numBox;
    public Vector3 nextPos;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Rob")
        {
            transform.position = originPos;
            nextPos = transform.position;
        }
    }
    private void Start()
    {
        originPos = transform.position;
        listTF = new bool[]{ true, true, true, true};
        moveDuration = Random.Range(1, 5);
        StartCoroutine(moveObject());
        numBox = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.forward * 3f);
        Gizmos.DrawRay(transform.position, Vector3.back * 3f);
        Gizmos.DrawRay(transform.position, Vector3.left * 3f);
        Gizmos.DrawRay(transform.position, Vector3.right * 3f);
    }
    IEnumerator moveObject()
    {
        originPos = transform.position;
        float timeElapsed = 0;
        nextPos = new Vector3(0,0,0);
        randDir = Random.Range(1, 4);

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 4f) && (hit.transform.tag == "Rob" || hit.transform.tag == "Wall" || hit.transform.tag == "Door" || hit.transform.tag == "dropzone"))
        {
            listTF[0] = false;
        }
        else
        {
            listTF[0] = true;
        }

        if (Physics.Raycast(transform.position, Vector3.back, out hit, 4f) && (hit.transform.tag == "Rob" || hit.transform.tag == "Wall" || hit.transform.tag == "Door" || hit.transform.tag == "dropzone"))
        {
            listTF[1] = false;
        }
        else
        {
            listTF[1] = true;
        }

        if (Physics.Raycast(transform.position, Vector3.right, out hit, 4f) && (hit.transform.tag == "Rob" || hit.transform.tag == "Wall" || hit.transform.tag == "Door" || hit.transform.tag == "dropzone"))
        {
            listTF[2] = false;
        }
        else
        {
            listTF[2] = true;
        }

        if (Physics.Raycast(transform.position, Vector3.left, out hit, 4f) && (hit.transform.tag == "Rob" || hit.transform.tag == "Wall" || hit.transform.tag == "Door" || hit.transform.tag == "dropzone"))
        {
            listTF[3] = false;
        }
        else
        {
            listTF[3] = true;
        }
        
        if (listTF[0] == false && listTF[1] == false && listTF[2] == false && listTF[3] == false)
        {
            nextPos = transform.position;
        }
        else
        {
            while (!((randDir == 1 && listTF[0] == true) || (randDir == 2 && listTF[1] == true) || (randDir == 3 && listTF[2] == true) || (randDir == 4 && listTF[3] == true)))
            {
                randDir = Random.Range(1, 4);
            }
            if (randDir == 1)
            {
                nextPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 4);
            }
            else if (randDir == 2)
            {
                nextPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4);
            }
            else if (randDir == 3)
            {
                nextPos = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
            }
            else if (randDir == 4)
            {
                nextPos = new Vector3(transform.position.x - 4, transform.position.y, transform.position.z);
            }
            else
            {
                nextPos = transform.position;
            }
        }

        
        while (timeElapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(originPos, nextPos, timeElapsed / moveDuration);
            yield return null;
            timeElapsed += Time.deltaTime;
            
        }
        StartCoroutine(moveObject());
    }
}
