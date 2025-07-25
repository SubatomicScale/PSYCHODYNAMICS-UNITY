using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager gm { get; private set; }

    public UnitHealth playerHealth = new UnitHealth(100, 100);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(this);
        }
        else
        {
            gm = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic can be added here if needed 

    }

}
