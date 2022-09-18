using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Colt : MonoBehaviour
{
    [SerializeField] bool isFinish, touchBarrel;
    [SerializeField] GameObject winPanel, wonPanel;

    private void Update()
    {
        if(isFinish&&touchBarrel)
        {
            winPanel.SetActive(true);
        }
        if(touchBarrel&&!isFinish)
        {
            wonPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Finish")
        {
            isFinish = true;
        }

        if(other.tag=="Barrel")
        {
            touchBarrel = true;
            Destroy(gameObject, 0.5f);
        }
       
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="BonusLine")
        {
           if(isFinish&&touchBarrel)
            {
                other.GetComponent<Animator>().enabled = true;
            }
        }
    }


}
