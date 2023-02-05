using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColllliderTest : MonoBehaviour
{
    [SerializeField] GameObject checkOther;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var collider = GetComponent<Collider2D>();
        var otherCollider = checkOther.GetComponent<Collider2D>();

        if(collider.IsTouching(otherCollider))
        {
            print("AOOO");
        }
    }
}
