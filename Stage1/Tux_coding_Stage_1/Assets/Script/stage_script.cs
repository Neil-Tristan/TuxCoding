using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_script : MonoBehaviour
{
    public string value = "null";
    public GameObject gm;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Blackhole")
        {
            if(int.Parse(gm.GetComponent<GameManager>().timer.GetComponent<TMPro.TextMeshPro>().text) == 0)
            {
                visibility(false);
            }
        }
    }

    public void visibility(bool stat)
    {
        gameObject.SetActive(stat);
    }
    
}

