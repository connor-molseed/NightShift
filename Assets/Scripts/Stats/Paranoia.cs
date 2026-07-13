using UnityEngine;

public class Paranoia : MonoBehaviour
{
    public int value;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseValue(int amt)
    {
        value += amt;
    }

    public void DecreaseValue(int amt)
    {
        value -= amt;
        if (value < 0)
        {
            value = 0;
        }
    }
}
