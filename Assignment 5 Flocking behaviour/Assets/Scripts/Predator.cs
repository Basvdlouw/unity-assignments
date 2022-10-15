using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : Agent
{
   protected override Vector3 Combine()
    {
       return base.conf.Kw * base.wander();
    }
}
