using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digest : MonoBehaviour
{
    float Scale = 1;
    float NutrientValue;
    Vector3 targetPosition = Vector3.up;
    Slime SlimeEating;
    void Start()
    {
        SlimeEating = GetComponentInParent<Slime>();
        NutrientValue = GetComponent<Item>().Quality;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.parent.position + targetPosition, Time.deltaTime*.5f);
        if (transform.position == transform.parent.position)
        {
            //WARNING HARD CODED SLIME BLORBLING
            targetPosition = (Vector3.up * Random.Range(0.25f, 1.2f) + Vector3.right * Random.Range(-0.8f, 0.8f));
        }

        Scale -= 0.01f * Time.deltaTime;
        transform.localScale = Vector3.one * Scale;

        if (Scale < 0.01f)
        {
            SlimeEating.Hunger += NutrientValue;
            Destroy(gameObject);
        }
    }


}
