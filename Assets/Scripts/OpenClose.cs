using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    private Animator AnimatorC;

    void Start()
    {
        AnimatorC = GetComponent<Animator>();
    }

    void Update()
    {
        if(AnimatorC != null)
        {
            if(Input.GetKeyDown(KeyCode.O))
            {
                AnimatorC.SetTrigger("TrOpen");
            }

            if(Input.GetKeyDown(KeyCode.C))
            {
                AnimatorC.SetTrigger("TrClose");
            }
        }
    }
}
