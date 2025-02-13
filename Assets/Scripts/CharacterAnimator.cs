﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{

    public delegate void AnimationCallback(bool flag);

    public SpriteRenderer spriteRenderer;

    private static CharacterAnimator _instance; //useless comment

    public Sprite[] sprites;
    private SpriteRenderer spriteR;
	private Vector3 startPos;
	private bool foot = false;
    private int[][] characterSelect = new int[][] { new int[] { 0, 1, 2, 9, 10, 11, 18, 19, 20, 27, 28, 29 },
            new int[] { 3, 4, 5, 12, 13, 14, 21, 22, 23, 30, 31, 32 },
            new int[] { 6, 7, 8, 15, 16, 17, 24, 25, 26, 33, 34, 35 } };
    private int characterInput = 2;

	public static CharacterAnimator instance {
		get {
			if (_instance == null) {
				CharacterAnimator[] list = (CharacterAnimator[])Resources.FindObjectsOfTypeAll(typeof(CharacterAnimator));
				foreach (CharacterAnimator c in list) {
					if (_instance == null) {   // add one of each type to list of istates, delete any duplicates
						_instance = c;
					} else {
						Debug.Log(string.Format("Destroyed duplicate CharacterAnimator: {0}", c.gameObject.name));
						DestroyImmediate(c.gameObject);
					}
				}
				return _instance;
			} else {
				return _instance;
			}
		}
	}

	public void Awake() {
		if (_instance == null || _instance == this) {
			_instance = this;
		} else {
			DestroyImmediate(this.gameObject);
		}
		
		startPos = this.gameObject.transform.localPosition;
	}

	readonly Vector2[] moveDir = new Vector2[] { new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0) };
    public IEnumerator<object> AnimateMovement(AnimationCallback callback, GameManager.Direction dir, float time, bool canMove)
    {
        float progress = 0.0f;
		//Vector3 startPos = this.gameObject.transform.position;
		// for some reason, changing the camera size messes this up if you use global position, so use local position instead.
		//Vector3 startPos = this.gameObject.transform.localPosition;
		Vector3 goalPos = startPos + (new Vector3(moveDir[(int)dir].x, moveDir[(int)dir].y, 0));
        

        //changes the direction of the player sprite
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        if ((int)dir == 0) {
            spriteR.sprite = sprites[characterSelect[characterInput][10]];
        }
        else if ((int)dir == 1) {
            spriteR.sprite = sprites[characterSelect[characterInput][7]];
        }
        else if ((int)dir == 2) {
            spriteR.sprite = sprites[characterSelect[characterInput][1]];
        }
        else if ((int)dir == 3) {
            spriteR.sprite = sprites[characterSelect[characterInput][4]];
        }
        foot = !foot;

		if (canMove) {
			//Slide forward
			while (progress <= time) {
				if (GameManager.getCurrentState()._stateType != GameManager.IStateType.gameplay) {
					yield return null;
					continue;
				}
				if ((int)dir == 0) {
					if (foot) {
						spriteR.sprite = sprites[characterSelect[characterInput][9]];
					}
					else {
						spriteR.sprite = sprites[characterSelect[characterInput][11]];
					}

				}
				else if ((int)dir == 1) {
					if (foot) {
						spriteR.sprite = sprites[characterSelect[characterInput][6]];
					}
					else {
						spriteR.sprite = sprites[characterSelect[characterInput][8]];
					}
				}
				else if ((int)dir == 2) {
					if (foot) {
						spriteR.sprite = sprites[characterSelect[characterInput][0]];
					}
					else {
						spriteR.sprite = sprites[characterSelect[characterInput][2]];
					}
				}
				else if ((int)dir == 3) {
					if (foot) {
						spriteR.sprite = sprites[characterSelect[characterInput][3]];
					}
					else {
						spriteR.sprite = sprites[characterSelect[characterInput][5]];
					}
				}
				progress += Time.deltaTime;
				//this.gameObject.transform.position = Vector3.Lerp(startPos, goalPos, progress / time);
				// for some reason, changing the camera size messes this up if you use global position, so use local position instead.
				this.gameObject.transform.localPosition = Vector3.Lerp(startPos, goalPos, progress / time);
				yield return null;
			}
			//Snap back
			resetPos();
			//this.gameObject.transform.position = startPos;
			// for some reason, changing the camera size messes this up if you use global position, so use local position instead.

			if ((int)dir == 0) {
				spriteR.sprite = sprites[characterSelect[characterInput][10]];
			}
			else if ((int)dir == 1) {
				spriteR.sprite = sprites[characterSelect[characterInput][7]];
			}
			else if ((int)dir == 2) {
				spriteR.sprite = sprites[characterSelect[characterInput][1]];
			}
			else if ((int)dir == 3) {
				spriteR.sprite = sprites[characterSelect[characterInput][4]];
			}
		}
		
		callback(true);
    }

	public void resetPos() {
			this.gameObject.transform.localPosition = startPos;
	}
}
