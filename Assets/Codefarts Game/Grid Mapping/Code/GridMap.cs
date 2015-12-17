/*
<copyright>
  Copyright (c) 2015 Codefarts
  All rights reserved.
  contact@codefarts.com
  http://www.codefarts.com
</copyright>
*/

namespace Codefarts.GridMapping
{
    using System;
    using System.Collections.Generic;

    using UnityEngine;

    /// <summary>
    /// Provides a component for grid mapping.
    /// </summary>
    public class GridMap : MonoBehaviour
    {
        /// <summary>
        /// Gets or sets the number of rows of cells.
        /// </summary>
        public int Rows;

        /// <summary>
        /// Gets or sets the number of columns of cells.
        /// </summary>
        public int Columns;

        /// <summary>
        /// Holds the names of all the map layers.
        /// </summary>
        [SerializeField]
        private string[] layerNames;

        /// <summary>
        /// Gets or sets the layer name information.
        /// </summary>
        public string[] LayerNames
        {
            get
            {
                return this.layerNames;
            }

            set
            {
                var length = this.layerNames.Length;
                this.layerNames = value;
                this.SyncLayerArraySizes();

                // by default new layers should be visible
                if (this.layerLocked.Length <= length)
                {
                    return;
                }

                for (var i = length; i < this.layerVisibility.Length; i++)
                {
                    this.layerVisibility[i] = true;
                }
            }
        }

        /// <summary>
        /// Holds the visibility state of all the map layers.
        /// </summary>
        [SerializeField]
        private bool[] layerVisibility;

        /// <summary>
        /// Holds the locked state of each map layer.
        /// </summary>
        [SerializeField]
        private bool[] layerLocked;

        /// <summary>
        /// Gets or sets the layer locked states.
        /// </summary>
        public bool[] LayerLocked
        {
            get
            {
                this.SyncLayerArraySizes();
                return this.layerLocked;
            }

            set
            {
                this.layerLocked = value;
                this.SyncLayerArraySizes();
            }
        }

        /// <summary>
        /// Ensures that the arrays used to store names, visibility and locked status are kept the same length.
        /// </summary>
        private void SyncLayerArraySizes()
        {
            if (this.layerLocked.Length != this.layerNames.Length)
            {
                Array.Resize(ref this.layerLocked, this.layerNames.Length);
            }

            if (this.layerVisibility.Length != this.layerNames.Length)
            {
                Array.Resize(ref this.layerVisibility, this.layerNames.Length);
            }
        }

        /// <summary>
        /// Gets or sets the layer visibility states.
        /// </summary>
        public bool[] LayerVisibility
        {
            get
            {
                this.SyncLayerArraySizes();
                return this.layerVisibility;
            }

            set
            {
                this.layerVisibility = value;
                this.SyncLayerArraySizes();
            }
        }

        /// <summary>
        /// Gets or sets the depth or thickness of the layers.
        /// </summary>
        public float Depth;

        /// <summary>
        /// Gets or sets the value of the cell width.
        /// </summary>
        public float CellWidth = 1;

        /// <summary>
        /// Gets or sets the value of the cell height.
        /// </summary>
        public float CellHeight = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridMap"/> class.
        /// </summary>
        public GridMap()
        {
            this.Columns = 20;
            this.Rows = 10;
            this.Depth = 1;

            // this.Layers = new[] { new GridMapLayerModel { Visible = true, Locked = false } };
            this.layerLocked = new[] { false };
            this.layerNames = new[] { string.Empty };
            this.layerVisibility = new[] { true };
        }
    }
}
