using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject bulletExplodeEffect;
    private Transform target;
    private float speed = 60f;

    public void Seek(Transform _target)
    {
        print("Im Here");
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);

    }
  
    private void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(bulletExplodeEffect, transform.position, transform.rotation);
        Destroy(effect, 3f);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
