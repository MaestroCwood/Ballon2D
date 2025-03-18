using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class TextTutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro; // Ваш компонент текста
    private string fullText; // Текст, который нужно напечатать
    [SerializeField] private float typingSpeed = 0.05f; // Скорость печатания (время между символами)
    [SerializeField] GameObject buttonOk;
    string langage;

    private void Start()
    {
        langage = YG2.envir.language;
        fullText = TextLangage();
        StartCoroutine(TypeText());
        
    }

    // Короутина для печатания текста
    private IEnumerator TypeText()
    {
        textMeshPro.text = ""; // Очищаем текст в начале
        foreach (char letter in fullText)
        {
            textMeshPro.text += letter; // Добавляем по одному символу
            yield return new WaitForSeconds(typingSpeed); // Ждем перед добавлением следующего символа
        }
        buttonOk.SetActive(true);
    }

    public string TextLangage()
    {
        if(langage == "ru")
        {
            fullText = "Привет! Твоя задача — надувать шарики, чтобы они взлетали вверх и сталкивались с другими шариками такого же цвета.\r\n Совпали цвета? " +
                "Лопнул — получай очки!\r\n Передержал — шарик лопнет!\r\n Используй Дротики, чтобы лопнуть случайный шарик.";

        } else
        {
            fullText = "Hello! Your task is to inflate balloons so they fly up and collide with other balloons of the same color.\r\n" +
                "Colors matched? It popped — earn points!\r\nHeld too long? The balloon will burst!\r\nUse Darts to pop a random balloon.";
        }

        return fullText;    
    }
}
