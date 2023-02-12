using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    Animator persoanim;

   private void Awake()
    {
        persoanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        persoanim.SetFloat("speed", Input.GetAxis("Vertical"));
    }
}
