using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Transform target;

    public float speed = 5f;
    public float rotatespeed = 200f;

    private Rigidbody2D rb;

    public GameObject sprite;

    public int m_amount;
    public TextMeshProUGUI amountText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        amountText.text = "+ " + m_amount.ToString();
    }

    private void setUpEffect(int item_id, int amount)
    {
        amountText.text = "+ " + amount.ToString();
    }

    private void ForceMovement()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotatespeed;

        rb.velocity = transform.up * speed;
    }

    private void FixedUpdate()
    {
        ForceMovement();
        sprite.transform.position = this.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Trigger!!");
        if (collision.gameObject.name == "TargetUI")
        {
            Destroy(gameObject);
        }
    }


}
