using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JailDoor : InteractiveItem
{
    public override void ActiveAction()
    {
        GetComponent<Animator>().SetBool("isOpen", true);
        GetComponent<BoxCollider>().enabled = false;
    }
}
