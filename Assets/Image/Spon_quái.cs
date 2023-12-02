using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spon_quái : MonoBehaviour
{public GameObject Quái;
    private float countdown;
    public float timeDuration;
    // Start is called before the first frame update
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
            Instantiate(Quái, new Vector3(Random.Range(-6f,250f), -3 ,0),Quaternion.identity);
            countdown = timeDuration;
        }
    }
}
