using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputAction thrust; // InputAction -> InputSystem'den gelen bir veri tipi. thrust -> Bir input aksiyonunu temsil eder. Örneğin: Space tuşuna basıldığında.
    [SerializeField] private InputAction rotation; // rotatAction -> Bir input aksiyonunu temsil eder. Örneğin: Mouse hareketi.
    [SerializeField] private float thrustStrength = 100f;
    [SerializeField] private float rotationStrength = 100f;
    [SerializeField] AudioClip mainEngineSfx; // AudioClip -> Oyun objesine ses eklemek için kullanılır.
    [SerializeField] ParticleSystem mainEngineParticles; // ParticleSystem -> Oyun objesine efekt eklemek için kullanılır.
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;
    
    private Rigidbody _rb;
    private AudioSource _audioSource; // AudioSource -> Oyun objesine ses eklemek için kullanılır.


    private void Start()
    {
        // Rigidbody componentini alıyoruz. çünkü bu scripti Rigidbody olan bir objeye ekleyeceğiz.
        //  GetComponent -> Oyun objesinin componentlerine erişmek için kullanılır.
        _rb = GetComponent<Rigidbody>(); 
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() // OnEnable -> Script aktif hale geldiğinde çalışır.
    {
        // Burada InputAction'ı aktif hale getiriyoruz. çünkü bu scripti kullanmaya başladığımızda InputAction'ı da kullanmaya başlamamız gerekiyor.
        thrust.Enable(); 
        rotation.Enable();
    }

    private void FixedUpdate() // FixedUpdate -> Fiziksel işlemler için kullanılır. Örneğin Rigidbody ile ilgili işlemler.
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessRotation() // ProcessRotation -> Oyun objesini döndürür.
    {
        float rotationInput = rotation.ReadValue<float>(); // ReadValue -> InputAction'ın değerini okur.
        if (rotationInput < 0)
        {
            ApplyRotation(rotationStrength);
        } else if (rotationInput > 0)
        {
            ApplyRotation(-rotationStrength);
        }

        // ParticleSystem'leri çalıştırır.
        HandleThrusterParticles(rotationInput);
        
    }

    private void HandleThrusterParticles(float rotationInput)
    {
        if (rotationInput < 0)
        {
            rightThrusterParticles.Play();
        } else if (rotationInput > 0)
        {
            leftThrusterParticles.Play();
        }
        else
        {
            rightThrusterParticles.Stop();
            leftThrusterParticles.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame) // ApplyRotation -> Oyun objesini döndürür.
    {
        _rb.freezeRotation = true; // freezeRotation -> Rigidbody'nin dönmesini engeller.
        transform.Rotate(rotationThisFrame * Time.fixedDeltaTime * Vector3.forward); // Rotate -> Oyun objesini döndürür.
        _rb.freezeRotation = false; // freezeRotation -> Rigidbody'nin dönmesini engeller.
    }

    private void ProcessThrust() // ProcessThrust -> İleri yönde kuvvet uygular.
    {
        if (thrust.IsPressed()) // IsPressed -> Kontrol o anda basılıysa true döndürür.
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StopThrusting()
    {
        _audioSource.Stop(); // Stop -> AudioSource'yi durdurur.
        mainEngineParticles.Stop(); // Stop -> ParticleSystem'i durdurur.
    }

    private void StartThrusting()
    {
        _rb.AddRelativeForce(thrustStrength * Time.fixedDeltaTime * Vector3.up); // AddRelativeForce -> Rigidbody'ye kuvvet uygular.
            
        if (!_audioSource.isPlaying) // isPlaying -> AudioSource'nin o anda çalıp çalmadığını kontrol eder.
        {
            _audioSource.PlayOneShot(mainEngineSfx); // PlayOneShot -> AudioSource'ye bir ses ekler.  
        } 
            
        if (!mainEngineParticles.isPlaying) // isPlaying -> ParticleSystem'in o anda çalışıp çalışmadığını kontrol eder.
        {
            mainEngineParticles.Play(); // Play -> ParticleSystem'i çalıştırır.
        }
    }
}
