//!
//! @file ClassAnalayzer.cs
//! @brief Analyze GameObject/Monobehaviour class.
//! @author koga
//!

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FieldInspector.Editor {

    //!
    //! @brief Analyze GameObject/Monobehaviour class.
    //!
    public class ClassAnalyzer {

        // for type metadata caching.
        private ComponentTypeCache typeCache = new ComponentTypeCache();

        private Dictionary<Type, Entity.ComponentInfo> componentInfos = new Dictionary<Type, Entity.ComponentInfo>();

        //!
        //! @brief Get Monobehaviour Component Information.
        //!
        public Entity.ComponentInfo GetComponentInfo( Component component ){
            var type = typeCache.GetComponentType( component );

            if( !componentInfos.ContainsKey( type ) ){
                componentInfos[ type ] = new Entity.ComponentInfo( type );
            }

            return componentInfos[ type ];
        }

        //!
        //! @brief Clear analyzed data.
        //!
        public void Clear(){
            typeCache.Clear();
        }
    }
}