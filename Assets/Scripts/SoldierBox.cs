using UnityEngine;
using TMPro; 

public class SoldierBox : MonoBehaviour
{
    public int soldiersToAdd;           
    public GameObject soldierPrefab;    
    public float clusterRadius = 2.0f;  
    public int maxSoldiers = 150;

    [SerializeField]
    public float moveSpeed = 15.0f; 

    public TextMeshPro numberText; 

    private bool hasBeenCollected;
    
    public Renderer boxRenderer;

    public Color verde = new Color(0f, 1f, 0f, 0.5f); 
    public Color rojo = new Color(1f, 0f, 0f, 0.5f); 

    void Start()
    {
        //soldiersToAdd = Random.Range(-10, 0);
        UpdateText(); 
    }

    void Update()
    {
        // Mover la caja hacia el jugador
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        if (soldiersToAdd > 0) 
        {
            boxRenderer.material.color = verde;
        }
        if (soldiersToAdd < 0) 
        {
            boxRenderer.material.color = rojo;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Como todos los soldiers tienen tag de "Player" para usar su hitbox
            // se necesita un bool para que no spawnee duplicado
            if (hasBeenCollected)
            {
                return;
            }

            hasBeenCollected = true;
            Debug.Log($"Adding {soldiersToAdd} soldiers to the console");
            
            // Cuantos soldados
            int currentSoldiers = other.transform.root.childCount;
            
            // limite
            int allowedToAdd = Mathf.Min(soldiersToAdd, maxSoldiers - currentSoldiers);


            if (soldiersToAdd > 0)
            {
                for (int i = 0; i < allowedToAdd; i++)
                {
                    Vector3 randomOffset = Random.insideUnitSphere * clusterRadius;
                    randomOffset.y = 0; 
                    
                    Vector3 spawnPosition = other.transform.position + randomOffset;
                    
                    Instantiate(soldierPrefab, spawnPosition, Quaternion.identity, other.transform.root);
                }
            }

            Destroy(gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            soldiersToAdd += 1;
            UpdateText(); 
            Destroy(other.gameObject);
        }
    }

    void UpdateText()
    {
        if (numberText != null)
        {
            numberText.text = soldiersToAdd.ToString();
        }
    }
}