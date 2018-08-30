using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLaserStatic : MonoBehaviour {

    Animator leftGeneratorAnimator;
    Animator rightGeneratorAnimator;
    Animator middleAnimator;
    GameObject leftGenerator;
    GameObject rightGenerator;
    GameObject middle;
    BoxCollider2D collider;
    SpriteRenderer middleSpriteRenderer;
    float widthOfGreenLaser;

    // Use this for initialization
    void Start () {
        leftGenerator = transform.Find("LeftGenerator").gameObject;
        rightGenerator = transform.Find("RightGenerator").gameObject;
        middle = transform.Find("Middle").gameObject;
        rightGeneratorAnimator = rightGenerator.GetComponent<Animator>();
        leftGeneratorAnimator = leftGenerator.GetComponent<Animator>();
        middleAnimator = middle.GetComponent<Animator>();
        collider = gameObject.GetComponent<BoxCollider2D>();
        RectTransform rectTrans = gameObject.GetComponent<RectTransform>();
        collider.size = new Vector2(widthOfGreenLaser = rectTrans.rect.width, rectTrans.rect.height);
        middleSpriteRenderer = middle.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        middleSpriteRenderer.size = new Vector2(widthOfGreenLaser - 1f, middleSpriteRenderer.size.y);

        if (Input.GetKeyDown(KeyCode.C))
        {
            leftGeneratorAnimator.SetBool("Fire", !leftGeneratorAnimator.GetBool("Fire"));
            rightGeneratorAnimator.SetBool("Fire", !rightGeneratorAnimator.GetBool("Fire"));
            middleAnimator.SetBool("Fire", !middleAnimator.GetBool("Fire"));
        }
	}
}
