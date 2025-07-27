using UnityEngine;

public class ArmsPosition : MonoBehaviour
{

    public Transform orientation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = orientation.position;
    }
}
