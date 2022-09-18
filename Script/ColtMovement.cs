using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColtMovement : MonoBehaviour
{
    #region Variables
    [SerializeField] PlayerController playerController;
    [SerializeField] float movementSpeed;
    [SerializeField] float xSpeed,limitX;

    [SerializeField] bool isTouching;
    

    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPoint;
    [SerializeField] float bulletSpeed;

    [SerializeField] float firerate = 0.5f;
    [SerializeField] float nextfire = 0f;

    #endregion

    
    void Update()
    {
       
        Shooting();
    }


    private void FixedUpdate()
    {
        Move();
    }


    #region Movement
    void Move()
    {
        float newX = 0;
        float touchXDelta = 0;

        transform.position += Vector3.forward * movementSpeed * Time.deltaTime;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }

        if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
    #endregion

    #region Shooting
    public void Shooting()
    {


        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            var _bullet = Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);

            _bullet.GetComponent<Rigidbody>().velocity = bulletPoint.forward * bulletSpeed;
        }



    }
    #endregion

}
