using UnityEngine;
using UnityEngine.UI;

public class FlyText : MonoBehaviour
{
    public float distance = 50;
    public Color color;
    public string content;
    public Transform trans;

    Text textBox;
    private Vector2 pos;
    void Start()
    {
        if (trans != null)
        {
            pos = Camera.main.WorldToScreenPoint(trans.position);
        }
        else
        {
            pos = textBox.rectTransform.anchoredPosition;
        }
        textBox = transform.GetComponent<Text>();
        textBox.text = content;
        textBox.color = color;
        textBox.rectTransform.anchoredPosition = pos;
        textBox.rectTransform.anchoredPosition = new Vector2(textBox.rectTransform.anchoredPosition.x, textBox.rectTransform.anchoredPosition.y + distance);
    }

    float fadeTimer = 1;
    void Update()
    {
        if (fadeTimer >= 0)
        {
            fadeTimer -= Time.deltaTime;
            textBox.color = new Color(color.r, color.g, color.b, fadeTimer);
            textBox.rectTransform.anchoredPosition = new Vector2(textBox.rectTransform.anchoredPosition.x, textBox.rectTransform.anchoredPosition.y + (1 - fadeTimer));
        }
        if (fadeTimer < 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

}
