using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStop : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WallLeft"))
        {
            transform.Translate(1,0,0);
        }
        if (collision.gameObject.CompareTag("WallRight"))
        {
            transform.Translate(-1,0,0);
        }
    }
}
