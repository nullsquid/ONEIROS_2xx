﻿/*
<copyright>
  Copyright (c) 2012 Codefarts
  All rights reserved.
  contact@codefarts.com
  http://www.codefarts.com
</copyright>
*/
namespace Codefarts.GridMapping.Editor.DrawingTools.Map2D
{
    using System;
    using System.IO;

    using Codefarts.CoreProjectCode;
    using Codefarts.CoreProjectCode.Settings;
    using Codefarts.Localization;
    using Codefarts.Map2D.Editor.Interfaces;

    using UnityEngine;

    /// <summary>
    /// Provides a tile drawing tool for Map2D.
    /// </summary>
    public class DrawTile : IEditorTool<IMapEditor>
    {
        /// <summary>
        /// Holds a reference to the editor that this tool is associated with.
        /// </summary>
        private IMapEditor editor;

        /// <summary>
        /// Used to determine if the tool is active.
        /// </summary>
        private bool isActive;

        /// <summary>
        /// Gets a value representing the content to be used for the tools button.
        /// </summary>
        public GUIContent ButtonContent
        {
            get
            {
                var settings = SettingsManager.Instance;
                var texturesPath = Path.Combine(settings.GetSetting(CoreGlobalConstants.ResourceFolderKey, "Codefarts.Unity"), "Textures");
                texturesPath = texturesPath.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

                var getPath = new Func<string, string>(x => Path.Combine(texturesPath, x).Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
                return new GUIContent(Resources.Load(getPath("Map2DDrawTile"), typeof(Texture2D)) as Texture2D, this.Title);
            }
        }

        /// <summary>
        /// Gets a value representing the title or name of the tool.
        /// </summary>
        public string Title
        {
            get
            {
                return LocalizationManager.Instance.Get("DrawTile");
            }
        }

        /// <summary>
        /// Gets a <see cref="Guid"/> value that uniquely identifies the tool.
        /// </summary>
        public Guid Uid
        {
            get
            {
                return new Guid("BA4A774E-2C2D-43DD-8048-3D941CA8CB10");
            }
        }

        /// <summary>
        /// Called by the editor to notify the tool to draw something.
        /// </summary>
        public void Draw()
        {
            // does nothing
        }

        /// <summary>
        /// Called by the editor to give the tool the ability to include additional tools in the inspector.
        /// </summary>
        public void OnInspectorGUI()
        {
            // does nothing
        }

        /// <summary>
        /// Called by the editor to allow the tool to draw it self on the tool bar.
        /// </summary>
        /// <returns>If true the tool has drawn it self and no further drawing is necessary, otherwise false.</returns>
        public bool DrawTool()
        {
            return false;
        }

        /// <summary>
        /// Method will be called when the tool is no longer of use by the system or a new tool is being selected.
        /// </summary>
        public void Shutdown()
        {
            this.isActive = false;
            if (this.editor != null)
            {
            }

            this.editor = null;
        }

        /// <summary>
        /// Called when the tool is set as the active tool.
        /// </summary>
        /// <param name="mapEditor">A reference to the editor that this tool should work against.</param>
        public void Startup(IMapEditor mapEditor)
        {
            if (this.isActive)
            {
                return;
            }

            this.editor = mapEditor;
            this.isActive = true;
        }

        /// <summary>
        /// Called by the editor to update the tool on every call to OnSceneGUI.
        /// </summary>
        public void Update()
        {
        }
    }
}
