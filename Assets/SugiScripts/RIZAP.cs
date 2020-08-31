using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIZAP : MonoBehaviour
{
    public int step, speed,jumpspeed;
    float startPos;
    float sumtime;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, startPos + Mathf.Sin(sumtime * jumpspeed) * step * 0.1f, transform.position.z);
        sumtime += Time.deltaTime;
    }
}
