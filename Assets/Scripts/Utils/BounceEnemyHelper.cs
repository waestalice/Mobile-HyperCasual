using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEnemyHelper : MonoBehaviour
{
    private BounceHelper bounceHelper;

    public float bounceInterval = 2f; // Intervalo de tempo entre cada "bounce" do inimigo

    private void Start()
    {
        FindBounceHelper();

        // Inicia o processo de "bounce" do inimigo
        StartBounceRoutine();
    }

    // Método para iniciar a rotina de "bounce" periódico do inimigo
    private void StartBounceRoutine()
    {
        // Chama o método BounceEnemy() periodicamente com o intervalo especificado
        InvokeRepeating(nameof(BounceEnemy), 0f, bounceInterval);
    }

    private void FindBounceHelper()
    {
        bounceHelper = FindObjectOfType<BounceHelper>();
        if (bounceHelper == null)
        {
            Debug.LogWarning("BounceHelper não encontrado. Verifique se o script está anexado a um GameObject na cena.");
        }
    }

    // Método para ser chamado periodicamente para executar o "bounce" do inimigo
    private void BounceEnemy()
    {
        // Verifica se há um BounceHelper atribuído
        if (bounceHelper != null)
        {
            // Chama o método BounceEnemy() do BounceHelper
            bounceHelper.Bounce();
        }
    }
}

