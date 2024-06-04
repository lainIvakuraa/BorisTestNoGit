using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] GameObject Joy;
    [SerializeField] GameObject Sprite;

    void Update()
    {
        GameObject handle = Joy.transform.GetChild(0).GetChild(0).gameObject;
        SpriteRenderer sr = Sprite.GetComponent<SpriteRenderer>();

        // Анимация ходьбы/ожидания
        bool move = false;

        if((handle.transform.localPosition.x != 0) || (handle.transform.localPosition.y != 0))
            move = true;


        this.GetComponent<Animator>().SetBool("isMoving", move);
        

        // Отражение спрайта в сторону движения
        
        bool mirror = true;

        if (handle.transform.localPosition.x > 0)
            mirror = false;

        
        sr.flipX = mirror;
    }
}
