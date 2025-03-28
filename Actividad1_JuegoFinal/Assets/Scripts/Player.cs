using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float inputH;
    private float inputV;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private float fuerzaMovimiento;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        inputV = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up *  fuerzaSalto, ForceMode.Impulse);
        }
    }

    //Fisicas CONTINUAS
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(inputH, 0, inputV) * fuerzaMovimiento, ForceMode.Force);
    }
}
