using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    
    void FixedUpdate()
    {
        transform.position = Player.Instance.transform.position;
    }
}
