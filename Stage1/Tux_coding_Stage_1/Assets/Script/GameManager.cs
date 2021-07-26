using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button overlayBtn;
    public Button startBtn;
    public GameObject timer;
    public GameObject generateGiven;
    public GameObject[] plaforms = new GameObject[10];

    private Vector3[] pos = new Vector3[10];

    private void Start()
    {
        for(int i = 0; i < plaforms.Length; i++)
        {
            pos[i] = new Vector3(plaforms[i].transform.position.x, plaforms[i].transform.position.y, plaforms[i].transform.position.z);
        }
    }

    private IEnumerator timerCd() //Governs da display of time
    {
        while (int.Parse(timer.GetComponent<TextMeshPro>().text) > 0) 
        {
            int newSec = int.Parse(timer.GetComponent<TextMeshPro>().text) - 1;
            timer.GetComponent<TextMeshPro>().text = newSec.ToString();
            yield return new WaitForSeconds(1f);
        }
        DropIncorrect();
    }

    private void DropIncorrect() 
    {
        for (int i = 0; i < plaforms.Length; i++) 
        {
            if(plaforms[i].GetComponent<stage_script>().value != generateGiven.GetComponent<generateGiven>().keyValue)
            {
                plaforms[i].GetComponent<Rigidbody>().useGravity = true;
            }
        }
        StartCoroutine(restartWait());
    }

    private IEnumerator restartWait()
    {
        for (int i = 0; i < 5; i++) 
        {
            yield return new WaitForSeconds(1f);
        }
        restart();
    }

    private void restart() 
    {
        timer.GetComponent<TextMeshPro>().text = "10";
        for (int i = 0; i < plaforms.Length; i++) 
        {
            plaforms[i].GetComponent<Rigidbody>().useGravity = false;
            plaforms[i].GetComponent<stage_script>().visibility(true);
            plaforms[i].transform.position = new Vector3(pos[i].x, pos[i].y, pos[i].z);
        }
        overlayBtn.gameObject.SetActive(true);
        startBtn.gameObject.SetActive(true);
    }

    public void startGame() 
    {
        overlayBtn.gameObject.SetActive(false);
        startBtn.gameObject.SetActive(false);
        StartCoroutine(timerCd());
        generateGiven.GetComponent<generateGiven>().RandomGiven();
    }
}
