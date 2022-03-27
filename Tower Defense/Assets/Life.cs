using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    static int lives = 20;
    [SerializeField] Text livesUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesUI.text = lives.ToString();
    }
    public void TookLife()
    {
        lives--;
    }
}
