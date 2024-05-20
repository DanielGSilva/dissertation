using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeController : MonoBehaviour
{
    public Button squares;
    public GameObject line;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("skillTree") == 1)
        {
            squares.interactable = true;
            line.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
