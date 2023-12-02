using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanController : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public Vector3 direction = Vector3.right;
    void Update()
    {
        transform.Translate(direction * 20f * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Quai")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
