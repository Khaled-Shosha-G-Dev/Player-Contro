using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
                        //To Show Speed for Car
    [SerializeField] private  PlayerControler playerControler;
    [SerializeField] private TextMeshProUGUI speedText;

                        //Sounds
    [SerializeField] private AudioSource backGroundAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerControler=GameObject.Find("Player").GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowSpeed(playerControler.speed);
    }
    void ShowSpeed(float speed)
    {

        speedText.text = "Speed : " + Mathf.Floor(speed) + " Km/h";
    }
}
