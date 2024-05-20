using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TriangleAnimationController : MonoBehaviour
{

    public GameObject point1, point2, point3, line1, line2, line3, triangle, scrollView, animationPlayer, playButton, pauseButton, questsButton;
    public Scrollbar scrollBar;
    public Button nextButton, previousButton;
    public TextMeshProUGUI panelText;
    public float update = 0.0f, fraction = 0.0f, timeSpent = 0.0f;
    public bool paused = true;
    public Slider slider;
    public int currentState = 0;
    List<AnimationStep> steps;


    void initSteps()
    {
        this.steps = new List<AnimationStep>();

        AnimationStep step0 = new AnimationStep();
        step0.setInitStep(
            new InitStep(delegate ()
            {
                animationPlayer.SetActive(false);
                panelText.text += "In Computer Graphics, every surface is drawn from a simplified shape, made of triangles. Let's see how they are made.";
                if (scrollBar != null)
                {
                    scrollBar.value = 0;
                }
            })
        );
        step0.setFinishStep(
            new FinishStep(delegate () { })
        );
        step0.setFinalState(
            new FinalState(delegate ()
            {
                panelText.text += "In Computer Graphics, every surface is drawn from a simplified shape, made of triangles. Let's see how they are made.";
                if (scrollBar != null)
                {
                    scrollBar.value = 0;
                }
            })
        );
        this.steps.Add(step0);

        AnimationStep step1 = new AnimationStep();
        step1.setInitStep(
            new InitStep(delegate ()
            {
                animationPlayer.SetActive(false);
                panelText.text += "\n\nEach triangle is made of 3 points, located in space:";
                if (scrollBar != null)
                {
                    scrollBar.value = 0;
                }
            })
        );
        step1.setFinishStep(
            new FinishStep(delegate () { })
        );
        step1.setFinalState(
            new FinalState(delegate ()
            {
                panelText.text += "\n\nEach triangle is made of 3 points, located in space:";
                if (scrollBar != null)
                {
                    scrollBar.value = 0;
                }
            })
        );
        this.steps.Add(step1);

        AnimationStep step2 = new AnimationStep();
        step2.setInitStep(
            new InitStep(delegate ()
            {
                animationPlayer.SetActive(false);
                point1.SetActive(true);
                panelText.text += "\n\nPoint 1 (1, 1, 0);";
                if (scrollBar != null)
                {
                    scrollBar.value = 0;
                }
            })
        );
        step2.setFinishStep(
            new FinishStep(delegate () { })
        );
        step2.setFinalState(
            new FinalState(delegate ()
            {
                point1.SetActive(true);
                panelText.text += "\n\nPoint 1 (1, 1, 0);";
                if (scrollBar != null)
                {
                    scrollBar.value = 0;
                }
            })
        );
        this.steps.Add(step2);

        AnimationStep step3 = new AnimationStep();
        step3.setInitStep(
            new InitStep(delegate ()
            {
                animationPlayer.SetActive(false);
                point2.SetActive(true);
                panelText.text += "\nPoint 2 (2, 1, 0);";
                if (scrollBar != null)
                {
                    scrollBar.value = 0;
                }
            })
        );
        step3.setFinishStep(
            new FinishStep(delegate () { })
        );
        step3.setFinalState(
            new FinalState(delegate ()
            {
                point2.SetActive(true);
                panelText.text += "\nPoint 2 (2, 1, 0);";
                if (scrollBar != null)
                {
                    scrollBar.value = 0;
                }
            })
        );
        this.steps.Add(step3);

        AnimationStep step4 = new AnimationStep();
        step4.setInitStep(
            new InitStep(delegate ()
            {
                animationPlayer.SetActive(false);
                point3.SetActive(true);
                panelText.text += "\nPoint 3 (1, 2, 0);";
                if (scrollBar != null)
                {
                    scrollBar.value = 0;
                }
            })
        );
        step4.setFinishStep(
            new FinishStep(delegate () { })
        );
        step4.setFinalState(
            new FinalState(delegate ()
            {
                point3.SetActive(true);
                panelText.text += "\nPoint 3 (1, 2, 0);";
                if (scrollBar != null)
                {
                    scrollBar.value = 0;
                }
            })
        );
        this.steps.Add(step4);

        AnimationStep step5 = new AnimationStep();
        step5.setInitStep(
            new InitStep(delegate ()
            {
                animationPlayer.SetActive(false);
                panelText.text += "\n\nThese points are joined and the corresponding triangle is drawn.";
                if (scrollBar != null)
                {
                    scrollBar.value = 0;
                }
            })
        );
        step5.setFinishStep(
            new FinishStep(delegate () { })
        );
        step5.setFinalState(
            new FinalState(delegate ()
            {
                panelText.text += "\n\nThese points are joined and the corresponding triangle is drawn.";
                if (scrollBar != null)
                {
                    scrollBar.value = 0;
                }
            })
        );
        this.steps.Add(step5);

        AnimationStep step6 = new AnimationStep(2.0f);
        step6.setUpdateStep(
            new UpdateStep(delegate (float update)
            {
                if (update >= step6.getDuration())
                {
                    step6.finishStep();
                    return;
                }
                fraction = update / step6.getDuration();
                slider.value = fraction;
                line1.GetComponent<Transform>().localScale = new Vector3(0.01f, fraction * 0.5f, 0.01f);
                line2.GetComponent<Transform>().localScale = new Vector3(0.01f, fraction * 0.7f, 0.01f);
                line3.GetComponent<Transform>().localScale = new Vector3(0.01f, fraction * 0.5f, 0.01f);
            })
        );
        step6.setInitStep(
            new InitStep(delegate ()
            {
                animationPlayer.SetActive(true);
                slider.value = 0.0f;
                pressPause();
                line1.GetComponent<Transform>().localScale = new Vector3(0.01f, 0.0f, 0.01f);
                line2.GetComponent<Transform>().localScale = new Vector3(0.01f, 0.0f, 0.01f);
                line3.GetComponent<Transform>().localScale = new Vector3(0.01f, 0.0f, 0.01f);
                line1.SetActive(true);
                line2.SetActive(true);
                line3.SetActive(true);
            })
        );
        step6.setFinishStep(
            new FinishStep(delegate ()
            {
                slider.value = 1.0f;
                line1.GetComponent<Transform>().localScale = new Vector3(0.01f, 0.5f, 0.01f);
                line2.GetComponent<Transform>().localScale = new Vector3(0.01f, 0.7f, 0.01f);
                line3.GetComponent<Transform>().localScale = new Vector3(0.01f, 0.5f, 0.01f);
            })
        );
        step6.setFinalState(
            new FinalState(delegate ()
            {
                line1.SetActive(true);
                line1.GetComponent<Transform>().localScale = new Vector3(0.01f, 0.5f, 0.01f);
                line2.SetActive(true);
                line2.GetComponent<Transform>().localScale = new Vector3(0.01f, 0.7f, 0.01f);
                line3.SetActive(true);
                line3.GetComponent<Transform>().localScale = new Vector3(0.01f, 0.5f, 0.01f);
            })
        );
        this.steps.Add(step6);

        AnimationStep step7 = new AnimationStep(2.0f);
        step7.setUpdateStep(
            new UpdateStep(delegate (float update)
            {
                if (update >= step7.getDuration())
                {
                    step7.finishStep();
                    return;
                }
                fraction = update / step7.getDuration();
                slider.value = fraction;
                triangle.GetComponent<Renderer>().material.color = new Color(fraction, fraction, fraction, 1.0f);
            })
        );
        step7.setInitStep(
            new InitStep(delegate ()
            {
                if (!questsButton.activeSelf)
                {
                    questsButton.SetActive(true);
                }
                animationPlayer.SetActive(true);
                slider.value = 0.0f;
                pressPause();
                triangle.SetActive(true);
                triangle.GetComponent<Triangle>().updateVertices(1f, 1f, 0f, 2f, 1f, 0f, 1f, 2f, 0f);
                triangle.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            })
        );
        step7.setFinishStep(
            new FinishStep(delegate ()
            {
                slider.value = 1.0f;
                triangle.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                point1.SetActive(false);
                point2.SetActive(false);
                point3.SetActive(false);
                line1.SetActive(false);
                line2.SetActive(false);
                line3.SetActive(false);
            })
        );
        step7.setFinalState(
            new FinalState(delegate ()
            {
                triangle.SetActive(true);
                Color tempColor = triangle.GetComponent<Renderer>().material.color;
                triangle.GetComponent<Renderer>().material.color = new Color(tempColor.r, tempColor.g, tempColor.b, 1.0f);
                point1.SetActive(false);
                point2.SetActive(false);
                point3.SetActive(false);
                line1.SetActive(false);
                line2.SetActive(false);
                line3.SetActive(false);
            })
        );
        this.steps.Add(step7);

        this.steps[0].initStep();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.initSteps();
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("explanationTime", timeSpent);
    }

    public void pressPlay()
    {
        paused = false;
        pauseButton.SetActive(true);
        playButton.SetActive(false);
    }

    public void pressPause()
    {
        paused = true;
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void changeSlider()
    {
        update = slider.value * steps[currentState].getDuration();
        if (currentState == 7)
        {
            point1.SetActive(true);
            point2.SetActive(true);
            point3.SetActive(true);
            line1.SetActive(true);
            line2.SetActive(true);
            line3.SetActive(true);
        }
        steps[currentState].updateStep(update);
    }

    public void pressNext()
    {
        if (currentState == 0)
        {
            previousButton.interactable = true;
        }
        steps[currentState].finishStep();
        currentState++;
        if (currentState != steps.Count)
        {
            steps[currentState].initStep();
            update = 0.0f;
            if (currentState == steps.Count - 1)
            {
                nextButton.interactable = false;
            }
        }
    }

    public void pressPrevious()
    {
        if (currentState == steps.Count - 1)
        {
            nextButton.interactable = true;
        }
        resetAnimation();
        currentState--;
        for (int i = 0; i < currentState; i++)
        {
            steps[i].finalState();
        }
        steps[currentState].initStep();
        update = 0.0f;
        if (currentState == 0)
        {
            previousButton.interactable = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        timeSpent += Time.deltaTime;
        if (currentState < steps.Count && steps[currentState].hasUpdate())
        {
            if (paused)
            {
                return;
            }
            update += Time.deltaTime;
            steps[currentState].updateStep(update);
        }
    }

    private void resetAnimation()
    {
        panelText.text = "";
        point1.SetActive(false);
        point2.SetActive(false);
        point3.SetActive(false);
        line1.SetActive(false);
        line2.SetActive(false);
        line3.SetActive(false);
        triangle.SetActive(false);
    }
}
