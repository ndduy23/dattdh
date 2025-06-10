using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;

    void Start()
    {
        StartCoroutine(ImageLoop());
    }
    IEnumerator ImageLoop()
    {
        while (true)
        {

            image1.SetActive(true);
            image2.SetActive(false);
            yield return new WaitForSeconds(1f);

            image1.SetActive(false);
            image2.SetActive(true);          
            yield return new WaitForSeconds(1f);

           
        } 
    }
}

