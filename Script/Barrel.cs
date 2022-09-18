using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Barrel : MonoBehaviour
{
    public TextMeshPro barrelText;
   
    public int barrelCount;
    
    private void Start()
    {
        barrelText.text = barrelCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bullet"))
        {
            barrelCount--;
            barrelText.text = barrelCount.ToString();

            if(barrelCount <= 0)
            {
                Destroy(gameObject);
            }
        }

        if(other.CompareTag("Player"))
        {
            
            other.gameObject.GetComponent<CollectedMovePlus>().impactPlus();
            other.gameObject.GetComponent<CollectedMovePlus>().impact();
        }

       
    }
}
