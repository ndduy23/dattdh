using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quaydau : MonoBehaviour
{
    public Transform player;
    
    private void Update()
    {
        transform.position = new Vector3(player.position.x,player.position.y ,transform.position.z);// player.position.x ,player.position.y:Đoạn mã này lấy giá trị vị trí x và y của player có một component Transform.
    }
}
