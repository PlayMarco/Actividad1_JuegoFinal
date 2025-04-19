using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float velocidadMov;
    [SerializeField] private Transform camara;
    [SerializeField] private InputManagerSO inputManager;
    [SerializeField] private float factorGravedad;
    [SerializeField] private Transform pies;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private float alturaSalto;
    private Animator animator;
    private Vector3 direccionMov;
    private Vector3 direccionInput;
    private Vector3 velocidadVertical;
    public Respawn respawn;

    private void OnEnable()
    {
        inputManager.OnSalto += Saltar;
        inputManager.OnMover += Mover;
    }

    private void Mover(Vector2 ctx)
    {
        direccionInput = new Vector3 (ctx.x, 0, ctx.y);
    }

    private void Saltar()
    {
        if (EstoyEnElSuelo()) 
        {
            velocidadVertical.y = Mathf.Sqrt(-2 * factorGravedad * alturaSalto);
            animator.SetTrigger("Jump");
        }
    }


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
        direccionMov = camara.forward * direccionInput.z + camara.right * direccionInput.x;
        direccionMov.y = 0;
        characterController.Move(direccionMov * velocidadMov * Time.deltaTime);
        animator.SetFloat ("velocidad", characterController.velocity.magnitude);
        if (direccionMov.sqrMagnitude > 0)
        {
            RotarHaciaDestino();
        }

        if (EstoyEnElSuelo() && velocidadVertical.y < 0) 
        {
            velocidadVertical.y = 0;
            animator.ResetTrigger("Jump");
        }

        AplicarGravedad();

    }
    private void AplicarGravedad()
    {
        velocidadVertical.y += factorGravedad * Time.deltaTime;
        characterController.Move(velocidadVertical * Time.deltaTime);
    }

    private bool EstoyEnElSuelo()
    {
       return Physics.CheckSphere(pies.position, radioDeteccion, queEsSuelo);
    }

    private void RotarHaciaDestino() 
    { 
        Quaternion rotacionObjetivo = Quaternion.LookRotation(direccionMov);
        transform.rotation = rotacionObjetivo;
    }


}
