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

    // M�todo para iniciar a rotina de "bounce" peri�dico do inimigo
    private void StartBounceRoutine()
    {
        // Chama o m�todo BounceEnemy() periodicamente com o intervalo especificado
        InvokeRepeating(nameof(BounceEnemy), 0f, bounceInterval);
    }

    private void FindBounceHelper()
    {
        bounceHelper = FindObjectOfType<BounceHelper>();
        if (bounceHelper == null)
        {
            Debug.LogWarning("BounceHelper n�o encontrado. Verifique se o script est� anexado a um GameObject na cena.");
        }
    }

    // M�todo para ser chamado periodicamente para executar o "bounce" do inimigo
    private void BounceEnemy()
    {
        // Verifica se h� um BounceHelper atribu�do
        if (bounceHelper != null)
        {
            // Chama o m�todo BounceEnemy() do BounceHelper
            bounceHelper.Bounce();
        }
    }
}

