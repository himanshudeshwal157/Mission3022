using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoCome : MonoBehaviour
{
    Vector3 StartingPosition;
    [SerializeField] Vector3 MoveVector;
    [SerializeField] [Range(0,1)] float MoveFactor;
    [SerializeField] float period = 2f;


    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return;}
        float Cycle = Time.time/ period; // grow over period
        const float tau = Mathf.PI*2;    //tau 6.28
    
        float RawSinWave=Mathf.Sin(Cycle* tau);  // growing from -1 to 1

        MoveFactor = (RawSinWave +1f/2f);     //regulated to go from -1 to 1 

        Vector3 offset = MoveVector*MoveFactor; 
        transform.position=StartingPosition+offset;

        
    }
}
