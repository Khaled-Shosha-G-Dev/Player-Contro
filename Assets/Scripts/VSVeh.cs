using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSVeh : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject veh;
    private bool isTouched=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched)
            veh.transform.Translate(Vector3.forward*Time.deltaTime*speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            isTouched=true;

        else if(other.CompareTag("Finish"))
        {
            Destroy(veh);
            //Destroy(gameObject);
        }
    }
}
