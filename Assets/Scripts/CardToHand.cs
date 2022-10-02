using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToHand : MonoBehaviour
{

    public GameObject Hand;
    public GameObject CardInHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hand = GameObject.Find("Hand");
        CardInHand.transform.SetParent(Hand.transform);
        CardInHand.transform.localScale = Vector3.one;
        CardInHand.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        CardInHand.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}
