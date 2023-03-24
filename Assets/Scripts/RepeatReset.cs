using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatReset : MonoBehaviour
{
public NeedsItem ToReset;
    public void Reset()
    {
        ToReset.Ready=true;
    }
}
