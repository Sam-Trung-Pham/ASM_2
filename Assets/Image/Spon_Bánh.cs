using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spon : MonoBehaviour
{
    public GameObject Bánh;
    //public GameObject Quái;
    private float countdown;
    public float timeDuration;
    private void Awake()
    {
        countdown = timeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;// mỗi frame countdown -=1/fps
        if (countdown<=0)
        {
            // Debug.Log("Sinh ra 1 hình vuông");
            Instantiate(Bánh, new Vector3(Random.Range(-6f,250f), 0 ,0),Quaternion.identity);
            countdown = timeDuration;
        }
    }
    }
