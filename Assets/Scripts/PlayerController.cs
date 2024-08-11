using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;           // Скорость передвижения персонажа
    public float jumpForce;       // Сила прыжка

    private Rigidbody2D rb;
    [SerializeField]private bool isGrounded;      // Переменная для определения, находится ли персонаж на земле

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)   // Проверяем, нажата ли клавиша прыжка и находится ли персонаж на земле
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);  // Применяем силу прыжка к Rigidbody
            isGrounded = false;   // Указываем, что персонаж больше не на земле
        }
    }

void OnCollisionEnter2D(Collision2D collision)
{
     if(collision.gameObject.CompareTag("Ground"))   // Проверяем столкновение с объектом "земля"
     {
         isGrounded = true;   // Указываем, что персонаж стоит на земле
     }
}

}


