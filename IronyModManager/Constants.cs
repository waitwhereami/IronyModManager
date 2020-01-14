﻿// ***********************************************************************
// Assembly         : IronyModManager
// Author           : Mario
// Created          : 01-13-2020
//
// Last Modified By : Mario
// Last Modified On : 01-14-2020
// ***********************************************************************
// <copyright file="Constants.cs" company="Mario">
//     Mario
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Avalonia.Markup.Xaml.Styling;

namespace IronyModManager
{
    /// <summary>
    /// Class Constants.
    /// </summary>
    public class Constants
    {
        #region Fields

        /// <summary>
        /// The culture
        /// </summary>
        public const string AppCulture = "en-US";

        /// <summary>
        /// The empty parameter
        /// </summary>
        public const string EmptyParam = "";

        /// <summary>
        /// The plugins path and name
        /// </summary>
        public const string PluginsPathAndName = "Plugins";

        /// <summary>
        /// The error message
        /// </summary>
        public const string UnhandledErrorMessage = "Unhandled error occurred";

        /// <summary>
        /// The error title
        /// </summary>
        public const string UnhandlerErrorTitle = "Error";

        #endregion Fields

        #region Classes

        /// <summary>
        /// Class Themes.
        /// </summary>
        public class Themes
        {
            #region Fields

            /// <summary>
            /// The dark theme
            /// </summary>
            public static readonly StyleInclude DarkTheme = new StyleInclude(new Uri("resm:Styles?assembly=Avalonia.ThemeManager"))
            {
                Source = new Uri("resm:Avalonia.Themes.Default.Accents.BaseDark.xaml?assembly=Avalonia.Themes.Default")
            };

            /// <summary>
            /// The light theme
            /// </summary>
            public static readonly StyleInclude LightTheme = new StyleInclude(new Uri("resm:Styles?assembly=Avalonia.ThemeManager"))
            {
                Source = new Uri("resm:Avalonia.Themes.Default.Accents.BaseLight.xaml?assembly=Avalonia.Themes.Default")
            };

            #endregion Fields
        }

        #endregion Classes
    }
}
