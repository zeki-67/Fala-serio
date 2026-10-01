using UnityEngine;

public class MapaInfinito : MonoBehaviour
{
    public Transform player;
    public Collider2D cenario;
    private float largura;
    void Start()
    {
        largura = cenario.bounds.size.x;

    }

    void Update()
    {
       if(player.position.x > cenario.transform.position.x + largura)
        {
            GameObject novoCenario = Instantiate( cenario.gameObject,
            cenario.transform.position + new Vector3(largura, 0, 0),
            cenario.transform.rotation);
            cenario = novoCenario.GetComponent<Collider2D>();
        }
    }
}
