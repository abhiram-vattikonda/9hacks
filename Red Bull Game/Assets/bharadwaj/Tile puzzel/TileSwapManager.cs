using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TileSwapManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform gridParent;
    public List<Sprite> tileSprites;

    private Tile firstSelected = null;
    private List<Tile> tiles = new List<Tile>();

    public Image logoPreview; // Show full image for few seconds

    void Start()
    {

        StartCoroutine(ShowPreviewAndStart());
            image = GetComponent<Image>();

    }

    IEnumerator ShowPreviewAndStart()
    {
        logoPreview.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        logoPreview.gameObject.SetActive(false);

        CreateTiles();
    }

    void CreateTiles()
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < tileSprites.Count; i++)
            indices.Add(i);

        // Shuffle
        for (int i = 0; i < indices.Count; i++)
        {
            int rand = Random.Range(i, indices.Count);
            (indices[i], indices[rand]) = (indices[rand], indices[i]);
        }

        // Create tiles
        for (int i = 0; i < tileSprites.Count; i++)
        {
            GameObject tileGO = Instantiate(tilePrefab, gridParent);
            Tile tile = tileGO.GetComponent<Tile>();
            tile.SetTile(tileSprites[indices[i]], i, indices[i]);
            Button btn = tileGO.GetComponent<Button>();
            int tileIndex = i;
            btn.onClick.AddListener(() => OnTileClicked(tile));
            tiles.Add(tile);
        }
    }

    void OnTileClicked(Tile clickedTile)
    {
        if (firstSelected == null)
        {
            firstSelected = clickedTile;
            return;
        }

        // Swap visuals
        Sprite tempSprite = clickedTile.image.sprite;
        clickedTile.image.sprite = firstSelected.image.sprite;
        firstSelected.image.sprite = tempSprite;

        // Swap indices
        int tempIndex = clickedTile.currentIndex;
        clickedTile.currentIndex = firstSelected.currentIndex;
        firstSelected.currentIndex = tempIndex;

        firstSelected = null;
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        foreach (Tile tile in tiles)
        {
            if (tile.currentIndex != tile.correctIndex)
                return;
        }

        Debug.Log("Puzzle Complete!");
        ShowFinalLogo();
    }

    void ShowFinalLogo()
    {
        logoPreview.gameObject.SetActive(true);
        // Optional: trigger animation, confetti, etc.
    }
}
