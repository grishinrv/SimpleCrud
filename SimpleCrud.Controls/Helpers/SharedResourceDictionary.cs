using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace SimpleCrud.Controls.Helpers
{
    /// <summary>
    /// Fixes Resource dictionary duplication issue by preventing loading same resource dictionaries multiple times.
    /// </summary>
    public class SharedResourceDictionary : ResourceDictionary
    {
        /// <summary>
        /// Internal cache of loaded dictionaries 
        /// </summary>
        private static readonly Dictionary<Uri, ResourceDictionary> _sharedDictionaries = new Dictionary<Uri, ResourceDictionary>();

        /// <summary>
        /// Local member of the source uri
        /// </summary>
        private Uri _sourceUri;

        /// <summary>
        /// Gets or sets the uniform resource identifier (URI) to load resources from.
        /// </summary>
        public new Uri Source
        {
            get 
            {
                if (IsInDesignMode)
                    return base.Source;
                return _sourceUri;
            }
            set
            {
                if (IsInDesignMode)
                {
                    try
                    {
                        _sourceUri = new Uri(value.OriginalString);
                    }
                    catch
                    {
                    }
                    return;
                }

                try
                {
                    _sourceUri = new Uri(value.OriginalString);
                }
                catch
                {
                }

                if (!_sharedDictionaries.ContainsKey(value))
                {
                    // If the dictionary is not yet loaded, load it by setting
                    // the source of the base class

                    base.Source = value;

                    // add it to the cache
                    _sharedDictionaries.Add(value, this);
                }
                else
                {
                    // If the dictionary is already loaded, get it from the cache
                    MergedDictionaries.Add(_sharedDictionaries[value]);
                }
            }
        }

        private static bool IsInDesignMode =>
            (bool)DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty,
                typeof(DependencyObject)).Metadata.DefaultValue;
    }
}