using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatReset : MonoBehaviour
{
public NeedsItem ToReset;

    // Update is called once per frame
    public void Reset()
    {
        ToReset.Ready=true;
    }
}
