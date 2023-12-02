using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private Rigidbody2D rigi;
    public int dung = 2;

    public int trai = 4;

    public int phai = 5;

    public int danh = 9;

    public int truong = 7;

    public Animator monkAni;
   
    public GameObject skill;

    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        monkAni = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    // Update is called once per frame
    void Update()
    {
        // nhảy
        if (Input.GetKey(KeyCode.Space))
        {
            rigi.AddForce(Vector2.up*10f);
            //skill.GetComponent<BanController>().direction= Vector3.up;
            
        }
        // di chuyển phải
        else if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            monkAni.SetInteger("Status",phai);
            transform.Translate(Vector3.right*speed*Time.deltaTime);
            skill.GetComponent<BanController>().direction= Vector3.right;
            skill.GetComponent<SpriteRenderer>().flipX = false; 
        }
        // di chuyển trái
        else if (Input.GetKey(KeyCode.A)|| (Input.GetKey(KeyCode.LeftArrow)))
        {
            monkAni.SetInteger("Status",trai);
            transform.Translate(Vector3.left*speed*Time.deltaTime);
            skill.GetComponent<BanController>().direction= Vector3.left;
            skill.GetComponent<SpriteRenderer>().flipX = true;
        }
        // bắn đạn
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            //monkAni.SetInteger("Status",truong);
            Instantiate(skill, transform.position, Quaternion.identity);
        }
        else
        {
            monkAni.SetInteger("Status",dung);
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Quai")
        {
            Destroy(other.gameObject);
            TakeDamamge(20);
        }
        if (other.gameObject.tag=="Bánh")
        {
            Destroy(other.gameObject);
            IncreaseHealth(10);
        }
    }
    void TakeDamamge(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    void UpdateHealthBar()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Đảm bảo giá trị máu không vượt quá maxHealth
        healthBar.SetHealth(currentHealth);
    }
    void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        UpdateHealthBar();
    }
}
