using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    
    [SerializeField]private Transform startPoint;
    public Transform endPoint;
    public float speed = 2f;
    private void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")

        {
            collision.gameObject.transform.SetParent(transform);
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
        
    }    
}

