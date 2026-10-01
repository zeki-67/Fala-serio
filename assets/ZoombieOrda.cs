using UnityEngine;
using System.Collections;
public class ZoombieOrda : MonoBehaviour
{
    public GameObject zoombie;
    public Transform spawnPoint;
    public int QuantidadeOrda = 1;
    public float TempoOrda = 120f;
    void Start()
    {
        StartCoroutine(CriarOrdas());
    }
    IEnumerator CriarOrdas()
    {
        while (true)
        {
            for(int i = 0; i < QuantidadeOrda; i++)
            {
                Instantiate(zoombie, spawnPoint.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(TempoOrda);
        }
    }

  
}
