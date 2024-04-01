using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Vector3 TPCam;
    [SerializeField] private Vector3 FPCam;
    [SerializeField] private Transform Vehcile;
    private Vector3 currentCam;
    private int currentCamIndex=1;
    // Start is called before the first frame update
    void Start()
    {
        currentCam = TPCam;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            currentCamIndex++;
        }
        switch(currentCamIndex%2)
        {
            case 0:
                {
                    currentCam = FPCam;
                    break;
                }
            case 1:
                {
                    currentCam = TPCam;
                    break;
                }
                default:
                    break;
        }
        if(currentCamIndex%2==0)
        {
            transform.rotation = Vehcile.rotation;
        }
        transform.position = Player.transform.position+currentCam;
    }
}
