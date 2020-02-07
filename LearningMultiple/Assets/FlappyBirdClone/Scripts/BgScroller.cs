using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour
{
    [SerializeField]
    private float bgMinPos = -65f;

    [SerializeField]
    private float scrollVel = -10f;

    [SerializeField]
    private List<Transform> backgrounds = null;

    private List<SpriteRenderer> bgSpritesRends = null;

    private void Awake()
    {
        bgSpritesRends = new List<SpriteRenderer>(backgrounds.Count);
        foreach (var bg in backgrounds)
        {
            var bgSpriteRend = bg.GetComponent<SpriteRenderer>();
            bgSpritesRends.Add(bgSpriteRend);
        }
    }

    private void Start()
    {
        for (int i = 0; i < backgrounds.Count; i++)
        {
            var bg = backgrounds[i];
            float posX;

            if (i == 0)
            {
                var bgSprite = bgSpritesRends[i];
                posX = 0 - bgSprite.bounds.extents.x;

                bg.position = new Vector2(posX, 0f);
                continue;
            }

            var prevBg = backgrounds[i - 1];
            var prevBgSprite = bgSpritesRends[i - 1];

            posX = prevBg.position.x + prevBgSprite.bounds.extents.x * 2;
            bg.position = new Vector2(posX, 0f);
        }
    }

    private void Update()
    {
        for(int i = 0; i < backgrounds.Count; i++)
        {
            var bg = backgrounds[i];
            bg.position += new Vector3(scrollVel * Time.deltaTime, 0f);

            if (bg.position.x < bgMinPos)
            {
                int prevIx = (i - 1) < 0
                        ? backgrounds.Count - 1
                        : i - 1;
                Debug.Log(prevIx);

                var prevBg = backgrounds[prevIx];
                var prevBgSprite = bgSpritesRends[prevIx];

                float posX = prevBg.position.x + prevBgSprite.bounds.extents.x * 2;
                bg.position = new Vector3(posX, 0f);
            }
        }
    }

}
