using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_VFX : MonoBehaviour
{
    public void Start()
    {
        Invoke("VFX_Death", 1f);
    }

    public void VFX_Death()
    {
        Destroy(gameObject);
    }
}
