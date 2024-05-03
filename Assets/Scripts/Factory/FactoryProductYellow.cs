using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FactoryProductYellow : Factory
{
    [SerializeField] private ProductYellow productYellowPrefab;

    public override IProduct GetProduct(Vector3 position)
    {
        GameObject instance = Instantiate(productYellowPrefab.gameObject, position, Quaternion.identity,null);
        ProductYellow newProduct = instance.GetComponent<ProductYellow>();
        newProduct.Initialize();
        return newProduct;
    }
}
