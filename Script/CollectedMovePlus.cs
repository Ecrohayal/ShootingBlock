using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectedMovePlus : MonoBehaviour
{
    public enum CollectType
    {
        Plus,
        Multiply

    }

    public GameObject bullet;

    public CollectType collectType;

    public List<GameObject> Collected;

    [SerializeField] PlayerController playerController;
  
    public List<GameObject> bulletPoint;
    
    public float bulletSpeed;

    public float firerate = 0.5f;
    public float nextfire = 0f;
   


    [SerializeField] TextMeshPro countText;
   
    public int count;
    
    public bool isActivePlus, addedPlus;
    
    public Transform partcilePrefab;
    
    public Material mat;

    GameObject obj;





    private void Start()
    {


        obj = this.gameObject;
        isActivePlus = false;



    }
    private void Update()
    {
        if (isActivePlus)
        {
            Shot();
        }


    }
    public void Shot()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;



            for (int i = 0; i < bulletPoint.Count; i++)
            {

                GameObject _bullet = Instantiate(bullet, bulletPoint[i].transform.position, bulletPoint[i].transform.rotation);
              
                _bullet.GetComponent<Rigidbody>().velocity = bulletPoint[i].transform.forward * bulletSpeed;


            }


        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("thorn"))
        {



            if (collectType == CollectType.Multiply)
            {
                impact();
            }

            else if (collectType == CollectType.Plus)
            {
                impactPlus();
            }




        }





    }

    public void AddCollectable()
    {
        if (collectType == CollectType.Multiply)
        {
            playerController.collectedCubeCount = playerController.collectedCubeCount * bulletPoint.Count;
        }

        else if (collectType == CollectType.Plus)
        {
            playerController.collectedCubeCount = playerController.collectedCubeCount + bulletPoint.Count;
        }

    }




    public void impactPlus()
    {

        transform.localScale = new Vector3(transform.localScale.x - 0.75f, transform.localScale.y, transform.localScale.z);
        count--;
        countText.text = "+" + count.ToString();

        Transform partcile = Instantiate(partcilePrefab, transform.position, Quaternion.identity);

        partcile.GetComponent<ParticleSystem>().startColor = mat.color;



        if (count <= 0 || transform.localScale.x <= 0.74)
        {
            isActivePlus = false;


            Destroy(obj);

        }

      

        if (count >= 1)
        {
            playerController.collectedCubeCount = (playerController.collectedCubeCount / bulletPoint.Count) * count;

        }

        if (playerController.collectedCubeCount < 1)
        {
            playerController.collectedCubeCount = 1;
        }

        if (count > 0)
        {
            bulletPoint.RemoveAt(0);

        }


    }



    public void impact()
    {

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - 0.75f, transform.localScale.z);
        count--;
        countText.text = "x" + count.ToString();

        Transform partcile = Instantiate(partcilePrefab, transform.position, Quaternion.identity);

        partcile.GetComponent<ParticleSystem>().startColor = mat.color;

        if (count <= 0 || transform.localScale.y <= 0.74)
        {
            isActivePlus = false;
            Destroy(obj);

        }

     



        if (count >= 1)
        {
            playerController.collectedCubeCount = (playerController.collectedCubeCount - bulletPoint.Count) + count;

        }

        if (playerController.collectedCubeCount < 1)
        {
            playerController.collectedCubeCount = 1;
        }

        if (count > 0)
        {
            bulletPoint.RemoveAt(0);

        }








    }


}
