using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour
{
    SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    public void ChangeStateEat()
    {
        sp.color = new Color(1, 0, 0);
    }

    public void ChangeStateIdle()
    {
        sp.color = new Color(1, 1, 1);
    }
}
