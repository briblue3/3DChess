using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class test : MonoBehaviour
{

    public Text text;
    private int i;
    public bool stop;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            text.text += "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT " + i++;
        }
    }
}
