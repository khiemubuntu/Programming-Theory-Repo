using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private GameObject dan;
    [SerializeField]
    protected float yBound = 5;

    // Update is called once per frame
    void Update()
    {
        move();
        Attack();
        TuHuy();
    }

    public Vector3 Nhin(Vector3 huowngMucTieu)
    {
        if (huowngMucTieu.x < 0)
        {
            return Vector3.Angle(huowngMucTieu, Vector3.forward) * Vector3.up * huowngMucTieu.x;
        }
        else
        {
            return Vector3.Angle(huowngMucTieu, Vector3.forward) * Vector3.up;
        }
    }
    
    public virtual void move()
    {
        Vector3 movementDirection = MovementDirection();
        if (movementDirection.magnitude > 0)
        {
            transform.eulerAngles = Nhin(movementDirection);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        //Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Horizontal") * 90, 0, Input.GetAxisRaw("Vertical") * 90);
        // this line checks whether the player is making inputs.
        //if (movementDirection.magnitude > 0.1f)
        //{
        //    Quaternion newRotation = Quaternion.LookRotation(movementDirection);
        //   transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
        //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //}
    }
    public virtual Vector3 MovementDirection()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        return new Vector3(horizontalInput, 0, verticalInput);
    }
    public virtual void Attack()
    {
        bool isAttackKey = Input.GetKeyDown(KeyCode.Space);
        if (isAttackKey)
        {
            SpawnDan();
        }
    }
    public void SpawnDan()
    {
        Instantiate(dan, transform.position + MovementDirection(), transform.rotation);
    } 
    public virtual void TuHuy()
    {
        if (transform.position.y < -yBound)
        {
            Destroy(gameObject);
        }
    }
}
