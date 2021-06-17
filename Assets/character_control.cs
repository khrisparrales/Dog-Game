using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_control : MonoBehaviour
{
    public float velocidad;
    private Rigidbody2D rigidBody;
    private bool mirandoDerecha = true;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocidad=6f;
                if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey("a"))
        {
            transform.position+= Vector3.left*velocidad*Time.deltaTime;
        }
         if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey("a"))
        {
            transform.position+= Vector3.right*velocidad*Time.deltaTime;
        }

        ProcesarMovimiento();
    }

    void ProcesarMovimiento()
    {
        // Lógica de movimiento
        float inputMovimiento = Input.GetAxis("Horizontal");

       // rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y);

        GestionarOrientacion(inputMovimiento);
    }

    void GestionarOrientacion(float inputMovimiento)
    {
        // Si se cumple condición
        if ((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0))
        {
            // Ejecutar código de volteado
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
// {
//       float speed =100f;
//     public float maxspeed=10f;
//     public bool grounded;
//     Animator anim;
//     Rigidbody2D rb2d;
//     // Start is called before the first frame update
//     void Start()
//     {
//      rb2d=GetComponent<Rigidbody2D>();
//         anim = GetComponent<Animator>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         anim.SetFloat("Speed",Mathf.Abs(rb2d.velocity.x));
//         anim.SetBool("Grounded",grounded);
        
//     }
//     void FixedUpdate() {
//         float h=Input.GetAxis("Horizontal");
//         if(h>=0.0f){
// transform.localScale=new Vector3(transform.localScale.x,1f,1f);
//          }
//          if(h<0f){
//             transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
//          }
//       //  else{
//         //     transform.localScale = new Vector3(-1f, 1f, 1f);
//         // }
      
//         rb2d.AddForce(Vector2.right*speed*h);
//         float limitedspeed=Mathf.Clamp(rb2d.velocity.x,-maxspeed,maxspeed);
//         rb2d.velocity = new Vector2(limitedspeed, rb2d.velocity.y);
//         // if(rb2d.velocity.x>maxspeed){
//         //     rb2d.velocity=new Vector2(maxspeed,rb2d.velocity.y);
//         // }
//         // if (rb2d.velocity.x < -maxspeed)
//         // {
//         //     rb2d.velocity = new Vector2(-maxspeed, rb2d.velocity.y);
//         // }

//     }
// }
