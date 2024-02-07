using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float laserspeed = 10;

    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        transform.Translate(UnityEngine.Vector3.up * laserspeed * Time.deltaTime);
        if (transform.position.y >= 8f)
        {
            Destroy(this.gameObject);
        }
    }
}
