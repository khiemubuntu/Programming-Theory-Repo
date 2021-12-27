using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : Human // INHERITANCE
{
    [SerializeField]
    private GameObject player;
    private bool isCooldown = false;
    [SerializeField]
    private GameObject spawnManager;

    void Start()
    {
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("Spawn Manager");
    }
    public override void move()// POLYMORPHISM
    {
        transform.LookAt(player.transform);
    }

    public override void Attack()// POLYMORPHISM
    {
        if (!isCooldown)
        {
            StartCoroutine(CoolDownattack());
        }
    }
    IEnumerator CoolDownattack()
    {
        SpawnDan();
        isCooldown = true;
        yield return new WaitForSeconds(2);
        isCooldown = false;
    }

    public override Vector3 MovementDirection()// POLYMORPHISM
    {
        return (player.transform.position - transform.position).normalized  * 0.5f;
    }

    public override void TuHuy()// POLYMORPHISM
    {
        if (transform.position.y < -yBound)
        {
            Destroy(gameObject);
            spawnManager.GetComponent<SpawnManager>().SoLuongDichConLai -= 1;
        }
    }
}

