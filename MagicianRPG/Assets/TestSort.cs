using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSort : MonoBehaviour
{
    int[] tree = { 3, 4, 7, 8, 1, 9, 10 };

     void Start()
    {
        int n = tree.Length;
        int[] treesort = heap_sort(tree, n);
        for(int i = 0; i < treesort.Length; i++)
        {
            Debug.Log(treesort[i]);
        }
    }

    void heapify(int[] tree, int n, int i)
    {
        if (i >= n)
            return;
        int c1 = 2 * i + 1;
        int c2 = 2 * i - 1;
        int max = i;
        if (c1 < n && tree[c1] > tree[max])
        {
            max = c1;
        }
        if (c2 < n && tree[c2] > tree[max])
        {
            max = c2;
        }
        if (max != i)
        {
            exch(tree, max, i);
            heapify(tree, n, max);

        }
    }


         void build_heap(int[] tree, int n)
        {
            int last_node = n - 1;
            int parent = (last_node - 1) / 2;

            for (int i = parent; i >= 0; i--)
            {
                heapify(tree, n, i);
            }

        }

        int[] heap_sort(int[] tree, int n)
        {
            build_heap(tree, n);
            for (int i = n - 1; i >= 0; i--)
            {
                exch(tree, i, 0);
                heapify(tree, i, 0);
            }
            return tree;
        }


        void exch(int[] a, int i, int j)
        {
            int t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

    }





