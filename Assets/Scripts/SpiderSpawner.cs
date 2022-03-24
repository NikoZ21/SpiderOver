using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour
{
    [SerializeField] GameObject spider;
    [SerializeField] float timer = 2f;
    [SerializeField] int spiderCount = 5;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (spiderCount > 0)
            {
                Instantiate(spider, transform.position, Quaternion.identity);
                spiderCount--;
                timer = 2;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
