using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    public void UseAbility(Interact source, CharController Character);
}
