using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg : MonoBehaviour
{
    public float speedbg = 0.5f;

    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // background vô hạn
        offset += Time.deltaTime * speedbg;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0);
    }
}
