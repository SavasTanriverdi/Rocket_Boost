using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay; // levelLoadDelay -> Sahnenin yüklenme süresi.
    [SerializeField] private AudioClip crashSound; // crashSound -> Çarpma sesi.
    [SerializeField] private AudioClip successSound; // successSound -> Başarı sesi.
    [SerializeField] private ParticleSystem crashParticles; // crashParticles -> Çarpma efekti.
    [SerializeField] private ParticleSystem successParticles; // successParticles -> Başarı efekti.

    private AudioSource _audioSource;

    bool _isControllable = true;
    bool _isCollidable = true;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            _isCollidable = !_isCollidable;
            Debug.Log("c key was pressed");
        }
    }

    private void OnCollisionEnter(Collision other) // OnCollisionEnter -> Oyun objesi başka bir objeye çarptığında çalışır.
    {
        // other.gameObject.tag -> Çarptığımız objenin tag'ini alır.

        if (!_isControllable || !_isCollidable) {return; } // _isControllable -> Oyun objesinin kontrol edilebilir olup olmadığını kontrol eder.

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You hit a friendly object.");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Fueld":
                Debug.Log("You hit a fuel object.");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        _isControllable = false;
        _audioSource.Stop(); // Stop -> Oyun objesinin sesini durdurur.
        _audioSource.PlayOneShot(successSound);
        successParticles.Play(); // Play -> ParticleSystem'i çalıştırır.
        
        GetComponent<Movement>().enabled = false; 
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    private void StartCrashSequence()
    {
        _isControllable = false;
        _audioSource.Stop();
        _audioSource.PlayOneShot(crashSound);
        crashParticles.Play();
        
        GetComponent<Movement>().enabled = false; // enabled -> Scriptin aktif olup olmadığını kontrol eder.
        Invoke("ReloadLevel", levelLoadDelay); // Invoke -> Belirli bir süre sonra bir metodu çalıştırır.
    }

    void ReloadLevel() // ReloadLevel -> Sahneyi yeniden yükler.
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // GetActiveScene -> Aktif olan sahneyi alır.
        SceneManager.LoadScene(currentSceneIndex); // LoadScene -> Sahneyi yükler.

    }
        
    void LoadNextLevel() // NextLevel -> Bir sonraki sahneye geçer.
    {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentSceneIndex + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings) // sceneCountInBuildSettings -> Build ayarlarında kaç tane sahne olduğunu alır.
        {
            nextScene = 0;
        }
            
        SceneManager.LoadScene(nextScene);
    }
}

