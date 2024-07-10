using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffAnim : MonoBehaviour
{
    public float wait;
    public float _wait;
    // private bool change = true;
    private MeshRenderer visible;
    

    void Start()
    {
        visible = GetComponent<MeshRenderer>();
        StartCoroutine(Anim());
    }

    private void FixedUpdate() 
    {
        transform.Translate(new Vector2(0, 0.4f) * Time.fixedDeltaTime);
    }

    private IEnumerator Anim() // Мигание надписи
    {
        while(wait >= 0.01f)
        {
            yield return new WaitForSeconds(wait);
            // if(change)
            // {

            //     visible.enabled = false;
            // }
            // else
            // {
            //     visible.enabled = true;
            // }
            visible.enabled = false;
            yield return new WaitForSeconds(0.1f);
            visible.enabled = true;
            // change = !change;
            wait -= _wait;
        }
        Destroy(gameObject);
    }
}
