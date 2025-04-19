using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform posRespawn;
    public Transform posPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trampas"))
        {
            Muerte();
        }
    }

    public void Muerte() 
    {
        posPlayer.position = posRespawn.position;
    }

}
