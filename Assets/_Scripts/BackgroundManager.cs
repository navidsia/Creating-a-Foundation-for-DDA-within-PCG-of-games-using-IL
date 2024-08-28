using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer;
    public Camera mainCamera;

    public Transform leftWall;   // Reference to the left wall
    public Transform rightWall;  // Reference to the right wall
    public Transform topWall;    // Reference to the top wall
    public Transform bottomWall; // Reference to the bottom wall
    public SpriteRenderer bottomWallRenderer; // Renderer for the bottom wall

    private string[] categories = { "Castle", "Lava", "Nature" };
    [SerializeField] int category_number;
    [SerializeField] int selected_image = -1;
    public float scaleFactor;
    public bool no_buttom;
    void Start()
    {
        // Select a random category
        category_number = Random.Range(0, categories.Length);
        category_number = 0;
        string selectedCategory = categories[category_number];

        // Load a random sprite from the selected category
        Sprite backgroundSprite = LoadRandomSpriteFromCategory(selectedCategory, "Background");


       // Sprite bottomWallSprite = LoadRandomSpriteFromCategory(selectedCategory, "Buttom wall");
        // Set the sprite while maintaining the scale
        if (backgroundSprite != null)
        {
            backgroundRenderer.sprite = backgroundSprite;

            // Set the bottom wall's sprite to the same as the background sprite
            if ( Resources.Load<Sprite>("Images/" + selectedCategory + "/" + "Buttom wall/" + backgroundSprite.name) != null)
            {
                bottomWallRenderer.sprite = Resources.Load<Sprite>("Images/" + selectedCategory + "/" + "Buttom wall/" + backgroundSprite.name);
            }
            else
            {
                // Get the current color of the sprite
                Color color = bottomWallRenderer.color;

                // Set the alpha value (0 is fully transparent, 1 is fully opaque)
                color.a = 0; // Change this value as needed

                // Apply the new color with the modified alpha
                bottomWallRenderer.color = color;
                no_buttom = true;
            }

        }


    


        // Scale the sprite to fit the camera height
        ScaleAndPositionSprites();

        // Add a 2D box collider to the bottom wall if not already present
        if (bottomWall.GetComponent<BoxCollider2D>() == null)
        {
            bottomWall.gameObject.AddComponent<BoxCollider2D>();
        }
    }
       private Sprite GetTransparentSprite()
        {
            // Create a 1x1 pixel texture
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, new Color(0, 0, 0, 0)); // Set pixel to fully transparent
            texture.Apply();

            // Create a sprite from the texture
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    Sprite LoadRandomSpriteFromCategory(string category, string subfolder)
    {
        string path = "Images/" + category + "/" + subfolder;
        Sprite[] sprites = Resources.LoadAll<Sprite>(path);

        if (sprites.Length == 0)
        {
            Debug.LogWarning("No sprites found in " + path);
            return null;
        }
        if(selected_image >=0)
        {
            selected_image = Random.Range(0, sprites.Length);

        }
        return sprites[selected_image];
    }

    void ScaleAndPositionSprites()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Get the height of the camera view in world units
        float height = 2f * mainCamera.orthographicSize;

        // Scale the background height to fit the camera view height while keeping the width unchanged
        scaleFactor = height / backgroundRenderer.sprite.bounds.size.y;
        backgroundRenderer.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);

        // Position the walls at the edges of the background and adjust their scale
        PositionAndScaleWalls(height);
    }

    void PositionAndScaleWalls(float backgroundHeight)
    {
        // Calculate half size for positioning
        float halfBackgroundHeight = backgroundHeight / 2f;

        // Adjust and position the left and right walls based on background width
        float backgroundWidth = backgroundRenderer.sprite.bounds.size.x * backgroundRenderer.transform.localScale.x;
        float halfBackgroundWidth = backgroundWidth / 2f;
        float wallThickness = leftWall.localScale.x; // Assuming the width of the left/right walls is controlled by x scale
        leftWall.position = new Vector3(-halfBackgroundWidth + wallThickness / 2, 0, 0);
        rightWall.position = new Vector3(halfBackgroundWidth - wallThickness / 2, 0, 0);

        // Adjust the height of the left and right walls to match the background's height
        leftWall.localScale = new Vector3(leftWall.localScale.x, backgroundHeight, leftWall.localScale.z);
        rightWall.localScale = new Vector3(rightWall.localScale.x, backgroundHeight, rightWall.localScale.z);

        // Get the camera's world boundaries
        float halfHeight = mainCamera.orthographicSize;
        float halfWidth = halfHeight * mainCamera.aspect;

        leftWall.position = new Vector3(-halfWidth + wallThickness / 2, 0, 0);
        rightWall.position = new Vector3(halfWidth - wallThickness / 2, 0, 0);

        // Adjust the height of the left and right walls to match the camera's height
        leftWall.localScale = new Vector3(leftWall.localScale.x, backgroundHeight, leftWall.localScale.z);
        rightWall.localScale = new Vector3(rightWall.localScale.x, backgroundHeight, rightWall.localScale.z);

        // Adjust and position the bottom wall
        float wallThicknessY = halfHeight * 0.1f; // Set height to 0.1 of the camera height
        float bottomWallYPosition = -halfHeight + (halfHeight * 0.05f); // Set Y position to 0.05 of the camera height from the bottom
     //   bottomWall.position = new Vector3(0, bottomWallYPosition, 0);

        // Set the width of the bottom wall to match the scale of the background's width
     //   bottomWall.localScale = new Vector3(scaleFactor * backgroundRenderer.sprite.bounds.size.x, wallThicknessY, bottomWall.localScale.z);

        // Adjust the top wall's scale and position
        topWall.position = new Vector3(0, halfBackgroundHeight - wallThicknessY / 2, 0);
        topWall.localScale = new Vector3(backgroundWidth, topWall.localScale.y, topWall.localScale.z);


        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Get the height of the camera view in world units
        float height = 2f * mainCamera.orthographicSize;

        // Scale the background height to fit the camera view height while keeping the width unchanged
        scaleFactor = height / bottomWallRenderer.sprite.bounds.size.y;
        if (!no_buttom)
        {
            bottomWallRenderer.transform.localScale = new Vector3(scaleFactor, scaleFactor / 10, 1);

            bottomWall.position = new Vector3(0, -(halfBackgroundHeight - wallThicknessY / 2) * 0.95f, 0);
        }
        else
        {
            bottomWallRenderer.transform.localScale = new Vector3(20, 1, 1);

            bottomWall.position = new Vector3(0, -(halfBackgroundHeight - wallThicknessY / 2) * 1.1f, 0);
        }



    }

    void Update()
    {
        // Optionally call this in Update if the camera size changes dynamically during runtime
        ScaleAndPositionSprites();
    }
}
