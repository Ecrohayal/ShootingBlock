using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class CollectedCubeController : MonoBehaviour
{
    PlayerController playerController;
    
    
    void Start()
    {
        
      
        playerController = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerController>();

        if (GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();

            Rigidbody rb = GetComponent<Rigidbody>();
            
            rb.useGravity = false;
            
            rb.constraints = RigidbodyConstraints.FreezeAll;


        }
    }


   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("obs"))
        {
          
            collision.gameObject.tag = "Player";
            
            collision.transform.parent = playerController.mainCollectedCube;
            
            collision.gameObject.AddComponent<CollectedCubeController>();


            
            collision.gameObject.GetComponent<CollectedMovePlus>().isActivePlus = true;
            
            collision.gameObject.GetComponent<CollectedMovePlus>().addedPlus = true;
            
            collision.gameObject.GetComponent<CollectedMovePlus>().AddCollectable();
               
           

        }



    }
    


}
