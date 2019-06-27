using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{
    int hp = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        Text t = gameObject.GetComponent<Text>();
        string s = hp.ToString();
        s = t.text[0] + s;
        t.text = s;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change(int m)
    {
        Text t = gameObject.GetComponent<Text>();
        string s = m.ToString();
        s = t.text[0] + s;
        t.text = s;
    }
}
