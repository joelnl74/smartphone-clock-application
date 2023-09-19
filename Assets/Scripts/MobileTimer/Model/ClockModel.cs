using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockModel
{
    public long TimeStamp { get; private set; }

    public ClockModel(long timeStamp)
    {
        TimeStamp = timeStamp;
    }

    public void SetTimer(long timeStamp)
        => this.TimeStamp = timeStamp;
}
