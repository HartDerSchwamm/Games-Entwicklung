using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextHandler : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 1.2f);
        transform.localPosition += new Vector3(3f, 1f, 0f);
    }

}
