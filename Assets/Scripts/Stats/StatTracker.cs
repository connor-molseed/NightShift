using System;
using UnityEngine;

public static class StatTracker
{
    public static event Action<int> OnParanoiaChange;

    public static void ModifyParanoia(int amt)
    {
        OnParanoiaChange?.Invoke(amt);
    }
}
