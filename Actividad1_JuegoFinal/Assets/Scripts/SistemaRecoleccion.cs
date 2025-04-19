using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class SistemaRecoleccion : MonoBehaviour
{
    public int cantidadLingotes;
    public int lingotesNecesarios = 9;
    public TextMeshProUGUI numero;
    public GameObject puerta;

    private void Update()
    {
        numero.text = cantidadLingotes.ToString();

        if (cantidadLingotes >= lingotesNecesarios && puerta != null)
        {
            puerta.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lingotes"))
        {
            Destroy(other.gameObject);
            cantidadLingotes++;
        }
    }
}
