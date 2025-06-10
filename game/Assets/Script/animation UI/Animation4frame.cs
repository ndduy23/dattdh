using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation4frame : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;

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
            image3.SetActive(false);
            image4.SetActive(false);
            yield return new WaitForSeconds(.5f);

            image1.SetActive(false);
            image2.SetActive(true);
            image3.SetActive(false);
            image4.SetActive(false);
            yield return new WaitForSeconds(.5f);

            image1.SetActive(false);
            image2.SetActive(false);
            image3.SetActive(true);
            image4.SetActive(false);
            yield return new WaitForSeconds(.5f);

            image1.SetActive(false);
            image2.SetActive(false);
            image3.SetActive(false);
            image4.SetActive(true);
            yield return new WaitForSeconds(.5f);
        }
    }
}
