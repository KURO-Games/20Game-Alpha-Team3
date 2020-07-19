using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// グラフ構造
/// </summary>
namespace OuKanu.DataStructure.Graph
{
    /// <summary>
    /// グラフ頂点
    /// </summary>
    /// <typeparam name="T">データタイプ</typeparam>
    public class Vertex<T>
    {
        public T Data;
        public bool IsVisited;
        public Vertex(T VertexData)
        {
            Data = VertexData;
        }
    }

    /// <summary>
    /// グラフ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Graph<T>
    {
        private const int initialVertMatrixLength = 10;


        private List<Vertex<T>> vertices;


        //隣接マトリックス
        public int[,] adjMatrix;

        //最後の頂点位置
        int LastVertPos = 0;



        private  int MaxVertexCount;
        /// <summary>
        /// 初期化
        /// </summary>
        public Graph()
        {
            
            adjMatrix = new int[initialVertMatrixLength, initialVertMatrixLength];
            vertices = new List<Vertex<T>>();

            //すべての頂点はリンクされないように初期化
            for (int i = 0; i < initialVertMatrixLength; i++)
            {
                for (int j = 0; j < initialVertMatrixLength; j++)
                {
                    adjMatrix[i, j] = 0;
                }
            }
            MaxVertexCount = initialVertMatrixLength;
        }

        private void ExpandGraph(int vertexNum)
        {
            //隣接マトリクスを
            adjMatrix = CreateNewAdjMatrix(vertexNum);
            MaxVertexCount += vertexNum;
        }

        private int[,] CreateNewAdjMatrix(int vertexNum)
        {
            int num = MaxVertexCount + vertexNum;
            int[,] matrix = new int[num, num];
            return matrix;
        }

        /// <summary>
        /// 頂点Add
        /// </summary>
        /// <param name="data"></param>
        public void AddVertex(T data)
        {

            if (LastVertPos < MaxVertexCount - 1)
            {
                Vertex<T> vert = new Vertex<T>(data);
                vertices.Add(vert);
            }
            else
            {
                ExpandGraph(initialVertMatrixLength);
            }

            LastVertPos++;
        }



        /// <summary>
        /// 頂点delete
        /// </summary>
        /// <param name="vertexNum">頂点位置</param>
        public void DeleteVertex(int vertexPos)
        {
            if (vertexPos < LastVertPos)
            {
                //頂点を消す
                for (int i = vertexPos; i < LastVertPos; i++)
                {
                    vertices[i] = vertices[i + 1];
                }

                //vertexPos行目を消す
                for (int j = vertexPos; j < LastVertPos; j++)
                {
                    MoveRow(j, LastVertPos);
                }

                //vertexPos列目を消す(既に1行消したから-1)
                for (int k = vertexPos; k < LastVertPos - 1; k++)
                {
                    MoveCol(k, LastVertPos - 1);
                }

                //LastPosを一個前移動
                LastVertPos--;
            }
        }



        /// <summary>
        /// 行を一行前に移動
        /// </summary>
        /// <param name="row">行位置</param>
        /// <param name="length">列長さ(要注意)</param>
        private void MoveRow(int row, int length)
        {
            //スタート行目から、col列の
            for (int col = row; col < length; col++)
            {
                //row行目のcol列目の要素をrow+1行目の要素に入れ替え
                adjMatrix[row, col] = adjMatrix[row + 1, col];
            }
        }

        /// <summary>
        /// 列を一列前に移動
        /// </summary>
        /// <param name="col">列位置</param>
        /// <param name="length">行長さ(要注意)</param>
        private void MoveCol(int col, int length)
        {
            //消したい列行目から
            for (int row = col; row < length; row++)
            {
                //row行目のcol列目の要素をcol+1列目の要素に入れ替え
                adjMatrix[row, col] = adjMatrix[row, col + 1];
            }
        }




        /// <summary>
        /// 単方向エージ(Edge)Add
        /// </summary>
        /// <param name="vertex1">start頂点の位置</param>
        /// <param name="vertex2">end頂点の位置</param>
        public void AddEdge(int vertex1, int vertex2)
        {
            adjMatrix[vertex1, vertex2] = 1;
        }




        /// <summary>
        /// 指定位置の頂点からデータを抽出
        /// </summary>
        /// <param name="vertexPosition">頂点位置</param>
        /// <returns>データ</returns>
        public T GetT(int vertexPosition)
        {
            return vertices[vertexPosition].Data;
        }
    }
}

