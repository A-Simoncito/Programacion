using UnityEngine;

public class MovimientoCuadrado : MonoBehaviour
{
    public float velocidad = 5f;

    private Vector3 puntoB = new Vector3(7.5f, 4f, 0f);
    private Vector3 puntoC = new Vector3(8f, -4.15f, 0f);

    private bool enMovimiento = false;
    private Vector3 destino;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !enMovimiento)
        {
            enMovimiento = true;
            destino = puntoB;
        }

        if (enMovimiento)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

            if (transform.position == destino)
            {
                if (destino == puntoB)
                    destino = puntoC;
                else if (destino == puntoC)
                    enMovimiento = false;
            }
        }
    }
}

