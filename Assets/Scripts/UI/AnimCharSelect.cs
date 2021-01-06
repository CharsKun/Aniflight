using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCharSelect : MonoBehaviour
{
    Animator anim;
    public int ChooseAnim;
    void Start()
    {
        anim = GetComponent<Animator>();
        if (ChooseAnim == 1)
        {
            anim.SetInteger("Character", 1);
        }else if(ChooseAnim == 2)
        {
            anim.SetInteger("Character", 2);
        }
        else if(ChooseAnim == 3)
        {
            anim.SetInteger("Character", 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
