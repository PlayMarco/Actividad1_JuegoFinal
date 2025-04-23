using UnityEngine;

public class Respawn : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trampas"))
        {
            Muerte();         
        }
        if (other.CompareTag("Victoria"))
        {
            Victoria();
        }
    }

    public void Muerte() 
    {
        FindAnyObjectByType<GameOver>().MostrarGameover();
    }

    public void Victoria()
    {
        FindAnyObjectByType<GameOver>().MostrarVictoria();
    }

}
