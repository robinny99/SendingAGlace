using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;
    
    public GameObject GameManager;
    public RectTransform Lever;
    
    public float speed = 1f;
    
    Rigidbody rigidbody;
    Vector3 movement;
    float _horizontal, _vertical;
 
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        if (GameManager.GetComponent<GameManager>().isMobile)
        {
            movement.Set(Lever.anchoredPosition.x, 0f, Lever.anchoredPosition.y);
            movement = movement.normalized * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + movement);
            
            animator.SetBool("isWalk", movement != Vector3.zero);
            
            Turn();
        }
        else
        {
            movement.Set(_horizontal, 0f, _vertical);
            movement = movement.normalized * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + movement);
            
            animator.SetBool("isWalk", movement != Vector3.zero);
            
            Turn();
        }
    }
    void Turn()
    {
        transform.LookAt(transform.position + movement); //Vector3.forward
    }
}
