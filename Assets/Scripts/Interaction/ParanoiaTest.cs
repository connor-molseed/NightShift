using UnityEngine;

public class ParanoiaTest : MonoBehaviour
{
    protected void IncreaseParanoia()
    {
        Debug.Log("This was only a press");
        StatTracker.ModifyParanoia(1);
    }

    protected void DecreaseParanoia()
    {
        Debug.Log("This was a full hold!");
        StatTracker.ModifyParanoia(-1);
    }
}