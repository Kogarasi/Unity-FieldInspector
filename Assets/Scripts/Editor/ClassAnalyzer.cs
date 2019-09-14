//!
//! @file ClassAnalayzer.cs
//! @brief Analyze GameObject/Monobehaviour class.
//! @author koga
//!

using System;
using System.Reflection;
using UnityEngine;

namespace FieldInspector.Editor {

    //!
    //! @brief Analyze GameObject/Monobehaviour class.
    //!
    public class ClassAnalyzer {
        private MetadataCache cache = new MetadataCache();

        //!
        //! @brief Analyze Monobehaviour class.
        //! @param[in] component Monobehaviour component.
        //!
        public void AnalyzeComponent( Component component ){
            var type = cache.GetComponentType( component );
        }

        //!
        //! @brief Clear analyzed data.
        //!
        public void Clear(){
            cache.Clear();
        }
    }
}