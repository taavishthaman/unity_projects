using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float loadDelay = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool collisionDisabled = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // crashParticles = GetComponent<ParticleSystem>();
        // successParticles = GetComponent<ParticleSystem>();
    }

    void Update()
    {

        RespondToDebugKeys();
    }

    void RespondToDebugKeys() {
        if(Input.GetKeyDown(KeyCode.L)) {
            LoadNextLevel();
        }
        else if(Input.GetKeyDown(KeyCode.C)) {
            collisionDisabled = !collisionDisabled; //toggle collision
        }
    }

    void OnCollisionEnter(Collision other) {
        if(isTransitioning || collisionDisabled) {
            return;
        }
        switch(other.gameObject.tag) {
            case "Friendly":
                Debug.Log("On Lanunchpad");
                break;
            case "Finished":
                StartFinishSequnce();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence() {
        isTransitioning = true;
        crashParticles.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void StartFinishSequnce() {
        isTransitioning = true;
        successParticles.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", loadDelay);
    }

    void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
