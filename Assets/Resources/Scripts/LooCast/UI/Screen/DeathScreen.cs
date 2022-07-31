using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.UI.Canvas;

namespace LooCast.UI.Screen
{
    public class DeathScreen : Screen
    {
        private UnityEngine.UI.Button continueButton;
        private Animator fade;
        private Animator gameOver;
        private float fadeTime;
        private float fadeTimer = 0.0f;
        private float gameOverTime;
        private float gameOverTimer = 0.0f;
        private float gameOverMoveTime;
        private float gameOverMoveTimer = 0.0f;
        private bool isFading = false;
        private bool isGameOvering = false;
        private bool isGameOverMoving = false;
        private bool isGameOver = false;

        public override void Initialize(InterfaceCanvas canvas)
        {
            isInitiallyVisible = false;
            isHideable = true;


            continueButton = transform.Find("Continue").GetComponent<UnityEngine.UI.Button>();
            fade = transform.Find("Fade").GetComponent<Animator>();
            gameOver = transform.Find("GameOverText").GetComponent<Animator>();
            fadeTime = Resources.Load<AnimationClip>("Animations/UI/Fade").length;
            gameOverTime = Resources.Load<AnimationClip>("Animations/UI/GameOverTextFade").length;
            gameOverMoveTime = Resources.Load<AnimationClip>("Animations/UI/GameOverTextMove").length;


            base.Initialize(canvas);
        }

        private void Update()
        {
            if (isFading)
            {
                fadeTimer += Time.deltaTime;
                if (fadeTimer >= fadeTime)
                {
                    isFading = false;
                    isGameOvering = true;
                    gameOver.gameObject.SetActive(true);
                    gameOver.Play("GameOverTextFade");
                }
            }

            if (isGameOvering)
            {
                gameOverTimer += Time.deltaTime;
                if (gameOverTimer > gameOverTime)
                {
                    isGameOvering = false;
                    isGameOverMoving = true;
                    gameOver.Play("GameOverTextMove");
                }
            }

            if (isGameOverMoving)
            {
                gameOverMoveTimer += Time.deltaTime;
                if (gameOverMoveTimer > gameOverMoveTime)
                {
                    isGameOverMoving = false;
                    isGameOver = true;
                    OnGameOver();
                }
            }

            if (isGameOver)
            {

            }
        }

        public override void SetVisibility(bool show)
        {
            if (show)
            {
                canvas.screenStack.Push(this);
                transform.SetAsLastSibling();
                IsVisible = true;
                fade.gameObject.SetActive(true);
                fade.Play("Fade");
                isFading = true;
            }
        }

        private void OnGameOver()
        {
            continueButton.gameObject.SetActive(true);
        }
    } 
}
