using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dan : MonoBehaviour
{
    public float speed;
    public float xBound;
    public float zBound;
    public float power = 10;
    // Update is called once per frame
    void Update()
    {
        Ply();
        TuHuy();
    }
    void Ply()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void TuHuy()
    {
        if (transform.position.x > xBound || transform.position.x < -xBound || transform.position.z > zBound || transform.position.z < -zBound)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRB = other.GetComponent<Rigidbody>();
        if (otherRB != null &&  other.gameObject.name != "Player")
        {
            otherRB.AddForce((other.transform.position - transform.position) * power, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
