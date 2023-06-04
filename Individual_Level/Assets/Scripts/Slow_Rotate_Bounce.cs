using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Rotate_Bounce : MonoBehaviour
{
    public Vector3 v3_rotation = new Vector3(0, 45, 0);
    public float speed = 2f;
    public float height = 0.5f;

    Vector3 pos;

    private void Start(){
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(v3_rotation * Time.deltaTime);

        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
