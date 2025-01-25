using System;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector; // movementVector -> Oyun objesinin hareket edeceği vektör.
    [SerializeField] private float speed; // speed -> Oyun objesinin hızı.
    
    private Vector3 starPosition; // startingPos -> Oyun objesinin başlangıç pozisyonu.
    private Vector3 endPosition; // movementFactor -> Oyun objesinin hareket faktörü.
    private float movementFactor; // movementFactor -> Oyun objesinin hareket faktörü.
    
    
    private void Start()
    {
        starPosition = transform.position; // transform.position -> Oyun objesinin pozisyonunu alır.
        endPosition = starPosition + movementVector;
    }

    private void Update()
    {
        movementFactor = Mathf.PingPong(Time.time * speed, 1f); // Mathf.Sin -> Bir sayının sinüs değerini alır.
        transform.position = Vector3.Lerp(starPosition, endPosition, movementFactor); // Lerp -> İki vektör arasında geçiş yapar.
    }
}
