using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fallingoff : MonoBehaviour
{
    public float threshold = -10f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < threshold){
                GameManager.Instance.HandleCurrentLevelFailure();
         
            
        }
        
    }

    
}
