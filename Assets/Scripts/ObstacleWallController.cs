using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWallController : MonoBehaviour
{
    public float upSpeed = 5f;
    public float downSpeed = 1f;
    public float maxHeight = 1f;
    public float minHeight =-1.4f;
    
    public bool isMovingUp = true;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
       if(isMovingUp){
        transform.Translate(Vector3.up * upSpeed * Time.deltaTime);

        if(transform.position.y >= maxHeight){
            isMovingUp = false;
        }
       
       }else{
         transform.Translate(Vector3.down * downSpeed * Time.deltaTime);

         if(transform.position.y <= minHeight){
            isMovingUp = true;
         }
       
       }
        
    }
}
