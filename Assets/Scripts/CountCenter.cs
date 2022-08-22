using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountCenter : MonoBehaviour
{
    //Classe para controlar todos los centros de las ondas que estan volviendo las paredes visibles

    Vector4[] Centers = new Vector4[49];
    float[] BackINvisible = new float[49];

    public Material Wall;
    //Como hay 49 valores mantiene todos los centros controla que cuando
    void Update()
    {
        for (int i = 0; i < BackINvisible.Length; i++)
        {

            if (BackINvisible[i] <= Time.timeSinceLevelLoad)
            {

                Centers[i] = new Vector4(0, 0, 0, 0);
                Wall.SetVectorArray("_CentersWeave", Centers);
            }
        }
    }

    public void AddCenter(Material Spuerficie, Vector4 center, float time)
    {

        for (int a = 0; a < Centers.Length; a++)
        {
            if (Centers[a] == new Vector4(0, 0, 0, 0))

            {
                BackINvisible[a] = time;
                Centers.SetValue(center, a);

                a = 100;
            }

        }

        Spuerficie.SetVectorArray("_CentersWeave", Centers);

    }

}
