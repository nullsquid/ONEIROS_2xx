/*
<copyright>
  Copyright (c) 2012 Codefarts
  All rights reserved.
  contact@codefarts.com
  http://www.codefarts.com
</copyright>
*/

namespace Codefarts.GridMapping
{
    using System;

    using UnityEditor;

    /// <summary>
    /// Provides extension methods for the <see cref="GridMap"/> type.
    /// </summary>
    public static class GridMapExtensionMethods
    {
        /// <summary>
        /// Adds a layer to the map.
        /// </summary>
        /// <param name="map">The reference to a <see cref="GridMap"/> type.</param>
        /// <param name="allowUndo">If true will allow the user to undo the action.</param>       
        /// <exception cref="ArgumentOutOfRangeException">Count can not be less than 1.</exception>
        public static void AddLayer(this GridMap map, bool allowUndo)
        {
            var local = Localization.LocalizationManager.Instance;
            if (allowUndo)
            {
                Undo.RecordObject(map, local.Get("AddLayer"));
            }

            map.AddLayer();
        }

        /// <summary>
        /// Sets the number of map layers.
        /// </summary>
        /// <param name="map">The reference to a <see cref="GridMap"/> type.</param>
        /// <param name="count">The number of layers that the <see cref="GridMap"/> will have.</param>
        /// <param name="allowUndo">If true will allow the user to undo the action.</param>       
        /// <exception cref="ArgumentOutOfRangeException">Count can not be less than 1.</exception>
        public static void SetLayerCount(this GridMap map, int count, bool allowUndo)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            if (allowUndo)
            {
                var local = Localization.LocalizationManager.Instance;
                Undo.RecordObject(map, local.Get("SetLayerCount"));
            }

            map.SetLayerCount(count);
        }

        /// <summary>
        /// Deletes the the specified layer from a <see cref="GridMap"/> type.
        /// </summary>
        /// <param name="map">The reference to a <see cref="GridMap"/> type.</param>
        /// <param name="index">
        /// The index of the layer that will be deleted.
        /// </param>
        /// <param name="allowUndo">If true will allow the user to undo the action.</param>       
        public static void DeleteLayer(this GridMap map, int index, bool allowUndo)
        {
            if (allowUndo)
            {
                // find list of objects to delete
                var items = map.GetLayerPrefabs(index);
                while (items.Count > 0)
                {
                    Undo.DestroyObjectImmediate(items[0]);
                    items.RemoveAt(0);
                }

                Undo.RecordObject(map, Localization.LocalizationManager.Instance.Get("DeleteLayer"));
            }

            if (index == 0)
            {
                Array.Copy(map.LayerNames, index + 1, map.LayerNames, index, map.LayerNames.Length - 1);
                Array.Copy(map.LayerVisibility, index + 1, map.LayerVisibility, index, map.LayerVisibility.Length - 1);
                Array.Copy(map.LayerLocked, index + 1, map.LayerLocked, index, map.LayerLocked.Length - 1);
            }
            else
            {
                if (index != map.LayerNames.Length - 1)
                {
                    Array.Copy(map.LayerNames, index + 1, map.LayerNames, index, map.LayerNames.Length - (index + 1));
                    Array.Copy(map.LayerVisibility, index + 1, map.LayerVisibility, index, map.LayerVisibility.Length - (index + 1));
                    Array.Copy(map.LayerLocked, index + 1, map.LayerLocked, index, map.LayerLocked.Length - (index + 1));
                }
            }

            map.SetLayerCount(map.LayerNames.Length - 1);
        }
    }
}