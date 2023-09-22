using Core.Pooling;
using NUnit.Framework;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.Core.Pooling
{
    public class MockGameObject : MonoBehaviour { }

    public class BaseObjectPoolTests
    {
        [UnityTest]
        public IEnumerator CreateObjectPool_ReceivedCorrectResult()
        {
            // Arrange.
            var go = new GameObject();
            var mockObject = go.AddComponent<MockGameObject>();
            var objectpool = new BaseObjectPool<MockGameObject>();

            // Act.
            objectpool.Configure(mockObject, null, 1);

            yield return new WaitForEndOfFrame();

            // Assert.
            var result = Object.FindObjectsOfType<MockGameObject>();
            Assert.That(result.Count() == 1);
        }

        [UnityTest]
        public IEnumerator GetFromPool_ReceivedCorrectResult()
        {
            // Arrange.
            var go = new GameObject();
            var mockObject = go.AddComponent<MockGameObject>();
            var objectpool = new BaseObjectPool<MockGameObject>();

            // Act.
            objectpool.Configure(mockObject, null, 1);

            yield return new WaitForEndOfFrame();

            // Assert.
            var result = objectpool.Get();
            
            Assert.NotNull(result);
        }

        [UnityTest]
        public IEnumerator GetFromPool_IsActiveTrue_ReceivedCorrectResult()
        {
            // Arrange.
            var go = new GameObject();
            var mockObject = go.AddComponent<MockGameObject>();
            var objectpool = new BaseObjectPool<MockGameObject>();

            // Act.
            objectpool.Configure(mockObject, null, 1);

            yield return new WaitForEndOfFrame();

            // Assert.
            var result = objectpool.Get();

            Assert.IsTrue(result.gameObject.activeSelf);
        }

        [UnityTest]
        public IEnumerator ReleaseFromPool_IsActiveFalse_ReceivedCorrectResult()
        {
            // Arrange.
            var go = new GameObject();
            var mockObject = go.AddComponent<MockGameObject>();
            var objectpool = new BaseObjectPool<MockGameObject>();
            objectpool.Configure(mockObject, null, 1);

            // Act.
            yield return new WaitForEndOfFrame();

            var result = objectpool.pool.Get();
            objectpool.Release(result);

            // Assert.

            Assert.IsFalse(result.gameObject.activeSelf);
        }

        [UnityTest]
        public IEnumerator ReleaseAll_ReceivedCorrectResult()
        {
            // Arrange.
            var go = new GameObject();
            var mockObject = go.AddComponent<MockGameObject>();
            var objectpool = new BaseObjectPool<MockGameObject>();
            objectpool.Configure(mockObject, null, 1);

            // Act.
            yield return new WaitForEndOfFrame();

            var result = objectpool.pool.Get();
            objectpool.ReleaseAll();

            // Assert.

            Assert.IsFalse(result.gameObject.activeSelf);
        }
    }
}