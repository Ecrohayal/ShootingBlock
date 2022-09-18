using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public int collectedCubeCount;
    
    public Transform mainCollectedCube;
    
    public Text textui;

    void Update()
    {
        textui.text = collectedCubeCount.ToString();
    }

    public void Button(string nextlvl)
    {

        SceneManager.LoadScene(nextlvl);
    }


}
