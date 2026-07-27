using TMPro;
using UnityEngine;

public class Paranoia : MonoBehaviour
{
    public static int value;
    public TextMeshProUGUI tmp;

    private void Update()
    {
      if (tmp != null)
        {
            tmp.text = value.ToString();
        }  
    }

    private void OnEnable()
    {
        StatTracker.OnParanoiaChange += ChangeValue;
    }

    private void OnDisable()
    {
        StatTracker.OnParanoiaChange -= ChangeValue;
    }

    public static void ChangeValue(int amt)
    {
        value += amt;
        if (value < 0)
        {
            value = 0;
        }

        Debug.Log(value);
    }
}
