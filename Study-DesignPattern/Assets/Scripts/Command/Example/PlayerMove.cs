using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public void Move(Vector3 movement)
    {
        transform.position = transform.position + movement;
    }
}