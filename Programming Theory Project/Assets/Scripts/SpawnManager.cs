using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int soLuongDichSeSinhRa = 1;
    public int SoLuongDichConLai = 0;
    [SerializeField] private Enermy enermy;
    public float xBound;
    public float zBound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (SoLuongDichConLai <= 0)
        {
            for(int i = 1; i <= soLuongDichSeSinhRa; i++)
            {
                SpawnEnermy();
            }
            soLuongDichSeSinhRa += 1;
        }
    }

    void SpawnEnermy()
    {
        Instantiate(enermy, new Vector3(Random.Range(-xBound, xBound), 0, Random.Range(-zBound,zBound)), enermy.transform.rotation);
        SoLuongDichConLai += 1;
    }
}
