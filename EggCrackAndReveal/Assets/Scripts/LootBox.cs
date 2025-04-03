using System.Collections;
using UnityEngine;
using Cinemachine; // For camera animations
using DG.Tweening; // For smooth UI animations
using TMPro; // For using TextMeshPro UI elements

[RequireComponent(typeof(Collider))] // Ensures a Collider component is attached
public class LootBox : MonoBehaviour
{
    // References for animations and game objects
    public Animator cameraAnimator; // Controls camera animation
    public GameObject lootBox; // The whole loot box model
    public GameObject lootBoxFractured; // Fractured version of the loot box after opening
    public GameObject characterGO; // The object that spawns from the loot box

    // Shader and UI elements
    public Renderer lootBoxRenderer; // Material renderer for glow effect
    public string glowProperty = "_ColorIntensity"; // Property name for glow in shader
    public TMP_Text clickCounterText; // UI text to show click count

    // Private variables
    private GameObject fracturedObject; // Stores the fractured box instance
    private GameObject spawnedCharacter; // Stores the spawned loot object
    private Animator animator; // Animator reference
    private int clickCount = 0; // Tracks number of clicks
    private readonly float[] glowLevels = { 0.3f, 0.66f, 1f }; // Glow intensity steps

    private RaycastHit hit; // Stores raycast hit information
    private Ray ray; // The ray that detects mouse input

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component

        // Check if the material renderer is assigned
        if (lootBoxRenderer == null)
        {
            Debug.LogError("LootBox Renderer is not assigned!");
        }

        UpdateClickCounterUI(); // Initialize UI display
    }

    void Update()
    {
        // Create a ray from the mouse position into the world
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Check if the ray hits an object
        if (Physics.Raycast(ray, out hit))
        {
            // If the object hit is this loot box, handle interaction
            if (hit.transform.name == gameObject.name)
            {
                Hover(); // Apply hover animations

                // If left mouse button is clicked, increase glow
                if (Input.GetMouseButtonDown(0))
                {
                    IncreaseGlow();
                }
            }
            else
            {
                Idle(); // Reset to idle state if the mouse is not hovering
            }
        }
    }

    /// <summary>
    /// Handles hover state animation logic
    /// </summary>
    void Hover()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Hover", true);

        cameraAnimator.SetBool("Idle", false);
        cameraAnimator.SetBool("Hover", true);
    }

    /// <summary>
    /// Resets animations to idle state
    /// </summary>
    void Idle()
    {
        animator.SetBool("Idle", true);
        animator.SetBool("Hover", false);

        cameraAnimator.SetBool("Idle", true);
        cameraAnimator.SetBool("Hover", false);
    }

    /// <summary>
    /// Increases the glow effect of the loot box and tracks click count.
    /// On the final click, it triggers the open animation.
    /// </summary>
    private void IncreaseGlow()
    {
        if (clickCount < glowLevels.Length - 1) // Ensure we don’t exceed the array
        {
            clickCount++; // Increase click count

            // Apply glow effect if material has the required property
            if (lootBoxRenderer != null && lootBoxRenderer.material.HasProperty(glowProperty))
            {
                lootBoxRenderer.material.SetFloat(glowProperty, glowLevels[clickCount]);
            }

            UpdateClickCounterUI(); // Update UI counter

            // If it's the final click, trigger opening animation
            if (clickCount == glowLevels.Length - 1)
            {
                animator.SetBool("Open", true);
                cameraAnimator.SetBool("Open", true);
            }
        }
    }

    /// <summary>
    /// Updates the click counter UI and applies a scale animation.
    /// </summary>
    private void UpdateClickCounterUI()
    {
        if (clickCounterText != null)
        {
            clickCounterText.text = $"Clicks: {clickCount}/2"; // Update text

            // Tween effect: Scale up and return to normal smoothly
            clickCounterText.transform.DOScale(1.5f, 0.2f).SetEase(Ease.OutBounce)
                .OnComplete(() => clickCounterText.transform.DOScale(1f, 0.2f));
        }
    }

    /// <summary>
    /// Instantiates the loot reward and hides the original loot box.
    /// Called via an animation event.
    /// </summary>
    public void LootReward()
    {
        // Spawn Character 
        spawnedCharacter = Instantiate(characterGO, Vector3.zero, Quaternion.Euler(0, 180, 0));
        lootBox.SetActive(false); // Hide the main loot box

        // If a fractured version exists, instantiate it
        if (lootBoxFractured != null)
            fracturedObject = Instantiate(lootBoxFractured, transform.position, transform.rotation);

    }

}
