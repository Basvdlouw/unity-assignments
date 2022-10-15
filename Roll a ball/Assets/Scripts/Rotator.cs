using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

public class Rotator : MonoBehaviour

{
    public float speed = 5f;
}

class RotatorSystem : ComponentSystem {
    struct Component {
        public Rotator rotator;
        public Transform transform;
    }

    protected override void OnUpdate() {
        foreach (var e in GetEntities<Component>()) {
            e.transform.Rotate(2f, e.rotator.speed * Time.deltaTime, 3f);
        }
    }
}
