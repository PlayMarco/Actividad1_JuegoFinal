using UnityEngine;

public class Player : MonoBehaviour
{
    private float inputH;
    private float inputV;
    private CharacterController characterController;
    [SerializeField] private float velocidadMov;
    [SerializeField] private Transform camara;
    private Animator animator;
    private Vector3 direccionMov;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        direccionMov = (camara.forward * inputV + camara.right * inputH).normalized;
        direccionMov.y = 0;
        characterController.Move(direccionMov * velocidadMov * Time.deltaTime);
        animator.SetFloat ("velocidad", characterController.velocity.magnitude);
        if (inputH != 0 || inputV != 0) 
        {
            RotarHaciaDestino(); 
        }
    }
    private void RotarHaciaDestino() 
    { 
        Quaternion rotacionObjetivo = Quaternion.LookRotation(direccionMov);
        transform.rotation = rotacionObjetivo;
    }
}
